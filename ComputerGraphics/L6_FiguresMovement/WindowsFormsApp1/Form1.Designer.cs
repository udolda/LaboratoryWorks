namespace WindowsFormsApp1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PB = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SnakeRB = new System.Windows.Forms.RadioButton();
            this.BiliardRB = new System.Windows.Forms.RadioButton();
            this.PlanetRB = new System.Windows.Forms.RadioButton();
            this.PingPongRB = new System.Windows.Forms.RadioButton();
            this.StartStopButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PB)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PB
            // 
            this.PB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.PB.Location = new System.Drawing.Point(16, 85);
            this.PB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(800, 431);
            this.PB.TabIndex = 1;
            this.PB.TabStop = false;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SnakeRB);
            this.groupBox1.Controls.Add(this.BiliardRB);
            this.groupBox1.Controls.Add(this.PlanetRB);
            this.groupBox1.Controls.Add(this.PingPongRB);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(800, 65);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите задание";
            // 
            // SnakeRB
            // 
            this.SnakeRB.AutoSize = true;
            this.SnakeRB.Location = new System.Drawing.Point(458, 23);
            this.SnakeRB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SnakeRB.Name = "SnakeRB";
            this.SnakeRB.Size = new System.Drawing.Size(76, 21);
            this.SnakeRB.TabIndex = 3;
            this.SnakeRB.Text = "змейка";
            this.SnakeRB.UseVisualStyleBackColor = true;
            this.SnakeRB.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // BiliardRB
            // 
            this.BiliardRB.AutoSize = true;
            this.BiliardRB.Location = new System.Drawing.Point(635, 23);
            this.BiliardRB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BiliardRB.Name = "BiliardRB";
            this.BiliardRB.Size = new System.Drawing.Size(157, 21);
            this.BiliardRB.TabIndex = 2;
            this.BiliardRB.Text = "круг отск от границ";
            this.BiliardRB.UseVisualStyleBackColor = true;
            this.BiliardRB.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // PlanetRB
            // 
            this.PlanetRB.AutoSize = true;
            this.PlanetRB.Location = new System.Drawing.Point(184, 23);
            this.PlanetRB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PlanetRB.Name = "PlanetRB";
            this.PlanetRB.Size = new System.Drawing.Size(185, 21);
            this.PlanetRB.TabIndex = 1;
            this.PlanetRB.Text = "вращение кр по орбите";
            this.PlanetRB.UseVisualStyleBackColor = true;
            this.PlanetRB.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // PingPongRB
            // 
            this.PingPongRB.AutoSize = true;
            this.PingPongRB.Location = new System.Drawing.Point(8, 23);
            this.PingPongRB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PingPongRB.Name = "PingPongRB";
            this.PingPongRB.Size = new System.Drawing.Size(90, 21);
            this.PingPongRB.TabIndex = 0;
            this.PingPongRB.Text = "круг <-/->";
            this.PingPongRB.UseVisualStyleBackColor = true;
            this.PingPongRB.CheckedChanged += new System.EventHandler(this.RB_CheckedChanged);
            // 
            // StartStopButton
            // 
            this.StartStopButton.Enabled = false;
            this.StartStopButton.Location = new System.Drawing.Point(16, 521);
            this.StartStopButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(800, 62);
            this.StartStopButton.TabIndex = 3;
            this.StartStopButton.Text = "СТАРТ";
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 597);
            this.Controls.Add(this.StartStopButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Движение фигур";
            ((System.ComponentModel.ISupportInitialize)(this.PB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox PB;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton BiliardRB;
        private System.Windows.Forms.RadioButton PlanetRB;
        private System.Windows.Forms.RadioButton PingPongRB;
        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.RadioButton SnakeRB;
    }
}

