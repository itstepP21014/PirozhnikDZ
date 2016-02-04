namespace LINQ
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.msQuery = new System.Windows.Forms.MenuStrip();
            this.queryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cdCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.producerCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.dgvQueryResult = new System.Windows.Forms.DataGridView();
            this.tITLEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aRTISTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOUNTRYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMPANYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRICEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yEARDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.msQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.AutoGenerateColumns = false;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tITLEDataGridViewTextBoxColumn,
            this.aRTISTDataGridViewTextBoxColumn,
            this.cOUNTRYDataGridViewTextBoxColumn,
            this.cOMPANYDataGridViewTextBoxColumn,
            this.pRICEDataGridViewTextBoxColumn,
            this.yEARDataGridViewTextBoxColumn});
            this.dgv1.DataSource = this.cDBindingSource;
            this.dgv1.Location = new System.Drawing.Point(0, 27);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(731, 163);
            this.dgv1.TabIndex = 2;
            // 
            // msQuery
            // 
            this.msQuery.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.queryToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.msQuery.Location = new System.Drawing.Point(0, 0);
            this.msQuery.Name = "msQuery";
            this.msQuery.Size = new System.Drawing.Size(732, 24);
            this.msQuery.TabIndex = 4;
            this.msQuery.Text = "menuStrip1";
            // 
            // queryToolStripMenuItem
            // 
            this.queryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11});
            this.queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            this.queryToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.queryToolStripMenuItem.Text = "Query";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(920, 22);
            this.toolStripMenuItem2.Text = "1. Список всех артистов, который выпустили свои альбомы после распада СССР";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(920, 22);
            this.toolStripMenuItem3.Text = "2. Список стран";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(920, 22);
            this.toolStripMenuItem4.Text = "3. Список наименований альбомов, выпущенных в США, упорядоченных по году выпуска";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(920, 22);
            this.toolStripMenuItem5.Text = "4. Суммарную стоимость альбомов за страну";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(920, 22);
            this.toolStripMenuItem6.Text = "5. Список: компания и количество альбомов за год, года упорядочены по возрастанию" +
    "";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(920, 22);
            this.toolStripMenuItem7.Text = "6. Наименование альбома и продюсера, получившего самое большое вознаграждение за " +
    "вклад в развитие";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(920, 22);
            this.toolStripMenuItem8.Text = "7. Количество альбомов каждого продюсера в период  между годами выхода альбома 19" +
    "88 – 1990 гг";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(920, 22);
            this.toolStripMenuItem9.Text = "8. Фамилию продюсера получившего вознаграждение последним";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(920, 22);
            this.toolStripMenuItem10.Text = "9. Информацию о самом дешевом альбоме (название альбома, исполнителя и продюсера)" +
    "";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(920, 22);
            this.toolStripMenuItem11.Text = "10. Полную информацию об альбомах, отсортированную по следующим критериям: год вы" +
    "хода альбома, стоимость  альбома, наименование альбома";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cdCollectionToolStripMenuItem,
            this.producerCollectionToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.fileToolStripMenuItem.Text = "Files";
            // 
            // cdCollectionToolStripMenuItem
            // 
            this.cdCollectionToolStripMenuItem.Name = "cdCollectionToolStripMenuItem";
            this.cdCollectionToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.cdCollectionToolStripMenuItem.Text = "Cd collection";
            // 
            // producerCollectionToolStripMenuItem
            // 
            this.producerCollectionToolStripMenuItem.Name = "producerCollectionToolStripMenuItem";
            this.producerCollectionToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.producerCollectionToolStripMenuItem.Text = "Producer collection";
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(0, 196);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(731, 151);
            this.dgv2.TabIndex = 5;
            // 
            // dgvQueryResult
            // 
            this.dgvQueryResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryResult.Location = new System.Drawing.Point(0, 353);
            this.dgvQueryResult.Name = "dgvQueryResult";
            this.dgvQueryResult.Size = new System.Drawing.Size(731, 150);
            this.dgvQueryResult.TabIndex = 6;
            // 
            // tITLEDataGridViewTextBoxColumn
            // 
            this.tITLEDataGridViewTextBoxColumn.DataPropertyName = "TITLE";
            this.tITLEDataGridViewTextBoxColumn.HeaderText = "TITLE";
            this.tITLEDataGridViewTextBoxColumn.Name = "tITLEDataGridViewTextBoxColumn";
            // 
            // aRTISTDataGridViewTextBoxColumn
            // 
            this.aRTISTDataGridViewTextBoxColumn.DataPropertyName = "ARTIST";
            this.aRTISTDataGridViewTextBoxColumn.HeaderText = "ARTIST";
            this.aRTISTDataGridViewTextBoxColumn.Name = "aRTISTDataGridViewTextBoxColumn";
            // 
            // cOUNTRYDataGridViewTextBoxColumn
            // 
            this.cOUNTRYDataGridViewTextBoxColumn.DataPropertyName = "COUNTRY";
            this.cOUNTRYDataGridViewTextBoxColumn.HeaderText = "COUNTRY";
            this.cOUNTRYDataGridViewTextBoxColumn.Name = "cOUNTRYDataGridViewTextBoxColumn";
            // 
            // cOMPANYDataGridViewTextBoxColumn
            // 
            this.cOMPANYDataGridViewTextBoxColumn.DataPropertyName = "COMPANY";
            this.cOMPANYDataGridViewTextBoxColumn.HeaderText = "COMPANY";
            this.cOMPANYDataGridViewTextBoxColumn.Name = "cOMPANYDataGridViewTextBoxColumn";
            // 
            // pRICEDataGridViewTextBoxColumn
            // 
            this.pRICEDataGridViewTextBoxColumn.DataPropertyName = "PRICE";
            this.pRICEDataGridViewTextBoxColumn.HeaderText = "PRICE";
            this.pRICEDataGridViewTextBoxColumn.Name = "pRICEDataGridViewTextBoxColumn";
            // 
            // yEARDataGridViewTextBoxColumn
            // 
            this.yEARDataGridViewTextBoxColumn.DataPropertyName = "YEAR";
            this.yEARDataGridViewTextBoxColumn.HeaderText = "YEAR";
            this.yEARDataGridViewTextBoxColumn.Name = "yEARDataGridViewTextBoxColumn";
            // 
            // cDBindingSource
            // 
            this.cDBindingSource.DataSource = typeof(LINQ.CD);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 475);
            this.Controls.Add(this.dgvQueryResult);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.msQuery);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.msQuery.ResumeLayout(false);
            this.msQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cDBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.MenuStrip msQuery;
        private System.Windows.Forms.ToolStripMenuItem queryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.DataGridViewTextBoxColumn tITLEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aRTISTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOUNTRYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMPANYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRICEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yEARDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource cDBindingSource;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cdCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem producerCollectionToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.DataGridView dgvQueryResult;

    }
}

