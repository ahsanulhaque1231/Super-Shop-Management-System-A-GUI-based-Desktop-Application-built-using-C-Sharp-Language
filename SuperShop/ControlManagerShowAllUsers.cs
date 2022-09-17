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
    public partial class ControlManagerShowAllUsers : UserControl
    {
        internal ClassDataAccess Da { get; set; }
        internal DataSet Ds { get; set; }
        internal string Sql { get; set; }
        internal string UserInfoToUpdate { get; set; }
        internal string CurrentRowUser { get; set; }
        internal ControlManagerEditUser ControlEmployeeEditUserInstance { get; set; }
        internal FormManager PreviousInstance { get; set; }

        public ControlManagerShowAllUsers(FormManager previousInstance)
        {
            InitializeComponent();
            this.Da = new ClassDataAccess();
            this.PopulateGridViewShowAllUsers();
            this.PreviousInstance = previousInstance;
            this.ControlEmployeeEditUserInstance = new ControlManagerEditUser(PreviousInstance);
        }

        internal void PopulateGridViewShowAllUsers(string sql = "select * from userlogin;")
        {
            this.Ds = this.Da.ExecuteQuery(sql);

            this.dgvShowAllUsers.AutoGenerateColumns = false;
            this.dgvShowAllUsers.DataSource = this.Ds.Tables[0];
        }

        private void ControlEmployeeShowAllUsers_Load(object sender, EventArgs e)
        {
            this.dgvShowAllUsers.ClearSelection();
            this.dgvShowAllUsers.Refresh();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            this.UserInfoToUpdate = this.dgvShowAllUsers.CurrentRow.Cells["id"].Value.ToString();
            this.ControlEmployeeEditUserInstance.UserInfoToUpdate = this.UserInfoToUpdate;
            this.PreviousInstance.pnlDefault.Controls.Add(ControlEmployeeEditUserInstance);
            this.ControlEmployeeEditUserInstance.BringToFront();
            this.ControlEmployeeEditUserInstance.UpdateNewUser();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            this.CurrentRowUser = this.dgvShowAllUsers.CurrentRow.Cells["id"].Value.ToString();

            if (this.CurrentRowUser != "u101")
            {
                this.Sql = @"DELETE FROM userlogin WHERE id ='" + this.CurrentRowUser + "';";
                int count = this.Da.ExecuteUpdateQuery(Sql);
                this.PopulateGridViewShowAllUsers();
                if (count == 1)
                {
                    MessageBox.Show("Successful.");
                }
            }
            else
            {
                MessageBox.Show("Master user cannot be DELETED.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            this.Sql = @"select * from userlogin where username like '" + this.txtSearchUser.Text + "%';";
            this.PopulateGridViewShowAllUsers(Sql);

            if (this.txtSearchUser.Text == "")
            {
                this.PopulateGridViewShowAllUsers();
            }
        }
    }
}
