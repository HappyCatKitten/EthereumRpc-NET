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
    }

    public enum EthereumStringType
    {
        Address = 0,
        TxHash = 1,
        BlockHash = 2,
        BlockHashOrTxHash = 3,
        Unknown = 4
    }
}
