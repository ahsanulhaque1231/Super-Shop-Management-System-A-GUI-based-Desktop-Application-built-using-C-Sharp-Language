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
    public partial class ControlEmployeeEditProduct : UserControl
    {
        internal ClassDataAccess Da { get; set; }
        internal DataSet Ds { get; set; }
        internal string Sql { get; set; }
        internal string ProductToUpdate { get; set; }
        internal FormEmployee PreviousInstance { get; set; }
        public ControlEmployeeEditProduct(FormEmployee previousInstance)
        {
            InitializeComponent();
            this.Da = new ClassDataAccess();
            this.PreviousInstance = previousInstance;
        }

        private void ControlEmployeeEditProduct_Load(object sender, EventArgs e)
        {
            
        }

        internal void UpdateNewProduct()
        {
            this.Sql = @"select * from product_roster where product_name = '" + this.ProductToUpdate + "';";
            this.Ds = Da.ExecuteQuery(Sql);
            if (Ds.Tables[0].Rows.Count == 1)
            {
                this.txtProductName.Text = Ds.Tables[0].Rows[0]["product_name"].ToString();
                this.txtQuantityAvailable.Text = Ds.Tables[0].Rows[0]["quantity"].ToString();
                this.txtMeasurementUnit.Text = Ds.Tables[0].Rows[0]["measurement_unit"].ToString();
                this.txtSupplier.Text = Ds.Tables[0].Rows[0]["supplier"].ToString();
                this.txtProductPricePerUnit.Text = Ds.Tables[0].Rows[0]["per_unit_price"].ToString();
                this.txtProductId.Text = Ds.Tables[0].Rows[0]["product_id"].ToString();
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtProductName.Text != "" && this.txtQuantityAvailable.Text != "" && this.txtMeasurementUnit.Text != "" && this.txtSupplier.Text != "" && this.txtProductPricePerUnit.Text != "" && this.txtProductId.Text != "")
                {
                    this.Sql = @"UPDATE product_roster SET product_name = '" + this.txtProductName.Text + "', quantity = " + this.txtQuantityAvailable.Text + ", measurement_unit = '" + this.txtMeasurementUnit.Text + "', supplier = '" + this.txtSupplier.Text + "', per_unit_price = " + this.txtProductPricePerUnit.Text + " WHERE product_id='" + this.txtProductId.Text + "';";
                    int updateInt = Da.ExecuteUpdateQuery(this.Sql);
                    if (updateInt > 0)
                    {
                        MessageBox.Show("Successful.");
                    }
                    this.PreviousInstance.MakeVisibleShowProducts();
                }
                else
                {
                    MessageBox.Show("Please fillup all the fields.");
                }
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc);
                MessageBox.Show("Please enter the values properly.");
            }
        }
    }
}
