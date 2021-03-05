using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zachetnayKryuchkovOffline
{
    public class SotrudnikClass : ClassElement
    {
        public int ks { get; set; }
        public string fam { get; set; }
        public string im { get; set; }
        public string otch { get; set; }
        public string dataR { get; set; }
        public string pol { get; set; }
        public string telP { get; set; }

        public override void AddParametrs(SqlDataReader reader)
        {
            this.ks = int.Parse(reader[0].ToString());
            this.fam = reader[1].ToString();
            this.im = reader[2].ToString();
            this.otch = reader[3].ToString();
            this.dataR = reader[4].ToString();
            this.pol = reader[5].ToString();
            this.telP = reader[6].ToString();
        }
    }
}
