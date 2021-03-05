using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zachetnayKryuchkovOffline.BD.BDclasses
{
    class BD7class:ClassElement
    {
        public string naimP { get; set; }
        public int kol_vo { get; set; }
        public int obiem { get; set; }
        public int stoim { get; set; }

        public override void AddParametrs(SqlDataReader reader)
        {
            this.naimP = reader[0].ToString();
            this.kol_vo = int.Parse(reader[1].ToString());
            this.obiem = int.Parse(reader[2].ToString());
            this.stoim = int.Parse(reader[3].ToString());
        }
    }
}
