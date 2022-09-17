
namespace SuperShop
{
    partial class ContorlEmployeeCheckout
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvCheckoutTable = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchase_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNetPayable = new System.Windows.Forms.Label();
            this.txtNetPayable = new System.Windows.Forms.TextBox();
            this.btnPaymentComplete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckoutTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(541, 125);
            this.panel3.TabIndex = 14;
            // 
            // dgvCheckoutTable
            // 
            this.dgvCheckoutTable.AllowUserToAddRows = false;
            this.dgvCheckoutTable.AllowUserToDeleteRows = false;
            this.dgvCheckoutTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Garamond", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCheckoutTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCheckoutTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckoutTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.purchase_unit,
            this.total_cost});
            this.dgvCheckoutTable.Location = new System.Drawing.Point(3, 134);
            this.dgvCheckoutTable.Name = "dgvCheckoutTable";
            this.dgvCheckoutTable.ReadOnly = true;
            this.dgvCheckoutTable.RowHeadersWidth = 51;
            this.dgvCheckoutTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheckoutTable.Size = new System.Drawing.Size(550, 134);
            this.dgvCheckoutTable.TabIndex = 15;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "product_name";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Garamond", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn1.HeaderText = "Product Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // purchase_unit
            // 
            this.purchase_unit.DataPropertyName = "purchase_unit";
            this.purchase_unit.HeaderText = "Unit";
            this.purchase_unit.Name = "purchase_unit";
            this.purchase_unit.ReadOnly = true;
            // 
            // total_cost
            // 
            this.total_cost.DataPropertyName = "total_cost";
            this.total_cost.HeaderText = "Full price for the product";
            this.total_cost.Name = "total_cost";
            this.total_cost.ReadOnly = true;
            // 
            // lblNetPayable
            // 
            this.lblNetPayable.AutoSize = true;
            this.lblNetPayable.BackColor = System.Drawing.Color.Transparent;
            this.lblNetPayable.Font = new System.Drawing.Font("Garamond", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetPayable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNetPayable.Location = new System.Drawing.Point(448, 314);
            this.lblNetPayable.Name = "lblNetPayable";
            this.lblNetPayable.Size = new System.Drawing.Size(76, 14);
            this.lblNetPayable.TabIndex = 17;
            this.lblNetPayable.Text = "Net payable ";
            // 
            // txtNetPayable
            // 
            this.txtNetPayable.Enabled = false;
            this.txtNetPayable.Location = new System.Drawing.Point(449, 291);
            this.txtNetPayable.Name = "txtNetPayable";
            this.txtNetPayable.Size = new System.Drawing.Size(104, 20);
            this.txtNetPayable.TabIndex = 16;
            // 
            // btnPaymentComplete
            // 
            this.btnPaymentComplete.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaymentComplete.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnPaymentComplete.Location = new System.Drawing.Point(380, 367);
            this.btnPaymentComplete.Name = "btnPaymentComplete";
            this.btnPaymentComplete.Size = new System.Drawing.Size(175, 33);
            this.btnPaymentComplete.TabIndex = 20;
            this.btnPaymentComplete.Text = "Payment complete";
            this.btnPaymentComplete.UseVisualStyleBackColor = true;
            this.btnPaymentComplete.Click += new System.EventHandler(this.btnPaymentComplete_Click);
            // 
            // ContorlEmployeeCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPaymentComplete);
            this.Controls.Add(this.lblNetPayable);
            this.Controls.Add(this.txtNetPayable);
            this.Controls.Add(this.dgvCheckoutTable);
            this.Controls.Add(this.panel3);
            this.Name = "ContorlEmployeeCheckout";
            this.Size = new System.Drawing.Size(555, 455);
            this.Load += new System.EventHandler(this.ContorlEmployeeCheckout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckoutTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvCheckoutTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchase_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_cost;
        private System.Windows.Forms.Label lblNetPayable;
        private System.Windows.Forms.TextBox txtNetPayable;
        private System.Windows.Forms.Button btnPaymentComplete;
    }
}
