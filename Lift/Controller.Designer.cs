namespace Lift
{
    partial class Controller
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controller));
            this.up_button = new System.Windows.Forms.Panel();
            this.down_button = new System.Windows.Forms.Panel();
            this.start_button = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // up_button
            // 
            this.up_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.up_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.up_button.Location = new System.Drawing.Point(64, 60);
            this.up_button.Name = "up_button";
            this.up_button.Size = new System.Drawing.Size(44, 39);
            this.up_button.TabIndex = 0;
            this.up_button.Click += new System.EventHandler(this.up_button_Click);
            this.up_button.DoubleClick += new System.EventHandler(this.up_button_DoubleClick);
            // 
            // down_button
            // 
            this.down_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.down_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.down_button.Location = new System.Drawing.Point(64, 148);
            this.down_button.Name = "down_button";
            this.down_button.Size = new System.Drawing.Size(44, 38);
            this.down_button.TabIndex = 1;
            this.down_button.Click += new System.EventHandler(this.down_button_Click);
            this.down_button.DoubleClick += new System.EventHandler(this.down_button_DoubleClick);
            // 
            // start_button
            // 
            this.start_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.start_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start_button.Location = new System.Drawing.Point(248, 104);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(43, 39);
            this.start_button.TabIndex = 2;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Location = new System.Drawing.Point(191, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выберите количество этажей:\n минимум - 6, максимум - 25.";
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Lift.Properties.Resources.Start;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(351, 245);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.down_button);
            this.Controls.Add(this.up_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(367, 283);
            this.MinimumSize = new System.Drawing.Size(367, 283);
            this.Name = "Controller";
            this.Text = "This is my Elevator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Controller_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel up_button;
        private System.Windows.Forms.Panel down_button;
        private System.Windows.Forms.Panel start_button;
        private System.Windows.Forms.Label label1;
    }
}

