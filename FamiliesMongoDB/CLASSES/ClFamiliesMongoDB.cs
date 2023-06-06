using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;

namespace CLASSES
{
    public class ClFamiliesMongoDB
    {
        private ClBDMongoDB bd = null;                     // referència a la BD
        public Boolean bdaccessible = false;
        public String idFamilia { get; set; }
        public String nomFamilia { get; set; }

        private string NomColeccio = "Families";

        // constructor
        public ClFamiliesMongoDB(String connexio, String nomBD)
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

        // destructor
        ~ClFamiliesMongoDB()
        {
        }

        // altres mètodes
        public Boolean existeixFamilia()
        {
            FilterDefinition<BsonDocument> filtre;

            filtre = Builders<BsonDocument>.Filter.Eq("_idFamilia", idFamilia); //Aqui creem el filtre,  per aixo posem Filter.Eq
            return ((Int32)bd.ConsultaQuants(NomColeccio, filtre) > 0);
        }

        public Boolean getFamilia()
        {
            Boolean xb = false;
            List<BsonDocument> lldocs = new List<BsonDocument>();
            FilterDefinition<BsonDocument> filtre; //Aqui definim el filtre

            filtre = Builders<BsonDocument>.Filter.Eq("_idFamilia", idFamilia); //Aqui tornem a crear el filtre de idfamilia
            bd.Consulta(NomColeccio, filtre, ref lldocs); //Aixo es el mateix que fem al sql que li pasem el dataset per referencia
            if (lldocs.Count > 0)
            {
                nomFamilia = lldocs[0]["_nomFamilia"].ToString(); //Aixo es el mateix que si pillem les dades del dataset
                xb = true;
            }
            return (xb);
        }

        public Boolean novaFamilia()
        {
            Boolean xb = false;
            BsonDocument doc; //Aqui creem el format json per inserir les dades

            doc = new BsonDocument
                    {
                        { "_idFamilia" , idFamilia }, //Aqui creem les dades
                        { "_nomFamilia" , nomFamilia } //Aqui creem les dades
                    };
            xb = bd.InserirDades(NomColeccio, doc);
            return (xb);
        }

        public Boolean modificarFamilia()
        {
            BsonDocument doc;
            FilterDefinition<BsonDocument> filtre;

            filtre = Builders<BsonDocument>.Filter.Eq("_idFamilia", idFamilia);
            doc = new BsonDocument
                        {
                            { "_idFamilia" , idFamilia },
                            { "_nomFamilia" , nomFamilia }
                        };
            return (bd.ModificarDades(NomColeccio, filtre, doc));
        }

        public Boolean suprimirFamilia()
        {
            FilterDefinition<BsonDocument> filtre;

            filtre = Builders<BsonDocument>.Filter.Eq("_idFamilia", idFamilia);

            return (bd.SuprimirDades(NomColeccio, filtre));
        }

        public Boolean llistaFamilies(ref DataSet dset, int n)
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
                    filtreSort = Builders<BsonDocument>.Sort.Ascending("_nomFamilia");
                    bd.ConsultaOrdenada(NomColeccio, filtreSort, ref lldocs);
                    break;

            }

            dset = new DataSet();
            dset.Tables.Add();
            dset.Tables[0].Columns.Add("idFamilia");
            dset.Tables[0].Columns.Add("nomFamilia");
            foreach (BsonDocument doc in lldocs)
            {
                dset.Tables[0].Rows.Add(doc["_idFamilia"].ToString(), doc["_nomFamilia"].ToString());
            }
            return (lldocs.Count > 0);
        }

        public int quantesFamiliesXprefix(String xprefix)
        {
            List<BsonDocument> lldocs = new List<BsonDocument>();
            FilterDefinition<BsonDocument> filtre;

            filtre = Builders<BsonDocument>.Filter.Eq("_nomFamilia", xprefix);
            return ((Int32)bd.ConsultaQuants(NomColeccio, filtre));
        }
    }
}
