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
    public partial class ControlManagerEditUser : UserControl
    {
        internal ClassDataAccess Da { get; set; }
        internal DataSet Ds { get; set; }
        internal string Sql { get; set; }
        internal string UserInfoToUpdate { get; set; }
        internal FormManager PreviousInstance { get; set; }
        public ControlManagerEditUser(FormManager previousInstance)
        {
            InitializeComponent();
            this.Da = new ClassDataAccess();
            this.PreviousInstance = previousInstance;
        }

        internal void UpdateNewUser()
        {
            this.Sql = @"select * from userlogin where id = '" + this.UserInfoToUpdate + "';";
            this.Ds = Da.ExecuteQuery(Sql);
            if (Ds.Tables[0].Rows.Count == 1)
            {
                this.txtUsername.Text = Ds.Tables[0].Rows[0]["username"].ToString();
                this.txtPassword.Text = Ds.Tables[0].Rows[0]["password"].ToString();
                this.cmbUserType.Text = Ds.Tables[0].Rows[0]["usertype"].ToString();
                this.txtUserId.Text = this.UserInfoToUpdate;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(this.txtUsername.Text != "" && this.txtPassword.Text != "" && this.cmbUserType.Text != "Select type" && this.txtUserId.Text != ""){
                this.Sql = @"UPDATE userlogin SET username = '" + this.txtUsername.Text + "', password = '" + this.txtPassword.Text + "', usertype = '" + this.cmbUserType.Text + "' WHERE id='" + this.UserInfoToUpdate + "';";
                int updateInt = Da.ExecuteUpdateQuery(this.Sql);
                if (updateInt > 0)
                {
                    MessageBox.Show("Successful.");
                }
                this.PreviousInstance.MakeVisibleShowUsers();
            }
        }
    }
}
