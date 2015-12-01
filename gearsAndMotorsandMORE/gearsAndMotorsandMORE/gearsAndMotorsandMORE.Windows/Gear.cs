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
                //Image image = new Image();
                //BitmapImage bitmapImage = new BitmapImage();
                //Uri uri = new Uri(ImagePath);
                //bitmapImage.UriSource = uri;
                //image.Source = bitmapImage;
                //return image;
                //var imgUrl = new Uri(ImagePath);
                //var imageData = new HttpClient();

                //// or you can download it Async won't block your UI
                //// var imageData = await new WebClient().DownloadDataTaskAsync(imgUrl);

                //var bitmapImage = new BitmapImage { CacheOption = BitmapCacheOption.OnLoad };
                //bitmapImage.BeginInit();
                //bitmapImage.StreamSource = new MemoryStream(imageData);
                //bitmapImage.EndInit();

                //return bitmapImage;
                StorageFile file;
                using (var fs = await file.OpenReadAsync())
                using (var writer = new DataWriter(fs))
                {
                    writer.WriteBytes(clientResponse);
                    await writer.StoreAsync();
                }


            }
        }
        public string ImagePath { get; set; }
        public string PartNumber { get; set; }
    }
}
