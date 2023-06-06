namespace FamiliesMongoDB
{
    partial class FrmFamilies
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgFamilies = new System.Windows.Forms.DataGridView();
            this.lbhdr = new System.Windows.Forms.Label();
            this.btDel = new System.Windows.Forms.Button();
            this.btNou = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgFamilies)).BeginInit();
            this.SuspendLayout();
            // 
            // dgFamilies
            // 
            this.dgFamilies.AllowUserToAddRows = false;
            this.dgFamilies.AllowUserToDeleteRows = false;
            this.dgFamilies.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgFamilies.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgFamilies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFamilies.Location = new System.Drawing.Point(18, 44);
            this.dgFamilies.Margin = new System.Windows.Forms.Padding(4);
            this.dgFamilies.MultiSelect = false;
            this.dgFamilies.Name = "dgFamilies";
            this.dgFamilies.ReadOnly = true;
            this.dgFamilies.RowHeadersVisible = false;
            this.dgFamilies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFamilies.Size = new System.Drawing.Size(498, 507);
            this.dgFamilies.TabIndex = 1;
            this.dgFamilies.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCP_CellDoubleClick);
            // 
            // lbhdr
            // 
            this.lbhdr.AutoSize = true;
            this.lbhdr.BackColor = System.Drawing.Color.Orange;
            this.lbhdr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbhdr.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbhdr.Location = new System.Drawing.Point(18, 12);
            this.lbhdr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbhdr.MinimumSize = new System.Drawing.Size(500, 2);
            this.lbhdr.Name = "lbhdr";
            this.lbhdr.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lbhdr.Size = new System.Drawing.Size(500, 30);
            this.lbhdr.TabIndex = 1;
            this.lbhdr.Text = "famílies";
            this.lbhdr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btDel
            // 
            this.btDel.BackColor = System.Drawing.Color.Transparent;
            this.btDel.FlatAppearance.BorderSize = 0;
            this.btDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDel.ForeColor = System.Drawing.Color.White;
            this.btDel.Image = global::FamiliesMongoDB.Properties.Resources.icons8_cancel_50;
            this.btDel.Location = new System.Drawing.Point(524, 481);
            this.btDel.Margin = new System.Windows.Forms.Padding(4);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(75, 70);
            this.btDel.TabIndex = 6;
            this.btDel.UseVisualStyleBackColor = false;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btNou
            // 
            this.btNou.BackColor = System.Drawing.Color.Transparent;
            this.btNou.FlatAppearance.BorderSize = 0;
            this.btNou.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNou.ForeColor = System.Drawing.Color.Transparent;
            this.btNou.Image = global::FamiliesMongoDB.Properties.Resources.icons8_plus_50;
            this.btNou.Location = new System.Drawing.Point(524, 418);
            this.btNou.Margin = new System.Windows.Forms.Padding(4);
            this.btNou.Name = "btNou";
            this.btNou.Size = new System.Drawing.Size(75, 70);
            this.btNou.TabIndex = 5;
            this.btNou.UseVisualStyleBackColor = false;
            this.btNou.Click += new System.EventHandler(this.btNou_Click);
            // 
            // FrmFamilies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 564);
            this.Controls.Add(this.btDel);
            this.Controls.Add(this.btNou);
            this.Controls.Add(this.dgFamilies);
            this.Controls.Add(this.lbhdr);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmFamilies";
            this.Text = "Famílies";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgFamilies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgFamilies;
        private System.Windows.Forms.Label lbhdr;
        private System.Windows.Forms.Button btNou;
        private System.Windows.Forms.Button btDel;
    }
}