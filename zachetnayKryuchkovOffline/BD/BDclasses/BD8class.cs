using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zachetnayKryuchkovOffline.BD.BDclasses
{
    class BD8class:ClassElement
    {
        public string dataP { get; set; }
        public string naimT { get; set; }
        public string naimP { get; set; }

        public override void AddParametrs(SqlDataReader reader)
        {
            this.dataP = reader[0].ToString().Split(' ')[0];
            this.naimT = reader[1].ToString();
            this.naimP = reader[2].ToString();
        }
    }
}
