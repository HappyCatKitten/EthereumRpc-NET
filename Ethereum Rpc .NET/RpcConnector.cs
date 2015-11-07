using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EthereumRpc
{
    public class RpcConnector
    {
        public static RpcResult MakeRequest(RpcRequest rpcRequest)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8545");
            //SetBasicAuthHeader(webRequest, _coinService.Parameters.RpcUsername, _coinService.Parameters.RpcPassword);
            //webRequest.Credentials = new NetworkCredential(_coinService.Parameters.RpcUsername, _coinService.Parameters.RpcPassword);
            webRequest.ContentType = "application/json-rpc";
            webRequest.Method = "POST";
            webRequest.Proxy = null;
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


        public static Byte[] GetBytes(string value)
        {
            String json = JsonConvert.SerializeObject(value);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
