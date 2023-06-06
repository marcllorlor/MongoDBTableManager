namespace FamiliesMongoDB.FORMS
{
    partial class FrmCicles
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btDel = new System.Windows.Forms.Button();
            this.btNou = new System.Windows.Forms.Button();
            this.dgCicles = new System.Windows.Forms.DataGridView();
            this.lbhdr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgCicles)).BeginInit();
            this.SuspendLayout();
            // 
            // btDel
            // 
            this.btDel.BackColor = System.Drawing.Color.Transparent;
            this.btDel.FlatAppearance.BorderSize = 0;
            this.btDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDel.ForeColor = System.Drawing.Color.White;
            this.btDel.Image = global::FamiliesMongoDB.Properties.Resources.icons8_cancel_50;
            this.btDel.Location = new System.Drawing.Point(519, 488);
            this.btDel.Margin = new System.Windows.Forms.Padding(4);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(75, 70);
            this.btDel.TabIndex = 10;
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
            this.btNou.Location = new System.Drawing.Point(519, 425);
            this.btNou.Margin = new System.Windows.Forms.Padding(4);
            this.btNou.Name = "btNou";
            this.btNou.Size = new System.Drawing.Size(75, 70);
            this.btNou.TabIndex = 9;
            this.btNou.UseVisualStyleBackColor = false;
            this.btNou.Click += new System.EventHandler(this.btNou_Click);
            // 
            // dgCicles
            // 
            this.dgCicles.AllowUserToAddRows = false;
            this.dgCicles.AllowUserToDeleteRows = false;
            this.dgCicles.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dgCicles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgCicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCicles.Location = new System.Drawing.Point(13, 51);
            this.dgCicles.Margin = new System.Windows.Forms.Padding(4);
            this.dgCicles.MultiSelect = false;
            this.dgCicles.Name = "dgCicles";
            this.dgCicles.ReadOnly = true;
            this.dgCicles.RowHeadersVisible = false;
            this.dgCicles.RowHeadersWidth = 51;
            this.dgCicles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCicles.Size = new System.Drawing.Size(498, 507);
            this.dgCicles.TabIndex = 7;
            this.dgCicles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCP_CellDoubleClick);
            // 
            // lbhdr
            // 
            this.lbhdr.AutoSize = true;
            this.lbhdr.BackColor = System.Drawing.Color.Orange;
            this.lbhdr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbhdr.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbhdr.Location = new System.Drawing.Point(13, 19);
            this.lbhdr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbhdr.MinimumSize = new System.Drawing.Size(500, 2);
            this.lbhdr.Name = "lbhdr";
            this.lbhdr.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lbhdr.Size = new System.Drawing.Size(500, 34);
            this.lbhdr.TabIndex = 8;
            this.lbhdr.Text = "Cicles";
            this.lbhdr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmCicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 666);
            this.Controls.Add(this.btDel);
            this.Controls.Add(this.btNou);
            this.Controls.Add(this.dgCicles);
            this.Controls.Add(this.lbhdr);
            this.Name = "FrmCicles";
            this.Text = "FrmCicles";
            this.Load += new System.EventHandler(this.FrmCicles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCicles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Button btNou;
        private System.Windows.Forms.DataGridView dgCicles;
        private System.Windows.Forms.Label lbhdr;
    }
}