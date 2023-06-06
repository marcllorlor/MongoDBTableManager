using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace FamiliesMongoDB
{
    public partial class FrmBD : Form
    {
        public FrmBD()
        {
            InitializeComponent();
        }

        private void FrmBD_Load(object sender, EventArgs e)
        {
            tbCadena.Text = ((FrmMain)this.MdiParent).cadenaConn;
            tbNomBD.Text= ((FrmMain)this.MdiParent).nomBD;
        }

        private void btNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            StreamWriter fcfg;

            if (((FrmMain) this.MdiParent).obrirConnexio(tbCadena.Text.Trim(),tbNomBD.Text.Trim()))
            {
                fcfg=new StreamWriter(((FrmMain)this.MdiParent).nomFitxerCfg,false);
                fcfg.WriteLine(tbCadena.Text.Trim());
                fcfg.WriteLine(tbNomBD.Text.Trim());
                fcfg.Close();
                ((FrmMain)this.MdiParent).opcionsMenuGestio(true);
                this.Close();
            } else
            {
                MessageBox.Show("No hi ha connexió amb la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((FrmMain)this.MdiParent).opcionsMenuGestio(false);
            }
        }
    }
}

