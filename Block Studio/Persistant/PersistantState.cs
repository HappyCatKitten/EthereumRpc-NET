using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ethereum.Wallet.Persistant;

namespace Block_Studio.Persistant
{
    public class PersistantState
    {
        public  static List<SavedConnection> SavedConnections{ get; set; }
        private static string savedConnectionsFilePath = "savedConnections.bin";

        public static void AddSavedConnection(SavedConnection savedConnection)
        {
            SavedConnections.Add(savedConnection);
            SaveStates();
        }

        public static void RemoveSavedConnection(SavedConnection savedConnection)
        {
            SavedConnections.Remove(savedConnection);
            SaveStates();
        }

        public static void LoadStates()
        {
            var savedConnectionsFile = FileSerialize.DeSerializeObject<List<SavedConnection>>(savedConnectionsFilePath);
            if (savedConnectionsFile != null)
            {
                SavedConnections = savedConnectionsFile;
            }
            else
            {
                SavedConnections = new List<SavedConnection>();
            }
            
        }

        public static void SaveStates()
        {
            FileSerialize.SerializeObject(SavedConnections, savedConnectionsFilePath);
        }
    }
}
