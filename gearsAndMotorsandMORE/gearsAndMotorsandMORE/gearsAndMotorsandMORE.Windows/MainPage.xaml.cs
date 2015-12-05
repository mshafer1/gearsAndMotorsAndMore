using gearsAndMotorsandMORE.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace gearsAndMotorsandMORE
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        IGearLibrary gearLib;
        IMotorLibrary motorLib;
        ISandboxItemLibrary sandboxItemLib;

        bool pressed;
        bool isDragged;
        SandboxItem draggedItem;

        public MainPage()
        {
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;

            this.InitializeComponent();

            gearLib = new ConstantGears();
            motorLib = new ConstantMotors();
            sandboxItemLib = new ISandboxItemLibrary();

            lstViewGears.ItemsSource = gearLib.Gears;
            lstViewMotors.ItemsSource = motorLib.Motors;
            //sandbox.ItemsSource = sandboxItemLib.SandboxItems;

            isDragged = false;
            pressed = false;
        }


        private void sandbox_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (isDragged)
            {
                sandboxItemLib.SandboxItems.Add(draggedItem);

                GridViewItem myGVImage = new GridViewItem();

                addImage(draggedItem);
                
                isDragged = false;
            }
        }

        private void addImage(SandboxItem itemToAdd)
        {
            GridViewItem myGVImage = new GridViewItem();

            String stringPath = "ms-appx:///" + itemToAdd.SandboxImagePath;
            Uri imageUri = new Uri(stringPath, UriKind.Absolute);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            Image myImage = new Image();
            myImage.Source = imageBitmap;

            if (motorLib.isMotor(itemToAdd.SandboxImagePath.ToString()))
            {
                myImage.Height = 200;
                myImage.Width = 200;
            }

            myGVImage.Content = myImage;

            sandbox.Children.Remove(sandbox.Children.Last());
            sandbox.Children.Add(myGVImage);
            sandbox.Children.Add(dragHereImage);

            lstViewGears.IsEnabled = true;
        }

        private void Motor_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if(pressed)
            {
                pressed = false;
                isDragged = true;

                string draggedUri = ((BitmapImage)((Image)e.OriginalSource).Source).UriSource.LocalPath.ToString();
                draggedItem = motorLib.findMotor(draggedUri);
            }
            
        }

        private void motorImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            pressed = true;
        }

        private void motorImage_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pressed = false;
        }

        private void Gear_PointerMoved_1(object sender, PointerRoutedEventArgs e)
        {
            if (pressed)
            {
                pressed = false;
                isDragged = true;

                string draggedUri = ((BitmapImage)((Image)e.OriginalSource).Source).UriSource.LocalPath.ToString();
                draggedItem = gearLib.findGear(draggedUri);
            }
        }

        private void gearImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            pressed = true;
        }

        private void gearImage_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            pressed = false;
        }

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            if (e.PageState != null && e.PageState.ContainsKey("sandboxItemString"))
            {
                repopulateSandbox(e.PageState["sandboxItemString"].ToString());
            }
        }

        private void repopulateSandbox (string itemsString)
        {
            List<string> itemList = new List<string>();

            int wordCount = 0;
            itemList.Add("");

            for (int i = 0; i < itemsString.Count(); i++)
            {
                if(itemsString[i] == ' ')
                {
                    wordCount++;
                    itemList.Add("");
                }
                else
                {
                    itemList[wordCount] = itemList[wordCount] + itemsString[i];
                }
            }

            foreach (string s in itemList)
            {
                if(s == "")
                {
                    //do nothing
                }

                else if(gearLib.isGear(s))
                {
                    Gear savedGear = gearLib.findGear("/" + s);
                    addImage(savedGear);
                    sandboxItemLib.SandboxItems.Add(savedGear);
                }
                else if(motorLib.isMotor(s))
                {
                    Motor savedMotor = motorLib.findMotor("/" + s);
                    addImage(savedMotor);
                    sandboxItemLib.SandboxItems.Add(savedMotor);
                }
                
            }
        }

        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            e.PageState["sandboxItemString"] = toSandboxString(sandboxItemLib.SandboxItems);
        }

        private string toSandboxString(List<SandboxItem> sandboxItems)
        {
            string result = "";

            foreach (SandboxItem s in sandboxItems)
            {
                result = result + s.SandboxImagePath.ToString() + " ";
            }

            return result;
        }

        #region NavigationHelper registration

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void About_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(About));
        }

        private void DeleteLast_Click(object sender, RoutedEventArgs e)
        {
            sandbox.Children.Remove(sandbox.Children.Last());
            sandbox.Children.Remove(sandbox.Children.Last());
            sandbox.Children.Add(dragHereImage);

            sandboxItemLib.SandboxItems.Remove(sandboxItemLib.SandboxItems.Last());
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            sandbox.Children.Clear();
            sandboxItemLib.SandboxItems.Clear();
            sandbox.Children.Add(dragHereImage);
        }
    }
}
