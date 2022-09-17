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
    public partial class ControlEmployeeShowAllProducts : UserControl
    {
        internal ClassDataAccess Da { get; set; }
        internal DataSet Ds { get; set; }
        internal string Sql { get; set; }
        internal string ProductToUpdate { get; set; }
        internal ControlEmployeeEditProduct ControlEditProduct { get; set; }
        internal FormEmployee PreviousInstance { get; set; }

        public ControlEmployeeShowAllProducts(FormEmployee previousInstance)
        {
            InitializeComponent();
            this.Da = new ClassDataAccess();
            this.PopulateGridViewShowAllProducts();
            this.PreviousInstance = previousInstance;
            this.ControlEditProduct = new ControlEmployeeEditProduct(PreviousInstance);
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            this.Sql = @"select * from product_roster where product_name like '" + this.txtSearchProduct.Text + "%';";
            this.PopulateGridViewShowAllProducts(Sql);

            if (this.txtSearchProduct.Text == "")
            {
                this.PopulateGridViewShowAllProducts();
            }
        }

        internal void PopulateGridViewShowAllProducts(string sql = "select * from product_roster;")
        {
            this.Ds = this.Da.ExecuteQuery(sql);

            this.dgvShowAllProducts.AutoGenerateColumns = false;
            this.dgvShowAllProducts.DataSource = this.Ds.Tables[0];

        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            this.ProductToUpdate = this.dgvShowAllProducts.CurrentRow.Cells["product_name"].Value.ToString();
            this.Sql = @"select * from product_roster where product_name = '" + ProductToUpdate + "';";
            this.Ds = this.Da.ExecuteQuery(Sql);

            if (Ds.Tables[0].Rows.Count == 1)
            {
                string productIdToDelete = Ds.Tables[0].Rows[0]["product_id"].ToString();
                this.Sql = @"DELETE FROM product_roster WHERE product_id ='"+ productIdToDelete + "';";
                this.Da.ExecuteUpdateQuery(Sql);
                this.PopulateGridViewShowAllProducts();
                MessageBox.Show("Product delete was successful.");
            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            this.ProductToUpdate = this.dgvShowAllProducts.CurrentRow.Cells["product_name"].Value.ToString();
            this.ControlEditProduct.ProductToUpdate = this.ProductToUpdate;
            this.PreviousInstance.pnlDefault.Controls.Add(ControlEditProduct);
            this.ControlEditProduct.BringToFront();
            this.ControlEditProduct.UpdateNewProduct();
        }

        private void dgvShowAllProducts_DoubleClick(object sender, EventArgs e)
        {
            this.ProductToUpdate = this.dgvShowAllProducts.CurrentRow.Cells["product_name"].Value.ToString();
            this.ControlEditProduct.ProductToUpdate = this.ProductToUpdate;
            MessageBox.Show("Product selected --> " + ProductToUpdate);
        }

        private void ControlEmployeeShowAllProducts_Load(object sender, EventArgs e)
        {
            //  this.PopulateGridViewShowAllProducts();
        }
    }
}
