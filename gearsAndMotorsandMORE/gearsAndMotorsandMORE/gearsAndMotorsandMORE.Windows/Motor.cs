using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gearsAndMotorsandMORE
{
    class Motor
    {
        public Motor()
        {
            Teeth = 0;
            ImagePath = "";
            PartNumber = "";
        }


        public Motor(int teeth, string path, string number)
        {
            Teeth = teeth;
            ImagePath = path;
            PartNumber = number;
        }
        public int Teeth { get; set; }

        public string ImagePath { get; set; }

        public string PartNumber { get; set; }
    }
}
