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
    public partial class BDmain : Form
    {
        public SqlHelperOffline sqlHelper;
        public BDmain(SqlHelperOffline sqlHelp)
        {
            InitializeComponent();
            sqlHelper = sqlHelp;
        }

        private void BDmain_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BD1 bD1 = new BD1(sqlHelper);
            bD1.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            BD2 bD2 = new BD2(sqlHelper);
            bD2.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            BD3 bD3 = new BD3(sqlHelper);
            bD3.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            BD4 bD4 = new BD4(sqlHelper);
            bD4.ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            BD5 bD5 = new BD5(sqlHelper);
            bD5.ShowDialog();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            BD6 bD6 = new BD6(sqlHelper);
            bD6.ShowDialog();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            BD7 bd7 = new BD7(sqlHelper);
            bd7.ShowDialog();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            BD8 bD8 = new BD8(sqlHelper);
            bD8.ShowDialog();
        }
    }
}
