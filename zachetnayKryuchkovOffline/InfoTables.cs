using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zachetnayKryuchkovOffline.Postavshik;
using zachetnayKryuchkovOffline.Sklad;
using zachetnayKryuchkovOffline.Sotrudnik;
using zachetnayKryuchkovOffline.Tovar;

namespace zachetnayKryuchkovOffline
{
    public partial class InfoTables : Form
    {
        SqlHelperOffline sqlHelper;
        public InfoTables(SqlHelperOffline sqlHelp)
        {
            InitializeComponent();
            sqlHelper = sqlHelp;
        }

        private void InfoTables_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e) //tovar
        {
            TovarTable tovarTable = new TovarTable(sqlHelper);
            tovarTable.ShowDialog();
        } 

        private void Button2_Click(object sender, EventArgs e) //post
        {
            PostavshikTable postavshikTable = new PostavshikTable(sqlHelper);
            postavshikTable.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e) //sotr
        {
            SotrudnikTable sotrudnikTable = new SotrudnikTable(sqlHelper);
            sotrudnikTable.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e) //sklad
        {
            SkladTable skladTable = new SkladTable(sqlHelper);
            skladTable.ShowDialog();
        }
    }
}
