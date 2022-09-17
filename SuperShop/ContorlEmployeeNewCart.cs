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
    public partial class ContorlEmployeeNewCart : UserControl
    {
        internal ClassDataAccess Da { get; set; }
        internal DataSet Ds { get; set; }
        internal string Sql { get; set; }
        internal string Quantity { get; set; }
        internal ContorlEmployeeCheckout newCustomerCheckout { get; set; }

        FormEmployee EmployeeFormInstance { set; get; }

        public ContorlEmployeeNewCart(FormEmployee employeeFormInstanceParameter)
        {
            InitializeComponent();
            this.Da = new ClassDataAccess();
            this.EmployeeFormInstance = employeeFormInstanceParameter;
            this.PopulateGridViewNewCart();
            this.newCustomerCheckout = new ContorlEmployeeCheckout(this.EmployeeFormInstance);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.EmployeeFormInstance.pnlDefault.Controls.Add(this.newCustomerCheckout);
            this.newCustomerCheckout.BringToFront();

            this.txtSearchProduct.Text = "";
        }

        internal void PopulateGridViewNewCart(string sql = "select * from product_roster;")
        {
            this.Ds = this.Da.ExecuteQuery(sql);

            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.DataSource = this.Ds.Tables[0];
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            this.Sql = @"select * from product_roster where product_name like '" + this.txtSearchProduct.Text + "%';";
            this.PopulateGridViewNewCart(Sql);

            if (this.txtSearchProduct.Text == "")
            {
                this.PopulateGridViewNewCart();
            }
        }

        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
            this.lblAvailable.Text = "";
            this.lblTransferSuccessful.Text = "";
            this.btnTransferToCart.Enabled = false;

            this.txtProductName.Text = dgvProducts.CurrentRow.Cells["product_name"].Value.ToString();
            this.txtUnitPrice.Text = dgvProducts.CurrentRow.Cells["per_unit_price"].Value.ToString();

            this.Quantity = dgvProducts.CurrentRow.Cells["quantity"].Value.ToString();
        }

        private void txtProvideQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtProvideQuantity.Text == "")
                {
                    this.txtTotalPrice.Text = "";
                }
                else
                {
                    double totalPrice = Convert.ToDouble(dgvProducts.CurrentRow.Cells["per_unit_price"].Value) * Convert.ToDouble(this.txtProvideQuantity.Text);
                    this.txtTotalPrice.Text = totalPrice.ToString();
                }
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc);
                MessageBox.Show("Please enter numeric value only as quantity.");
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.lblAvailable.Text = "";
            this.lblTransferSuccessful.Text = "";
            
            if (this.txtProvideQuantity.Text != "")
            {
                double availableQuantity = Convert.ToDouble(this.Quantity);
                double requiredQuantity = Convert.ToDouble(this.txtProvideQuantity.Text);
                if (requiredQuantity <= availableQuantity)
                {
                    this.btnTransferToCart.Enabled = true;
                    this.lblAvailable.Text = "Product available.";
                }
                else
                    MessageBox.Show("Out of stock, amount not available.");
            }
            else
            {
                MessageBox.Show("Please enter the quantity of the product.");
            }
        }

        private void btnTransferToCart_Click(object sender, EventArgs e)
        {
            if(this.txtProductName.Text != "" && this.txtProvideQuantity.Text != "" && this.txtUnitPrice.Text != "" && this.txtTotalPrice.Text != "")
            {
                this.btnTransferToCart.Enabled = false;
                this.lblProductTransfer.Text = this.txtProductName.Text;

                try
                {
                    this.Sql = @"select * from product_roster where product_name = '" + this.txtProductName.Text + "';";
                    this.Ds = this.Da.ExecuteQuery(Sql);

                    string productId = Ds.Tables[0].Rows[0][0].ToString();

                    this.Sql = @"insert into checkout_cart values ('" + productId + "','" + this.txtProductName.Text + "'," +
                           this.txtProvideQuantity.Text + "," + this.txtUnitPrice.Text + ",'" + this.txtTotalPrice.Text + "');";

                    int count = this.Da.ExecuteUpdateQuery(this.Sql);

                    if (count == 1)
                    {
                        this.lblTransferSuccessful.Text = "Transfer complete.";
                        this.txtProductName.Text = "";
                        this.txtProvideQuantity.Text = "";
                        this.txtUnitPrice.Text = "";
                        this.txtTotalPrice.Text = "";
                    }

                    else
                        MessageBox.Show("Error while inserting data");
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message);
                }
            }
        }

        private void ContorlEmployeeNewCart_Load(object sender, EventArgs e)
        {
            this.dgvProducts.ClearSelection();
            this.dgvProducts.Refresh();
        }
    }
}
