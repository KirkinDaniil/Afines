namespace Afines
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.MovingPoint = new System.Windows.Forms.Button();
            this.DXScroll = new System.Windows.Forms.VScrollBar();
            this.DYScroll = new System.Windows.Forms.VScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RotateScroll = new System.Windows.Forms.HScrollBar();
            this.label4 = new System.Windows.Forms.Label();
            this.ScaleScroll = new System.Windows.Forms.HScrollBar();
            this.label5 = new System.Windows.Forms.Label();
            this.Clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(353, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(758, 603);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "polygon";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.polygonDrawer_Click);
            // 
            // MovingPoint
            // 
            this.MovingPoint.AllowDrop = true;
            this.MovingPoint.BackColor = System.Drawing.Color.Transparent;
            this.MovingPoint.Image = ((System.Drawing.Image)(resources.GetObject("MovingPoint.Image")));
            this.MovingPoint.Location = new System.Drawing.Point(679, 307);
            this.MovingPoint.Name = "MovingPoint";
            this.MovingPoint.Size = new System.Drawing.Size(61, 62);
            this.MovingPoint.TabIndex = 5;
            this.MovingPoint.UseVisualStyleBackColor = false;
            // 
            // DXScroll
            // 
            this.DXScroll.Location = new System.Drawing.Point(12, 124);
            this.DXScroll.Maximum = 500;
            this.DXScroll.Minimum = -500;
            this.DXScroll.Name = "DXScroll";
            this.DXScroll.Size = new System.Drawing.Size(21, 159);
            this.DXScroll.TabIndex = 6;
            this.DXScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DXScroll_Scroll);
            // 
            // DYScroll
            // 
            this.DYScroll.Location = new System.Drawing.Point(66, 124);
            this.DYScroll.Maximum = 500;
            this.DYScroll.Minimum = -500;
            this.DYScroll.Name = "DYScroll";
            this.DYScroll.Size = new System.Drawing.Size(21, 159);
            this.DYScroll.TabIndex = 7;
            this.DYScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DYScroll_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "смещение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "dx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "dy";
            // 
            // RotateScroll
            // 
            this.RotateScroll.Location = new System.Drawing.Point(9, 365);
            this.RotateScroll.Maximum = 360;
            this.RotateScroll.Name = "RotateScroll";
            this.RotateScroll.Size = new System.Drawing.Size(179, 25);
            this.RotateScroll.TabIndex = 11;
            this.RotateScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.RotateScroll_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "поворот вокруг точки";
            // 
            // ScaleScroll
            // 
            this.ScaleScroll.Location = new System.Drawing.Point(12, 424);
            this.ScaleScroll.Minimum = -100;
            this.ScaleScroll.Name = "ScaleScroll";
            this.ScaleScroll.Size = new System.Drawing.Size(176, 25);
            this.ScaleScroll.TabIndex = 14;
            this.ScaleScroll.Value = 1;
            this.ScaleScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScaleScroll_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "масштабирование относительно точки";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(11, 50);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 32);
            this.Clear.TabIndex = 16;
            this.Clear.Text = "clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 627);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ScaleScroll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RotateScroll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DYScroll);
            this.Controls.Add(this.DXScroll);
            this.Controls.Add(this.MovingPoint);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button MovingPoint;
        private System.Windows.Forms.VScrollBar DXScroll;
        private System.Windows.Forms.VScrollBar DYScroll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.HScrollBar RotateScroll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.HScrollBar ScaleScroll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Clear;
    }
}

