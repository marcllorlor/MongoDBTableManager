using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamiliesMongoDB.FORMS
{
    public partial class FrmAMCicles : Form
    {
        public char operacio = ' ';
        public FrmCicles frmPare;
        public Boolean hanfetOK = false;

        private DataSet DsetFamilies = new DataSet();

        public FrmAMCicles()
        {
            InitializeComponent();
        }

        private void FrmAMCicles_Load(object sender, EventArgs e)
        {
            tbId.Enabled = (operacio == 'A');
            if (operacio == 'M')
            {
                tbId.Text = frmPare.ctrlCicle.idCicle;
                tbNom.Text = frmPare.ctrlCicle.nomCicle;
            }
            getdadesFamilia();
            afegirvalorscombox();
            
        }

        private void getdadesFamilia()
        {
            
            if (!frmPare.ctrlFamilia.modelAccessible())
            {
                MessageBox.Show("No hi ha accés a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DsetFamilies.Clear();
            frmPare.ctrlFamilia.llistaXnomFamilies(ref DsetFamilies);
        }

        private void afegirvalorscombox()
        {
            cbNomFamilia.DataSource = DsetFamilies.Tables[0];
            cbNomFamilia.DisplayMember = "nomFamilia";
            cbNomFamilia.ValueMember = "idFamilia";


            //Selected Item et donara el nom que has seleccionat
            //I EL SELECTED VALUE ET DONARA LA ID
        }

        private void btNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            frmPare.ctrlCicle.idCicle = tbId.Text.Trim();
            frmPare.ctrlCicle.nomCicle = tbNom.Text.Trim();

            //Aqui hauriem de posar el valor del combobox
            frmPare.ctrlCicle.idFamilia = cbNomFamilia.SelectedValue.ToString();
            switch (operacio)
            {
                case 'A':
                    hanfetOK = frmPare.ctrlCicle.nouCicle();
                    break;
                case 'M':
                    hanfetOK = frmPare.ctrlCicle.modificarCicle();
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
