using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EthereumRpc.RpcObjects
{
    public class RpcResultStringArray : RpcResultBase
    {
        [JsonProperty(PropertyName = "result", Order = 2)]
        public List<string> Result { get; set; }
    }


    public class RpcResult : RpcResultBase
    {
        [JsonProperty(PropertyName = "result", Order = 2)]
        public dynamic Result { get; set; }
    }


}
