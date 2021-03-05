using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zachetnayKryuchkovOffline.BD
{
    public partial class BD3 : Form
    {
        private SqlHelperOffline sqlHelper;
        List<BD3class> bd3;
        public BD3(SqlHelperOffline help)
        {
            InitializeComponent();
            sqlHelper = help;
        }

        private void BD3_Load(object sender, EventArgs e)
        {
            bd3 = sqlHelper.SelectReport<BD3class>(SqlRequests.BD3());
            listBox1.DisplayMember = "naimT";
            listBox1.DataSource = bd3;
        }
    }
}
