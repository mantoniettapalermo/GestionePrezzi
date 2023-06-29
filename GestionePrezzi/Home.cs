using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionePrezzi
{
    public partial class Home : Form
    {

        List<Prodotto> prodotti = new List<Prodotto>();
        String prezzoMin;
        
        public Home()
        {
            InitializeComponent();
            UpdateBinding();
            pictureBox1.Image = Image.FromFile(@"C:\Users\lele_\source\repos\GestionePrezzi\GestionePrezzi\Immagini\immagineProvv.jpg");
        }

        private void UpdateBinding()
        {
            
            productFoundListbox.DataSource = prodotti;
            productFoundListbox.DisplayMember = "InfoListBox";

        }
        public Image byteArrayToImage(byte[] bytesArr) {
            using (System.IO.MemoryStream memstr = new System.IO.MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }
        private void ShowImg(int idProductSelected) {

            DataAccess db = new DataAccess();
            byte[] bt = null;


            bt = db.GetImg(idProductSelected);

            pictureBox1.Image = byteArrayToImage(bt);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

         

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Console.WriteLine("click pulsante cerca fatto");
            DataAccess db = new DataAccess();
            prodotti = db.GetProdotti(rJtextBox1.Text);
            int numProdotti = prodotti.Count;
            Console.WriteLine("numero prodotti " + numProdotti);
            Console.WriteLine("text box text: " + rJtextBox1.Text);
           
            UpdateBinding();

            Console.WriteLine("fine metodo button click");
        }

        private void rJtextBox1_KeyDown(object sender, KeyEventArgs e) {
            Console.WriteLine("keydown");
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }

        }



        /*private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }*/
      

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void rJtextBox1_Load(object sender, EventArgs e) {

        }

        private void button3_Click(object sender, EventArgs e) {

            string selectedProduct = productFoundListbox.GetItemText(productFoundListbox.SelectedItem);
            Console.WriteLine("Prodotto selezionato: " + selectedProduct);

            Visualizza_prodotto form2 = new Visualizza_prodotto(selectedProduct);
            form2.Show();


        }

        private void button4_Click(object sender, EventArgs e) {


           

            InserisciProdotto formIns = new InserisciProdotto();
            formIns.Show();


        }

        private void productFoundListbox_SelectedIndexChanged(object sender, EventArgs e) {
            string selectedProduct = productFoundListbox.GetItemText(productFoundListbox.SelectedItem);
            string idProductString = selectedProduct.Split(')')[0];
            int idProductSelected = Convert.ToInt32(idProductString);

            DataAccess db = new DataAccess();
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

                /* string message = "Nessuna immaggine trovata";
                 string title = "Title";
                 MessageBox.Show(message, title);*/


                Console.WriteLine("Problemi con il caricamento dell'immagine: " + ex.Message);
                pictureBox1.Image = Image.FromFile(@"C:\Users\lele_\source\repos\GestionePrezzi\GestionePrezzi\Immagini\immagineProvv.jpg");
            }

      

        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void rJtextBox1_Load_1(object sender, EventArgs e) {

        }
    }
}
