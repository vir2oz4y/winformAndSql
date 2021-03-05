using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zachetnayKryuchkovOffline.BD.BDclasses
{
    class BD5class:ClassElement
    {
        public int ks { get; set; }
        public string fam { get; set; }
        public string im { get; set; }
        public string otch { get; set; }
        public int kol_vo { get; set; }

        public override void AddParametrs(SqlDataReader reader)
        {
            this.ks = int.Parse(reader[0].ToString());
            this.fam = reader[1].ToString();
            this.im = reader[2].ToString();
            this.otch = reader[3].ToString();
            this.kol_vo = int.Parse(reader[4].ToString());
        }
    }
}
