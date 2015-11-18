using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;


namespace gearsAndMotorsandMORE
{
    class ConstantGears: IGearLibrary
    {
        public ConstantGears()
        {
            //string path = Path.Combine(@"..\..\..\..\..\Pictures\18THex.png");
            var path = ApplicationData.Current.LocalFolder;
            string image = Path.Combine(path.Path, @"..\..\..\..\..\Pictures\18THex.png");
            Gear gear = new Gear(18,image,"217-3209");
            addGear(gear);

            gear = new Gear(20,@"..\..\..\..\..\Pictures\20THex.png","217-2702");
            addGear(gear);

            gear = new Gear(24,@"..\..\..\..\..\Pictures\24THex.png","217-2704");
            addGear(gear);

            gear = new Gear(30,@"..\..\..\..\..\Pictures\30THex.png","217-2705");
            addGear(gear);

            gear = new Gear(36,@"..\..\..\..\..\Pictures\364THex.png","217-3214");
            addGear(gear);
        }

        protected override void addGear(Gear newGear)
        {
            data.Add(newGear);
        }
    }
}
