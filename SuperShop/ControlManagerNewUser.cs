using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShop
{
    public partial class ControlManagerNewUser : UserControl
    {
        internal ClassDataAccess Da { get; set; }
        internal DataSet Ds { get; set; }
        internal string Sql { get; set; }
        internal string TableProductName { get; set; }
        internal string AutoIdValue { get; set; }
        internal FormManager FormManagerInstance { get; set; }
        public ControlManagerNewUser(FormManager formManagerInstance)
        {
            InitializeComponent();
            this.Da = new ClassDataAccess();
            this.FormManagerInstance = formManagerInstance;
        }

        internal void AutoIdGenerate()
        {
            string sql = "select id from userlogin order by id desc;";
            DataTable dt = this.Da.ExecuteQueryTable(sql);
            string previousId = dt.Rows[0][0].ToString();
            string[] temp = previousId.Split('u');
            int serialNo = Convert.ToInt32(temp[1]);
            string nextId = "u" + (++serialNo).ToString("000");
            this.AutoIdValue = nextId;
        }

        private void btnEnlistUser_Click(object sender, EventArgs e)
        {

            if (this.txtUsername.Text != "" && this.txtPassword.Text != "" && this.cmbUserType.Text != "Select type" && this.txtUserId.Text != "")
            {
                this.Sql = @"INSERT INTO userlogin VALUES('" + this.AutoIdValue + "', '" + this.txtUsername.Text + "', '" + this.txtPassword.Text + "', '" + this.cmbUserType.Text + "');";
                int productInsert = this.Da.ExecuteUpdateQuery(this.Sql);

                if (productInsert > 0)
                {
                    MessageBox.Show("INSERT Complete.");
                }

                this.txtUsername.Text = "";
                this.txtPassword.Text = "";
                this.cmbUserType.Text = "Select type";
                this.txtUserId.Text = "";
            }
            else
            {
                MessageBox.Show("Please fill up all the fields.");
            }

        }

        internal void setAutoId()
        {
            this.txtUserId.Text = this.AutoIdValue;
        }
    }
}
