using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockStudio.TreeNodes;
using EthereumRpc;

namespace BlockStudio.Project
{
    public class Connection
    {
        [Browsable(false)]
        public string Uid{ get; set; }

        public string DefaultDisplayName{ get; set; }
        public string RpcPort { get; set; }

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

        public string IpcPath { get; set; }

        public string CleverUrl()
        {
            return ConnectionType.Attach == ConnectionType ? Url : "http://localhost";
        }

        public ConnectionType ConnectionType{ get; set; }

        //private EthereumService _ethereumService;

        [Browsable(false)]
        public EthereumService EthereumService {
            get
            {
                return new EthereumService(CleverUrl(), RpcPort);
            }
        }


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

                foreach (var ethAccount in ethAccounts)
                {
                    var account = BlockStudioProjectService.BlockStudioProject.Accounts.FirstOrDefault(x => x.Address == ethAccount);

                    if (account==null)
                    {
                        account = new Account();
                        account.Address = ethAccount;
                        account.LockState = LockedState.Locked;
                    }

                    if (!string.IsNullOrEmpty(account.Password))
                    {
                        try
                        {
                            var unlockSuccessful = EthereumService.UnlockAccount(account.Address, account.Password);

                            if (unlockSuccessful)
                            {
                                account.Balance = EthereumService.GetBalance(account.Address, BlockTag.Latest);
                                account.LockState = LockedState.Unlocked;
                            }
                            else
                            {
                                account.ImageIconIndex = 6;
                                account.LockState = LockedState.WrongPassword;
                            }

                        }
                        catch (Exception exception)
                        {
                            return ConnectionStatus.ConnectedButPersonalNotSuppored;
                        }
                        
                    }
                    else
                    {
                        account.LockState = LockedState.Locked;
                    }

                    BlockStudioProjectService.BlockStudioProject.UpsertAccount(account);
                }

                BlockStudioProjectService.BlockStudioProject.SaveToDisk();

                return ConnectionStatus.Connected;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Connection()
        {

        }

        public Connection(bool factoryDefaults)
        {
            RpcPort = "8545";
            Port = "30303";
            Url = "http://localhost";
            Mine = true;
            NetworkId = 123;
            MaxPeers = 0;
            RpcAddress = "0.0.0.0";
            MinerThreads = 1;
            RpcCorsDomain = "*";
            RpcApi = "eth,web3,personal";
            DataDir = @"C:/Users/machine/Dropbox/Ethereum/Geth/privatechain/";
            IpcPath = @"\\.\pipe\geth.ipc";
        }
    }
}
