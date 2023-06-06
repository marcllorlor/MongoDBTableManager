namespace FamiliesMongoDB
{
    partial class FrmBD
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
            this.lbCadena = new System.Windows.Forms.Label();
            this.tbCadena = new System.Windows.Forms.TextBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btNo = new System.Windows.Forms.Button();
            this.tbNomBD = new System.Windows.Forms.TextBox();
            this.lbNomBD = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbCadena
            // 
            this.lbCadena.AutoSize = true;
            this.lbCadena.Location = new System.Drawing.Point(20, 24);
            this.lbCadena.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCadena.Name = "lbCadena";
            this.lbCadena.Size = new System.Drawing.Size(136, 14);
            this.lbCadena.TabIndex = 0;
            this.lbCadena.Text = "Cadena de connexió";
            // 
            // tbCadena
            // 
            this.tbCadena.Location = new System.Drawing.Point(23, 42);
            this.tbCadena.Name = "tbCadena";
            this.tbCadena.Size = new System.Drawing.Size(737, 22);
            this.tbCadena.TabIndex = 1;
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.Green;
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOK.ForeColor = System.Drawing.Color.White;
            this.btOK.Location = new System.Drawing.Point(290, 144);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(107, 34);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "&Acceptar";
            this.btOK.UseVisualStyleBackColor = false;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btNo
            // 
            this.btNo.BackColor = System.Drawing.Color.Red;
            this.btNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNo.ForeColor = System.Drawing.Color.White;
            this.btNo.Location = new System.Drawing.Point(420, 144);
            this.btNo.Name = "btNo";
            this.btNo.Size = new System.Drawing.Size(107, 34);
            this.btNo.TabIndex = 3;
            this.btNo.Text = "&Cancel·lar";
            this.btNo.UseVisualStyleBackColor = false;
            this.btNo.Click += new System.EventHandler(this.btNo_Click);
            // 
            // tbNomBD
            // 
            this.tbNomBD.Location = new System.Drawing.Point(26, 98);
            this.tbNomBD.Name = "tbNomBD";
            this.tbNomBD.Size = new System.Drawing.Size(196, 22);
            this.tbNomBD.TabIndex = 5;
            // 
            // lbNomBD
            // 
            this.lbNomBD.AutoSize = true;
            this.lbNomBD.Location = new System.Drawing.Point(23, 80);
            this.lbNomBD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNomBD.Name = "lbNomBD";
            this.lbNomBD.Size = new System.Drawing.Size(134, 14);
            this.lbNomBD.TabIndex = 4;
            this.lbNomBD.Text = "Nom Base de Dades";
            // 
            // FrmBD
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btNo;
            this.ClientSize = new System.Drawing.Size(786, 200);
            this.ControlBox = false;
            this.Controls.Add(this.tbNomBD);
            this.Controls.Add(this.lbNomBD);
            this.Controls.Add(this.btNo);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.tbCadena);
            this.Controls.Add(this.lbCadena);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmBD";
            this.Text = "Connexió amb la base de dades";
            this.Load += new System.EventHandler(this.FrmBD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCadena;
        private System.Windows.Forms.TextBox tbCadena;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btNo;
        private System.Windows.Forms.TextBox tbNomBD;
        private System.Windows.Forms.Label lbNomBD;
    }
}