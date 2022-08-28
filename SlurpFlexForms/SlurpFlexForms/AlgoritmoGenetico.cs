using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SlurpFlexForms;

namespace SLURP_Y_FLEX
{
    public class AlgoritmoGenetico
    {
        public List<Individuo> MejoresIndividuos = new List<Individuo>();
        public List<double> adecuacionesMejor = new List<double>();
        Form1 form;
        StreamWriter sw = new StreamWriter(@"MejoresIndividuos.txt", false);
        public int Gens = 0;
        public Poblacion P;
        public AlgoritmoGenetico(Form1 form)
        {
            this.form = form;
            P = new Poblacion();
            //Individuo x = new Individuo(0.5276671, 2.916459, 0.5236444);
            P.PoblacionAleatoria();
            P.OrdenarPoblacion();
            form.button1.Enabled = false;
            form.pictureBox1.Visible = true;
            while (!CriterioStop(P.individuo[0], Gens))
            {
                MejoresIndividuos.Add(Ciclo());
                form.pictureBox1.Refresh();
            }
            form.button1.Enabled = true;
            form.pictureBox1.Visible = false;
            sw.Close();
            form.textBox1.Text += "Mejor "+MejoresIndividuos.Last()+Environment.NewLine+ Environment.NewLine;
            form.Refresh();
        }
        public Individuo Ciclo()
        {
            if (Gens == 0)
            {
                Gens++;
                form.textBox1.Text += " Generacion " + Gens +" : "+P.individuo[0]+ Environment.NewLine;
                form.Refresh();
                sw.WriteLine("Generación " +Gens + " : "+ P.individuo[0]);
                return P.individuo[0];
            }
            Gens++;
            P.CruzarPoblacion();
            P.Mochacion();
            P.mutarPoblacion();
            //form.textBox1.Text += " Generacion " + Gens + " : " + P.individuo[0] + Environment.NewLine;
            sw.WriteLine("Generación " + Gens + " : " + P.individuo[0]);
            return P.individuo[0];            
        }
        public bool CriterioStop(Individuo individuo, int gen)
        {
            adecuacionesMejor.Add(individuo.adecuacion);
            if (adecuacionesMejor.Count > 1000)
                adecuacionesMejor.RemoveAt(0);
            if (adecuacionesMejor.Count == 1000)
            {
                if (criterioSumaStop() ==0)
                    return true;
                else
                    return false;
            }
            else
                return false;

        }
        public double criterioSumaStop()
        {
            double suma = 0;
            for (int i = 0; i < 1000; i += 2)
            {
                suma += adecuacionesMejor[i];
                suma -= adecuacionesMejor[i + 1];
            }
            return suma;
        }
    }
}
