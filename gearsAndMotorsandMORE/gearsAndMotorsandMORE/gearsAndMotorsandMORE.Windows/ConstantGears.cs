using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Controls;

namespace gearsAndMotorsandMORE
{
    class ConstantGears: IGearLibrary
    {
        public ConstantGears()
        {
            string image = "Assets/18THex.png";
            Gear gear = new Gear(18, image, "217-3209");
            gear.ImagePath = image;
            addGear(gear);

            image = "Assets/20THex.png";
            gear = new Gear(20,image,"217-2702");
            addGear(gear);

            image = "Assets/24THex.png";
            gear = new Gear(24, image,"217-2704");
            addGear(gear);

            image = "Assets/30THex.png";
            gear = new Gear(30, image,"217-2705");
            addGear(gear);

            image = "Assets/36THex.png";
            gear = new Gear(36, image,"217-3214");
            addGear(gear);
        }

        protected override void addGear(Gear newGear)
        {
            data.Add(newGear);
        }
    }
}
