using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockStudio.TreeNodes;
using Ethereum.Wallet.Persistant;

namespace BlockStudio.Tabs
{
    public class TabManager
    {
        public static TabControl TabControl{ get; set; }


        public static List<Tab> GetConnectionTabs()
        {
            var tabs = TabControl.TabPages.Cast<Tab>().ToList();
            return tabs;
        }

        public static void SetSelectedTab(SavedConnection savedConnection)
        {
            var tabs = TabControl.TabPages.Cast<Tab>().ToList();
            var tab = tabs.FirstOrDefault(x => x.SavedConnection.Uid == savedConnection.Uid);
            TabControl.SelectTab(tab);
        }

        public static void AddConnectionTabIfNew(SavedConnection savedConnection)
        {
            var connectionTabs = GetConnectionTabs();

            if (connectionTabs.All(x => x.SavedConnection.Uid != savedConnection.Uid))
            {
                var tab = new Tab(savedConnection);

                tab.Text = savedConnection.Name;
                TabControl.TabPages.Add(tab);
            }
        }

    }
}
