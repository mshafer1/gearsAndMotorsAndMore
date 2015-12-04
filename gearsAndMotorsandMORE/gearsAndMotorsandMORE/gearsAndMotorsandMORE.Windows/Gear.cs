using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using Windows.Storage.Streams;
using Windows.Storage;
using Windows.UI.Xaml.Media;

namespace gearsAndMotorsandMORE
{
    class Gear: SandboxItem
    {
        public Gear()
        {
            Teeth = 0;
            ImagePath = "";
            PartNumber = "";
        }


        public Gear(int teeth, string path, string number)
        {
            Teeth = teeth;
            ImagePath = path;
            PartNumber = number;
        }
        public int Teeth { get; set; }

        public string ImagePath { get; set; }

        public string PartNumber { get; set; }

        public override string GetSandboxImagePath()
        {
            return ImagePath;
        }
    }
}
