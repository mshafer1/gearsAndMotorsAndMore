using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gearsAndMotorsandMORE
{
    class Motor: SandboxItem
    {
        public Motor()
        {
            CommonName = "";
            FreeRPM = 0;
            StallTorque = 0;
            FreeCurrent = 0;
            StallCurrent = 0;
            SideImagePath = "";
            FrontImagePath = "";
            PartNumber = "";
        }


        public Motor(string commonName, int freeRPM, float stallTorque, float freeCurrent, float stallCurrent, string frontPath, string sidePath, string number)
        {
            CommonName = commonName;
            FreeRPM = freeRPM;
            StallTorque = stallTorque;
            FreeCurrent = freeCurrent;
            StallCurrent = stallCurrent;
            SideImagePath = sidePath;
            FrontImagePath = frontPath;
            PartNumber = number;
        }

        public string CommonName { get; set;}

        public int FreeRPM { get; set; }

        public float StallTorque { get; set; }

        public float FreeCurrent { get; set; }

        public float StallCurrent { get; set; }

        public string FrontImagePath { get; set; }

        public string SideImagePath { get; set; }

        public string PartNumber { get; set; }

        public override string GetSandboxImagePath()
        {
            return FrontImagePath;
        }
    }
}
