using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionePrezziCore;

namespace GestionePrezzi
{
    public partial class FileExplorer1 : Form
    {
        public int IdProdotto { get; internal set; }
        public string ReturnPath { get; internal set; }
        public FileExplorer1(int idProdottoTemp) {
            InitializeComponent();

         
        }

        private void SaveImg(int idProductSelected) { 
        
        }

            private void webBrowser_FileDownload(object sender, EventArgs e) {
            Console.WriteLine(e.ToString());
        }

        private void buttonOpenFile_Click(object sender, EventArgs e) {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Seleziona un file";
            //Recupero la path della cartella immagini
            String pathImgDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog1.InitialDirectory = pathImgDirectory;
            //openFileDialog1.InitialDirectory = @"C:\";//--"_\\";
            openFileDialog1.Filter = "All files (*.*)|*.*|Text File (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
                txtPath.Text = openFileDialog1.FileName;
            else
                txtPath.Text = "";
        }

        private void buttonSalvaDB_Click(object sender, EventArgs e) {


            Console.WriteLine("AAAAAAAAAA: id prodotto --> " + this.IdProdotto);
            if (this.IdProdotto != -1)
            {
                Console.WriteLine("Save img in DB --> path: " + txtPath.Text);
                GestionePrezziCore.DataAccessCore db = new GestionePrezziCore.DataAccessCore();
                db.SaveFileImg(this.IdProdotto, txtPath.Text);
                this.ReturnPath = txtPath.Text;
                this.Close();
            }

            else {
               
                this.ReturnPath = txtPath.Text;
                this.Close();
            }
      
        }


        private void FileExplorer_Load(object sender, EventArgs e) { 
        
        }
    }
}
