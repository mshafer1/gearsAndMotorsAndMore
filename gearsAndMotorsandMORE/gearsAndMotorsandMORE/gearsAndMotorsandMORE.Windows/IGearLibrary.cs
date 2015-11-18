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
        protected abstract void addGear(Gear newGear);
    }
}
