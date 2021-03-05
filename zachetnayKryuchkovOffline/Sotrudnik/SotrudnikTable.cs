using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zachetnayKryuchkovOffline.Sotrudnik
{
    public partial class SotrudnikTable : Form
    {
        SqlHelperOffline sqlHelper;
        List<SotrudnikClass> sotrudniks;
        BindingSource bindingSource;
        public SotrudnikTable(SqlHelperOffline sqlHelp)
        {
            InitializeComponent();
            sqlHelper = sqlHelp;
            bindingSource = new BindingSource();
        }

        private void UpdateBinding()
        {
            sotrudniks = sqlHelper.Select<SotrudnikClass>("SOTRUDNIK");
            bindingSource.DataSource = sotrudniks;
        }

        private void SotrudnikTable_Load(object sender, EventArgs e)
        {
            UpdateBinding();
            listBox1.DataSource = bindingSource;
            listBox1.DisplayMember = "fam";
            listBox1.ValueMember = "ks";
            

            dateTimePicker1.DataBindings.Add(new Binding("Value", bindingSource, "dataR"));

            textBox1.DataBindings.Add("Text", bindingSource, "telP");
            textBox2.DataBindings.Add("Text", bindingSource, "pol");
        }

        private void Button3_Click(object sender, EventArgs e) //delete
        {
            sqlHelper.Delete("Sotrudnik", "ks", listBox1.SelectedValue);
            UpdateBinding();
        }

        private void Button1_Click(object sender, EventArgs e) //change
        {
            SotrudnikEdit sotrudnikEdit = new SotrudnikEdit(sqlHelper, sotrudniks[listBox1.SelectedIndex], false);
            sotrudnikEdit.ShowDialog();
            UpdateBinding();
        }

        private void Button2_Click(object sender, EventArgs e) //add
        {
            SotrudnikEdit sotrudnikEdit = new SotrudnikEdit(sqlHelper, sotrudniks[sotrudniks.Count-1]);
            sotrudnikEdit.ShowDialog();
            UpdateBinding();
        }

        private void ListBox1_Format(object sender, ListControlConvertEventArgs e)
        {
            
        }
    }
}
