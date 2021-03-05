using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zachetnayKryuchkovOffline.BD.BDclasses
{
    class BD4class : ClassElement
    {
        public string naimT { get; set; }
        public override void AddParametrs(SqlDataReader reader)
        {
            this.naimT = reader[0].ToString();
        }
    }
}
