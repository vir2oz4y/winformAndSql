using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zachetnayKryuchkovOffline
{
    public class TovarClass : ClassElement
    {
        public int kt { get; set; }
        public string naimT { get; set; }
        public int srG { get; set; }
        public override void AddParametrs(SqlDataReader reader)
        {
            this.kt = int.Parse(reader[0].ToString());
            this.naimT = reader[1].ToString();
            this.srG = int.Parse(reader[2].ToString());
        }
    }
}
