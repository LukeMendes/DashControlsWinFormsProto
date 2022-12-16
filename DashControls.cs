using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DashControlsWinFormsProto
{
    public partial class DashControls : Form
    {
        public DashControls()
        {
            InitializeComponent();
        }

        private void Senden_Click(object sender, EventArgs e)
        {
            if (Eingabefeld.Text != "")
            {
                richTextBox1.Text += Eingabefeld.Text + "\n";
                Meldung.Text = "";
                Eingabefeld.Text = "";
            } else
            {
                Meldung.Text = "Sie haben nichts eingegeben";
            }
        }

        private void DashControls_Load(object sender, EventArgs e)
        {
            
        }
    }
}
