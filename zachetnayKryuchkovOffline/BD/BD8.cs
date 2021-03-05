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
    public partial class BD8 : Form
    {
        private SqlHelperOffline sqlHelper;
        List<BD8class> bd8;
        List<BD8class> filtered;
        public BD8(SqlHelperOffline help)
        {
            InitializeComponent();
            sqlHelper = help;
        }

        private void BD8_Load(object sender, EventArgs e)
        {
            bd8 = sqlHelper.SelectReport<BD8class>(SqlRequests.BD8());


            filtered = new List<BD8class>(bd8.Where(p => p.dataP == dateTimePicker1.Value.ToString()).ToList());
            dataGridView1.DataSource = filtered;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new List<BD8class>();
            filtered = new List<BD8class>(bd8.Where(p => p.dataP == dateTimePicker1.Value.ToString().Split(' ')[0]).ToList());
            dataGridView1.DataSource = filtered;
        }
    }
}
