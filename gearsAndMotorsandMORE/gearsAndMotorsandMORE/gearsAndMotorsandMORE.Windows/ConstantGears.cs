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
        readonly string basePath = "https://doc-08-3o-docs.googleusercontent.com/docs/securesc/uorpto6d16m0opo9fv0ds926er90osb7/raqmgdoigri0o5sohu0kjji6cqi8vvlr/1448920800000/10521602918889325161/13200700494010813670/";

        readonly string endPath = "?h=17437864563526662349&amp;e=view";
        public ConstantGears()
        {
            string image = basePath + "0BwEBnEBtHotGbTFyMk9yaFdaNHc" + endPath;
            image = "https://doc-08-3o-docs.googleusercontent.com/docs/securesc/uorpto6d16m0opo9fv0ds926er90osb7/raqmgdoigri0o5sohu0kjji6cqi8vvlr/1448920800000/10521602918889325161/13200700494010813670/0BwEBnEBtHotGbTFyMk9yaFdaNHc?e=view&h=17437864563526662349&nonce=cc7u6anckqk86&user=13200700494010813670&hash=j8j9sard2mv6oe29qq3qo509t8eap067";
            Gear gear = new Gear(18,image,"217-3209");
            addGear(gear);

            image = basePath + "0BwEBnEBtHotGMGw0cHpIT0M3N0E" + endPath;
            gear = new Gear(20,image,"217-2702");
            addGear(gear);

            image = basePath + "0BwEBnEBtHotGZGFxV2pnNkx1VTg" + endPath;
            gear = new Gear(24, image,"217-2704");
            addGear(gear);

            image = basePath + "0BwEBnEBtHotGVlhfMnloRnF5MHc" + endPath;
            gear = new Gear(30, image,"217-2705");
            addGear(gear);

            image = basePath + "0BwEBnEBtHotGc2w1aUxXQmJIc0U" + endPath;
            gear = new Gear(36, image,"217-3214");
            addGear(gear);
        }

        protected override void addGear(Gear newGear)
        {
            data.Add(newGear);
        }
    }
}
