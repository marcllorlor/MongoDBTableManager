using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLASSES
{
    public class ClFamilies
    {
        private ClFamiliesMongoDB model = null;
        public String idFamilia { get; set; }
        public String nomFamilia { get; set; }

        // constructor
        public ClFamilies(String cadenaConnexio, String nomBD)
        {
            this.model = new ClFamiliesMongoDB(cadenaConnexio, nomBD);
            if (!model.bdaccessible)
            {
                model = null;
            }
        }

        // destructor
        ~ClFamilies()
        {
        }

        public Boolean modelAccessible()
        {
            return (model != null);
        }

        public Boolean novaFamilia()
        {
            Boolean xb = false;

            if (verificarId(idFamilia.Trim()))
            {
                if (nomFamilia.Trim() == "")
                {
                    MessageBox.Show("S'ha d'introduir el nom de la família", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    model.idFamilia = idFamilia;
                    if (model.existeixFamilia())
                    {
                        MessageBox.Show("Aquesta família ja existeix a la BD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        model.nomFamilia = arreglarString(nomFamilia);
                        xb = model.novaFamilia();
                    }
                }
            }
            return (xb);
        }

        public Boolean modificarFamilia()
        {
            Boolean xb = false;

            model.idFamilia = idFamilia;
            if (!model.existeixFamilia())
            {
                MessageBox.Show("No existeix aquesta família a la BD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (nomFamilia.Trim() == "")
                {
                    MessageBox.Show("S'ha d'introduir el nom de la família", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    model.idFamilia = idFamilia;
                    model.nomFamilia = arreglarString(nomFamilia);
                    xb = model.modificarFamilia();
                }

            }
            return (xb);
        }

        public Boolean suprimirFamilia()
        {
            Boolean xb = false;

            model.idFamilia = idFamilia;
            if (!model.existeixFamilia())
            {
                MessageBox.Show("No existeix aquesta família a la BD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Segur que vols eliminar la família " + idFamilia + "?", "Qüestió", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    xb = model.suprimirFamilia();
                }
            }
            return (xb);
        }

        public Boolean getFamilia()
        {
            Boolean xb = false;

            model.idFamilia = idFamilia;
            if (model.getFamilia())
            {
                nomFamilia = model.nomFamilia;
                xb = true;
            }
            return (xb);
        }

        public Boolean existeixFamilia()
        {
            model.idFamilia = idFamilia;
            return (model.existeixFamilia());
        }

        public void llistaFamilies(ref DataSet dset)
        {
            model.llistaFamilies(ref dset, 0);
        }

        public void llistaXnomFamilies(ref DataSet dset)
        {
            model.llistaFamilies(ref dset, 1);
        }

        public Int32 quantesFamiliesXprefix(String xprefix)
        {
            return ((Int32)model.quantesFamiliesXprefix(xprefix));
        }

        private Boolean verificarId(String xid)
        {
            Int32 x = 0;
            Boolean xb = false;

            xb = ((xid.Length >= 3) && (xid.Length <= 5));
            if (!xb)
            {
                MessageBox.Show("L'identificador ha de ser d'entre 3 i 5 caràcters", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                while ((x < xid.Length) && (xb))
                {
                    xb = Char.IsUpper(xid.Substring(x, 1)[0]);
                    x++;
                }
                if (!xb)
                {
                    MessageBox.Show("L'identificador només pot contenir lletres majúscules", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return (xb);
        }


        private String arreglarString(String xs)
        {
            String xs1 = "";

            //xs1 = xs.Replace("'", "''");
            xs1 = xs;
            return (xs1);
        }
    }
}
