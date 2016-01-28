namespace Example
{
    partial class Form4
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
            this.time_comboBox = new System.Windows.Forms.ComboBox();
            this.time_label = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.data_lable = new System.Windows.Forms.Label();
            this.subject_label = new System.Windows.Forms.Label();
            this.name_subject_lable = new System.Windows.Forms.Label();
            this.group_label = new System.Windows.Forms.Label();
            this.group_name_label = new System.Windows.Forms.Label();
            this.topic_label = new System.Windows.Forms.Label();
            this.topic_textBox = new System.Windows.Forms.TextBox();
            this.OK_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // time_comboBox
            // 
            this.time_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.time_comboBox.FormattingEnabled = true;
            this.time_comboBox.Location = new System.Drawing.Point(12, 83);
            this.time_comboBox.Name = "time_comboBox";
            this.time_comboBox.Size = new System.Drawing.Size(260, 21);
            this.time_comboBox.TabIndex = 2;
            this.time_comboBox.SelectedIndexChanged += new System.EventHandler(this.time_comboBox_SelectedIndexChanged);
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(9, 67);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(43, 13);
            this.time_label.TabIndex = 1;
            this.time_label.Text = "Время:";
            this.time_label.Click += new System.EventHandler(this.time_label_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(12, 33);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(260, 20);
            this.dateTimePicker.TabIndex = 4;
            // 
            // data_lable
            // 
            this.data_lable.AutoSize = true;
            this.data_lable.Location = new System.Drawing.Point(9, 17);
            this.data_lable.Name = "data_lable";
            this.data_lable.Size = new System.Drawing.Size(36, 13);
            this.data_lable.TabIndex = 5;
            this.data_lable.Text = "Дата:";
            // 
            // subject_label
            // 
            this.subject_label.AutoSize = true;
            this.subject_label.Location = new System.Drawing.Point(9, 129);
            this.subject_label.Name = "subject_label";
            this.subject_label.Size = new System.Drawing.Size(55, 13);
            this.subject_label.TabIndex = 6;
            this.subject_label.Text = "Предмет:";
            this.subject_label.Click += new System.EventHandler(this.subject_label_Click);
            // 
            // name_subject_lable
            // 
            this.name_subject_lable.AutoSize = true;
            this.name_subject_lable.Location = new System.Drawing.Point(73, 129);
            this.name_subject_lable.Name = "name_subject_lable";
            this.name_subject_lable.Size = new System.Drawing.Size(123, 13);
            this.name_subject_lable.TabIndex = 7;
            this.name_subject_lable.Text = "%название предмета%";
            // 
            // group_label
            // 
            this.group_label.AutoSize = true;
            this.group_label.Location = new System.Drawing.Point(9, 151);
            this.group_label.Name = "group_label";
            this.group_label.Size = new System.Drawing.Size(45, 13);
            this.group_label.TabIndex = 8;
            this.group_label.Text = "Группа:";
            // 
            // group_name_label
            // 
            this.group_name_label.AutoSize = true;
            this.group_name_label.Location = new System.Drawing.Point(73, 151);
            this.group_name_label.Name = "group_name_label";
            this.group_name_label.Size = new System.Drawing.Size(110, 13);
            this.group_name_label.TabIndex = 9;
            this.group_name_label.Text = "%название группы%";
            // 
            // topic_label
            // 
            this.topic_label.AutoSize = true;
            this.topic_label.Location = new System.Drawing.Point(9, 191);
            this.topic_label.Name = "topic_label";
            this.topic_label.Size = new System.Drawing.Size(37, 13);
            this.topic_label.TabIndex = 10;
            this.topic_label.Text = "Тема:";
            // 
            // topic_textBox
            // 
            this.topic_textBox.Location = new System.Drawing.Point(76, 184);
            this.topic_textBox.Name = "topic_textBox";
            this.topic_textBox.Size = new System.Drawing.Size(196, 20);
            this.topic_textBox.TabIndex = 0;
            // 
            // OK_button
            // 
            this.OK_button.Location = new System.Drawing.Point(99, 232);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(75, 23);
            this.OK_button.TabIndex = 1;
            this.OK_button.Text = "OK";
            this.OK_button.UseVisualStyleBackColor = true;
            this.OK_button.Click += new System.EventHandler(this.OK_button_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 267);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.topic_textBox);
            this.Controls.Add(this.topic_label);
            this.Controls.Add(this.group_name_label);
            this.Controls.Add(this.group_label);
            this.Controls.Add(this.name_subject_lable);
            this.Controls.Add(this.subject_label);
            this.Controls.Add(this.data_lable);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.time_comboBox);
            this.Name = "Form4";
            this.Text = "Начало урока";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox time_comboBox;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label data_lable;
        private System.Windows.Forms.Label subject_label;
        private System.Windows.Forms.Label name_subject_lable;
        private System.Windows.Forms.Label group_label;
        private System.Windows.Forms.Label group_name_label;
        private System.Windows.Forms.Label topic_label;
        private System.Windows.Forms.TextBox topic_textBox;
        private System.Windows.Forms.Button OK_button;
    }
}