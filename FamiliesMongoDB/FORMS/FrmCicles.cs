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

namespace FamiliesMongoDB.FORMS
{
    public partial class FrmCicles : Form
    {
        public ClCicles ctrlCicle;                // utilitzem aquesta propietat per a facilitar la comunicació entre la connexió a la BD que hem fet al FrmMain i aquest Form
        public ClFamilies ctrlFamilia; //Amb aixo veurem quines families tenim disponibles
        
        private DataSet dset = new DataSet(); //Aqui fem la declaracio del dataset que farem servir per conseguir les dades del Cicle
        private DataSet dsetFamilies = new DataSet(); //Aqui fem la declaracio del dataset per conseguir les dades de la Familia

        

        
        public FrmCicles()
        {
            InitializeComponent();
        }

        private void FrmCicles_Load(object sender, EventArgs e)
        {
            getDades(); //Aqui recollim les dades de Cicles
            getDadesFamilies(); //Aqui recollim les dades de Families

            iniDgrid(); //Aqui posem el nom del header Text del DataGridView (la graella del form per mostrar les dades)

            
        }

        private void getDadesFamilies()
        {
            if (!ctrlFamilia.modelAccessible())
            {
                MessageBox.Show("No hi ha accés a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dsetFamilies.Clear(); //Abans de passarli el dsetfamilies per omplir les dades , el buidarem
            ctrlFamilia.llistaXnomFamilies(ref dsetFamilies); //Aqui llistem les dades de Families a dins de DataSet 
        }

        private void iniDgrid()
        {
            Graphics g = this.CreateGraphics();

            //Aqui estem posant el nom dels valors a les capçeleres del datagridview

            dgCicles.Columns[0].HeaderText = "id Cicle"; 
            dgCicles.Columns[1].HeaderText = "nom Cicle";
            dgCicles.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //Quan fem aixo es per adaptar la casella al contingut del text
            dgCicles.Columns[2].HeaderText = "id Familia";
            dgCicles.Columns[2].Visible = false; //El posem a invisible, encara que tenim el valor, el posem a invisible
            dgCicles.Columns[3].HeaderText = "nom Familia";
            dgCicles.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void getDades()
        {
            if (!ctrlCicle.modelAccessible())
            {
                MessageBox.Show("No hi ha accés a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dset.Clear();
            ctrlCicle.llistaXnomCicles(ref dset); //Aqui agafem les dades dels Cicle i el posem al dataset dset
            
            dgCicles.AutoResizeColumns();
            dset.Tables[0].Columns.Add("Nom Familia"); //Afegim una columna al Dataset, llavors quedaria aixi:
            //IDCICLES | NOMCICLE | IDFAMILIA | NOMFAMILIA
            // PHP     |  Llengua GON | PAPA  | PATATA

            //Aqui hem de fer la part
            foreach(DataRow fila in dset.Tables[0].Rows) //Per cada fila de informacio que ens retorni el dataset families fara una volta al bucle
            {
                ctrlFamilia.idFamilia = fila[2].ToString(); //Primer li passem la id al control 
                ctrlFamilia.getFamilia(); //Aqui fem la funcio de get familia per cada familia
                fila["Nom Familia"] = ctrlFamilia.nomFamilia; //I aqui com que tenim la variable nomfamilia a dins, sinolement la pillem
            }
            dgCicles.DataSource = dset.Tables[0];
        }

        private void btNou_Click(object sender, EventArgs e)
        {
            FrmAMCicles frm = new FrmAMCicles();

            frm.frmPare = this;
            frm.Text = "Alta d'una nova família";
            frm.operacio = 'A';
            ctrlCicle.idCicle = "";
            ctrlCicle.nomCicle = "";
            ctrlCicle.idFamilia = "";
            frm.ShowDialog();
            if (frm.hanfetOK)
            {
                getDades();

                // apliquem LINQ per a trobar al DataGridView la fila on és la familia que s'acaba d'inserir
                var quinaFila = from DataGridViewRow fila in dgCicles.Rows
                                where fila.Cells["idCicle"].Value.ToString().Trim() == ctrlCicle.idCicle
                                select fila.Index;

                dgCicles.Rows[quinaFila.First()].Selected = true;
            }
            frm = null;
            GC.Collect();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (dgCicles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Cal seleccionar una fila", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ctrlCicle.idCicle = dgCicles.SelectedRows[0].Cells["idCicle"].Value.ToString().Trim();
                if (ctrlCicle.suprimirCicle())
                {
                    getDades();
                    //Aqui hauriem d'assegorarnos que
                    if (dgCicles.Rows.Count != 0)
                    {
                        dgCicles.Rows[0].Selected = true;
                    }
                }
            }
        }

        private void dgCP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 quinafila = 0;
            FrmAMCicles frm;

            if (dgCicles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Cal seleccionar una fila", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                quinafila = dgCicles.SelectedRows[0].Index;
                frm = new FrmAMCicles();
                frm.frmPare = this;
                frm.Text = "Modificar una família";
                frm.operacio = 'M';
                ctrlCicle.idCicle = dgCicles.SelectedRows[0].Cells["idCicle"].Value.ToString();
                ctrlCicle.getCicle();
                frm.ShowDialog();
                if (frm.hanfetOK)
                {
                    getDades();
                }
                dgCicles.Rows[quinafila].Selected = true;
                frm = null;
                GC.Collect();
            }
        }
    }
}
