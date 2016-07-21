using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALGenerator
{
    class DBTableModel
    {
        public string table_name { set; get; }
        public string column_name { set; get; }
        public string data_type { set; get; }
        public string column_key { set; get; }
        public string extra { set; get; }
    }
}
