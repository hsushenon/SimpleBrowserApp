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
    public sealed partial class SettingPage : Page
    {
        ObservableCollection<ChannelItem> _ChannelList;

        public SettingPage()
        {   
            this.InitializeComponent();
            _ChannelList = Common.ChannelList;
            CbChannelId_SelectionChanged(this, null);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = cbChannelId.SelectedIndex.ToString();
                string name = txtChannelName.Text;
                string address = txtAddress.Text;

                if (_ChannelList != null && _ChannelList.Count > 0)
                {

                    ChannelItem c = _ChannelList.Where(x => x.ChannelId.Equals(id)).SingleOrDefault();

                    if (c != null)
                    {
                        DataAccess.UpdateData(id, name, address);
                    }
                    else
                    {
                        ChannelItem c1 = new ChannelItem(id, name, address);
                        DataAccess.InsertData(c1);
                    }
                }
                else
                {

                    ChannelItem c1 = new ChannelItem(id, name, address);
                    DataAccess.InsertData(c1);
                }
            }
            catch (Exception)
            { }
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

        private void CbChannelId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (_ChannelList != null && _ChannelList.Count > 0)
                {
                    string id = cbChannelId.SelectedIndex.ToString();
                    ChannelItem c = _ChannelList.Where(x => x.ChannelId.Equals(id)).SingleOrDefault();

                    if (c != null)
                    {
                        txtChannelName.Text = c.ChannelName;
                        txtAddress.Text = c.Address;
                    }
                }
            }
            catch (Exception)
            { }
        }
    }
}
