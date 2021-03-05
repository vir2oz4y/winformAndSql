using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zachetnayKryuchkovOffline.BD
{
    class BD6class:ClassElement
    {
        public int kp { get; set; }
        public string naimP { get; set; }
        public int vsego { get; set; }

        public override void AddParametrs(SqlDataReader reader)
        {
            this.kp = int.Parse(reader[0].ToString());
            this.naimP = reader[1].ToString();
            this.vsego = int.Parse(reader[2].ToString());
        }
    }
}
