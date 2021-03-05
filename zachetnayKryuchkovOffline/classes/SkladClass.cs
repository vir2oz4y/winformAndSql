using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zachetnayKryuchkovOffline
{
    public class SkladClass:ClassElement
    {
        public string datap { get; set; }
        public int obiem { get; set; }
        public int stoim { get; set; }
        public int kt { get; set; }
        public int kp { get; set; }
        public int ks { get; set; }

        public override void AddParametrs(SqlDataReader reader)
        {
            this.datap = reader[0].ToString();
            this.obiem = int.Parse(reader[1].ToString());
            this.stoim = int.Parse(reader[2].ToString());
            this.kt = int.Parse(reader[3].ToString());
            this.kp = int.Parse(reader[4].ToString());
            this.ks = int.Parse(reader[5].ToString());
        }
    }
}
