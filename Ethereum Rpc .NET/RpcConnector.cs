using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;
using System.Security.Policy;
using EthereumRpc.RpcObjects;

namespace EthereumRpc
{
    public class RpcConnector
    {
        public static Connection Connection{ get; set; }

        public RpcResult MakeRequest(RpcRequest rpcRequest)
        {
            if(Connection==null)
                throw new Exception("Connection property hasnt been set");

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}:{1}", Connection.Url, Connection.Port));
            //SetBasicAuthHeader(webRequest, _coinService.Parameters.RpcUsername, _coinService.Parameters.RpcPassword);
            //webRequest.Credentials = new NetworkCredential(_coinService.Parameters.RpcUsername, _coinService.Parameters.RpcPassword);
            webRequest.ContentType = "application/json-rpc";
            webRequest.Method = "POST";
            webRequest.Proxy = Connection.Proxy;
            webRequest.Timeout = 5000;
            

            var data = rpcRequest.ToJson();

            Byte[] byteArray = Encoding.UTF8.GetBytes(data);
            webRequest.ContentLength = byteArray.Length;

            try
            {
                using (Stream dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Dispose();
                }
            }
            catch (Exception exception)
            {
                throw exception;
                //throw new RpcException("There was a problem sending the request to the wallet", exception);
            }

            try
            {
                String json;

                using (WebResponse webResponse = webRequest.GetResponse())
                {
                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            var result = reader.ReadToEnd();

                            reader.Dispose();
                            json = result;
                        }
                    }
                }

                var rpcResult = JsonConvert.DeserializeObject<RpcResult>(json);
                return rpcResult;
            }
            catch (WebException webException)
            {

            }

            return null;
        }
    }
}
