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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SimpleBrowserApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            try
            {
                this.InitializeComponent();
                DataAccess.InitializeDatabase();
                Common.LoadChannelList();
            }
            catch (Exception)
            { }
        }

        private void BtnBox1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CommonConfig.CurrentSiteNo = 1;
                this.Frame.Navigate(typeof(WebPage));
            }
            catch (Exception)
            { }

        }

        private void BtnBox2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CommonConfig.CurrentSiteNo = 2;
                this.Frame.Navigate(typeof(WebPage));
            }
            catch (Exception)
            { }
        }

        private void BtnBox3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CommonConfig.CurrentSiteNo = 3;
                this.Frame.Navigate(typeof(WebPage));
            }
            catch (Exception)
            { }
        }

        private void BtnBox4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CommonConfig.CurrentSiteNo = 4;
                this.Frame.Navigate(typeof(WebPage));
            }
            catch (Exception)
            { }
        }

        private void BtnBox5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CommonConfig.CurrentSiteNo = 5;
                this.Frame.Navigate(typeof(WebPage));
            }
            catch (Exception)
            { }
        }

        private void BtnBox6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CommonConfig.CurrentSiteNo = 6;
                this.Frame.Navigate(typeof(WebPage));
            }
            catch (Exception)
            { }
        }

        private void BtnBox7_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CommonConfig.CurrentSiteNo = 7;
                this.Frame.Navigate(typeof(WebPage));
            }
            catch (Exception)
            { }
        }

        private void BtnBox8_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CommonConfig.CurrentSiteNo = 8;
                this.Frame.Navigate(typeof(MainPage));
            }
            catch (Exception)
            { }
        }

        private void BtnBox9_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CommonConfig.CurrentSiteNo = 9;
                this.Frame.Navigate(typeof(SettingPage));
            }
            catch (Exception)
            { }
        }
    }
}
