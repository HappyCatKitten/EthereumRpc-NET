using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthereumRpc
{
    public static class MethodExtension
    {
        public static string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Any()) ? attributes.First().Description : value.ToString();
        }

        public static string ToJsonMethodName(this RpcMethod value)
        {
            return GetEnumDescription(value);
        }
    }
}
