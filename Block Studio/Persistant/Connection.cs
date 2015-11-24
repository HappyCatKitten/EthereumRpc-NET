using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EthereumRpc;

namespace BlockStudio.Persistant
{
    public class Connection
    {
        [Browsable(false)]
        public string Uid{ get; set; }

        [Browsable(false)]
        public string Name { get; set; }

        public string Port { get; set; }

        public string Url { get; set; }

        public bool PrivateChain { get; set; }

        public bool Mine { get; set; }

        public int NetworkId { get; set; }

        public int MaxPeers { get; set; }

        public string RpcAddress { get; set; }

        public int MinerThreads { get; set; }

        public string RpcCorsDomain { get; set; }

        public string DataDir { get; set; }

        public string RpcApi { get; set; }

        public string PrivateChainPath{ get; set; }

        public string CleverUrl()
        {
            return ConnectionType.Attach == ConnectionType ? Url : "http://localhost";
        }

        public ConnectionType ConnectionType{ get; set; }

        public EthereumService EthereumService { get; set; }

        [Browsable(false)]
        public List<Account> Accounts{ get; set; }

        public ConnectionStatus GetConnectionProperties()
        {
            try
            {
                var version = EthereumService.GetWeb3ClientVersion();
            }
            catch (Exception)
            {
                return ConnectionStatus.CouldNotConnect;
            }


            try
            {
                var ethAccounts = EthereumService.GetAccounts();
                Accounts = new List<Account>();

                foreach (var ethAccount in ethAccounts)
                {
                    var account = PersistantState.Accounts.FirstOrDefault(x => x.AccountId == ethAccount);

                    if (account==null)
                    {
                        account = new Account();
                        account.AccountId = ethAccount;
                        account.Locked = true;
                    }

                    if (!string.IsNullOrEmpty(account.Password))
                    {
                        EthereumService.UnlockAccount(account.AccountId, account.Password);
                        account.Locked = false;
                    }

                    Accounts.Add(account);
                }

                return ConnectionStatus.Connected;
            }
            catch (Exception)
            {
                return ConnectionStatus.ConnectedButPersonalNotSuppored;
            }
        }

        public Connection()
        {
            Port = "8545";
            Url = "http://localhost";
            Mine = true;
            NetworkId = 123;
            MaxPeers = 0;
            RpcAddress = "0.0.0.0";
            MinerThreads = 1;
            RpcCorsDomain = "*";
            //RpcApi = "eth,web3,personal";
            DataDir = @"C:/Users/machine/Dropbox/Ethereum/Geth/privatechain/";
            PrivateChainPath = @"C:/Users/machine/Dropbox/Ethereum/Geth/privatechain/";

            EthereumService = new EthereumService(CleverUrl(), Port);
        }
    }
}
