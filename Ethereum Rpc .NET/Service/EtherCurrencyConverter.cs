using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EthereumRpc.Service
{
    public class EtherCurrencyConverter
    {
        public static string Convert(string value, EtherCurrencyConverter from, EtherCurrencyConverter to)
        {
            var v = value.ToBigInteger();
            var result = v / 1000000000000000000;
            return result.ToString();
        }

        public static string Convert(BigInteger value)
        {
             
            var result = value / 1000000000000000000;
            return result.ToString();
        }



    }
}
