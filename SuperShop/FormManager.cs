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
    public partial class FormManager : Form
    {
        internal ControlManagerShowAllUsers ControlShowAllUsers { get; set; }
        internal ControlManagerNewUser ControlNewUser { get; set; }
        internal ControlManagerShowAllUsers ShowUsers { get; set; }
        internal string UserName { get; set; }
        internal string Quantity { get; set; }
        public FormLogIn PreviousFormInstance { get; set; }
        internal ClassDataAccess Da { get; set; }
        internal DataSet Ds { get; set; }
        internal string Sql { get; set; }

        public FormManager()
        {
            InitializeComponent();
        }

        public FormManager(FormLogIn instance, string userName)
        {
            InitializeComponent();
            this.PreviousFormInstance = instance;
            this.UserName = userName;
            this.Da = new ClassDataAccess();
            string firstUpper = this.FirstLetterToUpper(this.UserName);
            this.txtUserName.Text = firstUpper;

            this.ShowUsers = new ControlManagerShowAllUsers(this);
            this.ControlNewUser = new ControlManagerNewUser(this);
        }

        public string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {

            this.ControlShowAllUsers = new ControlManagerShowAllUsers(this);
            this.pnlDefault.Controls.Add(ControlShowAllUsers);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.PreviousFormInstance.Visible = true;
        }

        internal void MakeVisibleShowUsers()
        {
            this.pnlDefault.Controls.Add(ShowUsers);
            this.ShowUsers.BringToFront();
            this.ShowUsers.PopulateGridViewShowAllUsers("select * from userlogin;");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.pnlDefault.Controls.Add(ShowUsers);
            this.ShowUsers.PopulateGridViewShowAllUsers();
            this.ShowUsers.BringToFront();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            this.pnlDefault.Controls.Add(ControlNewUser);
            this.ControlNewUser.AutoIdGenerate();
            this.ControlNewUser.BringToFront();
            this.ControlNewUser.setAutoId();
        }

        private void FormManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
