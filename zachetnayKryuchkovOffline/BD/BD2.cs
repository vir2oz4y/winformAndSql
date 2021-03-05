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
    public partial class BD2 : Form
    {
        SqlHelperOffline sqlHelper;
        List<TovarClass> tovars;
        List<BD2class> bd2;
        List<BD2class> filtered;
        public BD2(SqlHelperOffline sqlHelp)
        {
            InitializeComponent();
            sqlHelper = sqlHelp;
        }

        private void BD2_Load(object sender, EventArgs e)
        {
            tovars = sqlHelper.Select<TovarClass>("Tovar");
            bd2 = sqlHelper.SelectReport<BD2class>(SqlRequests.BD2());


            comboBox1.DisplayMember = "naimT";
            comboBox1.ValueMember = "kt";
            comboBox1.DataSource = tovars;


            filtered = new List<BD2class>(bd2.Where(p => p.kt == (int)comboBox1.SelectedValue).ToList());

            listBox1.DataSource = filtered;
            listBox1.DisplayMember = "fam";
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = new List<BD2class>();
            filtered = new List<BD2class>(bd2.Where(p => p.kt == (int)comboBox1.SelectedValue).ToList());
            listBox1.DataSource = filtered;
        }
    }
}
