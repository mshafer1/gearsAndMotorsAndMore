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

        public Motor findMotor(string uri)
        {
            //Motor foundMotor = new Motor();

            //foreach (Motor m in data)
            //{
            //    if("/" + m.SandboxImagePath == uri)
            //    {
            //        foundMotor = m;
            //    }
            //}

            //return foundMotor;

            return data.Find(x => "/" + x.SandboxImagePath == uri);
        }

        public bool isMotor(string item)
        {
            bool result = false;

            foreach (Motor m in data)
            {
                if (m.SandboxImagePath == item)
                {
                    result = true;
                }
            }

            return result;
        }
        protected abstract void addMotor(Motor newMotor);
    }
}
