namespace ExampleAsynch1
{
    partial class MainForm
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
            this.listInfo = new System.Windows.Forms.ListBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnGetDataAsynch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listInfo
            // 
            this.listInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listInfo.FormattingEnabled = true;
            this.listInfo.ItemHeight = 20;
            this.listInfo.Items.AddRange(new object[] {
            ""});
            this.listInfo.Location = new System.Drawing.Point(7, 10);
            this.listInfo.Name = "listInfo";
            this.listInfo.Size = new System.Drawing.Size(888, 324);
            this.listInfo.TabIndex = 0;
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGetData.Location = new System.Drawing.Point(389, 351);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(234, 56);
            this.btnGetData.TabIndex = 1;
            this.btnGetData.Text = "Получить данные";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnGetDataAsynch
            // 
            this.btnGetDataAsynch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetDataAsynch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGetDataAsynch.Location = new System.Drawing.Point(629, 351);
            this.btnGetDataAsynch.Name = "btnGetDataAsynch";
            this.btnGetDataAsynch.Size = new System.Drawing.Size(266, 56);
            this.btnGetDataAsynch.TabIndex = 1;
            this.btnGetDataAsynch.Text = "Получить данные в асинхронном режиме";
            this.btnGetDataAsynch.UseVisualStyleBackColor = true;
            this.btnGetDataAsynch.Click += new System.EventHandler(this.btnGetDataAsynch_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 419);
            this.Controls.Add(this.btnGetDataAsynch);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.listInfo);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "MainForm";
            this.Text = "Асинхронные операции";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listInfo;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnGetDataAsynch;
    }
}

