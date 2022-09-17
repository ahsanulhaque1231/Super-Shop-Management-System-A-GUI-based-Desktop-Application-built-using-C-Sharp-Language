using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShop
{
    public partial class FormLogIn : Form
    {
        internal FormEmployee Ef { get; set; }
        internal FormManager Mf { get; set; }
        internal ClassDataAccess Da { get; set; }
        internal DataSet Ds { get; set; }
        internal string Sql { get; set; }

        public FormLogIn()
        {
            InitializeComponent();
            this.Da = new ClassDataAccess();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string query = @"select * from userlogin where id = '" + this.txtId.Text + "' and password = '" + this.txtPassword.Text + "';";

            this.Ds = Da.ExecuteQuery(query);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                if (Ds.Tables[0].Rows[0]["usertype"].ToString() == "manager")
                {
                    FormManager managerForm = new FormManager(this, Ds.Tables[0].Rows[0]["username"].ToString());
                    this.Visible = false;
                    managerForm.Visible = true;
                }
                else if (Ds.Tables[0].Rows[0]["usertype"].ToString() == "salesman")
                {
                    FormEmployee employeForm = new FormEmployee(this, Ds.Tables[0].Rows[0]["username"].ToString());
                    this.Visible = false;
                    employeForm.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Wrong credentials.");
            }

            this.txtId.Text = "";
            this.txtPassword.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtId.Text = "";
            this.txtPassword.Text = "";
        }
    }
}
