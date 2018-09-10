using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SierpinskiTriangle
{
    public partial class MainForm : Form
    {
        private SierpinskiTriangle tra;

        public MainForm()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (tra == null)
            {
                tra = new SierpinskiTriangle(e.Graphics, new Point(this.Width/2, this.Height/2 + 50));
            }

            tra.Paint();
        }
    }
}
