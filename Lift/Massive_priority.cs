using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{
    //отдельный класс для массива был создан, так как изначально 
    //предполагался несколько более сложный алгоритм работы лифта
    public class Priority_mass
    {
        //поле
        int[] massiv_priority;
        //свойство
        public int[] Massiv_priority
        {
            get
            {
                return massiv_priority;
            }

            set
            {
                massiv_priority = value;
            }
        }
        //конструктор
        public  Priority_mass(int count)
        {
            Massiv_priority = new int[count];
        }
    }
}
