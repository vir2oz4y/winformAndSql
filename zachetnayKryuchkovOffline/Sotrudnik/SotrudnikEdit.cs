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
    public partial class SotrudnikEdit : Form
    {
        SqlHelperOffline sqlHelper;
        SotrudnikClass sotrChange;
        SotrudnikClass sotrAdd;
        List<string> Pol;
        bool isAdd = true;
        public SotrudnikEdit(SqlHelperOffline sqlHelp, SotrudnikClass lastSotr)
        {
            InitializeComponent();
            sqlHelper = sqlHelp;
            sotrAdd = lastSotr;
        }
        public SotrudnikEdit(SqlHelperOffline sqlHelp, SotrudnikClass sotrChang, bool variant=false)
        {
            InitializeComponent();
            sqlHelper = sqlHelp;
            sotrChange = sotrChang;
            isAdd = variant;
        }

        private int CheckPol(string pol)
        {
            if (pol == "Мужской")
            {
                return 0;
            }
            return 1;
        }

        private void SotrudnikEdit_Load(object sender, EventArgs e)
        {
            Pol = new List<string>() { "Мужской", "Женский" };
            listBox1.DataSource = Pol;

            if (!isAdd)
            {
                textBox1.Text = sotrChange.fam;
                textBox2.Text = sotrChange.im;
                textBox3.Text = sotrChange.otch;
                dateTimePicker1.Value = DateTime.Parse(sotrChange.dataR);
                listBox1.SelectedIndex = CheckPol(sotrChange.pol);
                textBox4.Text = sotrChange.telP;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                int ks = sotrAdd.ks + 1;
                string fam = textBox1.Text;
                string im = textBox2.Text;
                string otch = textBox3.Text;
                DateTime datar = dateTimePicker1.Value;
                string pol = listBox1.SelectedItem.ToString();
                string tel = textBox4.Text;

                sqlHelper.Insert("Sotrudnik",
                    ("KS",SqlDbType.Int, ks),
                    ("fam",SqlDbType.NVarChar, fam),
                    ("im", SqlDbType.NVarChar, im),
                    ("otch", SqlDbType.NVarChar, otch),
                    ("datar", SqlDbType.DateTime, datar),
                    ("pol", SqlDbType.NVarChar, pol),
                    ("telp", SqlDbType.NVarChar,tel)
                    );
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                int ks = sotrChange.ks;
                string fam = textBox1.Text;
                string im = textBox2.Text;
                string otch = textBox3.Text;
                DateTime datar = dateTimePicker1.Value;
                string pol = listBox1.SelectedItem.ToString();
                string tel = textBox4.Text;

                string sqlQuerry = "Update sotrudnik set fam = @fam, im=@im, otch=@otch, datar=@datar, pol=@pol, telp=@telp where KS = @KS";
                sqlHelper.Update(sqlQuerry,
                   ("KS", SqlDbType.Int, ks),
                    ("fam", SqlDbType.NVarChar, fam),
                    ("im", SqlDbType.NVarChar, im),
                    ("otch", SqlDbType.NVarChar, otch),
                    ("datar", SqlDbType.DateTime, datar),
                    ("pol", SqlDbType.NVarChar, pol),
                    ("telp", SqlDbType.NVarChar, tel)
                    );
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
