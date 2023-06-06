using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamiliesMongoDB
{
    public partial class FrmAMFamilies : Form
    {
        public char operacio = ' ';
        public FrmFamilies frmPare;
        public Boolean hanfetOK = false;            // ens indicarà si s'ha tancat aquest Form amb el botó OK o amb un altre

        public FrmAMFamilies()
        {
            InitializeComponent();
        }

        private void FrmAMFamilies_Load(object sender, EventArgs e)
        {
            tbId.Enabled = (operacio == 'A');
            if (operacio=='M')
            {
                tbId.Text = frmPare.ctrlFamilia.idFamilia;
                tbNom.Text = frmPare.ctrlFamilia.nomFamilia;
            }
        }

        private void btNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            frmPare.ctrlFamilia.idFamilia = tbId.Text.Trim();
            frmPare.ctrlFamilia.nomFamilia = tbNom.Text.Trim();
            switch (operacio)
            {
                case 'A':
                    hanfetOK=frmPare.ctrlFamilia.novaFamilia();
                    break;
                case 'M':
                    hanfetOK=frmPare.ctrlFamilia.modificarFamilia();
                    break;
                default: break;
            }
            if (hanfetOK)
            {
                this.Close();
            }
        }
    }
}
