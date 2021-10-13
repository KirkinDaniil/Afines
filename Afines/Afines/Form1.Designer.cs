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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pointDrawer = new System.Windows.Forms.Button();
            this.edgeDrawer = new System.Windows.Forms.Button();
            this.squareDrawer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(32, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(746, 407);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // pointDrawer
            // 
            this.pointDrawer.Location = new System.Drawing.Point(69, 439);
            this.pointDrawer.Name = "pointDrawer";
            this.pointDrawer.Size = new System.Drawing.Size(75, 23);
            this.pointDrawer.TabIndex = 1;
            this.pointDrawer.Text = "pointDrawer";
            this.pointDrawer.UseVisualStyleBackColor = true;
            this.pointDrawer.Click += new System.EventHandler(this.pointDrawer_Click);
            // 
            // edgeDrawer
            // 
            this.edgeDrawer.Location = new System.Drawing.Point(150, 439);
            this.edgeDrawer.Name = "edgeDrawer";
            this.edgeDrawer.Size = new System.Drawing.Size(75, 23);
            this.edgeDrawer.TabIndex = 2;
            this.edgeDrawer.Text = "EdgeDrawer";
            this.edgeDrawer.UseVisualStyleBackColor = true;
            this.edgeDrawer.Click += new System.EventHandler(this.edgeDrawer_Click);
            // 
            // squareDrawer
            // 
            this.squareDrawer.Location = new System.Drawing.Point(231, 439);
            this.squareDrawer.Name = "squareDrawer";
            this.squareDrawer.Size = new System.Drawing.Size(75, 23);
            this.squareDrawer.TabIndex = 3;
            this.squareDrawer.Text = "SquareDrawer";
            this.squareDrawer.UseVisualStyleBackColor = true;
            this.squareDrawer.Click += new System.EventHandler(this.squareDrawer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 493);
            this.Controls.Add(this.squareDrawer);
            this.Controls.Add(this.edgeDrawer);
            this.Controls.Add(this.pointDrawer);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button pointDrawer;
        private System.Windows.Forms.Button edgeDrawer;
        private System.Windows.Forms.Button squareDrawer;
    }
}

