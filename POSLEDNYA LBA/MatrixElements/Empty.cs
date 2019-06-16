using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace POSLEDNYA_LBA.MatrixElements
{
    class Empty : Cell
    {
        public Empty(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            Icon = Resource.Empty;
        }

    }
}
