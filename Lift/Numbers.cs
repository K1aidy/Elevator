using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lift
{
    public class Numbers
    {
        private Image[] numbers = {Properties.Resources.zero,
        Properties.Resources.one,
        Properties.Resources.two,
        Properties.Resources.three,
        Properties.Resources.four,
        Properties.Resources.five,
        Properties.Resources.six,
        Properties.Resources.seven,
        Properties.Resources.eight,
        Properties.Resources.nine};

        public Image[] NumbersProp
        {
            get
            {
                return numbers;
            }
        }
    }
}
