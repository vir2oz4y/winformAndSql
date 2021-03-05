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
    public partial class BD4 : Form
    {
        private SqlHelperOffline sqlHelper;
        List<BD4class> bd4;
        public BD4(SqlHelperOffline help)
        {
            InitializeComponent();
            sqlHelper = help;

        }

        private void BD4_Load(object sender, EventArgs e)
        {
            bd4 = sqlHelper.SelectReport<BD4class>(SqlRequests.BD4());

            listBox1.DisplayMember = "naimT";
            listBox1.DataSource = bd4;
        }
    }
}
