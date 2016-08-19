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
    public partial class View : UserControl
    {
        Model model;
        public View(Model model) // связываем пользовательский интерфейс с моделью в конструкторе
        {
            InitializeComponent();
            this.model = model;
        }
        //Переопределяем метод OnPaint()
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawNumbers(e);   
        }
        #region Рисуем цифры номера этажа
        private void DrawNumbers(PaintEventArgs e)
        {
            e.Graphics.DrawImage(model.First_number, new Point(0, 0));
            e.Graphics.DrawImage(model.Second_number, new Point(20, 0));
        }
        #endregion
    }
}
