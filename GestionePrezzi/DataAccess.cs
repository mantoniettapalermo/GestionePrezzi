using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionePrezziCore;

namespace GestionePrezzi
{

    internal class DataAccess
    {

        private GestionePrezziCore.DataAccessCore db1 = new GestionePrezziCore.DataAccessCore();

        public DataAccessCore Db1 {
            get {
                return db1;
            }

            set {
                db1 = value;
            }
        }

        public List<Prodotto> GetProdotti(string nomeProdotto) {
            return db1.GetProdotti(nomeProdotto);
        }

        public Prodotto GetProdotto(int idProdotto) {
            return db1.GetProdotto(idProdotto);
        }

        public Prezzo GetPrezzoMin(int idProdotto) {
            return db1.GetPrezzoMin(idProdotto);
        }

        public Prezzo GetPrezzoMax(int idProdotto) {
            return db1.GetPrezzoMax(idProdotto);
        }

        public int InsertOneProduct(long Barcode, string NomeParziale, string img, string Marca, String NomeProdotto, string Sottocategoria, string Categoria, string Origine) {
            return db1.InsertOneProduct(Barcode, NomeParziale, img, Marca, NomeProdotto, Sottocategoria, Categoria, Origine);
        }

        public int InsertOnePrice(int idProdotto, string prezzoUnitario, string unita, string supermercato, String data_offerta, string citta) {

            decimal prezzoUnitarioTemp = Convert.ToDecimal(prezzoUnitario);


            DateTime dataOffertaTemp;
            string[] formats = { "dd/MM/yyyy", "dd/MM/yy" };
            if (DateTime.TryParseExact(data_offerta, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dataOffertaTemp))
                Console.WriteLine("conversione ok");
            else
                throw new Exception("Il formato della data non è corretto, modificare e riprovare.");

            return db1.InsertOnePrice(idProdotto, prezzoUnitarioTemp, unita, supermercato, dataOffertaTemp, citta);
        }

        public decimal GetMediumPrice(int idProdotto) { 
            return db1.GetMediumPrice(idProdotto);
        }

        public void SaveFileImg(int idProdotto, string pathImg) { 
            db1.SaveFileImg(idProdotto, pathImg);
        }

        public byte[] GetImg(int idProdotto) { 
            return db1.GetImg(idProdotto);
        }

        public List<String> GetUnit() { 
            return db1.GetUnit();
        }
    }
}
