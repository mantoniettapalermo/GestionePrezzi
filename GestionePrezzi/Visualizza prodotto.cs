using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionePrezzi
{
    public partial class Visualizza_prodotto : Form
    {


        List<String> listUnit = new List<String>();
        public string PathImg { get; internal set; }
        public Visualizza_prodotto(string selectedProduct) {
            InitializeComponent();
            string idProductString = selectedProduct.Split(')')[0];
            int idProductSelected = Convert.ToInt32(idProductString);
            Console.WriteLine("Form 2 id selectedProduct: " + idProductString);
            UpdateBinding(idProductSelected);
            fillCombo();
        }


        private void UpdateBinding(int idProductSelected) {


            Prodotto prodottoToView = new Prodotto();
            


            DataAccess db = new DataAccess();
            prodottoToView = db.GetProdotto(idProductSelected);
          

            textBoxBarcode.Text = prodottoToView.barcode.ToString();
            textBoxNomeParziale.Text = prodottoToView.Nome_parziale;
            textBox_categoria.Text = prodottoToView.Categoria;
            textBox_nomeProdotto.Text = prodottoToView.Nome_prodotto;
            textBox_Marca.Text = prodottoToView.Marca;
            textBox_origine.Text = prodottoToView.Origine;
            textBox_sottocategoria.Text = prodottoToView.Sottocategorie;
            textBox_idProdotto.Text = idProductSelected.ToString();

            textBox_newCitta.Text = "Cremona";
            textBox_newData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            textBox_newSupermercato.Text = "Esselunga";
            textBox_newUnita.Text = "Kg";

            UpdateBindingPrezziMinMax(idProductSelected);

        }

        private void UpdateBindingPrezziMinMax(int idProductSelected) {


            Prezzo prezzoMinToView = new Prezzo();
            Prezzo prezzoMaxToView = new Prezzo();
            decimal prezzoMedio;

            DataAccess db = new DataAccess();
            try
            {
                prezzoMinToView = db.GetPrezzoMin(idProductSelected);
                prezzoMaxToView = db.GetPrezzoMax(idProductSelected);
                prezzoMedio = db.GetMediumPrice(idProductSelected);


                textBox_prezzoMinimo.Text = prezzoMinToView.PrezzoUnitario.ToString();
                textBox_superMin.Text = prezzoMinToView.Supermercato;
                textBox_unitàMin.Text = prezzoMinToView.Unità;
                textBox_cittaMin.Text = prezzoMinToView.Città;
                textBox_dataMin.Text = prezzoMinToView.date.ToString();


                textBox_prezzoMax.Text = prezzoMaxToView.PrezzoUnitario.ToString();
                textBox_superMax.Text = prezzoMaxToView.Supermercato;
                textBox_unitàMax.Text = prezzoMaxToView.Unità;
                textBox_cittaMax.Text = prezzoMaxToView.Città;
                textBox_dataMax.Text = prezzoMaxToView.date.ToString();

                textBox_PrezzoMedio.Text = prezzoMedio.ToString("0.##");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Errore durante il caricamento dei prezzi per il prodotto (" + idProductSelected + ". )" + ex.Message);
                    
            }


            try {
                ShowImg(idProductSelected);
            }
            
            catch (Exception ex) {

                /* string message = "Nessuna immaggine trovata";
                 string title = "Title";
                 MessageBox.Show(message, title);*/


                Console.WriteLine("Problemi con il caricamento dell'immagine: " + ex.Message);
            }

        }

        private void ShowImg(int idProductSelected) {

            DataAccess db = new DataAccess();
            byte[] bt = null;


            bt = db.GetImg(idProductSelected);

            pictureBox1.Image = byteArrayToImage(bt);
        }



        public Image byteArrayToImage(byte[] bytesArr) {
            using (System.IO.MemoryStream memstr = new System.IO.MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }
        private void label1_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void label1_Click_1(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void label1_Click_2(object sender, EventArgs e) {

        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void label1_Click_3(object sender, EventArgs e) {

        }

        private void label_prezzoMinimo_Click(object sender, EventArgs e) {

        }

        private void label1_Click_4(object sender, EventArgs e) {

        }

        private void Visualizza_prodotto_Load(object sender, EventArgs e) {

        }

        private void label_SuperMin_Click(object sender, EventArgs e) {

        }

        private void label1_Click_5(object sender, EventArgs e) {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e) {

        }

        private void label1_Click_6(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e) {

        }

        private void button_salvaModifiche_Click(object sender, EventArgs e) {

            DataAccess db = new DataAccess();

            Console.WriteLine("id prodotto da convertire : " + textBox_idProdotto.Text);

            try
            {
                int idProdottoTemp = Convert.ToInt32(textBox_idProdotto.Text);
                decimal prezzoUnitarioTemp = Convert.ToDecimal(textBox_newPrice.Text);
                string unitaTemp = textBox_newUnita.Text;
                string supermercatoTemp = textBox_newSupermercato.Text;
                string cittaTemp = textBox_newCitta.Text;
                DateTime dataOffertaTemp;
                if (DateTime.TryParseExact(textBox_newData.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataOffertaTemp))
                    dataOffertaTemp = DateTime.ParseExact(textBox_newData.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (DateTime.TryParseExact(textBox_newData.Text, "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataOffertaTemp))
                        dataOffertaTemp = DateTime.ParseExact(textBox_newData.Text, "dd/MM/yy", CultureInfo.InvariantCulture);

                        db.InsertOnePrice(idProdottoTemp, prezzoUnitarioTemp, unitaTemp, supermercatoTemp, dataOffertaTemp, cittaTemp);

                UpdateBindingPrezziMinMax(idProdottoTemp);
            }

            catch (Exception ex)
            {

                string text = "Errore nel salvataggio delle modifiche: " + ex.Message+ "\n. Riprovare.";
                MessageBox.Show(text);
                Console.WriteLine("An error occured during 'salvaModifiche_Click': " + ex.Message);

            }
        }

        private void button_modImg_Click(object sender, EventArgs e) {

            int idProdottoTemp = Convert.ToInt32(textBox_idProdotto.Text);
            FileExplorer1 form3 = new FileExplorer1(idProdottoTemp);
            form3.IdProdotto = idProdottoTemp;
            form3.ShowDialog();
            this.PathImg = form3.ReturnPath;
            Console.WriteLine("----> PATH img modImgClick Inserisci prodotto: " + this.PathImg);
            pictureBox1.Image = Image.FromFile(this.PathImg);

        }

        private void comboBoxListUnitVP_SelectedIndexChanged(object sender, EventArgs e) {

        }


        void fillCombo() {

            Console.WriteLine("Prendi le unità di misura dal DB.");
            DataAccess db = new DataAccess();
            listUnit = db.GetUnit();
            comboBoxListUnitVP.DataSource = listUnit;

        }
    }
}
