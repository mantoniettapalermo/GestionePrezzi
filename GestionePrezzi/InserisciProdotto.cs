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
    public partial class InserisciProdotto : Form
    {
        List<String> listUnit = new List<String>();
        public int IdProdotto { get; internal set; }
        public string PathImg { get; internal set; }
        DataAccess db = new DataAccess();
        public InserisciProdotto() {
            InitializeComponent();
            fillCombo();
        }

        private void button1_salvaProdotto_Click(object sender, EventArgs e) 
        {

            textBox_newCitta.Text = "Cremona";
            textBox_newData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            textBox_newSupermercato.Text = "Esselunga";
            textBox_newUnita.Text = "Kg";

            int id = db.InsertOneProduct(long.Parse(textBoxBarcode.Text), textBoxNomeParziale.Text, "", textBox_Marca.Text, textBox_nomeProdotto.Text, textBox_sottocategoria.Text, textBox_categoria.Text, textBox_origine.Text);
            this.IdProdotto = id;
            Console.WriteLine("id prodotto dopo salvataggio in db: " + this.IdProdotto);
            Console.WriteLine("path: " + this.PathImg);

            if (String.IsNullOrEmpty(this.PathImg))
                Console.WriteLine("Path is empty, no img for this product");
            else
                db.SaveFileImg(this.IdProdotto, this.PathImg);
                textBox_idProdotto.Text = this.IdProdotto.ToString();
        }

        private void UpdateBindingPrezziMinMax(int idProductSelected) 
        {
            Prezzo prezzoMinToView = new Prezzo();
            Prezzo prezzoMaxToView = new Prezzo();
            decimal prezzoMedio;

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

        private void button_modImg_Click(object sender, EventArgs e) 
        {
            FileExplorer1 form3 = new FileExplorer1(-1);
            form3.IdProdotto = -1;
            form3.ShowDialog();
            this.PathImg = form3.ReturnPath;
            Console.WriteLine("----> PATH img modImgClick Inserisci prodotto: " + this.PathImg);

            try
            {
                pictureBox1.Image = Image.FromFile(this.PathImg);
            }

            catch (Exception ex)
            {
                string text = "Errore nel caricamento dell'immagine: " + ex.Message + "\n. Riprovare.";
                MessageBox.Show(text);
            }
        }

        private void button_salvaModifiche_Click(object sender, EventArgs e) 
        {
            Console.WriteLine("id prodotto da convertire : " + this.IdProdotto);

            try
            {
                string unitaTemp = textBox_newUnita.Text;
                string supermercatoTemp = textBox_newSupermercato.Text;
                string cittaTemp = textBox_newCitta.Text;
              
                db.InsertOnePrice(this.IdProdotto, textBox_newPrice.Text, unitaTemp, supermercatoTemp, textBox_newData.Text, cittaTemp);
                UpdateBindingPrezziMinMax(this.IdProdotto);
            }
            catch (Exception ex)
            {
                string text = "Errore nel salvataggio delle modifiche: " + ex.Message + "\n. Riprovare.";
                MessageBox.Show(text);
                Console.WriteLine("An error occured during 'salvaModifiche_Click': " + ex.Message);
            }
        }

    private void button1_Click(object sender, EventArgs e) 
    {
            textBox_prezzoMinimo.Text = "";
            textBox_unitàMin.Text = "";
            textBox_cittaMin.Text = "";
            textBox_dataMin.Text = "";

            textBox_cittaMin.Text = "";
            textBox_prezzoMax.Text = "";
            textBox_superMax.Text = "";
            textBox_unitàMax.Text = "";
            textBox_cittaMax.Text = "";
            textBox_dataMax.Text = "";
            textBox_PrezzoMedio.Text = "";
            textBox_idProdotto.Text = "";
            textBoxBarcode.Text = "";
            textBoxNomeParziale.Text = "";
            textBox_nomeProdotto.Text = "";
            textBox_origine.Text = "";
            textBox_categoria.Text = "";
            textBox_sottocategoria.Text = "";
            textBox_Marca.Text = "";

         
            textBox_newPrice.Text = "";

            pictureBox1.Image = null;
    }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) 
        {
            Console.WriteLine("cambiato combox in: " + comboBoxListUnit.SelectedValue);
            String selectedUnit  = (string)comboBoxListUnit.SelectedValue;
            textBox_newUnita.Text = selectedUnit;
        }

        void fillCombo() 
        {
            Console.WriteLine("Prendi le unità di misura dal DB.");
            listUnit = db.GetUnit();
            comboBoxListUnit.DataSource = listUnit;
        }
    }
}
