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

        public static string ToJsonMethodName(this BlockTag value)
        {
            return GetEnumDescription(value);
        }

        public static string ToHexString(this int value)
        {
            return string.Format("0x{0}", 2.ToString("X").ToLower());
        }

        public static int HexToInt(this string value)
        {
            if (value.Length == 2)
            {
                return 2;
            }
            
            return Convert.ToInt32(value, 16);
        }


    }
}
