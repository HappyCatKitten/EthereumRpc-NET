using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using EthereumRpc;

namespace System
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
            return string.Format("0x{0}", value.ToString("X").ToLower());
        }

        public static int HexToInt(this string value)
        {
            if (value.Length == 2)
            {
                return 0;
            }

            return Convert.ToInt32(value, 16);
        }


        public static BigInteger ToBigInteger(this string value)
        {
            var bigInteger = BigInteger.Parse(value.Substring(2), Globalization.NumberStyles.HexNumber);
            return bigInteger;
        }


        public static long HexToLong(this string value)
        {
            if (value.Length == 2)
            {
                return 0;
            }

            return Convert.ToInt64(value, 16);
        }
    }
}
