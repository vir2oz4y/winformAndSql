using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zachetnayKryuchkovOffline.Sklad
{
    public partial class SkladTable : Form
    {
        BindingSource tovarBinding;
        BindingSource postavshikBinding;
        BindingSource sotrundikBinding;
        BindingSource skladBinding;
        SqlHelperOffline sqlHelper;
        List<Post> postavshiks;
        List<TovarClass> tovars;
        List<SotrudnikClass> sotrudniks;
        List<SkladClass> sklad;
        List<SkladClass> filtered;
        int index;

        public SkladTable(SqlHelperOffline sqlHelp)
        {
            InitializeComponent();
            sqlHelper = sqlHelp;
            tovarBinding = new BindingSource();
            postavshikBinding = new BindingSource();
            sotrundikBinding = new BindingSource();
            skladBinding = new BindingSource();
        }

        private void UpdateBinding()
        {
            skladBinding.DataSource = new List<SkladClass>();
            sklad = sqlHelper.Select<SkladClass>("SKLAD");
            filtered = new List<SkladClass>(sklad.Where(p => p.ks == (int)listBox1.SelectedValue && p.kp == (int)listBox2.SelectedValue && p.kt == ((int)listBox3.SelectedValue)).ToList());
            skladBinding.DataSource = filtered;
            dataGridView1.DataSource = skladBinding;
        }

        private void SkladTable_Load(object sender, EventArgs e)
        {
            postavshiks = sqlHelper.Select<Post>("POSTAVSHIK");
            tovars = sqlHelper.Select<TovarClass>("TOVAR");
            sotrudniks = sqlHelper.Select<SotrudnikClass>("SOTRUDNIK");
            

            postavshikBinding.DataSource = postavshiks;
            sotrundikBinding.DataSource = sotrudniks;
            tovarBinding.DataSource = tovars;

            listBox1.DataSource = sotrundikBinding;
            listBox1.DisplayMember = "fam";
            listBox1.ValueMember = "ks";

            listBox2.DataSource = postavshikBinding;
            listBox2.DisplayMember = "naimP";
            listBox2.ValueMember = "kp";

            listBox3.DataSource = tovarBinding;
            listBox3.DisplayMember = "naimT";
            listBox3.ValueMember = "kt";

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = skladBinding;
            dataGridView1.Columns.Add("data", "дата");
            dataGridView1.Columns.Add("obiem", "объем");
            dataGridView1.Columns.Add("stoim", "стоимость");
            dataGridView1.Columns["data"].DataPropertyName = "dataP";
            dataGridView1.Columns["obiem"].DataPropertyName = "obiem";
            dataGridView1.Columns["stoim"].DataPropertyName = "stoim";
            UpdateBinding();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                filtered = new List<SkladClass>(sklad.Where(p => p.ks== (int)listBox1.SelectedValue && p.kp == (int)listBox2.SelectedValue && p.kt == ((int)listBox3.SelectedValue)).ToList());
                dataGridView1.DataSource = filtered;
            }
            catch
            {

            }
        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                filtered = new List<SkladClass>(sklad.Where(p => p.ks == (int)listBox1.SelectedValue && p.kp == (int)listBox2.SelectedValue && p.kt == ((int)listBox3.SelectedValue)).ToList());
                dataGridView1.DataSource = filtered;

            }
            catch
            {

            }
        }

        private void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                filtered = new List<SkladClass>(sklad.Where(p => p.ks == (int)listBox1.SelectedValue && p.kp == (int)listBox2.SelectedValue && p.kt == ((int)listBox3.SelectedValue)).ToList());
                dataGridView1.DataSource = filtered;
            }
            catch
            {

            }
        }

        private void Button3_Click(object sender, EventArgs e) //delete
        {
            if (index !=-1)
            {
                sqlHelper.DeleteFromSklad(dataGridView1.Rows[index].Cells[0].Value.ToString(), int.Parse(dataGridView1.Rows[index].Cells[2].Value.ToString()), (int)listBox3.SelectedValue);
                UpdateBinding();
            }
            
        }

        private void Button1_Click(object sender, EventArgs e) //change
        {
            KeyValuePair<int, string> KS = new KeyValuePair<int, string>((int)listBox1.SelectedValue, listBox1.Text);
            KeyValuePair<int, string> KP = new KeyValuePair<int, string>((int)listBox2.SelectedValue, listBox2.Text);
            KeyValuePair<int, string> KT = new KeyValuePair<int, string>((int)listBox3.SelectedValue, listBox3.Text);

            SkladEdit skladEdit = new SkladEdit(sqlHelper, filtered, KS,KP,KT,  false);
            skladEdit.ShowDialog();
            UpdateBinding();
        }

        private void Button2_Click(object sender, EventArgs e) //add
        {
            KeyValuePair<int, string> KS = new KeyValuePair<int, string>((int)listBox1.SelectedValue, listBox1.Text);
            KeyValuePair<int, string> KP = new KeyValuePair<int, string>((int)listBox2.SelectedValue, listBox2.Text);
            KeyValuePair<int, string> KT = new KeyValuePair<int, string>((int)listBox3.SelectedValue, listBox3.Text);

            SkladEdit skladEdit = new SkladEdit(sqlHelper, filtered, KS, KP, KT);
            skladEdit.ShowDialog();
            UpdateBinding();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
        }
    }
}
