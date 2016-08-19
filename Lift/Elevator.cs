using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{
    public class Elevator
    {
        #region Поля
        const int x=172;
        int y;
        int carrying; // грузоподъемность
        int delta_y=-1;
        int min_y; //на всякий случай, чтобы лифт не уехал в небо :)
        bool running=false;
        int now_level = 0;
        List<People> passangers;
        #endregion
        #region Свойства полей
        public int X
        {
            get
            {
                return x;
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
                if (value <=640 && value>=Min_y)
                y = value;
            }
        }
        public int Carrying
        {
            get
            {
                return carrying;
            }

            set
            {
                if (value>0)
                carrying = value;
            }
        }
        public int Delta_y
        {
            get
            {
                return delta_y;
            }

            set
            {
                if (value==-1||value==1)
                delta_y = value;
            }
        }
        public int Min_y
        {
            get
            {
                return min_y;
            }

            set
            {
                min_y = value;
            }
        }
        public bool Running
        {
            get
            {
                return running;
            }

            set
            {
                running = value;
            }
        }
        public List<People> Passangers
        {
            get
            {
                return passangers;
            }

            set
            {
                passangers = value;
            }
        }
        public int Now_level
        {
            get
            {
                return now_level;
            }

            set
            {
                now_level = value;
            }
        }
        #endregion
        #region Конструктор лифта
        public Elevator(int y=640, int carrying=6)
        {
            this.Y = y;
            this.Carrying = carrying;
            this.Delta_y = -1;
            Passangers = new List<People>();
        }
        #endregion
        #region Методы
        //Движение лифта, согласно заданному направлению
        public void Run_Elevator()
        {            
            Y += Delta_y;
            Now_level = (640 - Y) / 20;
        }
        //Смена направления
        public void Change_of_direction()
        {
            Delta_y = -Delta_y;
        }
        #endregion
    }
}
