namespace Example
{
    partial class Form5
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
            this.choise_kind_label = new System.Windows.Forms.Label();
            this.choise_kind_comboBox = new System.Windows.Forms.ComboBox();
            this.kind_label = new System.Windows.Forms.Label();
            this.kind_comboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // choise_kind_label
            // 
            this.choise_kind_label.AutoSize = true;
            this.choise_kind_label.Location = new System.Drawing.Point(13, 22);
            this.choise_kind_label.Name = "choise_kind_label";
            this.choise_kind_label.Size = new System.Drawing.Size(29, 13);
            this.choise_kind_label.TabIndex = 0;
            this.choise_kind_label.Text = "Вид:";
            // 
            // choise_kind_comboBox
            // 
            this.choise_kind_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.choise_kind_comboBox.FormattingEnabled = true;
            this.choise_kind_comboBox.Location = new System.Drawing.Point(137, 14);
            this.choise_kind_comboBox.Name = "choise_kind_comboBox";
            this.choise_kind_comboBox.Size = new System.Drawing.Size(249, 21);
            this.choise_kind_comboBox.TabIndex = 1;
            this.choise_kind_comboBox.SelectedIndexChanged += new System.EventHandler(this.choise_kind_comboBox_SelectedIndexChanged);
            // 
            // kind_label
            // 
            this.kind_label.AutoSize = true;
            this.kind_label.Location = new System.Drawing.Point(16, 56);
            this.kind_label.Name = "kind_label";
            this.kind_label.Size = new System.Drawing.Size(0, 13);
            this.kind_label.TabIndex = 2;
            // 
            // kind_comboBox
            // 
            this.kind_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kind_comboBox.FormattingEnabled = true;
            this.kind_comboBox.Location = new System.Drawing.Point(137, 48);
            this.kind_comboBox.Name = "kind_comboBox";
            this.kind_comboBox.Size = new System.Drawing.Size(249, 21);
            this.kind_comboBox.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.time,
            this.group,
            this.teacher,
            this.topic});
            this.dataGridView1.Location = new System.Drawing.Point(12, 99);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(671, 150);
            this.dataGridView1.TabIndex = 4;
            // 
            // date
            // 
            this.date.HeaderText = "ДАТА";
            this.date.Name = "date";
            // 
            // time
            // 
            this.time.HeaderText = "ВРЕМЯ";
            this.time.Name = "time";
            // 
            // group
            // 
            this.group.HeaderText = "ГРУППА";
            this.group.Name = "group";
            // 
            // teacher
            // 
            this.teacher.HeaderText = "ПРЕПОДАВАТЕЛЬ";
            this.teacher.Name = "teacher";
            // 
            // topic
            // 
            this.topic.HeaderText = "ТЕМА";
            this.topic.Name = "topic";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 261);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.kind_comboBox);
            this.Controls.Add(this.kind_label);
            this.Controls.Add(this.choise_kind_comboBox);
            this.Controls.Add(this.choise_kind_label);
            this.Name = "Form5";
            this.Text = "Проведенные занятия";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label choise_kind_label;
        private System.Windows.Forms.ComboBox choise_kind_comboBox;
        private System.Windows.Forms.Label kind_label;
        private System.Windows.Forms.ComboBox kind_comboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn group;
        private System.Windows.Forms.DataGridViewTextBoxColumn teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn topic;
    }
}