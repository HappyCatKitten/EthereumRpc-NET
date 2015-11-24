using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlockStudio.Persistant
{
    public class PersistantStore
    {
        public List<Connection> SavedConnections { get; set; }
        public List<Account> Accounts { get; set; }
    }

    public class PersistantState
    {
        public static List<Connection> SavedConnections { get; set; }
        public static List<Account> Accounts { get; set; }

        private static string savedConnectionsFilePath = "savedConnections.bin";

        public static void SavedConnection(Connection connection)
        {
            var existing = SavedConnections.FirstOrDefault(x => x.Uid == connection.Uid);

            if (existing != null)
            {
                existing = connection;
            }
            else
            {
                SavedConnections.Add(connection);
            }
            
            SaveStates();
        }

        public static void RemoveSavedConnection(Connection connection)
        {
            SavedConnections.Remove(connection);
            SaveStates();
        }

        public static void LoadStates()
        {
            var persistantStore = FileSerialize.DeSerializeObject<PersistantStore>(savedConnectionsFilePath);
            if (persistantStore != null)
            {
                SavedConnections = persistantStore.SavedConnections;
                Accounts = persistantStore.Accounts;
            }
            else
            {
                SavedConnections = new List<Connection>();
                Accounts = new List<Account>();
            }
            
        }

        public static void SaveStates()
        {
            var persistantStore = new PersistantStore()
            {
                Accounts = Accounts,
                SavedConnections = SavedConnections
            };

            FileSerialize.SerializeObject(persistantStore, savedConnectionsFilePath);
        }
    }
}
