using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace gearsAndMotorsandMORE
{
    class Gear
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
        public Image Picture
        {
            get
            {
                Image image = new Image();
                BitmapImage bitmapImage = new BitmapImage();
                Uri uri = new Uri(ImagePath);
                bitmapImage.UriSource = uri;
                image.Source = bitmapImage;
                return image;
            }
        }
        public string ImagePath { get; set; }
        public string PartNumber { get; set; }
    }
}
