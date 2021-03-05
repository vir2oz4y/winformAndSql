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
    public partial class BD1 : Form
    {
        private SqlHelperOffline sqlHelper;
        List<TovarClass> tovars;
        List<BD1class> bd1;
        List<BD1class> filtered;

        public BD1(SqlHelperOffline help)
        {
            InitializeComponent();
            sqlHelper = help;
        }

        private void BD1_Load(object sender, EventArgs e)
        {
            tovars = sqlHelper.Select<TovarClass>("Tovar");
            bd1 = sqlHelper.SelectReport<BD1class>(SqlRequests.BD1());


            comboBox1.DisplayMember = "naimT";
            comboBox1.ValueMember = "kt";
            comboBox1.DataSource = tovars;
            

            filtered = new List<BD1class>(bd1.Where(p => p.kt == (int)comboBox1.SelectedValue).ToList());

            listBox1.DataSource = filtered;
            listBox1.DisplayMember = "naimP";
        }

        

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = new List<BD1class>();
            filtered = new List<BD1class>(bd1.Where(p => p.kt == (int)comboBox1.SelectedValue).ToList());
            listBox1.DataSource = filtered;
        }
            
    }
}
