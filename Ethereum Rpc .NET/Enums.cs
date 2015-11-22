using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumRpc
{
    public enum BlockTag
    {
        [Description("quantity")]
        Quantity,
        [Description("latest")]
        Latest,
        [Description("earliest")]
        Earliest,
        [Description("pending")]
        Pending
    }

    public enum EtherUnit
    {
        [Description("Wei")]
        Wei,
        [Description("Kwei")]
        Kwei,
        [Description("Mwei")]
        Mwei,
        [Description("Gwei")]
        Gwei,
        [Description("Szabo")]
        Szabo,
        [Description("Finney")]
        Finney,
        [Description("Ether")]
        Ether,

    }
}
