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
    public partial class BD6 : Form
    {
        private SqlHelperOffline sqlHelper;
        List<Post> posts;
        List<BD6class> bd6;
        List<BD6class> filtered;
        public BD6(SqlHelperOffline help)
        {
            InitializeComponent();
            sqlHelper = help;
        }

        private void BD6_Load(object sender, EventArgs e)
        {
            posts = sqlHelper.Select<Post>("Postavshik");
            bd6 = sqlHelper.SelectReport<BD6class>(SqlRequests.BD6());

            comboBox1.DisplayMember = "naimP";
            comboBox1.ValueMember = "kp";
            comboBox1.DataSource = posts;


            try
            {
                filtered = new List<BD6class>(bd6.Where(p => p.kp == (int)comboBox1.SelectedValue).ToList());
                textBox1.Text = filtered[0].vsego.ToString();
            }
            catch
            {
                textBox1.Text = "0";
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                filtered = new List<BD6class>(bd6.Where(p => p.kp == (int)comboBox1.SelectedValue).ToList());
                textBox1.Text = filtered[0].vsego.ToString();
            }
            catch
            {
                textBox1.Text = "0";
            }
            
        }
    }
}
