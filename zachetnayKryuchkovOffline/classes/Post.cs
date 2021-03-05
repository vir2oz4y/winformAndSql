using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zachetnayKryuchkovOffline
{
    public class Post : ClassElement
    {
        public Post(){ }
        public override void AddParametrs(SqlDataReader reader)
        {
            this.kp =int.Parse(reader[0].ToString());
            this.naimP = reader[1].ToString();
            this.telP = reader[2].ToString();
        }
        public int kp { get; set; }
        public string naimP { get; set; }
        public string telP { get; set; }
    }
}
