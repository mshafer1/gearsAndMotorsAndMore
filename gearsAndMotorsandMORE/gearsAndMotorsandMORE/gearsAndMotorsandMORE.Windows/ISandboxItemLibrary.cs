using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gearsAndMotorsandMORE
{
    class ISandboxItemLibrary
    {
        public ISandboxItemLibrary()
        {
            data = new List<SandboxItem>();
            string image = "Assets/18THex.png";
            Gear gear = new Gear(18, image, "217-3209");
            gear.ImagePath = image;
            addSandboxItem(gear);
            image = "Assets/18THex.png";
            gear = new Gear(18, image, "217-3209");
            gear.ImagePath = image;
            addSandboxItem(gear);
        }
        public List<SandboxItem> SandboxItems
        {
            get { return data; }
        }

        public List<SandboxItem> data;

        public void addSandboxItem(SandboxItem newSandboxItem)
        {
            data.Add(newSandboxItem);
        }
    }
}
