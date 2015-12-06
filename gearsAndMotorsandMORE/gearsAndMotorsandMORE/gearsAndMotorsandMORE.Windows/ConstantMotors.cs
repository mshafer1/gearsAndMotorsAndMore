using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gearsAndMotorsandMORE
{
    class ConstantMotors: IMotorLibrary
    {
        public ConstantMotors()
        {
            Motor motor = new Motor()
            {
                SideImagePath = "Assets/BaneBots-M7‐RS775‐18.png",
                FrontImagePath = "Assets/BaneBots-M7‐RS775‐18.png",
                CommonName = "BaneBots RS775",
                FreeCurrent = 1.8f,
                FreeRPM = 13000,
                PartNumber = "M7-RS775",
                StallCurrent = 86.7f,
                StallTorque = .5875f
            };
            addMotor(motor);

            motor = new Motor()
            {
                SideImagePath = "Assets/CIM.png",
                FrontImagePath = "Assets/CIM.png",
                CommonName = "CIM",
                FreeCurrent = 2.3f,
                FreeRPM = 5300,
                PartNumber = "CIM",
                StallCurrent = 133.0f,
                StallTorque = 1.789f
            };
            addMotor(motor);
        }

        protected override void addMotor(Motor newMotor)
        {
            data.Add(newMotor);
        }
    }
}
