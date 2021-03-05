using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zachetnayKryuchkovOffline
{
    public abstract class ClassElement
    {
        public abstract void AddParametrs(SqlDataReader reader);
    }
}
