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
    public partial class FormEmployee : Form
    {
        internal FormLogIn PreviousFormInstance { get; set; }
        internal ContorlEmployeeNewCart NewCart { get; set; }
        internal ControlEmployeeNewProduct NewProduct { get; set; }
        internal ControlEmployeeShowAllProducts ShowProducts { get; set; }
        internal ClassDataAccess Da { get; set; }
        internal DataSet Ds { get; set; }
        internal string Sql { get; set; }
        internal string UserName { get; set; }
        internal string Quantity { get; set; }

        public FormEmployee()
        {
            InitializeComponent();
            this.Da = new ClassDataAccess();
        }

        public FormEmployee(FormLogIn instance, string userName)
        {
            InitializeComponent();
            this.PreviousFormInstance = instance;
            this.UserName = userName;

            this.Da = new ClassDataAccess();

            this.NewProduct = new ControlEmployeeNewProduct();
            this.ShowProducts = new ControlEmployeeShowAllProducts(this);

            string firstUpper = this.FirstLetterToUpper(this.UserName);
            this.txtUserName.Text = firstUpper;
        }

        public string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        private void PopulateGridView(string sql = "select * from userlogin;")
        {
            this.Ds = this.Da.ExecuteQuery(sql);
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {

            this.NewCart = new ContorlEmployeeNewCart(this);
            this.pnlDefault.Controls.Add(NewCart);

            this.Sql = @"DELETE FROM checkout_cart WHERE product_id LIKE '%%';";
            this.Ds = this.Da.ExecuteQuery(Sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.PreviousFormInstance.Visible = true;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.pnlDefault.Controls.Add(this.NewCart);
            this.NewCart.PopulateGridViewNewCart();
            this.NewCart.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pnlAnalytics_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlDashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            this.pnlDefault.Controls.Add(NewProduct);
            this.NewProduct.MakeFieldsEmpty();
            this.NewProduct.BringToFront();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.pnlDefault.Controls.Add(ShowProducts);
            this.ShowProducts.PopulateGridViewShowAllProducts();
            this.ShowProducts.BringToFront();
        }

        internal void MakeVisibleShowProducts()
        {
            this.pnlDefault.Controls.Add(ShowProducts);
            this.ShowProducts.BringToFront();
            this.ShowProducts.PopulateGridViewShowAllProducts("select * from product_roster;");
        }

        private void FormEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
