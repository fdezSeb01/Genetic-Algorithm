using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLURP_Y_FLEX
{
    public class Individuo
    {
        public Cromosoma k1, k2, k3;
        Ambiente ambiente;
        Random r = new Random();
        public double adecuacion;
        public Individuo(double k1, double k2, double k3, Ambiente ambiente)
        {
            this.k1 = new Cromosoma(k1);
            this.k2 = new Cromosoma(k2);
            this.k3 = new Cromosoma(k3);
            this.ambiente = ambiente;
            CalcularAdecuacion();
        }
        public double valorFuncion(double x)
        {
            return (k1.VD * x) + (k2.VD * Math.Sin(k3.VD*x)) + 312;
        }
        public void CalcularAdecuacion()
        {
            double adec=0;
            for (int i=0; i<50;i++)
            {
                adec += Math.Pow(ambiente.punto[i].y - valorFuncion(ambiente.punto[i].x),2);
            }
            adecuacion=adec;
        }
        public void Mutar(Cromosoma cromosoma,int rnd, int rnd1, int rnd2, int rnd3, int rnd4)
        {
            cromosoma.VBA.Set(rnd, !cromosoma.VBA.Get(rnd));
            cromosoma.VBA.Set(rnd1, !cromosoma.VBA.Get(rnd1));
            cromosoma.VBA.Set(rnd2, !cromosoma.VBA.Get(rnd2));
            cromosoma.VBA.Set(rnd3, !cromosoma.VBA.Get(rnd3));
            cromosoma.VBA.Set(rnd4, !cromosoma.VBA.Get(rnd4));
        }
        public override string ToString()
        {
            string s = "Individuo: " + "k1: " + k1.VD.ToString() + ", " + "k2: " + k2.VD.ToString() + ", " + "k3: " + k3.VD.ToString() + ". " + "Adecuación: " + adecuacion.ToString();
            return s;
        }
    }
}
