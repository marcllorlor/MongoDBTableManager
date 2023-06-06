using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLASSES;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FamiliesMongoDB.CLASSES
{
    public class ClCiclesMongoDB
    {
        private ClBDMongoDB bd = null;                     // referència a la BD
        public Boolean bdaccessible = false;
        public String idCicle { get; set; }
        public String nomCicle { get; set; }

        public String idFamilia { get; set; }

        private string NomColeccio = "Cicles";

        public ClCiclesMongoDB(String connexio, String nomBD)
        {
            bd = new ClBDMongoDB(connexio);
            if (bd.Connectar())
            {
                if (bd.ObrirBD(nomBD))
                {
                    bdaccessible = true;
                }
            }
            if (!bdaccessible)
            {
                bd = null;
            }
        }

        ~ClCiclesMongoDB()
        {

        }

        public Boolean existeixCicle()
        {
            FilterDefinition<BsonDocument> filtre;

            filtre = Builders<BsonDocument>.Filter.Eq("_idCicle", idCicle); //Aqui creem el filtre,  per aixo posem Filter.Eq
            return ((Int32)bd.ConsultaQuants(NomColeccio, filtre) > 0);
        }

        public Boolean getCicle()
        {
            Boolean xb = false;
            List<BsonDocument> lldocs = new List<BsonDocument>(); //Aquest és l'equivalent a DataSet a SQL
            FilterDefinition<BsonDocument> filtre; //Aqui definim el filtre

            filtre = Builders<BsonDocument>.Filter.Eq("_idCicle", idCicle); //Aqui tornem a crear el filtre de idfamilia
            bd.Consulta(NomColeccio, filtre, ref lldocs); //Aixo es el mateix que fem al sql que li pasem el dataset per referencia
            if (lldocs.Count > 0)
            {
                nomCicle = lldocs[0]["_nomCicle"].ToString(); //Aixo es el mateix que si pillem les dades del dataset
                idFamilia = lldocs[0]["_idFamilia"].ToString();
                xb = true;
            }
            return (xb);
        }

        public Boolean nouCicle()
        {
            Boolean xb = false;
            BsonDocument doc; //Aqui creem el format json per inserir les dades

            doc = new BsonDocument
                    {
                        { "_idCicle" , idCicle }, //Aqui creem les dades
                        { "_nomCicle" , nomCicle }, //Aqui creem les dades
                        {"_idFamilia", idFamilia }
                    };
            xb = bd.InserirDades(NomColeccio, doc);
            return (xb);
        }

        public Boolean modificarCicle()
        {
            BsonDocument doc;
            FilterDefinition<BsonDocument> filtre;

            filtre = Builders<BsonDocument>.Filter.Eq("_idCicle", idCicle);
            doc = new BsonDocument
                        {
                            { "_idCicle" , idCicle },
                            { "_nomCicle" , nomCicle },
                            {"_idFamilia", idFamilia }
                        };
            return (bd.ModificarDades(NomColeccio, filtre, doc));
        }

        public Boolean suprimirCicle()
        {
            FilterDefinition<BsonDocument> filtre;

            filtre = Builders<BsonDocument>.Filter.Eq("_idCicle", idCicle);

            return (bd.SuprimirDades(NomColeccio, filtre));
        }

        public Boolean llistaCicles(ref DataSet dset, int n)
        {
            // Per a poder mantenir la classes Controlador sense canvis excessius aquest mètode retornarà un DataSet
            // que caldrà construir a partir de la llista de documents obtinguts al cridar el mètode Consulta de la classe ClBDMongoDB
            //
            List<BsonDocument> lldocs = new List<BsonDocument>();
            FilterDefinition<BsonDocument> filtre;
            SortDefinition<BsonDocument> filtreSort;

            filtre = Builders<BsonDocument>.Filter.Empty;
            switch (n)
            {
                case 0:
                    bd.Consulta(NomColeccio, filtre, ref lldocs);
                    break;
                case 1:
                    filtreSort = Builders<BsonDocument>.Sort.Ascending("_nomCicle");
                    bd.ConsultaOrdenada(NomColeccio, filtreSort, ref lldocs);
                    break;

            }

            dset = new DataSet();
            dset.Tables.Add();
            dset.Tables[0].Columns.Add("idCicle");
            dset.Tables[0].Columns.Add("nomCicle");
            dset.Tables[0].Columns.Add("idFamilia");
            //dset.Tables[0].Columns.Add("nomFamilia");
            foreach (BsonDocument doc in lldocs)
            {
                dset.Tables[0].Rows.Add(doc["_idCicle"].ToString(), doc["_nomCicle"].ToString(), doc["_idFamilia"].ToString());
            }
            return (lldocs.Count > 0);
        }

        public int quantsCiclesXprefix(String xprefix)
        {
            List<BsonDocument> lldocs = new List<BsonDocument>();
            FilterDefinition<BsonDocument> filtre;

            filtre = Builders<BsonDocument>.Filter.Eq("_nomCicle", xprefix);
            return ((Int32)bd.ConsultaQuants(NomColeccio, filtre));
        }
    }
}
