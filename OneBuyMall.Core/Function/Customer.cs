using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBuyMall
{
    public partial class Core
    {
        public HRESULT Login(string name, string pass)
        {
            return HRESULT.Success;
        }
        public HRESULT Register(string Name,string Pass)
        {

            return HRESULT.Success;
        }
        public HRESULT ChangeMoney(int ID, int Money, MoneyChangeType changetype = MoneyChangeType.Consume)
        {
            return HRESULT.Success;
        }
    }
}
