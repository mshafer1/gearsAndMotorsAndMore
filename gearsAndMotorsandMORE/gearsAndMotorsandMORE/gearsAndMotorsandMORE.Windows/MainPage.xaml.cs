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

        public MainPage()
        {
            this.InitializeComponent();

            gearLib = new ConstantGears();
            motorLib = new ConstantMotors();
            sandboxItemLib = new ISandboxItemLibrary();

            lstViewGears.ItemsSource = gearLib.Gears;
            lstViewMotors.ItemsSource = motorLib.Motors;
            //sandbox.ItemsSource = sandboxItemLib.SandboxItems;
        }


        private void sandbox_DragOver(object sender, DragEventArgs e)
        {

        }

        private void sandbox_Drop(object sender, DragEventArgs e)
        {
            sandbox.ItemsSource = sandboxItemLib.SandboxItems;
        }
    }
}
