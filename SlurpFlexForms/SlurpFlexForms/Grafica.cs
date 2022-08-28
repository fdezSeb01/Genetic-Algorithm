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
using System.IO;

namespace SlurpFlexForms
{
    public partial class Grafica : Form
    {
        double k1, k2, k3;
        SLURP_Y_FLEX.Point[] ambiente;
        private void Grafica_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            this.DoubleBuffered = true;
            Graficar(g);
        }

        public Grafica(double k1, double k2, double k3,SLURP_Y_FLEX.Point[] ambiente)
        {
            //width =1200
            //height = 760
            //x = 40, 100-140
            //y=50, 350-400
            InitializeComponent();
            this.k1 = k1;
            this.k2 = k2;
            this.k3 = k3;
            this.ambiente = ambiente;
            this.CenterToScreen();
        }

        private void Grafica_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void Graficar(Graphics g)
        {
            System.Drawing.Point[] puntosGrafica = new System.Drawing.Point[119];

            g.DrawLine(Pens.White, 0, 700, 1200, 700);
            g.DrawLine(Pens.White, 10, 0, 10, 750);
            g.DrawLine(Pens.White, 0, 0, 1200, 0);


            label1.Text = "Individuo: k1: " + k1 + " , k2: " + k2 + " , k3: " + k3;

            for (int i = 100; i <= 141; i+=5)
            {
                g.DrawString(" " + i, Font, Brushes.White, new System.Drawing.Point((i-100)*30+10,700-15));
                g.DrawLine(Pens.White, (i - 100) * 30+10, 700 - 5, (i - 100) * 30+10, 700 + 5);
            }
            for (int i = 350; i <= 401; i += 5)
            {
                g.DrawString(" " + i, Font, Brushes.White, new System.Drawing.Point(15, -(i-350)*15+750));
                g.DrawLine(Pens.White,5, -(i - 350) * 15 + 750, 15, -(i - 350) * 15 + 750);
            }


            int contador = 0;
            for(int i=10;i<1200;i+=10)
            {
                double a = ((double)i-10) /30;
                double b = a+100; //coordenadaxParafuncion
                double c = valorF(b); //coordenadayParaFuncion
                int d = (int)Math.Truncate(c) - 350;
                int e = (int)Math.Truncate(((c - (d + 350)) * 100)) / 6;
                int f = -d * 15 + 700 - e;
                puntosGrafica[contador] = new System.Drawing.Point(i,f);
                contador++;
            }
            g.DrawLines(Pens.White, puntosGrafica);


            for (int i = 0; i < 50; i++)
            {
                int puntox = (int)Math.Truncate(ambiente[i].x) - 100;
                int punto2x = (int)Math.Truncate(((ambiente[i].x - (puntox + 100)) * 100)) / 3;
                int punto3x = puntox * 30 + 10 + punto2x;
                int puntoy = (int)Math.Truncate(ambiente[i].y) - 350;
                int punto2y = (int)Math.Truncate(((ambiente[i].y - (puntoy + 350)) * 100)) / 6;
                int punto3y = -puntoy * 15 + 700 - punto2y;
                g.DrawEllipse(Pens.Red, punto3x, punto3y, 3, 3);
            }
        }
        public double valorF(double x)
        {
            return (k1 * x) + (k2 * Math.Sin(k3 * x)) + 312;
        }
    }
}
