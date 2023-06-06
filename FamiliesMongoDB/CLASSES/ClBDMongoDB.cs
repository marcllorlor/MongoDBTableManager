using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CLASSES
{
    public class ClBDMongoDB
    {
        private String cadenaConnexio;
        private String nomBD;
        private IMongoClient mgClient; //Aquest es el client que es connecta al servidor
        private IMongoDatabase mgDatabase; //Aixo es el mateix que el SlqConnnection

        // constructor
        public ClBDMongoDB(String xconnexio)
        {
            cadenaConnexio = xconnexio;
        }

        // destructor
        ~ClBDMongoDB()
        {
        }

        public Boolean Connectar()
        {
            Boolean xb = true;

            try
            {
                mgClient = new MongoClient(cadenaConnexio);
            }
            catch
            {
                xb = false;
            }

            return (xb);
        }

        public Boolean Desconnectar()
        {
            Boolean xb = true;

            cadenaConnexio = "";
            mgClient = null;
            return (xb);
        }

        public Boolean ObrirBD(String xnomBD)
        {
            Boolean xb = true;

            if (xnomBD != nomBD)
            {
                xb = validarConnexio(xnomBD);
                nomBD = xnomBD;
                mgDatabase = mgClient.GetDatabase(nomBD);
            }
            return (xb);
        }

        public Boolean TancarBD()
        {
            Boolean xb = true;

            try
            {
                nomBD = "";
            }
            catch (Exception excp)
            {
                xb = false;
                MessageBox.Show(excp.Message, "Excepció", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return (xb);
        }

        public Boolean EstaOberta()
        {
            return (validarConnexio(nomBD));
        }

        public void Consulta(string xnomcoleccio, FilterDefinition<BsonDocument> xfiltre, ref List<BsonDocument> lldocs)
        {
            IMongoCollection<BsonDocument> colecc;

            try
            {
                colecc = mgDatabase.GetCollection<BsonDocument>(xnomcoleccio);
                lldocs = colecc.Find(xfiltre).ToList();
            }
            catch
            {
                lldocs = null;
            }
        }

        public void ConsultaOrdenada(string xnomcoleccio, SortDefinition<BsonDocument> xsort, ref List<BsonDocument> lldocs)
        {
            IMongoCollection<BsonDocument> colecc;

            try
            {
                colecc = mgDatabase.GetCollection<BsonDocument>(xnomcoleccio);
                lldocs = colecc.Find(FilterDefinition<BsonDocument>.Empty).Sort(xsort).ToList();
            }
            catch
            {
                lldocs = null;
            }
        }

        public Int64 ConsultaQuants(string xnomcoleccio, FilterDefinition<BsonDocument> xfiltre)
        {
            List<BsonDocument> lldocs = null; //Aqui dekcarem una llista de documents bson buits, que aqui es a on posarem les dades de la consulta
            IMongoCollection<BsonDocument> colecc;
            Int64 res;

            try
            {
                colecc = mgDatabase.GetCollection<BsonDocument>(xnomcoleccio); //Aqui conseguim totes les daes de la taula
                lldocs = colecc.Find(xfiltre).ToList(); //Aqui apliquem el filtre que hem buscat
                res = lldocs.Count; //Aqui fem un count de valors que tingui la llista i retornarem aquestu numero
            }
            catch
            {
                res = 0; //Si no es pot fer la consulta saltara el catch
            }
            return (res);
        }

        public Boolean InserirDades(string xnomcoleccio, BsonDocument doc)
        {
            Boolean xb = true;
            IMongoCollection<BsonDocument> colecc;

            try
            {
                colecc = mgDatabase.GetCollection<BsonDocument>(xnomcoleccio);
                var accio = colecc.InsertOneAsync(doc);
                accio.Wait();
            }
            catch
            {
                xb = false;
            }
            return (xb);
        }

        public Boolean ModificarDades(string xnomcoleccio, FilterDefinition<BsonDocument> xfiltre, BsonDocument doc)
        {
            Boolean xb = true;
            IMongoCollection<BsonDocument> colecc;

            try
            {
                colecc = mgDatabase.GetCollection<BsonDocument>(xnomcoleccio);
                colecc.FindOneAndReplace(xfiltre, doc);
            }
            catch
            {
                xb = false;
            }
            return (xb);
        }


        public Boolean SuprimirDades(string xnomcoleccio, FilterDefinition<BsonDocument> xfiltre)
        {
            Boolean xb = true;
            IMongoCollection<BsonDocument> colecc;

            try
            {
                colecc = mgDatabase.GetCollection<BsonDocument>(xnomcoleccio);
                colecc.FindOneAndDelete(xfiltre);
            }
            catch
            {
                xb = false;
            }
            return (xb);
        }

        private bool validarConnexio(String xnomBD)
        {
            bool xb = false;
            int x = 0;

            try
            {
                var mgCursor = mgClient.ListDatabasesAsync();
                mgCursor.Wait();

                using (mgCursor.Result)
                {
                    if (mgCursor.Result.MoveNextAsync().Result)
                    {
                        x = 0;
                        var doc = mgCursor.Result.Current.GetEnumerator();
                        doc.MoveNext();
                        while ((!xb) && (x < mgCursor.Result.Current.Count()))
                        {
                            x++;
                            xb = (doc.Current["name"].ToString() == xnomBD);
                            doc.MoveNext();
                        }
                    }
                }
            }
            catch
            {
            }
            return (xb);
        }
    }
}
