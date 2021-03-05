using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zachetnayKryuchkovOffline.Tovar
{
    public partial class TovarTable : Form
    {
        SqlHelperOffline sqlHelper;
        List<TovarClass> tovars;
        BindingSource bindingSource;
        public TovarTable(SqlHelperOffline sqlHelp)
        {
            InitializeComponent();
            sqlHelper = sqlHelp;
            bindingSource = new BindingSource();
            
        }

        private void UpdateBinding()
        {
            bindingSource.DataSource = new List<TovarClass>();
            tovars = sqlHelper.Select<TovarClass>("Tovar");
            bindingSource.DataSource = tovars;

        }

        private void TovarTable_Load(object sender, EventArgs e)
        {

            UpdateBinding();

            listBox1.DataSource = bindingSource;
            listBox1.DisplayMember = "naimT";
            listBox1.ValueMember = "kt";

            numericUpDown1.DataBindings.Add(new Binding("Value", bindingSource, "SrG"));

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TovarEdit tovarEdit = new TovarEdit(sqlHelper, tovars[listBox1.SelectedIndex], false);
            tovarEdit.ShowDialog();
            UpdateBinding();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            TovarEdit tovarEdit = new TovarEdit(sqlHelper, tovars[tovars.Count-1]);
            tovarEdit.ShowDialog();
            UpdateBinding();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            sqlHelper.Delete("Tovar", "kt", listBox1.SelectedValue);
            UpdateBinding();
        }
    }
}
