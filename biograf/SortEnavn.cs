using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biograf.Model;

namespace biograf
{
    class SortEnavn : IComparer<Kunder>
    {
        public int Compare(Kunder x, Kunder y)
        {
            return string.Compare(x.Enavn, y.Enavn);
        }
    }
}
