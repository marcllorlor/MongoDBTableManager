using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLASSES;
using FamiliesMongoDB.CLASSES;

namespace FamiliesMongoDB
{
    public partial class FrmFamilies : Form
    {
        public ClFamilies ctrlFamilia;                // utilitzem aquesta propietat per a facilitar la comunicació entre la connexió a la BD que hem fet al FrmMain i aquest Form
        private DataSet dset = new DataSet();

        public FrmFamilies()
        {
            InitializeComponent();
        }


        private void FrmMain_Load(object sender, EventArgs e)
        {
            getDades();
            iniDgrid();
        }

        private void iniDgrid()
        {
            Graphics g = this.CreateGraphics();

            dgFamilies.Columns[0].HeaderText = "id.";
            dgFamilies.Columns[1].HeaderText = "nom família";
            dgFamilies.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void getDades()
        {
            if (!ctrlFamilia.modelAccessible())
            {
                MessageBox.Show("No hi ha accés a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dset.Clear();
            ctrlFamilia.llistaXnomFamilies(ref dset);
            dgFamilies.DataSource = dset.Tables[0];
            dgFamilies.AutoResizeColumns();
        }

        private void btNou_Click(object sender, EventArgs e)
        {
            FrmAMFamilies frm = new FrmAMFamilies();

            frm.frmPare = this;
            frm.Text = "Alta d'una nova família";
            frm.operacio = 'A';
            ctrlFamilia.idFamilia = "";
            ctrlFamilia.nomFamilia = "";
            frm.ShowDialog();
            if (frm.hanfetOK)
            {
                getDades();

                // apliquem LINQ per a trobar al DataGridView la fila on és la familia que s'acaba d'inserir
                var quinaFila = from DataGridViewRow fila in dgFamilies.Rows
                                where fila.Cells["idFamilia"].Value.ToString().Trim() == ctrlFamilia.idFamilia
                                select fila.Index;

                dgFamilies.Rows[quinaFila.First()].Selected = true;
            }
            frm = null;
            GC.Collect();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (dgFamilies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Cal seleccionar una fila", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ctrlFamilia.idFamilia = dgFamilies.SelectedRows[0].Cells["idFamilia"].Value.ToString().Trim();
                if (ctrlFamilia.suprimirFamilia())
                {
                    getDades();
                    if (dgFamilies.Rows.Count != 0)
                    {
                        dgFamilies.Rows[0].Selected = true;
                    }
                }
            }
        }

        private void dgCP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 quinafila = 0;
            FrmAMFamilies frm;

            if (dgFamilies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Cal seleccionar una fila", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                quinafila = dgFamilies.SelectedRows[0].Index;
                frm = new FrmAMFamilies();
                frm.frmPare = this;
                frm.Text = "Modificar una família";
                frm.operacio = 'M';
                ctrlFamilia.idFamilia = dgFamilies.SelectedRows[0].Cells["idFamilia"].Value.ToString();
                ctrlFamilia.getFamilia();
                frm.ShowDialog();
                if (frm.hanfetOK)
                {
                    getDades();
                }
                dgFamilies.Rows[quinafila].Selected = true;
                frm = null;
                GC.Collect();
            }
        }
    }
}
