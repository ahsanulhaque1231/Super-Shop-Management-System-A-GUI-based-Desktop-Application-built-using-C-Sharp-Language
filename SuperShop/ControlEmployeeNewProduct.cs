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
    public partial class ControlEmployeeNewProduct : UserControl
    {
        internal ClassDataAccess Da { get; set; }
        internal DataSet Ds { get; set; }
        internal string Sql { get; set; }
        internal string TableProductName { get; set; }
        internal string AutoIdValue { get; set; }

        public ControlEmployeeNewProduct()
        {
            InitializeComponent();
            this.Da = new ClassDataAccess();
        }

        private void AutoIdGenerate()
        {
            string sql = "select product_id from product_roster order by product_id desc;";
            DataTable dt = this.Da.ExecuteQueryTable(sql);
            string previousId = dt.Rows[0][0].ToString();
            string[] temp = previousId.Split('p');
            int serialNo = Convert.ToInt32(temp[1]);
            string nextId = "p" + (++serialNo).ToString("000");
            this.AutoIdValue = nextId;
        }

        private void txtProvideQuantity_TextChanged(object sender, EventArgs e)
        {
            if (this.txtProductName.Text == "")
            {
                this.dgvNewProductTable.DataSource = null;
            }
            else
            {
                this.Sql = @"select * from product_roster where product_name like '" + this.txtProductName.Text + "%';";
                this.PopulateGridViewExistingProduct(Sql);
            }
        }

        private void PopulateGridViewExistingProduct(string sql = "select * from product_roster;")
        {
            this.Ds = this.Da.ExecuteQuery(sql);

            this.dgvNewProductTable.AutoGenerateColumns = false;
            this.dgvNewProductTable.DataSource = this.Ds.Tables[0];

            //this.dgvMovie.ClearSelection();
            //this.dgvMovie.Refresh();
        }

        private void dgvNewProductTable_DoubleClick(object sender, EventArgs e)
        {
            this.TableProductName = this.dgvNewProductTable.CurrentRow.Cells["product_name"].Value.ToString();

            this.Sql = "select * from product_roster where product_name = '" + this.TableProductName + "';";
            this.Ds = Da.ExecuteQuery(Sql);

            this.txtProductName.Text = Ds.Tables[0].Rows[0]["product_name"].ToString();
            this.txtMeasurementUnit.Text = Ds.Tables[0].Rows[0]["measurement_unit"].ToString();
            this.txtSupplier.Text = Ds.Tables[0].Rows[0]["supplier"].ToString();
            this.txtProductPricePerUnit.Text = Ds.Tables[0].Rows[0]["per_unit_price"].ToString();

            this.txtShipmentQuantity.Text = "";
            this.txtTotalPayableToTheSupplier.Text = "";
        }

        private void txtShipmentQuantity_TextChanged(object sender, EventArgs e)
        {
            try{
                if (this.txtProductPricePerUnit.Text != "")
                {
                    this.txtTotalPayableToTheSupplier.Text = (Convert.ToDouble(this.txtShipmentQuantity.Text) * Convert.ToDouble(this.txtProductPricePerUnit.Text)).ToString();
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                MessageBox.Show("Error. Please fillup all the values correctly.");
            }
        }

        private void btnEnlistProductShipment_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.txtTotalPayableToTheSupplier.Text != "")
                {
                    this.Sql = "select * from product_roster where product_name = '" + this.txtProductName.Text + "';";
                    this.Ds = Da.ExecuteQuery(Sql);
                    if (Ds.Tables[0].Rows.Count == 1)
                    {
                        string currentProductsId = Ds.Tables[0].Rows[0]["product_id"].ToString();
                        string currentProductsQuantity = Ds.Tables[0].Rows[0]["quantity"].ToString();
                        string updateQuantity = (Convert.ToDouble(currentProductsQuantity) + Convert.ToDouble(this.txtShipmentQuantity.Text)).ToString();
                        string updateSql = "UPDATE product_roster SET quantity = " + updateQuantity + " WHERE product_id = '" + currentProductsId + "';";
                        int upInfo = Da.ExecuteUpdateQuery(updateSql);

                        if (upInfo > 0)
                        {
                            MessageBox.Show("Complete.");
                        }
                    }
                    else
                    {
                        this.AutoIdGenerate();
                        this.Sql = @"INSERT INTO product_roster VALUES('" + this.AutoIdValue + "', '" + this.txtProductName.Text + "', " + this.txtShipmentQuantity.Text + ", '" + this.txtMeasurementUnit.Text + "', '" + this.txtSupplier.Text + "', " + this.txtProductPricePerUnit.Text + ");";
                        int productInsert = this.Da.ExecuteUpdateQuery(this.Sql);

                        if (productInsert > 0)
                        {
                            MessageBox.Show("INSERT Complete.");
                        }
                    }

                    this.txtMeasurementUnit.Text = "";
                    this.txtProductName.Text = "";
                    this.txtProductPricePerUnit.Text = "";
                    this.txtShipmentQuantity.Text = "";
                    this.txtSupplier.Text = "";
                    this.txtTotalPayableToTheSupplier.Text = "";
                }
                else
                {
                    MessageBox.Show("Please enter the values correctly.");
                }
                
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc);
                MessageBox.Show("Error. Please fillup all the values correctly.");
            }
            
        }

        internal void MakeFieldsEmpty()
        {
            this.txtMeasurementUnit.Text = "";
            this.txtProductName.Text = "";
            this.txtProductPricePerUnit.Text = "";
            this.txtShipmentQuantity.Text = "";
            this.txtSupplier.Text = "";
            this.txtTotalPayableToTheSupplier.Text = "";
        }

        //private void txtProductPricePerUnit_TextChanged(object sender, EventArgs e)
        //{
        //    // Calculate 
        //    //if (this.txtProductPricePerUnit.Text != "")
        //    //{
        //    //    this.txtTotalPayableToTheSupplier.Text = (Convert.ToDouble(this.txtShipmentQuantity.Text) * Convert.ToDouble(this.txtProductPricePerUnit.Text)).ToString();
        //    //}
        //}

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtTotalPayableToTheSupplier.Text = (Convert.ToDouble(this.txtShipmentQuantity.Text) * Convert.ToDouble(this.txtProductPricePerUnit.Text)).ToString();
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc);
                MessageBox.Show("Enter the numeric values properly.");
            }
        }
    }
}
