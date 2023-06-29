using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Drawing;

namespace GestionePrezzi
{
   
    public class DataAccess
    {
          

        public List<Prodotto> GetProdotti(string nomeProdotto) {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))

            {
                List<String> parole = new List<String>();
                String querySQL = $"select * from Prodotti where Nome_prodotto like ";
                parole = nomeProdotto.Split(' ').ToList();
                int counter = 0; 

                if (parole.Count > 1)
                {
                    foreach (String s in parole)
                    {
                        String newS = s;

                        if (s.Contains("'")){ 
                            newS = s.Replace("'", "''");
                            Console.WriteLine("string s modify -> : " + newS);
                        }

                        if (counter == 0)
                            querySQL = querySQL + "'%" + newS + "%'";
                        else querySQL = querySQL + " AND Nome_prodotto like '%" + newS + "%'";

                        counter++;
                    }
                    Console.WriteLine("querySQL: " + querySQL);
                    return connection.Query<Prodotto>(querySQL).ToList();

                }
                
                else 
                    return connection.Query<Prodotto>($"select * from Prodotti where Nome_prodotto like '%{ nomeProdotto }%'").ToList();

            }
        }



        public Prodotto GetProdotto(int idProdotto) {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))

            {
                String querySQL = $"select * from Prodotti where ID = {idProdotto} ";

                Console.WriteLine("querySQL GetProdotto: " + querySQL);
                return connection.QuerySingle<Prodotto>(querySQL);
            }

        }

        public Prezzo GetPrezzoMin(int idProdotto) {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))

            {
                var sp = "[GetProductMinPrice]";
                var values = new { Id_Prodotto = idProdotto};
                
                try
                {
                    var prezzoMiniRec = connection.QuerySingle<Prezzo>(sp, values, commandType: CommandType.StoredProcedure);
                    return prezzoMiniRec;
                }
                catch
                {
                    return new Prezzo();
                }
              

                
            }

        }

        public Prezzo GetPrezzoMax(int idProdotto) {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))

            {
                var sp = "[GetProductMaxPrice]";
                var values = new { Id_Prodotto = idProdotto };

                try
                {
                    var prezzoMiniRec = connection.QuerySingle<Prezzo>(sp, values, commandType: CommandType.StoredProcedure);
                    return prezzoMiniRec;
                }
                catch
                {
                    return new Prezzo();
                }



            }

        }


        public int InsertOneProduct(long Barcode, string NomeParziale, string img, string Marca, String NomeProdotto, string Sottocategoria, string Categoria, string Origine) {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))

            {

   
                var sp = "[InsertProdotto]";

                var dParam2 = new DynamicParameters();

                dParam2.Add("Barcode", Barcode, DbType.Int64);
                dParam2.Add("Nome_parziale", NomeParziale, DbType.String);
                dParam2.Add("Immagine", img, DbType.String);
                dParam2.Add("Marca", Marca, DbType.String);
                dParam2.Add("Nome_prodotto", NomeProdotto, DbType.String);
                dParam2.Add("Sottocategorie", Sottocategoria, DbType.String);
                dParam2.Add("Categoria", Categoria, DbType.String);
                dParam2.Add("Origine", Origine, DbType.String);
                dParam2.Add("IdProdotto", dbType: DbType.Int32, direction: ParameterDirection.Output);


                // var values = new { Barcode = Barcode, Nome_parziale = NomeParziale, Immagine = img, Marca = Marca, Nome_prodotto = NomeProdotto, Sottocategorie =Sottocategoria, Categoria = Categoria, Origine = Origine };
                connection.Execute(sp, dParam2, commandType: CommandType.StoredProcedure);
                int idProdotto = dParam2.Get<int>("@IdProdotto");
                
                return idProdotto;

            }

        }

        public int InsertOnePrice(int idProdotto, decimal prezzoUnitario, string unita, string supermercato, DateTime data_offerta, string citta) {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))

            {
                var sp = "[InsertOnePrice]";
                var values = new { Id_Prodotto = idProdotto, Prezzo_Unitario = prezzoUnitario, Unita = unita, Supermercato = supermercato, Data_offerta = data_offerta, Città = citta };
                int IdProdotto = connection.Execute(sp, values, commandType: CommandType.StoredProcedure);
                return IdProdotto;
                    
                }

                


            

        }



        public decimal GetMediumPrice(int idProdotto) {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))

            {
                var sp = "[GetMediumPrice]";
                var values = new { Id_Prodotto = idProdotto };

                
                    decimal prezzoMedio = connection.QuerySingle<decimal>(sp, values, commandType: CommandType.StoredProcedure);
                    return prezzoMedio;
               
            



            }

        }

        public void SaveFileImg(int idProdotto, string pathImg) {


                Image img = Image.FromFile(pathImg);
                ImageConverter Converter = new ImageConverter();
                var ImageConverter = Converter.ConvertTo(img, typeof(byte[]));

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))

            {





                //String querySQL = "INSERT INTO TbImagesInDb (IDProdotto, Image, FileName, ImagePath) VALUES(@IDProdotto, @Image, @FileName, @ImagePath )";
                String querySQL = "INSERT INTO TbImagesInDb (IDProdotto, Image) VALUES(@IDProdotto, @Image)";
               
                var dParam = new DynamicParameters();

                dParam.Add("IDProdotto", idProdotto, DbType.Int64);
                dParam.Add("Image", ImageConverter, DbType.Binary);




                  //  new { IDProdotto = idProdotto, Image = img, FileName = pathImg, ImagePath = pathImg};
                connection.Execute(querySQL, dParam);
                


            }

        }

        public byte[] GetImg(int idProdotto) {




            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))

            {


                String querySQL = $"select top 1 Image from TbImagesInDb where IDProdotto = {idProdotto} ";

                Console.WriteLine("querySQL GetImg: " + querySQL);
                return connection.QuerySingle<byte[]>(querySQL);



            }

        }


        public List<String> GetUnit() {


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))

            {
                String querySQL = $"select DISTINCT Unità from Prezzi";

                Console.WriteLine("querySQL GetUnit: " + querySQL);
                return connection.Query<String>(querySQL).ToList();
            }

        }


    }
}
