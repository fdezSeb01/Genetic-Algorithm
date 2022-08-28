using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLURP_Y_FLEX
{
    public class Poblacion
    {
        public List<Individuo> individuo = new List<Individuo>(); //50 individuos por poblacion
        Random r = new Random();
        public Ambiente ambiente = new Ambiente();
        int a, b;
        string s;
        List<int> Seleccionados = new List<int>();// se guardan los individuos que se van a cruzar
        public override string ToString()
        {
            for (int i = 0; i < individuo.Count; i++)
            {
                s = "Individuo " + (i + 1) + ": " + "k1: " + individuo[i].k1.VD.ToString() + ", " + "k2: " + individuo[i].k2.VD.ToString() + ", " + "k3: " + individuo[i].k3.VD.ToString() + ". " + "Adecuación: " + individuo[i].adecuacion.ToString();
                Console.WriteLine(s);
            }
            return "";
        }
        public void PoblacionAleatoria()
        {
            int entero;
            double deciml;
            double[] k = new double[3];
            for (int i = 0;i<100;i++)
            {
                for (int j =0;j<3;j++)
                {
                    entero = r.Next(0, 8);
                    deciml = r.Next(0, 16777214);//16777214
                    deciml = deciml / (Math.Pow(10, deciml.ToString().Length));
                    k[j] = entero + deciml;
                }
                individuo.Add(new Individuo(k[0],k[1],k[2],ambiente));
            }
        }
        public void OrdenarPoblacion()
        {
            individuo.Sort(new Comparer());
        }
        public void CruzarPoblacion()
        {
            for (int i = 0; i< 20; i++)
            {
                if (i >=0 && i <= 8)
                {
                    do
                    {
                        b = r.Next(0, 20);
                    
                    } while (Seleccionados.Contains(b));
                    Seleccionados.Add(b);
                    //Console.WriteLine(b+1);
                }
                else
                     if (i >= 9 && i <= 12)
                {
                    do
                    {
                        b = r.Next(0, 20);

                    } while (Seleccionados.Contains(b+20));
                    Seleccionados.Add(b+20);
                    //Console.WriteLine(b + 21);
                }
                else
                     if (i >= 13 && i <= 15)
                {
                    do
                    {
                        b = r.Next(0, 20);

                    } while (Seleccionados.Contains(b+40));
                    Seleccionados.Add(b+40);
                    //Console.WriteLine(b + 41);
                }
                else
                     if (i >= 16 && i <= 17)
                {
                    do
                    {
                        b = r.Next(0, 20);

                    } while (Seleccionados.Contains(b+60));
                    Seleccionados.Add(b+60);
                    //Console.WriteLine(b + 61);
                }
                else
                     if (i >= 18 && i <= 19)
                {
                    do
                    {
                        b = r.Next(0, 20);

                    } while (Seleccionados.Contains(b+80));
                    Seleccionados.Add(b+80);
                    //Console.WriteLine(b + 81);
                }            
            }
            for (int j = 0; j < 10; j++)
            {
                individuo.Add(Cruza(individuo[Seleccionados[j]], individuo[Seleccionados[j + 10]]));
                individuo.Add(Cruza(individuo[Seleccionados[j+10]], individuo[Seleccionados[j]]));
            }
            Seleccionados.Clear();
            OrdenarPoblacion();
        }
        public Individuo Cruza(Individuo i1, Individuo i2)
        {
            int rnd = r.Next(6, 30);
            Individuo hijo =new Individuo(1.1,1.1,1.1,ambiente);
            bool[] tempk1 = new bool[34];
            bool[] tempk2 = new bool[34];
            bool[] tempk3 = new bool[34];
            for (int i =0; i< rnd;i++)
            {
                tempk1[i] = i1.k1.VBA.Get(i);
                tempk2[i] = i1.k2.VBA.Get(i);
                tempk3[i] = i1.k3.VBA.Get(i);
            }
            for (int j = rnd; j < 34; j++)
            {
                tempk1[j] = i2.k1.VBA.Get(j);
                tempk2[j] = i2.k2.VBA.Get(j);
                tempk3[j] = i2.k3.VBA.Get(j);
            }
            hijo.k1.VBA = new BitArray(tempk1);
            hijo.k2.VBA = new BitArray(tempk2);
            hijo.k3.VBA = new BitArray(tempk3);
            hijo.k1.ValorDouble();
            hijo.k2.ValorDouble();
            hijo.k3.ValorDouble();
            hijo.CalcularAdecuacion();
            return hijo;
        }
        public void mutarIndividuo(int x)
        {
                a = r.Next(0, 3);
                //Console.WriteLine("     " + a + "  " + b);
                switch (a)
                {
                case 0:
                    individuo[x].Mutar(individuo[x].k1, r.Next(7, 34), r.Next(7, 34), r.Next(7, 34), r.Next(7, 34), r.Next(7, 34));
                    individuo[x].k1.ValorDouble();
                    individuo[x].Mutar(individuo[x].k2, r.Next(7, 34), r.Next(7, 34), r.Next(7, 34), r.Next(7, 34), r.Next(7, 34));
                    individuo[x].k2.ValorDouble();
                    break;
                case 1:
                    individuo[x].Mutar(individuo[x].k2, r.Next(7, 34), r.Next(7, 34), r.Next(7, 34), r.Next(7, 34), r.Next(7, 34));
                    individuo[x].k2.ValorDouble();
                    individuo[x].Mutar(individuo[x].k3, r.Next(7, 34), r.Next(7, 34), r.Next(7, 34), r.Next(7, 34), r.Next(7, 34));
                    individuo[x].k3.ValorDouble();
                    break;
                case 2:
                    individuo[x].Mutar(individuo[x].k3, r.Next(7, 34), r.Next(7, 34), r.Next(7, 34), r.Next(7, 34), r.Next(7, 34));
                    individuo[x].k3.ValorDouble();
                    individuo[x].Mutar(individuo[x].k1, r.Next(7, 34), r.Next(7, 34), r.Next(7, 34), r.Next(7, 34), r.Next(7, 34));
                    individuo[x].k1.ValorDouble();
                    break;
            }
            individuo[x].CalcularAdecuacion();
        }
        public void mutarPoblacion()
        {
            for(int i =0; i<30;i++)
            {
                do
                {
                    a = r.Next(1, 100);
                } while (Seleccionados.Contains(a));
                Seleccionados.Add(a);
                //Console.WriteLine(a);
                mutarIndividuo(a);
            }
            Seleccionados.Clear();
            OrdenarPoblacion();
        }
        public void Mochacion()
        {
            for(int i = 19; i>=0;i--)
            {
                individuo.RemoveAt(i+100);
            }
        }
    }
}
