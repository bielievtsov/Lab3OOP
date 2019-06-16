using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLEDNYA_LBA
{
    class Time
    {
        public Time()
        {

        }
        public int sec;
        public  int min;
        public int value { get; set; } = 0;


        public void tick()
        {
            sec++;
            if (sec > 59)
            {
                min++;
                sec = 0;
            }
        }
    }
}
