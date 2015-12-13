using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
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
            var attributes = (DescriptionAttribute[]) field.GetCustomAttributes(typeof (DescriptionAttribute), false);
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

        public static string ToHexString(this BigInteger value)
        {
            return string.Format("0x{0}", value.ToString("X").ToLower());
        }

        public static string WeiToEther(this BigInteger value)
        {
            var divRem1 = BigInteger.Zero;
            var bal = BigInteger.DivRem(value, 1000000000000000000, out divRem1);
            var balanceString = string.Format("{0}.{1}", bal, divRem1);
            var decimalBalance = decimal.Parse(balanceString);
            return decimalBalance.ToString("0.00");
        }


        public static string ToHexString(this string value)
        {
            var result = string.Format("0x{0}", value.ToBigInteger().ToString("X").ToLower());
            return result;
        }

        public static int HexToInt(this string value)
        {
            if (value.Length == 2)
            {
                return 0;
            }

            return Convert.ToInt32(value, 16);
        }


        public static BigInteger ToBigInteger(this string value, Globalization.NumberStyles numberStyles = Globalization.NumberStyles.HexNumber)
        {
            value = numberStyles == Globalization.NumberStyles.HexNumber ? value.Substring(2) : value;
            var bigInteger = BigInteger.Parse(value, numberStyles);
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

        public static bool IsUri(this string source)
        {
            if (!string.IsNullOrEmpty(source) && Uri.IsWellFormedUriString(source, UriKind.RelativeOrAbsolute))
            {
                Uri tempValue;
                return (Uri.TryCreate(source, UriKind.RelativeOrAbsolute, out tempValue));
            }
            return (false);
        }

        public static string FormatLine(this string source, params object[] objects)
        {
            return string.Format(string.Format("{0}{1}", source,Environment.NewLine), objects);
        }
    }
}
