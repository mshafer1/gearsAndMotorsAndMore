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
            string image = "Assets/18THex.png";
            Motor motor = new Motor(18, image, "217-3209");
            motor.ImagePath = image;
            addMotor(motor);

            image = "Assets/20THex.png";
            motor = new Motor(20, image, "217-2702");
            addMotor(motor);
        }

        protected override void addMotor(Motor newMotor)
        {
            data.Add(newMotor);
        }
    }
}
