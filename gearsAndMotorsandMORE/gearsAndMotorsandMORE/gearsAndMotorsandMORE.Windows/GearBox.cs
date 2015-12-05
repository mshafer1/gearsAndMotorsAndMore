using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gearsAndMotorsandMORE
{

    /*
     * 
     * While working on this I found a couple of things:
     * 1. need to enforce starting with a motor in the sandbox (disable gears unless there is at least 1 item??)
     * 
     * 
     * 2. later, when moving towards public release:
     * would be need to add an actualSpeed(float torqueApplied) to the Motor class
     * 
     * 
     */
    class GearBox
    {
        public GearBox()
        {
            Items = new List<SandboxItem>();
        }

        public GearBox(List<SandboxItem> t)
        {
            Items = new List<SandboxItem>(t);
        }

        public List<SandboxItem> Items;


        //values that need to be input
        public int RobotWeight { get; set; }
       
        public float WheelRadius { get; set; } //in inches

        //values to display
        public bool CanMove { get { return MinTorque < FinalTorque; } }
        public float MaxSpeed { get { return maxSpeed; } }  /*in ft/second*/
        private float maxSpeed;

        //values for calculating
        private float FinalTorque; //return stall torque * motors * gear ration - if motors speed matched
        private float MinTorque { get { return (int)((RobotWeight / 2 /*assuming 2 gear boxes on the robot*/) * (WheelRadius / 12 /*convert to feet*/) * 1/*sin of 90°*/); } }


        //the body of the class
        //this function returns whether or not the gear box will work (if false is returned, an error message about matching motor speeds should be displayed, if true, display the values from CanMove and maxSpeed
        public bool checkGearBox()
        {
            bool canWork = true;
            int lastGear = -1, RPM = -1, currentGear = 1;
            float netGearRatio = 1, netTorque = 0, finalGearRatio = 1;

            foreach(var item in Items)
            {
                if(typeof(Motor) == item.GetType())
                {
                    Motor m = (Motor)item;
                    netTorque += m.StallTorque * netGearRatio;

                    if(RPM < 0)
                    {
                        RPM = m.FreeRPM;
                    }
                    else
                    {
                        canWork = (RPM == (m.FreeRPM * netGearRatio)) && canWork;
                    }
                    finalGearRatio = 1;
              
                }
                else
                {
                    Gear g = (Gear)item;
                    currentGear = g.Teeth;

                    if(lastGear > 0)
                    {
                        netGearRatio *= ((float)lastGear/currentGear);
                        finalGearRatio *= ((float)lastGear / currentGear);
                    }
                    lastGear = currentGear;
                }

                if(!canWork)
                {
                    return canWork;
                }
            }
            FinalTorque = netTorque/finalGearRatio;
            maxSpeed = (RPM * finalGearRatio)/*final max rpm*/ * (WheelRadius/12 /*convert to feet*/) /*convert to linear speed*/;
            return canWork;
        }

    }
}
