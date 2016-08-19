using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Threading;

namespace Lift
{
    public partial class Controller : Form
    {
        Thread program_flow;
        View view;
        Viewhead viewhead;
        Model model;
        public Controller()
        {
            model = new Model();
            view = new View(model);
            viewhead = new Viewhead(model);
            InitializeComponent();
            this.Controls.Add(view);
            
        }

        private void up_button_Click(object sender, EventArgs e)
        {
            if (model.Number_count < 25)
            {
                model.Number_count++;
                model.Run();
                view.Invalidate();
            }
        }

        private void down_button_Click(object sender, EventArgs e)
        {
            if (model.Number_count > 6)
            {
                model.Number_count--;
                model.Run();
                view.Invalidate();
            }
        }

        private void up_button_DoubleClick(object sender, EventArgs e)
        {
            if (model.Number_count < 25)
            {
                model.Number_count++;
                model.Run();
                view.Invalidate();
            }
        }

        private void down_button_DoubleClick(object sender, EventArgs e)
        {
            if (model.Number_count > 6)
            {
                model.Number_count--;
                model.Run();
                view.Invalidate();
            }
        }

        private void Controller_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(program_flow != null)
            {
                model.St_app = Status_app.stop;
                program_flow.Abort();
            }
            if (MessageBox.Show("Хотите выйти? ", "Выход из программы", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {               
                e.Cancel = false;
            }
            else { e.Cancel = true; model.St_app = Status_app.play;
                program_flow = new Thread(model.Doing);
                program_flow.Start();
                viewhead.Invalidate();
                }
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            //this.BackgroundImage;
            
            view.Visible = false;
            this.down_button.Visible = false;
            this.up_button.Visible = false;
            this.start_button.Visible = false;
            this.view.Visible = false;
            this.label1.Visible = false;
            //this.Controls.Clear();
            this.Controls.Add(viewhead);
            this.Height = 700;
            this.MaximumSize = new Size(367, 700);
            this.MinimumSize = new Size(367, 700);
            this.Location = new Point(500, 0);
            model.InitializationModel();            
            program_flow = new Thread(model.Doing);
            program_flow.Start();
            model.timer = new System.Threading.Timer(model.tm, model.Number_count, 0, 1000);

        }

       /* private void timer1_Tick(object sender, EventArgs e)
        {
            model.peoples_1.Add(new People(rnd.Next(660 - model.number_count, 661), model.number_count));
        }*/
    }
}
