using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zachetnayKryuchkovOffline.Postavshik
{
    public partial class PostavshikEdit : Form
    {
        SqlHelperOffline sqlHelper;
        Post postChange;
        Post postAdd;
        bool isAdd = true;
        public PostavshikEdit(SqlHelperOffline sqlHelp, Post lastElem)
        {
            InitializeComponent();
            sqlHelper = sqlHelp;
            postAdd = lastElem;
        }

        public PostavshikEdit(SqlHelperOffline sqlHelp, Post postChange1, bool variant = false)
        {
            InitializeComponent();
            sqlHelper = sqlHelp;
            postChange = postChange1;
            isAdd = variant;
        }

        private void PostavshikEdit_Load(object sender, EventArgs e)
        {
            if (!isAdd)
            {
                textBox1.Text = postChange.naimP;
                textBox2.Text = postChange.telP;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                int kp = postAdd.kp + 1;
                string name = textBox1.Text;
                string tel = textBox2.Text;

                sqlHelper.Insert("Postavshik",
                    ("KP", SqlDbType.Int, kp),
                    ("naimP", SqlDbType.NVarChar, name),
                    ("TelP", SqlDbType.NVarChar, tel));
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                int kp = postChange.kp;
                string name = textBox1.Text;
                string tel = textBox2.Text;
                string sqlQuerry = "Update Postavshik set naimP = @naimP, TelP = @TelP where KP = @KP";
                sqlHelper.Update(sqlQuerry,
                    ("KP", SqlDbType.Int, kp),
                    ("naimP", SqlDbType.NVarChar, name),
                    ("TelP", SqlDbType.NVarChar, tel));
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
