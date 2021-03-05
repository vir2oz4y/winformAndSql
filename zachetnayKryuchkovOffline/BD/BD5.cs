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
    public partial class BD5 : Form
    {
        private SqlHelperOffline sqlHelper;
        List<SotrudnikClass> sotrs;
        List<BD5class> bd5;
        List<BD5class> filtered;
        public BD5(SqlHelperOffline help)
        {
            InitializeComponent();
            sqlHelper = help;
        }

        private void BD5_Load(object sender, EventArgs e)
        {
            sotrs = sqlHelper.Select<SotrudnikClass>("Sotrudnik");
            bd5 = sqlHelper.SelectReport<BD5class>(SqlRequests.BD5());

            comboBox1.DisplayMember = "fam";
            comboBox1.ValueMember = "ks";
            comboBox1.DataSource = sotrs;

            filtered = new List<BD5class>(bd5.Where(p => p.ks == (int)comboBox1.SelectedValue).ToList());

            textBox1.Text = filtered[0].kol_vo.ToString();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtered = new List<BD5class>(bd5.Where(p => p.ks == (int)comboBox1.SelectedValue).ToList());
            textBox1.Text = filtered[0].kol_vo.ToString();
        }
    }
}
