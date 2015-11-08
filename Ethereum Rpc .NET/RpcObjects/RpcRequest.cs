using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EthereumRpc
{
    public class RpcRequest
    {
        [JsonProperty(PropertyName = "jsonrpc", Order = 0)]
        public string JsonRpc { get; set; }
  
        [JsonProperty(PropertyName = "method", Order = 0)]
        public string Method { get; set; }
 
        [JsonProperty(PropertyName = "params", Order = 0)]
        public object[] Params { get; set; }

        [JsonProperty(PropertyName = "id", Order = 0)]
        public int Id { get; set; }

        public RpcRequest(RpcMethod rpcMethod)
        {
            Params= new string[0];
            JsonRpc = "2.0";
            Id = 68;
            Method = rpcMethod.ToJsonMethodName();
        }

        public void AddParam(object value)
        {
            var list = Params.ToList();
            list.Add(value);
            Params = list.ToArray();
        }

        public string ToJson()
        {
            var json = JsonConvert.SerializeObject(this);
            return json;
        }
    }
}
