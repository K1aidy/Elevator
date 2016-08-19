using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Lift
{
    public partial class Viewhead : UserControl
    {
        Model model;
        public Viewhead(Model model) // связываем пользовательский интерфейс с моделью в конструкторе
        {
            InitializeComponent();
            this.model = model;

        }
        //переопределим OnPaint для рисования элементов
        protected override void OnPaint(PaintEventArgs e)
        {
                DrawLevel(e);
            try
            {
                //блок try-catch стоит из-за ограничений для перебирания коллекции Queue в foreach
                DrawPeople(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Скажите разработчику этого приложения, что эксепшен никуда не делся :( \n"+ex.Message);
            }           
            finally
            {
                if (model.St_app == Status_app.play) //при попытке закрыть приложение, процесс рисования остановится
                {
                    DrawExitPeople(e);
                    DrawElevator(e);
                    Invalidate();
                    Thread.Sleep(20);
                }
            }           
        }

        #region Рисуем людей, идущих на выход
        private void DrawExitPeople(PaintEventArgs e)
        {
            for (int i = 0; i < model.Peoples_exit.Count(); i++)
                if (model.Peoples_exit[i] != null)
                    foreach (People people in model.Peoples_exit[i])
                    {
                        if(people.X>190 && people.X < 317)
                        e.Graphics.DrawImage(people.People_image, people.X, people.Y);
                    }
        }
        #endregion
        #region Рисуем людей, идущих к лифту
        private void DrawPeople(PaintEventArgs e)
        {
            for (int i = 0; i< model.Peoples.Count(); i++)
                if (model.Peoples[i]!=null)
            foreach (People people in model.Peoples[i])
            {
                        if(people.X>30)
                e.Graphics.DrawImage(people.People_image, people.X, people.Y);
            }
        }
        #endregion
        #region Рисуем здание
        void DrawLevel(PaintEventArgs e)
        {
            for (int i = 1; i <= model.Number_count; i++)
            {
                e.Graphics.DrawImage(Properties.Resources.one_level_of_house, new Point(30, 660 - (i * 20)));
                e.Graphics.DrawImage(Properties.Resources.elevator_shaft_20x20, new Point(171, 660 - (i * 20)));
            }
        }
        #endregion
        #region рисуем лифт
        void DrawElevator(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.elevator_16x20,model.Elevator.X,model.Elevator.Y);
            for (int i=model.rope_begin.Y; i<model.rope_end.Y;i++)
            {
                e.Graphics.DrawImage(Properties.Resources.rope, new Point(model.rope_begin.X,i));
            }
        }
        #endregion
    }
}
