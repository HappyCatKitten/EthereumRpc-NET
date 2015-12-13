using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockStudio
{
    public enum EthereumFilterType
    {
        NewBlock = 0,
        PendingTransaction = 1,
        Filter = 2
    }

    public enum SolcProjectFileType
    {
        Bin = 0,
        Sol = 1,
        Abi = 2
    }

    public enum LockedState
    {
        Locked = 0,
        Unlocked = 1,
        WrongPassword = 2
    }
    public enum GethInstanceState
    {
        NoInstanceRunning = 0,
        InstanceRunning = 1,
        NoInstanceRunningButPortInUse = 2
    }

    public enum NodeType
    {
        NewConnection = 0,
        Connection = 1,
        AccountParent = 2,
        Account = 3,
        Address = 4,
        Balance = 5,
        Solc = 6,
        SolcParent = 7,
        ProjectFiles = 8
    }

    public enum ConnectionStatus
    {
        Connected = 0,
        CouldNotConnect = 1,
        ConnectedButPersonalNotSuppored = 2
    }

    public enum EthereumStringType
    {
        Address = 0,
        TxHash = 1,
        BlockHash = 2,
        BlockHashOrTxHash = 3,
        Unknown = 4
    }

    public enum ConnectionType
    {
        Attach = 0,
        Instance = 1
    }
}
