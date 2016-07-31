using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBuyMall
{
    public partial class Core
    {
        public Dictionary<HRESULT, string> ResultMsg;
        public enum HRESULT
        {
            Success,
            Fail,
            RemainingLess
        }
        public enum MoneyChangeType
        {
            Recharge,
            Consume,
            Award,
        }
        public enum eStore
        {
            One,
            Exchange
        }
    }
}
