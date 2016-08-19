using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lift
{
    public class People
    {
        #region Поля
        static Random rnd=new Random();
        int x;
        int y;
        int begin_level;
        int end_level;
        int picture_count = 0;
        bool call_elevator = false;
        Image people_image;
        People_Image images = new People_Image();
        #endregion
        #region Свойства
        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
        public int Begin_level
        {
            get
            {
                return begin_level;
            }

            set
            {
                begin_level = value;
            }
        }
        public int End_level
        {
            get
            {
                return end_level;
            }

            set
            {
                end_level = value;
            }
        }
        public Image People_image
        {
            get
            {
                return people_image;
            }

            set
            {
                people_image = value;
            }
        }
        public bool Call_elevator
        {
            get
            {
                return call_elevator;
            }

            set
            {
                call_elevator = value;
            }
        }
        #endregion
        #region Конструктор
        public People(int y, int number_count)
        {
            this.X = 40;
            this.Y = y - y%20;
            this.Begin_level = (660 - y) / 20;
            People_image = images.Image[picture_count];
            #region Выбор этажа прибытия
            switch (Begin_level)
            {
                case 0:
                    this.End_level = rnd.Next(1, number_count);
                    break;
                default:
                    this.End_level = 0;
                    break;
            }
            #endregion
        }
        #endregion
        #region Методы
        //Движение людей по направлению к лифту
        public void Run(int max_dist, int index)
        {
            X++;
            if (X > max_dist-index*8) { X = max_dist-index*8; Call_elevator = true; }

            Select_Picture();
        }
        //Движение людей к выходу
        public bool Run_to_exit(int end_level)
        {
            X++;            
            Select_Picture();
            if (X > end_level+48) { X = end_level+48; return true; }
            return false;
        }
        //Анимация движения людей
        public void Select_Picture()
        {
            picture_count++;
            if (picture_count > 2) picture_count = 0;
            People_image = images.Image[picture_count];
        }
        #endregion
    }
}
