using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault_Calculator
{
    class Ring
    {

        private int _sum = 0;
        public int Sum { get { return _sum; } }
        private int _start;
        public int Start { get { return _start; } set { _start = value; } }
        private int _rings;
        public int Rings { get { return _rings; } set { _rings = value; } }
        private int _space;
        public int Space { get { return _space; } set { _space = value; } }

        public Ring()
        {
            _space = 0;
            _rings = 0;
            _start = 0;
        }

        public int TotalCost()
        {
            _sum = 0;

            for (int r = _start; r < _start + _rings * _space; r += _space)
            {
                _sum = SingleCost(r);
            }

            return _sum;
        }

        public int SingleCost(int r)
        {
            if (r > 3)
                return 4 * ((int)((r - 3) * Math.Sqrt(2))) + 20;
            else if (r != 0)
                return 4 * r + 4;
            else
                return 0;
        }
    }
}
