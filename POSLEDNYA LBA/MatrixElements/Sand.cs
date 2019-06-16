using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLEDNYA_LBA.MatrixElements
{
    class Sand :Cell
    {
        public Sand(int X,  int Y)
        {
            this.X = X;
            this.Y = Y;
            Icon = Resource.Sand;
        }
    }
}
