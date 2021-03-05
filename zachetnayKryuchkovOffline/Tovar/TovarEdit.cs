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
    public partial class TovarEdit : Form
    {
        SqlHelperOffline sqlHelper;
        TovarClass tovarChange;
        TovarClass tovarAdd;
        bool isAdd = true;
        public TovarEdit(SqlHelperOffline sqlHelp, TovarClass lastElem)
        {
            InitializeComponent();
            sqlHelper = sqlHelp;
            tovarAdd = lastElem;
        }

        public TovarEdit(SqlHelperOffline sqlHelp, TovarClass tovarChange1, bool variant=false)
        {
            InitializeComponent();
            sqlHelper = sqlHelp;
            tovarChange = tovarChange1;
            isAdd = variant;
        }

        private void TovarEdit_Load(object sender, EventArgs e)
        {
            if (!isAdd)
            {
                textBox1.Text = tovarChange.naimT;
                numericUpDown1.Value = tovarChange.srG;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                int kt = tovarAdd.kt + 1;
                string name = textBox1.Text;
                int srg = int.Parse(numericUpDown1.Value.ToString());
                sqlHelper.Insert("Tovar",
                    ("KT", SqlDbType.Int, kt),
                    ("naimT", SqlDbType.NVarChar, name),
                    ("SrG", SqlDbType.Int, srg));
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                int kt = tovarChange.kt;
                string name = textBox1.Text;
                int srg = int.Parse(numericUpDown1.Value.ToString());
                string sqlQuerry = "Update tovar set naimt = @naimt, SrG = @SrG where KT = @KT";
                sqlHelper.Update(sqlQuerry,
                    ("naimt", SqlDbType.NVarChar, name),
                    ("SrG", SqlDbType.Int, srg),
                    ("KT", SqlDbType.Int, kt));
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
