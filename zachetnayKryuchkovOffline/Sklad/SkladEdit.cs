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
    public partial class SkladEdit : Form
    {
        List<SkladClass> sklad;
        List<SkladClass> copy;
        SqlHelperOffline sqlHelper;
        BindingSource bindingSource;
        KeyValuePair<int, string> KS;
        KeyValuePair<int, string> KP;
        KeyValuePair<int, string> KT;
        int index;
        bool isAdd = true;
        public SkladEdit(SqlHelperOffline sqlHelp, List<SkladClass> sklads, KeyValuePair<int, string> ks, KeyValuePair<int, string> kp, KeyValuePair<int, string> kt)
        {
            InitializeComponent();
            KS = ks;
            KT = kt;
            KP = kp;
            sqlHelper = sqlHelp;
            sklad = sklads;
            bindingSource = new BindingSource();
        }

        public SkladEdit(SqlHelperOffline sqlHelp, List<SkladClass> sklads, KeyValuePair<int, string> ks, KeyValuePair<int, string> kp, KeyValuePair<int, string> kt, bool check=false)
        {
            InitializeComponent();
            KS = ks;
            KT = kt;
            KP = kp;
            sqlHelper = sqlHelp;
            sklad = sklads;
            bindingSource = new BindingSource();
            isAdd = check;
        }

        private void SkladEdit_Load(object sender, EventArgs e)
        {
            copy = sklad;
            bindingSource.DataSource = sklad;
            comboBox1.Text = KS.Value;
            comboBox2.Text = KP.Value;
            comboBox3.Text = KT.Value;


            if (isAdd)
            {

            }
            else
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = bindingSource;
                dataGridView1.Columns.Add("data", "дата");
                dataGridView1.Columns.Add("obiem", "объем");
                dataGridView1.Columns.Add("stoim", "стоимость");
                dataGridView1.Columns["data"].DataPropertyName = "dataP";
                dataGridView1.Columns["obiem"].DataPropertyName = "obiem";
                dataGridView1.Columns["stoim"].DataPropertyName = "stoim";
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index != -1)
            {
                numericUpDown1.Value = Decimal.Parse(dataGridView1.Rows[index].Cells[1].Value.ToString());
                numericUpDown2.Value = Decimal.Parse(dataGridView1.Rows[index].Cells[2].Value.ToString());
                dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (!isAdd)
            {
                dataGridView1.Rows[index].Cells[0].Value = dateTimePicker1.Value.ToString();
            }
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!isAdd)
            {
                dataGridView1.Rows[index].Cells[1].Value = numericUpDown1.Value;
            }
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (!isAdd)
            {
                dataGridView1.Rows[index].Cells[2].Value = numericUpDown2.Value;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!isAdd)
            {
                string sqlQuerry = "Update sklad set datap = @data, obiem = @obiem, stoim = @stoim where datap = @lastdata and Stoim = @laststoim and KT = @lastKT";
                for (int i = 0; i < copy.Count; i++)
                {
                    sqlHelper.Update(sqlQuerry,
                        ("data", SqlDbType.DateTime, sklad[i].datap),
                        ("obiem", SqlDbType.Int, sklad[i].obiem),
                        ("stoim", SqlDbType.Int, sklad[i].stoim),
                        ("lastdata", SqlDbType.DateTime, copy[i].datap),
                        ("laststoim", SqlDbType.Int, copy[i].stoim),
                        ("lastKT", SqlDbType.Int, sklad[i].kt)
                        );
                }
            }
            else
            {
                sqlHelper.Insert("sklad",
                        ("data", SqlDbType.DateTime, dateTimePicker1.Value),
                        ("obiem", SqlDbType.Int, numericUpDown1.Value),
                        ("stoim", SqlDbType.Int, numericUpDown2.Value),
                        ("kp", SqlDbType.Int, KP.Key),
                        ("kt", SqlDbType.Int, KT.Key),
                        ("ks", SqlDbType.Int, KS.Key)
                    );
            }

            this.DialogResult = DialogResult.OK;
        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }
    }
}
