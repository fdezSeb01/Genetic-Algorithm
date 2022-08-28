using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLURP_Y_FLEX
{
    class Comparer: IComparer<Individuo>
    {
        public int Compare(Individuo x, Individuo y)
        {
            if (x.adecuacion > y.adecuacion)
            {
                return 1;
            }
            if (x.adecuacion < y.adecuacion)
            {
                return -1;
            }
            return 0;
        }

        
    }
}
