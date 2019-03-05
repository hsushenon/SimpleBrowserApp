using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBrowserApp
{
    public static class Common
    {
        public static ObservableCollection<ChannelItem> ChannelList;

        public static void LoadChannelList()
        {
            ChannelList = DataAccess.GetData();
        }


    }
}
