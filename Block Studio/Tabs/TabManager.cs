using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockStudio.Persistant;

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

        public static void SetSelectedTab(Connection connection)
        {
            var tabs = TabControl.TabPages.Cast<Tab>().ToList();
            var tab = tabs.FirstOrDefault(x => x.Connection.Uid == connection.Uid);
            TabControl.SelectTab(tab);
        }

        public static void AddConnectionTabIfNew(Connection connection)
        {
            var connectionTabs = GetConnectionTabs();

            if (connectionTabs.All(x => x.Connection.Uid != connection.Uid))
            {
                var tab = new Tab(connection);

                tab.Text = connection.Name;
                TabControl.TabPages.Add(tab);
            }
        }

    }
}
