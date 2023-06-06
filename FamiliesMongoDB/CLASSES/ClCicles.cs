using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLASSES;

namespace FamiliesMongoDB.CLASSES
{
    public class ClCicles
    {
        private ClCiclesMongoDB model = null;
        public String idCicle { get; set; }
        public String nomCicle { get; set; }
        public String idFamilia { get; set; }

        public ClCicles(String cadenaConnexio, String nomBD)
        {
            this.model = new ClCiclesMongoDB(cadenaConnexio, nomBD);
            if (!model.bdaccessible)
            {
                model = null;
            }
        }

        ~ClCicles()
        {

        }

        public Boolean modelAccessible()
        {
            return (model != null);
        }

        public Boolean nouCicle()
        {
            Boolean xb = false;

            if (verificarId(idCicle.Trim()))
            {
                if (nomCicle.Trim() == "")
                {
                    MessageBox.Show("S'ha d'introduir el nom del cicle", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    model.idCicle = idCicle;
                    if (model.existeixCicle())
                    {
                        MessageBox.Show("Aquest Cicle ja existeix a la BD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        model.nomCicle = arreglarString(nomCicle);
                        model.idFamilia = idFamilia;
                        xb = model.nouCicle();
                    }
                }
            }
            return (xb);
        }

        public Boolean modificarCicle()
        {
            Boolean xb = false;

            model.idCicle = idCicle;
            if (!model.existeixCicle())
            {
                MessageBox.Show("No existeix aquest Cicle a la BD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (nomCicle.Trim() == "")
                {
                    MessageBox.Show("S'ha d'introduir el nom del Cicle", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    model.idCicle = idCicle;
                    model.nomCicle = arreglarString(nomCicle);
                    model.idFamilia = idFamilia;
                    xb = model.modificarCicle();
                }

            }
            return (xb);
        }

        public Boolean suprimirCicle()
        {
            Boolean xb = false;

            model.idCicle = idCicle;
            if (!model.existeixCicle())
            {
                MessageBox.Show("No existeix aquest Cicle a la BD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Segur que vols eliminar el Cicle " + idCicle + "?", "Qüestió", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    xb = model.suprimirCicle();
                }
            }
            return (xb);
        }

        public Boolean getCicle()
        {
            Boolean xb = false;

            model.idCicle = idCicle;
            if (model.getCicle())
            {
                nomCicle = model.nomCicle;
                idFamilia = model.idFamilia;
                xb = true;
            }
            return (xb);
        }

        public Boolean existeixCicle()
        {
            model.idCicle = idCicle;
            return (model.existeixCicle());
        }

        public void llistaCicles(ref DataSet dset)
        {
            model.llistaCicles(ref dset, 0);
        }

        public void llistaXnomCicles(ref DataSet dset)
        {
            model.llistaCicles(ref dset, 1);
        }

        public Int32 quantsCiclesXprefix(String xprefix)
        {
            return ((Int32)model.quantsCiclesXprefix(xprefix));
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
