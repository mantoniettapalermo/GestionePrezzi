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
    public partial class RJtextBox : UserControl
    {

        //Fields

        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 2;
        private bool underlinedStyle  = false;

        //Constructor
        public RJtextBox() {
            InitializeComponent();
        }

        //Properties
        public Color BorderColor {
            get {
                return borderColor;
            }

            set {
                borderColor = value;
                this.Invalidate();
            }
        }

        public int BorderSize {
            get {
                return borderSize;
            }

            set {
                borderSize = value;
                this.Invalidate();
            }
        }

        public bool UnderlinedStyle {
            get {
                return underlinedStyle;
            }

            set {
                underlinedStyle = value;
                this.Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            //Draw boder

            using (Pen penBorder = new Pen(borderColor, borderSize)) {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                if (underlinedStyle)
                    graph.DrawLine(penBorder, 0, this.Height-1, this.Width, this.Height-1);
                else
                    graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
           }


        }
       
        public string Text{
            get {
                return textBoxR.Text;
            }

            set {
                textBoxR.Text = value;
            }
        }
        protected override void OnResize(EventArgs e) {

           
            base.OnResize(e);
            if(this.DesignMode)
                UpdateControlHeight();
        }

  

    

    protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        //Private method

        private void UpdateControlHeight() {
            if (textBoxR.Multiline == false) {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBoxR.Multiline = true;
                textBoxR.MinimumSize = new System.Drawing.Size(0, txtHeight);
                textBoxR.Multiline = false;


                this.Height = textBoxR.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }
        private void RJtextBox_Load(object sender, EventArgs e) {

        }

        private void RJtextBox_OnKeyDown(object sender, KeyEventArgs e) {

            if (e.KeyCode == Keys.Enter) { 
            Console.WriteLine("aaaa");

            e.Handled = true;
            e.SuppressKeyPress = true;
            base.OnKeyDown(e);
        }


        }
    }
}
