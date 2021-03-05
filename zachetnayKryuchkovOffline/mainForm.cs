using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zachetnayKryuchkovOffline.BD;

namespace zachetnayKryuchkovOffline
{
    public partial class mainForm : Form
    {
        SqlHelperOffline sqlHelper;
        public mainForm()
        {
            InitializeComponent();
            sqlHelper = new SqlHelperOffline();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //List<Post> postavshiks = sqlHelper.Select<Post>("POSTAVSHIK");
            //List<TovarClass> tovars = sqlHelper.Select<TovarClass>("TOVAR");
            //List<SotrudnikClass> sotrudniks = sqlHelper.Select<SotrudnikClass>("SOTRUDNIK");
            //List<SkladClass> sklad = sqlHelper.Select<SkladClass>("SKLAD");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            InfoTables infoTables = new InfoTables(sqlHelper);
            infoTables.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            BDmain bDmain = new BDmain(sqlHelper);
            bDmain.ShowDialog();
        }
    }
}
