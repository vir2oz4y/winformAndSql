using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zachetnayKryuchkovOffline.BD
{
    class BD3class : ClassElement
    {
        public string naimT { get; set; }
        public override void AddParametrs(SqlDataReader reader)
        {
            this.naimT = reader[0].ToString();
        }
    }
}
