using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionePrezzi
{
    public class Prezzo
    {

        public int IDPrezzo { get; set; }
        public int IDProdotto { get; set; }
        public decimal PrezzoUnitario { get; set; }
        public string Unità { get; set; }
        public string Supermercato { get; set; }
        public DateTime date { get; set; }
        public string Città { get; set; }

        public string FullInfo {
            get {

                Console.WriteLine("data stampata: " + date.ToString("dd/MM/yyyy"));
                return $"{IDPrezzo},{IDProdotto },{ PrezzoUnitario },{Unità },{Supermercato},{ date },{ Città}";
            }
        }

    }
}
