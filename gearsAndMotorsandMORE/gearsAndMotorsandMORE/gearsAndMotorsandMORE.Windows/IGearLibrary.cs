using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gearsAndMotorsandMORE
{
    abstract class  IGearLibrary
    {
        public IGearLibrary()
        {
            data = new List<Gear>();
        }
        public List<Gear> Gears
        {
            get { return data; }
        }

        protected List<Gear> data;

        public Gear findGear(string uri)
        {
            //Gear foundGear = new Gear();

            //foreach (Gear g in data)
            //{
            //    if ("/" + g.SandboxImagePath == uri)
            //    {
            //        foundGear = g;
            //    }
            //}

            //return foundGear;

            return data.Find(x => "/" + x.SandboxImagePath == uri);
        }
        public bool isGear(string item)
        {
            bool result = false;

            foreach (Gear g in data)
            {
                if (g.SandboxImagePath == item)
                {
                    result = true;
                }
            }

            return result;
        }

        protected abstract void addGear(Gear newGear);
    }
}
