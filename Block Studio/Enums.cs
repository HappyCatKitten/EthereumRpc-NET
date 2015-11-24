using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockStudio
{
    public enum NodeType
    {
        NewConnection = 0,
        Connection = 1,
        AccountParent = 2,
        Account = 3
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
