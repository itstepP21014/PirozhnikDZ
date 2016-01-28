namespace Example
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.new_password_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.check_new_password_textBox = new System.Windows.Forms.TextBox();
            this.OK_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите новый пароль:";
            // 
            // new_password_textBox
            // 
            this.new_password_textBox.Location = new System.Drawing.Point(38, 47);
            this.new_password_textBox.Name = "new_password_textBox";
            this.new_password_textBox.Size = new System.Drawing.Size(219, 20);
            this.new_password_textBox.TabIndex = 0;
            this.new_password_textBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Подтверждение пароля:";
            // 
            // check_new_password_textBox
            // 
            this.check_new_password_textBox.Location = new System.Drawing.Point(38, 106);
            this.check_new_password_textBox.Name = "check_new_password_textBox";
            this.check_new_password_textBox.Size = new System.Drawing.Size(219, 20);
            this.check_new_password_textBox.TabIndex = 1;
            this.check_new_password_textBox.UseSystemPasswordChar = true;
            // 
            // OK_button
            // 
            this.OK_button.Location = new System.Drawing.Point(103, 145);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(75, 23);
            this.OK_button.TabIndex = 2;
            this.OK_button.Text = "ОК";
            this.OK_button.UseVisualStyleBackColor = true;
            this.OK_button.Click += new System.EventHandler(this.OK_button_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 181);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.check_new_password_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.new_password_textBox);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Смена пароля";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox new_password_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox check_new_password_textBox;
        private System.Windows.Forms.Button OK_button;
    }
}