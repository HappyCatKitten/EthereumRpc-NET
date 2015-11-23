using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockStudio;

namespace Ethereum.Wallet.Ethereum
{
    public class EthereumSearchService
    {
        public EthereumStringType GetStringType(string value)
        {
            if (value.Length == 42)
            {
                return EthereumStringType.Address;
            }

            if (value.Length == 66)
            {
                return EthereumStringType.BlockHashOrTxHash;
            }
    
            return EthereumStringType.Unknown;
        }
    }
}
