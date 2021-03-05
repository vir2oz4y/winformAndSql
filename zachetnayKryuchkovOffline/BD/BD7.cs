using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zachetnayKryuchkovOffline.BD.BDclasses;

namespace zachetnayKryuchkovOffline.BD
{
    public partial class BD7 : Form
    {
        private SqlHelperOffline sqlHelper;
        List<BD7class> bd7;
        public BD7(SqlHelperOffline help)
        {
            InitializeComponent();
            sqlHelper = help;

        }

        private void BD7_Load(object sender, EventArgs e)
        {
            bd7 = sqlHelper.SelectReport<BD7class>(SqlRequests.BD7());
            dataGridView1.DataSource = bd7;
        }
    }
}
