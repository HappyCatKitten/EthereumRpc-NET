using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BlockStudio.Project
{
    public class Account
    {
        public string Address { get; set; }
        public string Password { get; set; }

        public string Label { get; set; }

        public int ImageIconIndex { get; set; }

        public BigInteger Balance { get; set; }
        public string BalanceEther => Balance.WeiToEther();

        public LockedState LockState{ get; set; }

        //public string ToStringValue { get; set; }

        public Account()
        {
            Balance = 0;
            Label = "My Account";
            ImageIconIndex = 3;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} Eth", Label, BalanceEther);
        }
    }
}
