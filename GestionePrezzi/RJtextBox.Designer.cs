namespace GestionePrezzi
{
    partial class RJtextBox
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent() {
            this.textBoxR = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxR
            // 
            this.textBoxR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxR.Location = new System.Drawing.Point(7, 7);
            this.textBoxR.Name = "textBoxR";
            this.textBoxR.Size = new System.Drawing.Size(236, 18);
            this.textBoxR.TabIndex = 0;
            this.textBoxR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RJtextBox_OnKeyDown);
            // 
            // RJtextBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.textBoxR);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RJtextBox";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Size = new System.Drawing.Size(250, 30);
            this.Load += new System.EventHandler(this.RJtextBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxR;
    }
}
