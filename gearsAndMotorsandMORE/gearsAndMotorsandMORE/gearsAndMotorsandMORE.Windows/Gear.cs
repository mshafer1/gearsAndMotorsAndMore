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

        public async void Picture()
        {
            var client = new HttpClient();

            var imageUrl = "https://drive.google.com/uc?export=view&id=0BwEBnEBtHotGVlhfMnloRnF5MHc";

            Uri imageUri = new Uri(imageUrl);

            var clientResponse = await client.GetByteArrayAsync(imageUri);

            var temp = ApplicationData.Current.TemporaryFolder;
            StorageFile file;
            if ((await temp.GetFilesAsync()).Any(f => f.Name == "temp_image.png"))
            {
                file = await temp.GetFileAsync("tempcolorizer.png");
            }
            else
            {
                file = await temp.CreateFileAsync("temp_image.png");
            }
            using (var fs = await file.OpenReadAsync())
            using (var writer = new DataWriter(fs))
            {
                writer.WriteBytes(clientResponse);
                await writer.StoreAsync();


            }
            
        }

        public Image ImageProperty
        {
            get
            {
                Picture();
                //Image image = new Image();
                //BitmapImage bitmapimage = new BitmapImage();
                //Uri uri = new Uri("temp_image.png");
                //bitmapimage.UriSource = uri;
                //image.Source = bitmapimage;
                return null;
            }
        }
        //public Image Picture
        //{
        //    get
        //    {
        //        //Image image = new Image();
        //        //BitmapImage bitmapImage = new BitmapImage();
        //        //Uri uri = new Uri(ImagePath);
        //        //bitmapImage.UriSource = uri;
        //        //image.Source = bitmapImage;
        //        //return image;
        //        //var imgUrl = new Uri(ImagePath);
        //        //var imageData = new HttpClient();

        //        //// or you can download it Async won't block your UI
        //        //// var imageData = await new WebClient().DownloadDataTaskAsync(imgUrl);

        //        //var bitmapImage = new BitmapImage { CacheOption = BitmapCacheOption.OnLoad };
        //        //bitmapImage.BeginInit();
        //        //bitmapImage.StreamSource = new MemoryStream(imageData);
        //        //bitmapImage.EndInit();

        //        //return bitmapImage;



        //        //var path = ApplicationData.Current.LocalFolder;
        //        //Image image = new Image();
        //        //string imagePath = "ms-appx:///Assets/18THex.png";
        //        //Uri uri = new Uri(imagePath, UriKind.RelativeOrAbsolute);
        //        //ImageSource imgSource = new BitmapImage(uri);
        //        //image.Source = imgSource;
        //        //return image;

        //        //Image image = new Image();
        //        //BitmapImage bitmapImage = new BitmapImage();
        //        //Uri uri = new Uri("18THex.png");
        //        //bitmapImage.UriSource = uri;
        //        //image.Source = bitmapImage;
        //        //return image;
        //    }
        //}
        public string ImagePath { get; set; }
        public string PartNumber { get; set; }
    }
}
