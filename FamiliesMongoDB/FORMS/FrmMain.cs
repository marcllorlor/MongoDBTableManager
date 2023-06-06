using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLASSES;
using FamiliesMongoDB.CLASSES;
using FamiliesMongoDB.FORMS;

namespace FamiliesMongoDB
{
    public partial class FrmMain : Form
    {
        public String nomFitxerCfg = "CFGBD.TXT";
        public String cadenaConn = "";
        public String nomBD = "";

        public ClFamilies ctrlFamilia = null;
        public ClCicles ctrlCicle = null;

        private DataSet dset = new DataSet();

        private Boolean esticSortint = false;
        private FrmBD frmBD;

        private FrmFamilies frmFam = null;
        private FrmCicles frmCic = null;
        public FrmMain()
        {
            InitializeComponent();
        }

        private Boolean jaObert(Form xform)
        {
            int n = 0;
            Boolean xb = false;

            while ((!xb) && (n < this.MdiChildren.Count()))
            {
                xb = (this.MdiChildren[n] == xform);
                n++;
            }
            return (xb);
        }

        private void famíliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
                 if ((frmFam == null) || (!jaObert(frmFam)))
                {
                    frmFam = new FrmFamilies();
                    frmFam.MdiParent = this;
                    frmFam.ctrlFamilia = ctrlFamilia;
                }
                frmFam.Show();
        }

        private void connexióBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(jaObert(frmBD)))
            {
                frmBD = new FrmBD();
                frmBD.MdiParent = this;           
            }
            frmBD.WindowState = FormWindowState.Normal;
            frmBD.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            StreamReader fcfg;

            if (File.Exists(nomFitxerCfg))
            {
                fcfg = new StreamReader(nomFitxerCfg);
                cadenaConn = fcfg.ReadLine().Trim();
                nomBD = fcfg.ReadLine().Trim();
                fcfg.Close();
                opcionsMenuGestio(obrirConnexio(cadenaConn, nomBD));
            }
            else
            {
                cadenaConn = "";
                nomBD = "";
                opcionsMenuGestio(false);
            }
        }

        public Boolean obrirConnexio(String xconn, String xbd)
        {
            Boolean xb = false;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ctrlFamilia = new ClFamilies(xconn, xbd);
                if (ctrlFamilia.modelAccessible())
                {
                    ctrlCicle = new ClCicles(xconn, xbd);
                    if (ctrlCicle.modelAccessible())
                    {
                        xb = true;
                    }
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
            return (xb);
        }

        public void opcionsMenuGestio(Boolean xb)
        {
            dadesToolStripMenuItem.Enabled = xb;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!esticSortint)
            {
                if (MessageBox.Show("Segur que vols sortir?", "Finalitzar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void sortirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Segur que vols sortir?", "Finalitzar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                esticSortint = true;
                this.Close();
            }
        }

        private void ciclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((frmCic == null) || (!jaObert(frmCic)))
            {
                frmCic = new FrmCicles();
                frmCic.MdiParent = this;
                frmCic.ctrlCicle = ctrlCicle;
                frmCic.ctrlFamilia = ctrlFamilia;
            }
            frmCic.Show();
        }
    }
    }
