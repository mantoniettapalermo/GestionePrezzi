using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GestionePrezzi
{
    internal static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {

            /*
            string cs = "Data Source=localhost;Initial Catalog=AntoPrezzi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(cs);

            try
            {
                conn.Open();

                Console.WriteLine("Connessione eseguita");
            }
            catch (Exception ex) {
                Console.WriteLine("C'è stato un errore durante la connessione al database.");
                throw;
            
            }
            */

            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());


        }
    }
}
