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
    public partial class PostavshikTable : Form
    {
        SqlHelperOffline sqlHelper;
        List<Post> postavshiki;
        BindingSource bindingSource;

        public PostavshikTable(SqlHelperOffline sqlHelp)
        {
            InitializeComponent();
            sqlHelper = sqlHelp;
            bindingSource = new BindingSource();
        }


        private void UpdateBinding()
        {
            bindingSource.DataSource = new List<Post>();
            postavshiki = sqlHelper.Select<Post>("Postavshik");
            bindingSource.DataSource = postavshiki;

        }

        private void PostavshikTable_Load(object sender, EventArgs e)
        {
            UpdateBinding();

            listBox1.DataSource = bindingSource;
            listBox1.DisplayMember = "naimP";
            listBox1.ValueMember = "kp";

            textBox1.DataBindings.Add(new Binding("Text", bindingSource, "telP"));
        }

        private void Button3_Click(object sender, EventArgs e) //delete
        {
            sqlHelper.Delete("Postavshik", "kp", listBox1.SelectedValue);
            UpdateBinding();
        }

        private void Button1_Click(object sender, EventArgs e) //change
        {
            PostavshikEdit postavshikEdit = new PostavshikEdit(sqlHelper, postavshiki[listBox1.SelectedIndex], false);
            postavshikEdit.ShowDialog();
            UpdateBinding();
        }

        private void Button2_Click(object sender, EventArgs e) //add
        {
            PostavshikEdit postavshikEdit = new PostavshikEdit(sqlHelper, postavshiki[postavshiki.Count - 1]);
            postavshikEdit.ShowDialog();
            UpdateBinding();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
