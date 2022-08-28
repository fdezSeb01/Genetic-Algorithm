using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLURP_Y_FLEX
{
    public class Cromosoma
    {
        public double VD;
        public BitArray VBA;
        public int PosicionPunto = 10;

        public Cromosoma(double VD)
        {
            this.VD = VD;
            VBA = new BitArray(ValorBit(VD));
        }
        public bool[] ValorBit(double VD)
        {
            bool[] temp = new bool[34];
            string[] values = VD.ToString().Split('.');
            int pEntera = Int32.Parse(values[0]);
            int pDecimal = Int32.Parse(values[1]);
            for (int i = 9; i >= 0; i--)
            {
                temp[i] = (pEntera % 2 == 1);
                pEntera = pEntera / 2;
            }
            for (int i = 33; i >= 10; i--)
            {
                temp[i] = (pDecimal % 2 == 1);
                pDecimal = pDecimal / 2;
            }
            return temp;
        }
        public void ValorDouble()
        {
            double entero = 0, deciml = 0;
            int a;
            for (int i = 9; i >= 0; i--)
            {
                if (VBA.Get(i))
                    a = 1;
                else
                    a = 0;
                entero += (a * (Math.Pow(2, 9 - i)));
            }
            for (int i = 33; i >= 10; i--)
            {
                if (VBA.Get(i))
                    a = 1;
                else
                    a = 0;
                deciml += (a * (Math.Pow(2, 33 - i)));
            }
            deciml = deciml / (Math.Pow(10, deciml.ToString().Length));
            VD = entero + deciml;
        }
    }
}
