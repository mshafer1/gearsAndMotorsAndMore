using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gearsAndMotorsandMORE
{
    abstract class IMotorLibrary
    {
        public IMotorLibrary()
        {
            data = new List<Motor>();
        }
        public List<Motor> Motors
        {
            get { return data; }
        }

        protected List<Motor> data;
        protected abstract void addMotor(Motor newMotor);
    }
}
