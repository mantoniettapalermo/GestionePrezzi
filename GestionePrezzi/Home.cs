using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionePrezziCore;

namespace GestionePrezzi
{
    public partial class Home : Form
    {

        List<Prodotto> prodotti = new List<Prodotto>();
        String prezzoMin;
        DataAccess db = new DataAccess();
  
        public Home()
        {
            InitializeComponent();
       
            string imgPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Immagini", "immagineProvv.jpg");
            pictureBox1.Image = Image.FromFile(imgPath);
            // cercare di mettere il riferimento su GestionePrezziCore
            //.gitignore -  pictureBox1.Image pictureBox1.Image = Image.FromFile(@"C:\Users\lele_\source\repos\GestionePrezzi\GestionePrezzi\Immagini\immagineProvv.jpg");
        }

        private void UpdateBinding()
        {
            productFoundListbox.SelectedIndexChanged -= this.productFoundListbox_SelectedIndexChanged;
            productFoundListbox.DataSource = prodotti;
            productFoundListbox.DisplayMember ="InfoListBox";
            productFoundListbox.SelectedIndexChanged += this.productFoundListbox_SelectedIndexChanged;
        }
        public Image byteArrayToImage(byte[] bytesArr) {
            using (System.IO.MemoryStream memstr = new System.IO.MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }
        private void ShowImg(int idProductSelected) 
        {
          
            byte[] bt = null;
            bt = db.GetImg(idProductSelected);
            pictureBox1.Image = byteArrayToImage(bt);
        }

        //Ricerca dei prodotti all'interno del database tramite il testo inserito inserito come ricerca
        private void CercaButton_Click(object sender, EventArgs e) {
            Console.WriteLine("click pulsante cerca fatto");
         
            prodotti = db.GetProdotti(rJtextBox1.Text);
            int numProdotti = prodotti.Count;
            Console.WriteLine("numero prodotti " + numProdotti);
            Console.WriteLine("text box text: " + rJtextBox1.Text);
           
            UpdateBinding();

            Console.WriteLine("fine metodo button click");
        }

        private void rJtextBox1_KeyDown(object sender, KeyEventArgs e) 
            {
            Console.WriteLine("keydown");
            if (e.KeyCode == Keys.Enter)
            {
                CercaButton_Click(this, new EventArgs());
            }

        }

        private void button3_Click(object sender, EventArgs e) 
        {    
            string selectedProduct = productFoundListbox.GetItemText(productFoundListbox.SelectedItem);
            Console.WriteLine("Prodotto selezionato: " + selectedProduct);

            Visualizza_prodotto form2 = new Visualizza_prodotto(selectedProduct);
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e) 
        {
            InserisciProdotto formIns = new InserisciProdotto();
            formIns.Show();
        }

        private void productFoundListbox_SelectedIndexChanged(object sender, EventArgs e) 
        {
            string selectedProduct = productFoundListbox.GetItemText(productFoundListbox.SelectedItem);
            string idProductString = selectedProduct.Split(')')[0];
            int idProductSelected = Convert.ToInt32(idProductString);
  
            Prezzo prezzoMinToView = new Prezzo();
            prezzoMinToView = db.GetPrezzoMin(idProductSelected);
            prezzoMin = prezzoMinToView.PrezzoUnitario.ToString();
            textBox_prezzoMinimo.Text = prezzoMin;

            try
            {
                ShowImg(idProductSelected);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Problemi con il caricamento dell'immagine: " + ex.Message);
                string imgPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Immagini", "immagineProvv.jpg");
                pictureBox1.Image = Image.FromFile(imgPath);
               // .gitignore -  pictureBox1.Image = Image.FromFile(@"C:\Users\lele_\source\repos\GestionePrezzi\GestionePrezzi\Immagini\immagineProvv.jpg");
            }
        }   
    }
}
