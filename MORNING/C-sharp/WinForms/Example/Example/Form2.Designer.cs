namespace Example
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.change_password_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.start_lesson_button = new System.Windows.Forms.Button();
            this.last_lessons_lable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // change_password_button
            // 
            this.change_password_button.Location = new System.Drawing.Point(146, 52);
            this.change_password_button.Name = "change_password_button";
            this.change_password_button.Size = new System.Drawing.Size(111, 23);
            this.change_password_button.TabIndex = 2;
            this.change_password_button.Text = "Сменить пароль";
            this.change_password_button.UseVisualStyleBackColor = true;
            this.change_password_button.Click += new System.EventHandler(this.change_password_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "здрасьте, %username% ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // start_lesson_button
            // 
            this.start_lesson_button.Location = new System.Drawing.Point(16, 52);
            this.start_lesson_button.Name = "start_lesson_button";
            this.start_lesson_button.Size = new System.Drawing.Size(111, 23);
            this.start_lesson_button.TabIndex = 0;
            this.start_lesson_button.Text = "Начать урок";
            this.start_lesson_button.UseVisualStyleBackColor = true;
            this.start_lesson_button.Click += new System.EventHandler(this.start_lesson_button_Click);
            // 
            // last_lessons_lable
            // 
            this.last_lessons_lable.Location = new System.Drawing.Point(16, 92);
            this.last_lessons_lable.Name = "last_lessons_lable";
            this.last_lessons_lable.Size = new System.Drawing.Size(241, 23);
            this.last_lessons_lable.TabIndex = 1;
            this.last_lessons_lable.Text = "Проссмотр занятий";
            this.last_lessons_lable.UseVisualStyleBackColor = true;
            this.last_lessons_lable.Click += new System.EventHandler(this.last_lessons_lable_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 146);
            this.Controls.Add(this.last_lessons_lable);
            this.Controls.Add(this.start_lesson_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.change_password_button);
            this.Name = "Form2";
            this.Text = "Добро пожаловать!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button change_password_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button start_lesson_button;
        private System.Windows.Forms.Button last_lessons_lable;
    }
}