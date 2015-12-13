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
        public static ConnectionOptions ConnectionOptions{ get; set; }

        public RpcResult MakeRequest(RpcRequest rpcRequest)
        {
            if(ConnectionOptions==null)
                throw new Exception("ConnectionOptions property hasnt been set");

            if(!ConnectionOptions.IsUrlValid)
                throw new EthereumRpcException(string.Format("Specified address '{0}:{1}' is not valid", ConnectionOptions.Url, ConnectionOptions.Port));

            var webRequest = (HttpWebRequest)WebRequest.Create(ConnectionOptions.FullUrl);

            if (ConnectionOptions.NetworkCredential != null)
            {
                //SetBasicAuthHeader(webRequest, _coinService.Parameters.RpcUsername, _coinService.Parameters.RpcPassword);
                webRequest.Credentials = ConnectionOptions.NetworkCredential;
            }

            webRequest.ContentType = "application/json-rpc";
            webRequest.Method = "POST";
            webRequest.Proxy = ConnectionOptions.Proxy;
            webRequest.Timeout = ConnectionOptions.TimeOut;

            var data = rpcRequest.ToJson();

            var byteArray = Encoding.UTF8.GetBytes(data);
            webRequest.ContentLength = byteArray.Length;

            try
            {
                using (var dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Dispose();
                }
            }
            catch (WebException exception)
            {
                
                throw new EthereumRpcException(string.Format("Could not connect to ethereum on network address {0}:{1}. Check Ethereum is running and the correct port is specified (8545 for live)", ConnectionOptions.Url, ConnectionOptions.Port));
            }
            catch (Exception exception)
            {
                throw exception;
                //throw new RpcException("There was a problem sending the request to the wallet", exception);
            }

            try
            {
                String json;

                using (var webResponse = webRequest.GetResponse())
                {
                    using (var stream = webResponse.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
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
                throw new EthereumRpcException(string.Format("Ethereum returned unknown response"));
            }

            return null;
        }
    }
}
