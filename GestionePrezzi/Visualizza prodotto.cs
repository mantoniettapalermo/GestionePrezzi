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
using GestionePrezziCore;

namespace GestionePrezzi
{
    public partial class Visualizza_prodotto : Form
    {
        List<String> listUnit = new List<String>();

        public int IdProdotto { get; internal set; }
        public string PathImg { get; internal set; }
        DataAccess db = new DataAccess();
        public Visualizza_prodotto(string selectedProduct) {
            InitializeComponent();
            string idProductString = selectedProduct.Split(')')[0];
            this.IdProdotto = Convert.ToInt32(idProductString);
            Console.WriteLine("Form 2 id selectedProduct: " + this.IdProdotto);
            UpdateBinding();
            fillCombo();
        }

        private void UpdateBinding()
        {
            Prodotto prodottoToView = new Prodotto();
            prodottoToView = db.GetProdotto(this.IdProdotto);
          
            textBoxBarcode.Text = prodottoToView.barcode.ToString();
            textBoxNomeParziale.Text = prodottoToView.Nome_parziale;
            textBox_categoria.Text = prodottoToView.Categoria;
            textBox_nomeProdotto.Text = prodottoToView.Nome_prodotto;
            textBox_Marca.Text = prodottoToView.Marca;
            textBox_origine.Text = prodottoToView.Origine;
            textBox_sottocategoria.Text = prodottoToView.Sottocategorie;
            textBox_idProdotto.Text = this.IdProdotto.ToString();

            textBox_newCitta.Text = "Cremona";
            textBox_newData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            textBox_newSupermercato.Text = "Esselunga";
            textBox_newUnita.Text = "Kg";

            UpdateBindingPrezziMinMax();
        }

        private void UpdateBindingPrezziMinMax() 
        {
            Prezzo prezzoMinToView = new Prezzo();
            Prezzo prezzoMaxToView = new Prezzo();
            decimal prezzoMedio;

            try
            {
                prezzoMinToView = db.GetPrezzoMin(this.IdProdotto);
                prezzoMaxToView = db.GetPrezzoMax(this.IdProdotto);
                prezzoMedio = db.GetMediumPrice(this.IdProdotto);


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
                Console.WriteLine("Errore durante il caricamento dei prezzi per il prodotto (" + this.IdProdotto + ". )" + ex.Message);
                    
            }


            try
            {
                ShowImg();
            }
            
            catch (Exception ex) 
            {

                /* string message = "Nessuna immaggine trovata";
                 string title = "Title";
                 MessageBox.Show(message, title);*/


                Console.WriteLine("Problemi con il caricamento dell'immagine: " + ex.Message);
            }
        }

        private void ShowImg() 
        {
 
            byte[] bt = null;

            bt = db.GetImg(this.IdProdotto);
            pictureBox1.Image = byteArrayToImage(bt);
        }

        public Image byteArrayToImage(byte[] bytesArr) 
        {
            using (System.IO.MemoryStream memstr = new System.IO.MemoryStream(bytesArr))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }
        }

        private void button_salvaModifiche_Click(object sender, EventArgs e) 
        {

            Console.WriteLine("id prodotto da convertire : " + textBox_idProdotto.Text);

            try
            { 
                string unitaTemp = textBox_newUnita.Text;
                string supermercatoTemp = textBox_newSupermercato.Text;
                string cittaTemp = textBox_newCitta.Text;
    
                db.InsertOnePrice(this.IdProdotto, textBox_newPrice.Text, unitaTemp, supermercatoTemp, textBox_newData.Text, cittaTemp);

                UpdateBindingPrezziMinMax();
            }

            catch (Exception ex)
            {

                string text = "Errore nel salvataggio delle modifiche: " + ex.Message+ "\n. Riprovare.";
                MessageBox.Show(text);
                Console.WriteLine("An error occured during 'salvaModifiche_Click': " + ex.Message);

            }
        }

        private void button_modImg_Click(object sender, EventArgs e) 
        {
           
            FileExplorer1 form3 = new FileExplorer1(this.IdProdotto);
            form3.IdProdotto = this.IdProdotto;
            form3.ShowDialog();
            this.PathImg = form3.ReturnPath;
            Console.WriteLine("----> PATH img modImgClick Inserisci prodotto: " + this.PathImg);
            pictureBox1.Image = Image.FromFile(this.PathImg);

        }

        void fillCombo() 
        {
            Console.WriteLine("Prendi le unità di misura dal DB.");    
            listUnit = db.GetUnit();
            comboBoxListUnitVP.DataSource = listUnit;
        }
    }
}
