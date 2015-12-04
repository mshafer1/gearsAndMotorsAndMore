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

                String stringPath = "ms-appx:///" + draggedItem.SandboxImagePath;
                Uri imageUri = new Uri(stringPath, UriKind.Absolute);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                Image myImage = new Image();
                myImage.Source = imageBitmap;
                myImage.Height = 200;
                myImage.Width = 200;

                myGVImage.Content = myImage;

                sandbox.Items.Remove(sandbox.Items.Last());
                sandbox.Items.Add(myGVImage);
                sandbox.Items.Add(dragHereImage);
                
                isDragged = false;
            }
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
    }
}
