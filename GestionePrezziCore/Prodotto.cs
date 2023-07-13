using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePrezziCore
{
    public class Prodotto
    {

        public int id { get; set; }
        public long barcode { get; set;  }
        public string Nome_parziale { get; set; }

        public string Immagine { get; set; }

        public string Marca { get; set; }
        public string Nome_prodotto { get; set; }
        public string Sottocategorie { get; set; }
        public string Categoria { get; set; }
        public string Origine { get; set; }

        private string myVar;

        public string InfoListBox {
            get {
                return $"{id}) { Nome_prodotto } ({ Nome_parziale })";
            }

        }
        public string FullInfo { 
            get {
                return  $"{id},{ barcode },{ Nome_parziale },{ Nome_prodotto },{Origine},{ Categoria },{ Sottocategorie}";
            }
           
        }
    }
}
