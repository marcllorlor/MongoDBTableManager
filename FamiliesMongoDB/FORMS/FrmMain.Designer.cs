namespace FamiliesMongoDB
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnu_main = new System.Windows.Forms.MenuStrip();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connexióBDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sortirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.famíliesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finestresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ciclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnu_main
            // 
            this.mnu_main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnu_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem,
            this.dadesToolStripMenuItem,
            this.finestresToolStripMenuItem});
            this.mnu_main.Location = new System.Drawing.Point(0, 0);
            this.mnu_main.MdiWindowListItem = this.finestresToolStripMenuItem;
            this.mnu_main.Name = "mnu_main";
            this.mnu_main.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.mnu_main.Size = new System.Drawing.Size(1479, 28);
            this.mnu_main.TabIndex = 12;
            this.mnu_main.Text = "menuStrip1";
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connexióBDToolStripMenuItem,
            this.toolStripSeparator1,
            this.sortirToolStripMenuItem});
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.generalToolStripMenuItem.Text = "General";
            // 
            // connexióBDToolStripMenuItem
            // 
            this.connexióBDToolStripMenuItem.Name = "connexióBDToolStripMenuItem";
            this.connexióBDToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.connexióBDToolStripMenuItem.Text = "Connexió BD";
            this.connexióBDToolStripMenuItem.Click += new System.EventHandler(this.connexióBDToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // sortirToolStripMenuItem
            // 
            this.sortirToolStripMenuItem.Name = "sortirToolStripMenuItem";
            this.sortirToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.sortirToolStripMenuItem.Text = "Sortir";
            this.sortirToolStripMenuItem.Click += new System.EventHandler(this.sortirToolStripMenuItem_Click);
            // 
            // dadesToolStripMenuItem
            // 
            this.dadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.famíliesToolStripMenuItem,
            this.ciclesToolStripMenuItem});
            this.dadesToolStripMenuItem.Name = "dadesToolStripMenuItem";
            this.dadesToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.dadesToolStripMenuItem.Text = "&Dades";
            // 
            // famíliesToolStripMenuItem
            // 
            this.famíliesToolStripMenuItem.Name = "famíliesToolStripMenuItem";
            this.famíliesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.famíliesToolStripMenuItem.Text = "Famílies";
            this.famíliesToolStripMenuItem.Click += new System.EventHandler(this.famíliesToolStripMenuItem_Click);
            // 
            // finestresToolStripMenuItem
            // 
            this.finestresToolStripMenuItem.Name = "finestresToolStripMenuItem";
            this.finestresToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.finestresToolStripMenuItem.Text = "Finestres";
            // 
            // ciclesToolStripMenuItem
            // 
            this.ciclesToolStripMenuItem.Name = "ciclesToolStripMenuItem";
            this.ciclesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ciclesToolStripMenuItem.Text = "Cicles";
            this.ciclesToolStripMenuItem.Click += new System.EventHandler(this.ciclesToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1479, 710);
            this.Controls.Add(this.mnu_main);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.Text = "Gestió de Cicles Formatius";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.mnu_main.ResumeLayout(false);
            this.mnu_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnu_main;
        private System.Windows.Forms.ToolStripMenuItem dadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem famíliesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connexióBDToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sortirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finestresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ciclesToolStripMenuItem;
    }
}

