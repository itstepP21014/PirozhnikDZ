namespace ProjectCSharpAndWinforms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.x_pos_label = new System.Windows.Forms.Label();
            this.y_pos_lable = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.width_label = new System.Windows.Forms.Label();
            this.hight_label = new System.Windows.Forms.Label();
            this.x_pos_numeric = new System.Windows.Forms.NumericUpDown();
            this.y_pos_numeric = new System.Windows.Forms.NumericUpDown();
            this.width_numeric = new System.Windows.Forms.NumericUpDown();
            this.height_numeric = new System.Windows.Forms.NumericUpDown();
            this.main_panel = new System.Windows.Forms.Panel();
            this.fill_color_panel = new System.Windows.Forms.Panel();
            this.square_draw_button = new System.Windows.Forms.Button();
            this.circle_draw_button = new System.Windows.Forms.Button();
            this.triangle_draw_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.border_color_label = new System.Windows.Forms.Label();
            this.border_color_panel = new System.Windows.Forms.Panel();
            this.border_width_label = new System.Windows.Forms.Label();
            this.border_width_numeric = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.to_first_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.to_next_eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.to_last_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copy_button = new System.Windows.Forms.Button();
            this.border_style_button = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Solid_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Dot_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Dash_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DashDot_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DashDotDot_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.border_style_label = new System.Windows.Forms.Label();
            this.safe_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.x_pos_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_pos_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.width_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.height_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.border_width_numeric)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // x_pos_label
            // 
            this.x_pos_label.AutoSize = true;
            this.x_pos_label.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.x_pos_label.Font = new System.Drawing.Font("Buxton Sketch", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.x_pos_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.x_pos_label.Location = new System.Drawing.Point(12, 17);
            this.x_pos_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.x_pos_label.Name = "x_pos_label";
            this.x_pos_label.Size = new System.Drawing.Size(22, 19);
            this.x_pos_label.TabIndex = 0;
            this.x_pos_label.Text = "X:";
            // 
            // y_pos_lable
            // 
            this.y_pos_lable.AutoSize = true;
            this.y_pos_lable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.y_pos_lable.Font = new System.Drawing.Font("Buxton Sketch", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.y_pos_lable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.y_pos_lable.Location = new System.Drawing.Point(12, 47);
            this.y_pos_lable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.y_pos_lable.Name = "y_pos_lable";
            this.y_pos_lable.Size = new System.Drawing.Size(23, 19);
            this.y_pos_lable.TabIndex = 1;
            this.y_pos_lable.Text = "Y:";
            // 
            // width_label
            // 
            this.width_label.AutoSize = true;
            this.width_label.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.width_label.Font = new System.Drawing.Font("Buxton Sketch", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.width_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.width_label.Location = new System.Drawing.Point(121, 17);
            this.width_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.width_label.Name = "width_label";
            this.width_label.Size = new System.Drawing.Size(25, 19);
            this.width_label.TabIndex = 5;
            this.width_label.Text = "W:";
            // 
            // hight_label
            // 
            this.hight_label.AutoSize = true;
            this.hight_label.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hight_label.Font = new System.Drawing.Font("Buxton Sketch", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hight_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.hight_label.Location = new System.Drawing.Point(125, 47);
            this.hight_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hight_label.Name = "hight_label";
            this.hight_label.Size = new System.Drawing.Size(23, 19);
            this.hight_label.TabIndex = 6;
            this.hight_label.Text = "H:";
            // 
            // x_pos_numeric
            // 
            this.x_pos_numeric.DecimalPlaces = 1;
            this.x_pos_numeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.x_pos_numeric.Location = new System.Drawing.Point(30, 13);
            this.x_pos_numeric.Margin = new System.Windows.Forms.Padding(2);
            this.x_pos_numeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.x_pos_numeric.Name = "x_pos_numeric";
            this.x_pos_numeric.Size = new System.Drawing.Size(79, 21);
            this.x_pos_numeric.TabIndex = 14;
            this.x_pos_numeric.ValueChanged += new System.EventHandler(this.x_pos_numeric_ValueChanged);
            // 
            // y_pos_numeric
            // 
            this.y_pos_numeric.DecimalPlaces = 1;
            this.y_pos_numeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.y_pos_numeric.Location = new System.Drawing.Point(30, 47);
            this.y_pos_numeric.Margin = new System.Windows.Forms.Padding(2);
            this.y_pos_numeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.y_pos_numeric.Name = "y_pos_numeric";
            this.y_pos_numeric.Size = new System.Drawing.Size(79, 21);
            this.y_pos_numeric.TabIndex = 15;
            this.y_pos_numeric.ValueChanged += new System.EventHandler(this.y_pos_numeric_ValueChanged);
            // 
            // width_numeric
            // 
            this.width_numeric.DecimalPlaces = 1;
            this.width_numeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.width_numeric.Location = new System.Drawing.Point(145, 13);
            this.width_numeric.Margin = new System.Windows.Forms.Padding(2);
            this.width_numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.width_numeric.Name = "width_numeric";
            this.width_numeric.Size = new System.Drawing.Size(79, 21);
            this.width_numeric.TabIndex = 16;
            this.width_numeric.ValueChanged += new System.EventHandler(this.width_numeric_ValueChanged);
            // 
            // height_numeric
            // 
            this.height_numeric.DecimalPlaces = 1;
            this.height_numeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.height_numeric.Location = new System.Drawing.Point(145, 47);
            this.height_numeric.Margin = new System.Windows.Forms.Padding(2);
            this.height_numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.height_numeric.Name = "height_numeric";
            this.height_numeric.Size = new System.Drawing.Size(79, 21);
            this.height_numeric.TabIndex = 17;
            this.height_numeric.ValueChanged += new System.EventHandler(this.height_numeric_ValueChanged);
            // 
            // main_panel
            // 
            this.main_panel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.main_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.main_panel.Location = new System.Drawing.Point(1, 82);
            this.main_panel.Margin = new System.Windows.Forms.Padding(0);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(891, 402);
            this.main_panel.TabIndex = 18;
            this.main_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.main_panel_Paint);
            this.main_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.main_panel_MouseDown);
            this.main_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.main_panel_MouseUp);
            // 
            // fill_color_panel
            // 
            this.fill_color_panel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.fill_color_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fill_color_panel.Location = new System.Drawing.Point(694, 22);
            this.fill_color_panel.Margin = new System.Windows.Forms.Padding(2);
            this.fill_color_panel.Name = "fill_color_panel";
            this.fill_color_panel.Size = new System.Drawing.Size(44, 42);
            this.fill_color_panel.TabIndex = 0;
            this.fill_color_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fill_color_panel_MouseClick);
            // 
            // square_draw_button
            // 
            this.square_draw_button.BackColor = System.Drawing.SystemColors.HighlightText;
            this.square_draw_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("square_draw_button.BackgroundImage")));
            this.square_draw_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.square_draw_button.Location = new System.Drawing.Point(576, 17);
            this.square_draw_button.Margin = new System.Windows.Forms.Padding(2);
            this.square_draw_button.Name = "square_draw_button";
            this.square_draw_button.Size = new System.Drawing.Size(50, 52);
            this.square_draw_button.TabIndex = 20;
            this.square_draw_button.UseVisualStyleBackColor = false;
            this.square_draw_button.MouseClick += new System.Windows.Forms.MouseEventHandler(this.square_draw_button_MouseClick);
            // 
            // circle_draw_button
            // 
            this.circle_draw_button.BackColor = System.Drawing.SystemColors.HighlightText;
            this.circle_draw_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("circle_draw_button.BackgroundImage")));
            this.circle_draw_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.circle_draw_button.Location = new System.Drawing.Point(520, 17);
            this.circle_draw_button.Margin = new System.Windows.Forms.Padding(2);
            this.circle_draw_button.Name = "circle_draw_button";
            this.circle_draw_button.Size = new System.Drawing.Size(50, 52);
            this.circle_draw_button.TabIndex = 21;
            this.circle_draw_button.UseVisualStyleBackColor = false;
            this.circle_draw_button.MouseClick += new System.Windows.Forms.MouseEventHandler(this.circle_draw_button_MouseClick);
            // 
            // triangle_draw_button
            // 
            this.triangle_draw_button.BackColor = System.Drawing.SystemColors.HighlightText;
            this.triangle_draw_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("triangle_draw_button.BackgroundImage")));
            this.triangle_draw_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.triangle_draw_button.Location = new System.Drawing.Point(466, 18);
            this.triangle_draw_button.Margin = new System.Windows.Forms.Padding(2);
            this.triangle_draw_button.Name = "triangle_draw_button";
            this.triangle_draw_button.Size = new System.Drawing.Size(50, 52);
            this.triangle_draw_button.TabIndex = 22;
            this.triangle_draw_button.UseVisualStyleBackColor = false;
            this.triangle_draw_button.Click += new System.EventHandler(this.triangle_draw_button_Click);
            // 
            // delete_button
            // 
            this.delete_button.BackColor = System.Drawing.SystemColors.HighlightText;
            this.delete_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delete_button.BackgroundImage")));
            this.delete_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.delete_button.Location = new System.Drawing.Point(742, 22);
            this.delete_button.Margin = new System.Windows.Forms.Padding(2);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(43, 43);
            this.delete_button.TabIndex = 24;
            this.delete_button.UseVisualStyleBackColor = false;
            this.delete_button.MouseClick += new System.Windows.Forms.MouseEventHandler(this.delete_button_MouseClick);
            // 
            // border_color_label
            // 
            this.border_color_label.AutoSize = true;
            this.border_color_label.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.border_color_label.Font = new System.Drawing.Font("Buxton Sketch", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.border_color_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.border_color_label.Location = new System.Drawing.Point(239, 34);
            this.border_color_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.border_color_label.Name = "border_color_label";
            this.border_color_label.Size = new System.Drawing.Size(94, 19);
            this.border_color_label.TabIndex = 25;
            this.border_color_label.Text = "Border color:";
            // 
            // border_color_panel
            // 
            this.border_color_panel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.border_color_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.border_color_panel.Location = new System.Drawing.Point(333, 33);
            this.border_color_panel.Margin = new System.Windows.Forms.Padding(2);
            this.border_color_panel.Name = "border_color_panel";
            this.border_color_panel.Size = new System.Drawing.Size(58, 21);
            this.border_color_panel.TabIndex = 1;
            this.border_color_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.border_color_panel_MouseClick);
            // 
            // border_width_label
            // 
            this.border_width_label.AutoSize = true;
            this.border_width_label.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.border_width_label.Font = new System.Drawing.Font("Buxton Sketch", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.border_width_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.border_width_label.Location = new System.Drawing.Point(239, 14);
            this.border_width_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.border_width_label.Name = "border_width_label";
            this.border_width_label.Size = new System.Drawing.Size(96, 19);
            this.border_width_label.TabIndex = 26;
            this.border_width_label.Text = "Border width:";
            // 
            // border_width_numeric
            // 
            this.border_width_numeric.DecimalPlaces = 1;
            this.border_width_numeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.border_width_numeric.Location = new System.Drawing.Point(333, 10);
            this.border_width_numeric.Margin = new System.Windows.Forms.Padding(2);
            this.border_width_numeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.border_width_numeric.Name = "border_width_numeric";
            this.border_width_numeric.Size = new System.Drawing.Size(58, 21);
            this.border_width_numeric.TabIndex = 27;
            this.border_width_numeric.ValueChanged += new System.EventHandler(this.border_width_numeric_ValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.to_first_ToolStripMenuItem,
            this.to_next_eToolStripMenuItem,
            this.to_last_ToolStripMenuItem});
            this.contextMenuStrip1.Margin = new System.Windows.Forms.Padding(100);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(188, 70);
            // 
            // to_first_ToolStripMenuItem
            // 
            this.to_first_ToolStripMenuItem.Name = "to_first_ToolStripMenuItem";
            this.to_first_ToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.to_first_ToolStripMenuItem.Text = "На передний план";
            this.to_first_ToolStripMenuItem.Click += new System.EventHandler(this.to_first_ToolStripMenuItem_Click);
            // 
            // to_next_eToolStripMenuItem
            // 
            this.to_next_eToolStripMenuItem.Name = "to_next_eToolStripMenuItem";
            this.to_next_eToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.to_next_eToolStripMenuItem.Text = "Переместить вперед";
            this.to_next_eToolStripMenuItem.Click += new System.EventHandler(this.to_next_eToolStripMenuItem_Click);
            // 
            // to_last_ToolStripMenuItem
            // 
            this.to_last_ToolStripMenuItem.Name = "to_last_ToolStripMenuItem";
            this.to_last_ToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.to_last_ToolStripMenuItem.Text = "На задний план";
            this.to_last_ToolStripMenuItem.Click += new System.EventHandler(this.to_last_ToolStripMenuItem_Click);
            // 
            // copy_button
            // 
            this.copy_button.BackColor = System.Drawing.SystemColors.HighlightText;
            this.copy_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("copy_button.BackgroundImage")));
            this.copy_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.copy_button.Location = new System.Drawing.Point(789, 22);
            this.copy_button.Margin = new System.Windows.Forms.Padding(2);
            this.copy_button.Name = "copy_button";
            this.copy_button.Size = new System.Drawing.Size(43, 43);
            this.copy_button.TabIndex = 28;
            this.copy_button.UseVisualStyleBackColor = false;
            this.copy_button.Click += new System.EventHandler(this.copy_button_Click);
            // 
            // border_style_button
            // 
            this.border_style_button.Font = new System.Drawing.Font("Buxton Sketch", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.border_style_button.Location = new System.Drawing.Point(333, 56);
            this.border_style_button.Margin = new System.Windows.Forms.Padding(2);
            this.border_style_button.Name = "border_style_button";
            this.border_style_button.Size = new System.Drawing.Size(58, 24);
            this.border_style_button.TabIndex = 29;
            this.border_style_button.Text = "Style";
            this.border_style_button.UseVisualStyleBackColor = true;
            this.border_style_button.Click += new System.EventHandler(this.border_style_button_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Solid_ToolStripMenuItem,
            this.Dot_ToolStripMenuItem,
            this.Dash_ToolStripMenuItem,
            this.DashDot_ToolStripMenuItem,
            this.DashDotDot_ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(117, 114);
            // 
            // Solid_ToolStripMenuItem
            // 
            this.Solid_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Solid_ToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Solid_ToolStripMenuItem.BackgroundImage")));
            this.Solid_ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Solid_ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Solid_ToolStripMenuItem.Name = "Solid_ToolStripMenuItem";
            this.Solid_ToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Solid_ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.Solid_ToolStripMenuItem.Text = "              ";
            this.Solid_ToolStripMenuItem.Click += new System.EventHandler(this.Solid_ToolStripMenuItem_Click);
            // 
            // Dot_ToolStripMenuItem
            // 
            this.Dot_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Dot_ToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Dot_ToolStripMenuItem.BackgroundImage")));
            this.Dot_ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Dot_ToolStripMenuItem.Name = "Dot_ToolStripMenuItem";
            this.Dot_ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.Dot_ToolStripMenuItem.Click += new System.EventHandler(this.Dot_ToolStripMenuItem_Click);
            // 
            // Dash_ToolStripMenuItem
            // 
            this.Dash_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Dash_ToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Dash_ToolStripMenuItem.BackgroundImage")));
            this.Dash_ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Dash_ToolStripMenuItem.Name = "Dash_ToolStripMenuItem";
            this.Dash_ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.Dash_ToolStripMenuItem.Click += new System.EventHandler(this.Dash_ToolStripMenuItem_Click);
            // 
            // DashDot_ToolStripMenuItem
            // 
            this.DashDot_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DashDot_ToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DashDot_ToolStripMenuItem.BackgroundImage")));
            this.DashDot_ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DashDot_ToolStripMenuItem.Name = "DashDot_ToolStripMenuItem";
            this.DashDot_ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.DashDot_ToolStripMenuItem.Click += new System.EventHandler(this.DashDot_ToolStripMenuItem_Click);
            // 
            // DashDotDot_ToolStripMenuItem
            // 
            this.DashDotDot_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DashDotDot_ToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DashDotDot_ToolStripMenuItem.BackgroundImage")));
            this.DashDotDot_ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DashDotDot_ToolStripMenuItem.Name = "DashDotDot_ToolStripMenuItem";
            this.DashDotDot_ToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.DashDotDot_ToolStripMenuItem.Click += new System.EventHandler(this.DashDotDot_ToolStripMenuItem_Click);
            // 
            // border_style_label
            // 
            this.border_style_label.AutoSize = true;
            this.border_style_label.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.border_style_label.Font = new System.Drawing.Font("Buxton Sketch", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.border_style_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.border_style_label.Location = new System.Drawing.Point(239, 56);
            this.border_style_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.border_style_label.Name = "border_style_label";
            this.border_style_label.Size = new System.Drawing.Size(94, 19);
            this.border_style_label.TabIndex = 30;
            this.border_style_label.Text = "Border style:";
            // 
            // safe_button
            // 
            this.safe_button.BackColor = System.Drawing.SystemColors.HighlightText;
            this.safe_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("safe_button.BackgroundImage")));
            this.safe_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.safe_button.Location = new System.Drawing.Point(836, 22);
            this.safe_button.Margin = new System.Windows.Forms.Padding(2);
            this.safe_button.Name = "safe_button";
            this.safe_button.Size = new System.Drawing.Size(43, 43);
            this.safe_button.TabIndex = 31;
            this.safe_button.UseVisualStyleBackColor = false;
            this.safe_button.Click += new System.EventHandler(this.safe_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(894, 488);
            this.Controls.Add(this.safe_button);
            this.Controls.Add(this.border_style_label);
            this.Controls.Add(this.square_draw_button);
            this.Controls.Add(this.fill_color_panel);
            this.Controls.Add(this.border_style_button);
            this.Controls.Add(this.copy_button);
            this.Controls.Add(this.triangle_draw_button);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.border_width_numeric);
            this.Controls.Add(this.border_width_label);
            this.Controls.Add(this.border_color_panel);
            this.Controls.Add(this.border_color_label);
            this.Controls.Add(this.circle_draw_button);
            this.Controls.Add(this.main_panel);
            this.Controls.Add(this.height_numeric);
            this.Controls.Add(this.width_numeric);
            this.Controls.Add(this.y_pos_numeric);
            this.Controls.Add(this.x_pos_numeric);
            this.Controls.Add(this.hight_label);
            this.Controls.Add(this.width_label);
            this.Controls.Add(this.y_pos_lable);
            this.Controls.Add(this.x_pos_label);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Shapemaker";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.x_pos_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_pos_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.width_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.height_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.border_width_numeric)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label x_pos_label;
        private System.Windows.Forms.Label y_pos_lable;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label width_label;
        private System.Windows.Forms.Label hight_label;
        private System.Windows.Forms.NumericUpDown x_pos_numeric;
        private System.Windows.Forms.NumericUpDown y_pos_numeric;
        private System.Windows.Forms.NumericUpDown width_numeric;
        private System.Windows.Forms.NumericUpDown height_numeric;
        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Panel fill_color_panel;
        private System.Windows.Forms.Button square_draw_button;
        private System.Windows.Forms.Button circle_draw_button;
        private System.Windows.Forms.Button triangle_draw_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Label border_color_label;
        private System.Windows.Forms.Panel border_color_panel;
        private System.Windows.Forms.Label border_width_label;
        private System.Windows.Forms.NumericUpDown border_width_numeric;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem to_first_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem to_next_eToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem to_last_ToolStripMenuItem;
        private System.Windows.Forms.Button copy_button;
        private System.Windows.Forms.Button border_style_button;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem Solid_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Dot_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Dash_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DashDot_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DashDotDot_ToolStripMenuItem;
        private System.Windows.Forms.Label border_style_label;
        private System.Windows.Forms.Button safe_button;


    }
}

