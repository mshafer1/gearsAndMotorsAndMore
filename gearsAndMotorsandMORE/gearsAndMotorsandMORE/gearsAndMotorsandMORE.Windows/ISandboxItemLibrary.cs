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
