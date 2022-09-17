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
    public partial class ContorlEmployeeCheckout : UserControl
    {
        internal ClassDataAccess Da { get; set; }
        internal DataSet Ds { get; set; }
        internal string Sql { get; set; }
        internal FormEmployee EmployeeFormInstance { set; get; }

        public ContorlEmployeeCheckout(FormEmployee employeeFormInstanceParameter)
        {
            InitializeComponent();
            this.EmployeeFormInstance = employeeFormInstanceParameter;
            this.Da = new ClassDataAccess();
        }

        private void ContorlEmployeeCheckout_Load(object sender, EventArgs e)
        {
            this.PopulateGridCheckoutCart();

            this.Sql = @"SELECT Sum(total_cost) AS Total FROM checkout_cart;";
            this.Ds = this.Da.ExecuteQuery(Sql);
            this.txtNetPayable.Text = Ds.Tables[0].Rows[0][0].ToString() + "  taka";
        }

        private void PopulateGridCheckoutCart(string sql = "select * from checkout_cart;")
        {
            this.Ds = this.Da.ExecuteQuery(sql);

            this.dgvCheckoutTable.AutoGenerateColumns = false;
            this.dgvCheckoutTable.DataSource = this.Ds.Tables[0];

            //this.dgvMovie.ClearSelection();
            //this.dgvMovie.Refresh();
        }

        private void btnPaymentComplete_Click(object sender, EventArgs e)
        {
            this.Sql = "select * from checkout_cart;";
            this.Ds = this.Da.ExecuteQuery(Sql);
            int loop = Ds.Tables[0].Rows.Count;

            int count = 0;
            while (count < loop)
            {
                this.Sql = "select * from checkout_cart;";
                this.Ds = this.Da.ExecuteQuery(Sql);
                string paymentProductId = Ds.Tables[0].Rows[count]["product_id"].ToString();
                string paymentProductQuantity = Ds.Tables[0].Rows[count]["purchase_unit"].ToString();


                this.Sql = "select * from product_roster WHERE product_id='" + paymentProductId + "';";
                this.Ds = this.Da.ExecuteQuery(Sql);
                string paymentProductPreviousQuantity = Ds.Tables[0].Rows[0]["quantity"].ToString();
                string paymentProductNewQuantity = (Convert.ToDouble(paymentProductPreviousQuantity) - Convert.ToDouble(paymentProductQuantity)).ToString();

                this.Sql = @"UPDATE product_roster SET quantity = " + paymentProductNewQuantity + " WHERE product_id='" + paymentProductId + "';";
                Da.ExecuteUpdateQuery(Sql);
                count++;

            }

            this.Sql = @"DELETE FROM checkout_cart WHERE product_id LIKE '%%';";
            this.Ds = this.Da.ExecuteQuery(Sql);
            this.PopulateGridCheckoutCart();
            this.txtNetPayable.Text = "";

            EmployeeFormInstance.NewCart.PopulateGridViewNewCart();
            this.EmployeeFormInstance.NewCart.BringToFront();
        }
    }
}
