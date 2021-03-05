using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zachetnayKryuchkovOffline.BD.BDclasses
{
    class BD2class : ClassElement
    {
        public int kt { get; set; }
        public string naimT { get; set; }
        public string fam { get; set; }
        public override void AddParametrs(SqlDataReader reader)
        {
            this.kt = int.Parse(reader[0].ToString());
            this.naimT = reader[1].ToString();
            this.fam = reader[2].ToString();
        }
    }
}
