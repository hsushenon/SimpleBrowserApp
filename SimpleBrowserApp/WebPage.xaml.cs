using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class WebPage : Page
    {
        ObservableCollection<ChannelItem> _ChannelList;
       
        public WebPage()
        {
            try
            {
                this.InitializeComponent();

                _ChannelList = Common.ChannelList;//DataAccess.GetData();
                LoadSite();
            }
            catch (Exception)
            { }
        }

  

        private void LoadSite()
        {
            try
            {
                int currentSiteNo = CommonConfig.CurrentSiteNo;
                if (_ChannelList != null && _ChannelList.Count >= currentSiteNo)
                {
                    string webAddress = _ChannelList[currentSiteNo - 1].Address;


                    //if (currentSiteNo == 1)
                    //    webAddress = "https://google.com/";
                    //else
                    //    webAddress = "https://bing.com/";

                    DoWebNavigate(webAddress);
                }
            }
            catch (Exception)
            { }

        }

        private void DoWebNavigate(string webAddress)
        {
          
            try
            {
                if (webAddress.Length > 0)
                {
                    webView.Navigate(new Uri(webAddress));
                }
                else
                {
                    //TODO
                    //DisplayMessage("You need to enter a web address.");
                }
            }
            catch (Exception e)
            {
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Frame.Navigate(typeof(HomePage));
            }
            catch (Exception)
            { }

        }
    }
}
