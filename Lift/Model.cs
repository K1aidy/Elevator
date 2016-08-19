using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Lift
{
    
    public class Model
    {
        #region Поля
        Numbers numbers_start = new Numbers();
        Image first_number;
        Image second_number;
        int number_count = 10;
        Point elevator_point;
        public Point rope_begin;
        public Point rope_end;
        Status_app st_app;
        Elevator elevator;
        List<People> peoples_1;
        Queue<People>[] peoples;
        Queue<People>[] peoples_exit;
        Priority_mass pM;
        //постоянные переменные для расчетов
        const int max_dist = 164;
        const int begin_exit_dist = 190;
        const int end_distance = 318;
        public int zero_level = 660;
        //временные поля для расчетов
        public List<People> temp;
        int[] amount_people_level;
        bool temp_3;
        int temp_4=0;
        //поля для рандомного создания людей
        static Random rnd = new Random();
        public Timer timer;
        public TimerCallback tm;
        #endregion
        #region Свойства
        public Numbers Numbers_start
        {
            get
            {
                return numbers_start;
            }

            set
            {
                numbers_start = value;
            }
        }
        public Image First_number
        {
            get
            {
                return first_number;
            }

            set
            {
                first_number = value;
            }
        }
        public Image Second_number
        {
            get
            {
                return second_number;
            }

            set
            {
                second_number = value;
            }
        }
        public int Number_count
        {
            get
            {
                return number_count;
            }

            set
            {
                number_count = value;
            }
        }
        public Point Elevator_point
        {
            get
            {
                return elevator_point;
            }

            set
            {
                elevator_point = value;
            }
        }
        public Status_app St_app
        {
            get
            {
                return st_app;
            }

            set
            {
                st_app = value;
            }
        }
        public Elevator Elevator
        {
            get
            {
                return elevator;
            }

            set
            {
                elevator = value;
            }
        }
        public List<People> Peoples_1
        {
            get
            {
                return peoples_1;
            }

            set
            {
                peoples_1 = value;
            }
        }
        public Queue<People>[] Peoples
        {
            get
            {
                return peoples;
            }

            set
            {
                peoples = value;
            }
        }
        public Queue<People>[] Peoples_exit
        {
            get
            {
                return peoples_exit;
            }

            set
            {
                peoples_exit = value;
            }
        }
        public Priority_mass PM
        {
            get
            {
                return pM;
            }

            set
            {
                pM = value;
            }
        }
        #endregion
        #region Конструктор
        public Model()
        { 
            First_number = Numbers_start.NumbersProp[Number_count/10];
            Second_number = Numbers_start.NumbersProp[Number_count % 10];
            Elevator = new Elevator();
            Peoples_1 = new List<People>();
            Elevator_point = new Point(172, Elevator.Y);
            St_app = Status_app.stop;            
        }
        #endregion
        #region Методы
        #region Инициализация коллекций и прочее
        public void InitializationModel()
        {           
            Peoples = new Queue<People>[Number_count];
            for (int i = 0; i < Peoples.Count(); i++)
                Peoples[i] = new Queue<People>();
            Peoples_exit = new Queue<People>[Number_count];
            for (int i = 0; i < Peoples_exit.Count(); i++)
                Peoples_exit[i] = new Queue<People>();
                Koord_Rope();
            temp = new List<People>();
            PM = new Priority_mass(Number_count);
            tm = new TimerCallback(Create_people);
            St_app = Status_app.play;
            Elevator.Min_y = 660 - Number_count * 20;

        }
        #endregion
        #region Создание людей
        public void Create_people(object number)
        {
            int y = (int) number;
                y = rnd.Next(0, y);
            if(St_app == Status_app.play)
            Peoples_1.Add(new People(660 -(y+1)*20+1, Number_count));
        }
        #endregion
        #region Присваивание семисегментникам в начальном меню значений
        public void Run()
        {
            First_number = Numbers_start.NumbersProp[Number_count / 10];
            Second_number = Numbers_start.NumbersProp[Number_count % 10];
        }
        #endregion
        #region Измеряем начало и конец троса лифта
        public void Koord_Rope()
        {
            rope_begin.X = 179;
            rope_begin.Y = 660 - (Number_count * 20);
            rope_end.X = 179;
            rope_end.Y = Elevator.Y;
            amount_people_level = new int[Number_count];
        }
        #endregion
        #region Этот метод проверяет, надо ли кому-то из пассажиров выходить на данном этаже
        bool Exit_elevator(List<People> peoples)
        {
            foreach(People p in peoples)
            {
                if (p.End_level == Elevator.Now_level) return true;
            }
            return false;
        }
        #endregion
        #region Основной метод с алгоритмами
        public void Doing()
        {
            while(St_app == Status_app.play) //при попытке закрыть приложение появится MessageBox, 
                                             //сменится статус на stop и
                                             //завершится поток, в котором запускался метод Doing()
            {
                //перенос людей из общева массива в массивы по этажам
                foreach (People p in Peoples_1)
                {
                    Peoples[p.Begin_level].Enqueue(p);
                }
                Peoples_1.Clear();
                #region Заполнение массива кнопок вызова лифта
                for (int i = 0; i < Number_count; i++)
                {
                    if ((from p in Peoples[i] where p.Call_elevator == true select p).Count() > 0
                        && Elevator.Passangers.Count == 0)
                    {
                        Elevator.Running = true;
                        PM.Massiv_priority[i]++;
                    }
                    else PM.Massiv_priority[i] = 0;
                }
                #endregion
                #region Хождение людей к лифту
                foreach (int a in amount_people_level)
                    amount_people_level[a]=0;//сброс счетчиков на каждом этаже
                
                for (int i = 0; i < Peoples.Count(); i++)
                {
                    if(Peoples[i] !=null)
                    foreach (People people in Peoples[i])
                    {
                        people.Run(max_dist, amount_people_level[people.Begin_level]++);
                    }
                }
                #endregion
                #region Хождение людей по этажу к выходу
                for (int i = 0; i < Peoples_exit.Count(); i++)
                {
                    if (Peoples_exit[i] != null)
                        foreach (People people in Peoples_exit[i])
                        {
                            temp_3 = people.Run_to_exit(end_distance);
                            if (temp_3) break;
                        }
                    if (temp_3 && Peoples_exit[i].Count >0) Peoples_exit[i].Dequeue();//Clear(); 
                }
                #endregion
                #region Выгрузка пассажиров
                if ((from p in Elevator.Passangers where p.End_level==Elevator.Now_level select p).Count() > 0 && Elevator.Y%20==0)
                {
                    Elevator.Running = false;
                }
                if (Elevator.Passangers != null)
                    if (Elevator.Passangers.Count() > 0 && Elevator.Running == false && Exit_elevator(Elevator.Passangers))
                    {
                        //разделяем массив пассажиров на тех, кому надо выйти, и тех, кому не надо выходить
                        List<People> temp1 = (from p in Elevator.Passangers where (p.End_level == Elevator.Now_level) select p).ToList<People>();
                        List<People> temp2 = (from p in Elevator.Passangers where (p.End_level != Elevator.Now_level) select p).ToList<People>();
                        Elevator.Passangers.Clear();
                        foreach (People p in temp2) Elevator.Passangers.Add(p);
                        amount_people_level[Elevator.Now_level] = 1;//сброс счетчиков на данном этаже
                        foreach (People p in temp1)
                        {
                            p.X = begin_exit_dist - (amount_people_level[Elevator.Now_level]++) * 8;//задаем начальную координату, с которой люди пойдут на выход
                            p.Y = 640 - (Elevator.Now_level * 20);// задаем координату Y на выход
                            Peoples_exit[Elevator.Now_level].Enqueue(p);
                        }
                        Elevator.Running = true;
                    }
                #endregion
                #region Определим направление движения лифта
                if (Elevator.Passangers.Count() > 0)
                {
                    temp_4 = 0;
                    foreach (People p in Elevator.Passangers)
                    {
                        if (Math.Abs(temp_4) < Math.Abs(Elevator.Now_level - p.End_level))
                            temp_4 = Elevator.Now_level - p.End_level;
                    }
                    if (temp_4 < 0) Elevator.Delta_y = -1; else Elevator.Delta_y = 1;
                    //elevator.Running = true;                     
                }
                else
                {
                    temp_4 = 0;
                    for(int i=0;i< PM.Massiv_priority.Count(); i++)
                    {
                        if (PM.Massiv_priority[i] > 0) temp_4 = i;
                    }
                    if (Elevator.Now_level > temp_4) Elevator.Delta_y = 1;
                    else if (Elevator.Now_level < temp_4) Elevator.Delta_y = -1;
                    else if (Elevator.Y%20==0){
                        Elevator.Running = false;
                        Elevator.Change_of_direction();
                         } 
                }
                #endregion
                #region загрузка пассажиров в лифт
                if (Peoples[Elevator.Now_level] != null)
                    if (Peoples[Elevator.Now_level].Count() > 0)
                        if (Peoples[Elevator.Now_level].Peek().X == max_dist &&
                            Elevator.Passangers.Count() < Elevator.Carrying &&
                            /*elevator.Running == false &&*/ Elevator.Y % 20 == 0)
                            if ((Elevator.Now_level == 0) || (Elevator.Now_level != 0 && Elevator.Delta_y == 1))
                            {
                                Elevator.Running = false;
                                Elevator.Passangers.Add(Peoples[Elevator.Now_level].Dequeue());
                                if (Peoples[Elevator.Now_level] != null)
                                    if (Peoples[Elevator.Now_level].Count() == 0)
                                        Elevator.Running = true;
                                    else if (max_dist - Peoples[Elevator.Now_level].Peek().X > 50 || Elevator.Passangers.Count() == Elevator.Carrying)
                                        Elevator.Running = true;
                                    else Elevator.Running = false;
                            }
                            //else elevator.Running = true;

                #endregion
                if (Elevator.Running) Elevator.Run_Elevator();
                Koord_Rope(); // репозиционирование троса
                Thread.Sleep(20);
            }
        }
        #endregion
        #endregion
    }
}
