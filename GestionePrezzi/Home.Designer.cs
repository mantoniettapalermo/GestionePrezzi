namespace GestionePrezzi
{
    partial class Home
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.productFoundListbox = new System.Windows.Forms.ListBox();
            this.cercaButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button_InserisciProdotto = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_prezzoMinimo = new System.Windows.Forms.TextBox();
            this.label_prezzoMinimo = new System.Windows.Forms.Label();
            this.rJtextBox1 = new GestionePrezzi.RJtextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // productFoundListbox
            // 
            this.productFoundListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productFoundListbox.FormattingEnabled = true;
            this.productFoundListbox.HorizontalScrollbar = true;
            this.productFoundListbox.ItemHeight = 16;
            this.productFoundListbox.Location = new System.Drawing.Point(12, 196);
            this.productFoundListbox.Name = "productFoundListbox";
            this.productFoundListbox.ScrollAlwaysVisible = true;
            this.productFoundListbox.Size = new System.Drawing.Size(649, 212);
            this.productFoundListbox.TabIndex = 0;
            this.productFoundListbox.SelectedIndexChanged += new System.EventHandler(this.productFoundListbox_SelectedIndexChanged);
            // 
            // cercaButton
            // 
            this.cercaButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cercaButton.Location = new System.Drawing.Point(314, 86);
            this.cercaButton.Name = "cercaButton";
            this.cercaButton.Size = new System.Drawing.Size(99, 26);
            this.cercaButton.TabIndex = 3;
            this.cercaButton.Text = "Cerca";
            this.cercaButton.UseVisualStyleBackColor = true;
            this.cercaButton.Click += new System.EventHandler(this.CercaButton_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(86, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 36);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button3.Location = new System.Drawing.Point(226, 441);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(291, 37);
            this.button3.TabIndex = 6;
            this.button3.Text = "Visualizza prodotto";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_InserisciProdotto
            // 
            this.button_InserisciProdotto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_InserisciProdotto.Location = new System.Drawing.Point(270, 118);
            this.button_InserisciProdotto.Name = "button_InserisciProdotto";
            this.button_InserisciProdotto.Size = new System.Drawing.Size(183, 36);
            this.button_InserisciProdotto.TabIndex = 7;
            this.button_InserisciProdotto.Text = "Inserisci Prodotto";
            this.button_InserisciProdotto.UseVisualStyleBackColor = true;
            this.button_InserisciProdotto.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.Location = new System.Drawing.Point(685, 199);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 212);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_prezzoMinimo
            // 
            this.textBox_prezzoMinimo.Location = new System.Drawing.Point(784, 421);
            this.textBox_prezzoMinimo.Name = "textBox_prezzoMinimo";
            this.textBox_prezzoMinimo.Size = new System.Drawing.Size(104, 22);
            this.textBox_prezzoMinimo.TabIndex = 16;
            // 
            // label_prezzoMinimo
            // 
            this.label_prezzoMinimo.AutoSize = true;
            this.label_prezzoMinimo.BackColor = System.Drawing.Color.SpringGreen;
            this.label_prezzoMinimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_prezzoMinimo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_prezzoMinimo.Location = new System.Drawing.Point(671, 424);
            this.label_prezzoMinimo.Name = "label_prezzoMinimo";
            this.label_prezzoMinimo.Size = new System.Drawing.Size(107, 16);
            this.label_prezzoMinimo.TabIndex = 15;
            this.label_prezzoMinimo.Text = "Prezzo minimo";
            // 
            // rJtextBox1
            // 
            this.rJtextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rJtextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.rJtextBox1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.rJtextBox1.BorderSize = 2;
            this.rJtextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rJtextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.rJtextBox1.Location = new System.Drawing.Point(124, 44);
            this.rJtextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rJtextBox1.Name = "rJtextBox1";
            this.rJtextBox1.Padding = new System.Windows.Forms.Padding(7);
            this.rJtextBox1.Size = new System.Drawing.Size(462, 35);
            this.rJtextBox1.TabIndex = 5;
            this.rJtextBox1.UnderlinedStyle = false;
            this.rJtextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rJtextBox1_KeyDown);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(921, 547);
            this.Controls.Add(this.textBox_prezzoMinimo);
            this.Controls.Add(this.label_prezzoMinimo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_InserisciProdotto);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.rJtextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cercaButton);
            this.Controls.Add(this.productFoundListbox);
            this.Name = "Home";
            this.Text = "GestionePrezzi";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox productFoundListbox;
        private System.Windows.Forms.Button cercaButton;
        private System.Windows.Forms.Button button2;
        private RJtextBox rJtextBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button_InserisciProdotto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_prezzoMinimo;
        private System.Windows.Forms.Label label_prezzoMinimo;
    }
}

