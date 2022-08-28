using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SLURP_Y_FLEX;

namespace SlurpFlexForms
{
    public partial class Form1 : Form
    {
        AlgoritmoGenetico AG;
        Grafica graph;
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AG = new AlgoritmoGenetico(this);
            button2.Visible = true;
            graph = new Grafica(AG.MejoresIndividuos.Last().k1.VD, AG.MejoresIndividuos.Last().k2.VD, AG.MejoresIndividuos.Last().k3.VD,AG.P.ambiente.punto);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graph.Show();
        }
    }
}
