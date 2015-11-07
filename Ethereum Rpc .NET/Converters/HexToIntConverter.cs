using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EthereumRpc.Converters
{
    public class HexToIntConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                var hex = serializer.Deserialize<string>(reader);
                
                if (!string.IsNullOrEmpty(hex))
                {
                    var intValue = Convert.ToInt32(hex, 16);
                    return intValue;
                }
            }

            return 0;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var bytes = value as byte[];
            var @string = BitConverter.ToString(bytes).Replace("-", string.Empty);
            serializer.Serialize(writer, @string);
        }
    }
}
