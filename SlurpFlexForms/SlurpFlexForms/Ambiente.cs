using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.IO;

namespace SLURP_Y_FLEX
{
    public class Ambiente
    {
        public Point[] punto = new Point[50];
        int i = 0;
        public Ambiente()
        {
            i = 0;
            StreamReader sr = new StreamReader(@"../../Equipo6.csv");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] valor = line.Split(new char[] { ',' });
                punto[i] = new Point(Double.Parse(valor[0]), Double.Parse(valor[1]));
                i++;
            }
        }
    }
}
