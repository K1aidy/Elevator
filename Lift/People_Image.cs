using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lift
{
    public class People_Image
    {
        Image[] image = {Properties.Resources.people_0, Properties.Resources.people_1, Properties.Resources.people_2 };
        public Image[] Image
        {
            get
            {
                return image;
            }
        }
    }
}
