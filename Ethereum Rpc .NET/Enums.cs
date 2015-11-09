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
        [Description("quanitiy")]
        Quantity,
        [Description("latest")]
        Latest,
        [Description("earliest")]
        Earliest,
        [Description("pending")]
        Pending
    }
}
