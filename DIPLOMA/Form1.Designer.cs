namespace DIPLOMA
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
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.number_points_textbox = new System.Windows.Forms.TextBox();
            this.z1 = new ZedGraph.ZedGraphControl();
            this.save_name = new System.Windows.Forms.TextBox();
            this.points_count = new System.Windows.Forms.TextBox();
            this.P_C = new System.Windows.Forms.TextBox();
            this.exact_points_checkbox = new System.Windows.Forms.CheckBox();
            this.cool_method_box = new System.Windows.Forms.GroupBox();
            this.inaccuracy_button = new System.Windows.Forms.Button();
            this.invariant_checkbox = new System.Windows.Forms.CheckBox();
            this.cool_method_4_checkbox = new System.Windows.Forms.CheckBox();
            this.cool_method_3_checkbox = new System.Windows.Forms.CheckBox();
            this.cool_method_2_checkbox = new System.Windows.Forms.CheckBox();
            this.cool_method_1_checkbox = new System.Windows.Forms.CheckBox();
            this.s1_textBox = new System.Windows.Forms.TextBox();
            this.s1_param_label = new System.Windows.Forms.Label();
            this.b_param_label = new System.Windows.Forms.Label();
            this.s_param_label = new System.Windows.Forms.Label();
            this.b_textBox = new System.Windows.Forms.TextBox();
            this.s_textBox = new System.Windows.Forms.TextBox();
            this.save_label = new System.Windows.Forms.Label();
            this.note_button = new System.Windows.Forms.Button();
            this.start_params_box_button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.start_values_box = new System.Windows.Forms.GroupBox();
            this.y0 = new System.Windows.Forms.TextBox();
            this.x0 = new System.Windows.Forms.TextBox();
            this.y0_label = new System.Windows.Forms.Label();
            this.x0_label = new System.Windows.Forms.Label();
            this.paprams_box_button = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.Kepler = new System.Windows.Forms.Button();
            this.start_speed_button = new System.Windows.Forms.Button();
            this.params_in_picture = new System.Windows.Forms.GroupBox();
            this.out_params = new System.Windows.Forms.Label();
            this.params_watch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.start_params_box = new System.Windows.Forms.GroupBox();
            this.G_label = new System.Windows.Forms.Label();
            this.M2_label = new System.Windows.Forms.Label();
            this.M1_label = new System.Windows.Forms.Label();
            this.G = new System.Windows.Forms.TextBox();
            this.M2 = new System.Windows.Forms.TextBox();
            this.M1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.params_watch_box = new System.Windows.Forms.GroupBox();
            this.cool_method_checkbox = new System.Windows.Forms.CheckBox();
            this.middle_point_check_box = new System.Windows.Forms.CheckBox();
            this.verle_explicit_checkbox = new System.Windows.Forms.CheckBox();
            this.eiler_check_box = new System.Windows.Forms.CheckBox();
            this.exact_solution_check_box = new System.Windows.Forms.CheckBox();
            this.runge_check_box = new System.Windows.Forms.CheckBox();
            this.start_speed_box = new System.Windows.Forms.GroupBox();
            this.epsilon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Vy0 = new System.Windows.Forms.TextBox();
            this.Vx0 = new System.Windows.Forms.TextBox();
            this.vx0_label = new System.Windows.Forms.Label();
            this.Vy0_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3.SuspendLayout();
            this.cool_method_box.SuspendLayout();
            this.start_values_box.SuspendLayout();
            this.params_in_picture.SuspendLayout();
            this.start_params_box.SuspendLayout();
            this.params_watch_box.SuspendLayout();
            this.start_speed_box.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.number_points_textbox);
            this.tabPage3.Controls.Add(this.z1);
            this.tabPage3.Controls.Add(this.save_name);
            this.tabPage3.Controls.Add(this.points_count);
            this.tabPage3.Controls.Add(this.P_C);
            this.tabPage3.Controls.Add(this.exact_points_checkbox);
            this.tabPage3.Controls.Add(this.cool_method_box);
            this.tabPage3.Controls.Add(this.save_label);
            this.tabPage3.Controls.Add(this.note_button);
            this.tabPage3.Controls.Add(this.start_params_box_button);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.start_values_box);
            this.tabPage3.Controls.Add(this.paprams_box_button);
            this.tabPage3.Controls.Add(this.save);
            this.tabPage3.Controls.Add(this.Kepler);
            this.tabPage3.Controls.Add(this.start_speed_button);
            this.tabPage3.Controls.Add(this.params_in_picture);
            this.tabPage3.Controls.Add(this.params_watch);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.start_params_box);
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.params_watch_box);
            this.tabPage3.Controls.Add(this.start_speed_box);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1754, 894);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Решения и графики";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1274, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 34);
            this.label6.TabIndex = 42;
            this.label6.Text = "Точек в точном \r\nрешении";
            // 
            // number_points_textbox
            // 
            this.number_points_textbox.Location = new System.Drawing.Point(1276, 234);
            this.number_points_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.number_points_textbox.Name = "number_points_textbox";
            this.number_points_textbox.Size = new System.Drawing.Size(100, 22);
            this.number_points_textbox.TabIndex = 41;
            this.number_points_textbox.Text = "200";
            // 
            // z1
            // 
            this.z1.Location = new System.Drawing.Point(5, 0);
            this.z1.Margin = new System.Windows.Forms.Padding(5);
            this.z1.Name = "z1";
            this.z1.ScrollGrace = 0D;
            this.z1.ScrollMaxX = 0D;
            this.z1.ScrollMaxY = 0D;
            this.z1.ScrollMaxY2 = 0D;
            this.z1.ScrollMinX = 0D;
            this.z1.ScrollMinY = 0D;
            this.z1.ScrollMinY2 = 0D;
            this.z1.Size = new System.Drawing.Size(923, 846);
            this.z1.TabIndex = 0;
            this.z1.Load += new System.EventHandler(this.zedGraphControl1_Load);
            this.z1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.z1_MouseClick_1);
            // 
            // save_name
            // 
            this.save_name.Location = new System.Drawing.Point(1396, 642);
            this.save_name.Margin = new System.Windows.Forms.Padding(4);
            this.save_name.Name = "save_name";
            this.save_name.Size = new System.Drawing.Size(209, 22);
            this.save_name.TabIndex = 32;
            // 
            // points_count
            // 
            this.points_count.Location = new System.Drawing.Point(1072, 258);
            this.points_count.Margin = new System.Windows.Forms.Padding(4);
            this.points_count.Name = "points_count";
            this.points_count.Size = new System.Drawing.Size(135, 22);
            this.points_count.TabIndex = 24;
            this.points_count.Text = "200";
            // 
            // P_C
            // 
            this.P_C.Location = new System.Drawing.Point(1133, 226);
            this.P_C.Margin = new System.Windows.Forms.Padding(4);
            this.P_C.Name = "P_C";
            this.P_C.Size = new System.Drawing.Size(73, 22);
            this.P_C.TabIndex = 27;
            this.P_C.Text = "1";
            // 
            // exact_points_checkbox
            // 
            this.exact_points_checkbox.AutoSize = true;
            this.exact_points_checkbox.Location = new System.Drawing.Point(939, 197);
            this.exact_points_checkbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exact_points_checkbox.Name = "exact_points_checkbox";
            this.exact_points_checkbox.Size = new System.Drawing.Size(270, 21);
            this.exact_points_checkbox.TabIndex = 40;
            this.exact_points_checkbox.Text = "Показывать точки точного решения";
            this.exact_points_checkbox.UseVisualStyleBackColor = true;
            this.exact_points_checkbox.CheckedChanged += new System.EventHandler(this.exact_points_checkbox_CheckedChanged);
            // 
            // cool_method_box
            // 
            this.cool_method_box.Controls.Add(this.inaccuracy_button);
            this.cool_method_box.Controls.Add(this.invariant_checkbox);
            this.cool_method_box.Controls.Add(this.cool_method_4_checkbox);
            this.cool_method_box.Controls.Add(this.cool_method_3_checkbox);
            this.cool_method_box.Controls.Add(this.cool_method_2_checkbox);
            this.cool_method_box.Controls.Add(this.cool_method_1_checkbox);
            this.cool_method_box.Controls.Add(this.s1_textBox);
            this.cool_method_box.Controls.Add(this.s1_param_label);
            this.cool_method_box.Controls.Add(this.b_param_label);
            this.cool_method_box.Controls.Add(this.s_param_label);
            this.cool_method_box.Controls.Add(this.b_textBox);
            this.cool_method_box.Controls.Add(this.s_textBox);
            this.cool_method_box.Location = new System.Drawing.Point(1524, 290);
            this.cool_method_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cool_method_box.Name = "cool_method_box";
            this.cool_method_box.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cool_method_box.Size = new System.Drawing.Size(163, 246);
            this.cool_method_box.TabIndex = 39;
            this.cool_method_box.TabStop = false;
            this.cool_method_box.Text = "Метод и параметры";
            this.cool_method_box.Visible = false;
            // 
            // inaccuracy_button
            // 
            this.inaccuracy_button.Location = new System.Drawing.Point(0, 202);
            this.inaccuracy_button.Name = "inaccuracy_button";
            this.inaccuracy_button.Size = new System.Drawing.Size(163, 33);
            this.inaccuracy_button.TabIndex = 1;
            this.inaccuracy_button.Text = "Погрешности";
            this.inaccuracy_button.UseVisualStyleBackColor = true;
            this.inaccuracy_button.Click += new System.EventHandler(this.inaccuracy_button_Click);
            // 
            // invariant_checkbox
            // 
            this.invariant_checkbox.AutoSize = true;
            this.invariant_checkbox.Location = new System.Drawing.Point(27, 159);
            this.invariant_checkbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.invariant_checkbox.Name = "invariant_checkbox";
            this.invariant_checkbox.Size = new System.Drawing.Size(115, 38);
            this.invariant_checkbox.TabIndex = 15;
            this.invariant_checkbox.Text = "Пересчет \r\nинвариантов";
            this.invariant_checkbox.UseVisualStyleBackColor = true;
            this.invariant_checkbox.CheckedChanged += new System.EventHandler(this.invariant_checkbox_CheckedChanged);
            // 
            // cool_method_4_checkbox
            // 
            this.cool_method_4_checkbox.AutoSize = true;
            this.cool_method_4_checkbox.Location = new System.Drawing.Point(77, 48);
            this.cool_method_4_checkbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cool_method_4_checkbox.Name = "cool_method_4_checkbox";
            this.cool_method_4_checkbox.Size = new System.Drawing.Size(38, 21);
            this.cool_method_4_checkbox.TabIndex = 14;
            this.cool_method_4_checkbox.Text = "4";
            this.cool_method_4_checkbox.UseVisualStyleBackColor = true;
            this.cool_method_4_checkbox.CheckedChanged += new System.EventHandler(this.cool_method_4_checkbox_CheckedChanged);
            // 
            // cool_method_3_checkbox
            // 
            this.cool_method_3_checkbox.AutoSize = true;
            this.cool_method_3_checkbox.Location = new System.Drawing.Point(77, 21);
            this.cool_method_3_checkbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cool_method_3_checkbox.Name = "cool_method_3_checkbox";
            this.cool_method_3_checkbox.Size = new System.Drawing.Size(38, 21);
            this.cool_method_3_checkbox.TabIndex = 13;
            this.cool_method_3_checkbox.Text = "3";
            this.cool_method_3_checkbox.UseVisualStyleBackColor = true;
            this.cool_method_3_checkbox.CheckedChanged += new System.EventHandler(this.cool_method_3_checkbox_CheckedChanged);
            // 
            // cool_method_2_checkbox
            // 
            this.cool_method_2_checkbox.AutoSize = true;
            this.cool_method_2_checkbox.Location = new System.Drawing.Point(16, 48);
            this.cool_method_2_checkbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cool_method_2_checkbox.Name = "cool_method_2_checkbox";
            this.cool_method_2_checkbox.Size = new System.Drawing.Size(38, 21);
            this.cool_method_2_checkbox.TabIndex = 12;
            this.cool_method_2_checkbox.Text = "2";
            this.cool_method_2_checkbox.UseVisualStyleBackColor = true;
            this.cool_method_2_checkbox.CheckedChanged += new System.EventHandler(this.cool_method_2_checkbox_CheckedChanged);
            // 
            // cool_method_1_checkbox
            // 
            this.cool_method_1_checkbox.AutoSize = true;
            this.cool_method_1_checkbox.Location = new System.Drawing.Point(16, 21);
            this.cool_method_1_checkbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cool_method_1_checkbox.Name = "cool_method_1_checkbox";
            this.cool_method_1_checkbox.Size = new System.Drawing.Size(38, 21);
            this.cool_method_1_checkbox.TabIndex = 11;
            this.cool_method_1_checkbox.Text = "1";
            this.cool_method_1_checkbox.UseVisualStyleBackColor = true;
            this.cool_method_1_checkbox.CheckedChanged += new System.EventHandler(this.cool_method_1_checkbox_CheckedChanged);
            // 
            // s1_textBox
            // 
            this.s1_textBox.Location = new System.Drawing.Point(44, 130);
            this.s1_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.s1_textBox.Name = "s1_textBox";
            this.s1_textBox.Size = new System.Drawing.Size(100, 22);
            this.s1_textBox.TabIndex = 10;
            this.s1_textBox.Text = "0,580947501931113";
            // 
            // s1_param_label
            // 
            this.s1_param_label.AutoSize = true;
            this.s1_param_label.Location = new System.Drawing.Point(20, 134);
            this.s1_param_label.Name = "s1_param_label";
            this.s1_param_label.Size = new System.Drawing.Size(23, 17);
            this.s1_param_label.TabIndex = 9;
            this.s1_param_label.Text = "s1";
            // 
            // b_param_label
            // 
            this.b_param_label.AutoSize = true;
            this.b_param_label.Location = new System.Drawing.Point(23, 106);
            this.b_param_label.Name = "b_param_label";
            this.b_param_label.Size = new System.Drawing.Size(16, 17);
            this.b_param_label.TabIndex = 6;
            this.b_param_label.Text = "b";
            // 
            // s_param_label
            // 
            this.s_param_label.AutoSize = true;
            this.s_param_label.Location = new System.Drawing.Point(23, 78);
            this.s_param_label.Name = "s_param_label";
            this.s_param_label.Size = new System.Drawing.Size(15, 17);
            this.s_param_label.TabIndex = 5;
            this.s_param_label.Text = "s";
            // 
            // b_textBox
            // 
            this.b_textBox.Location = new System.Drawing.Point(44, 103);
            this.b_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_textBox.Name = "b_textBox";
            this.b_textBox.Size = new System.Drawing.Size(100, 22);
            this.b_textBox.TabIndex = 2;
            this.b_textBox.Text = "0,27777777777778";
            // 
            // s_textBox
            // 
            this.s_textBox.Location = new System.Drawing.Point(44, 75);
            this.s_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.s_textBox.Name = "s_textBox";
            this.s_textBox.Size = new System.Drawing.Size(100, 22);
            this.s_textBox.TabIndex = 1;
            this.s_textBox.Text = "-0,5773502691896258";
            // 
            // save_label
            // 
            this.save_label.AutoSize = true;
            this.save_label.Location = new System.Drawing.Point(947, 778);
            this.save_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.save_label.Name = "save_label";
            this.save_label.Size = new System.Drawing.Size(0, 17);
            this.save_label.TabIndex = 36;
            // 
            // note_button
            // 
            this.note_button.Location = new System.Drawing.Point(1310, 557);
            this.note_button.Margin = new System.Windows.Forms.Padding(4);
            this.note_button.Name = "note_button";
            this.note_button.Size = new System.Drawing.Size(149, 34);
            this.note_button.TabIndex = 35;
            this.note_button.Text = "Сделать заметку";
            this.note_button.UseVisualStyleBackColor = true;
            this.note_button.Click += new System.EventHandler(this.note_button_Click);
            // 
            // start_params_box_button
            // 
            this.start_params_box_button.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_params_box_button.Location = new System.Drawing.Point(932, 5);
            this.start_params_box_button.Margin = new System.Windows.Forms.Padding(4);
            this.start_params_box_button.Name = "start_params_box_button";
            this.start_params_box_button.Size = new System.Drawing.Size(153, 44);
            this.start_params_box_button.TabIndex = 16;
            this.start_params_box_button.Text = "Начальные данные";
            this.start_params_box_button.UseVisualStyleBackColor = true;
            this.start_params_box_button.Click += new System.EventHandler(this.start_params_box_button_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1395, 615);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 17);
            this.label5.TabIndex = 33;
            this.label5.Text = "Придумайте название файла:";
            // 
            // start_values_box
            // 
            this.start_values_box.AutoSize = true;
            this.start_values_box.Controls.Add(this.y0);
            this.start_values_box.Controls.Add(this.x0);
            this.start_values_box.Controls.Add(this.y0_label);
            this.start_values_box.Controls.Add(this.x0_label);
            this.start_values_box.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_values_box.Location = new System.Drawing.Point(933, 55);
            this.start_values_box.Margin = new System.Windows.Forms.Padding(4);
            this.start_values_box.Name = "start_values_box";
            this.start_values_box.Padding = new System.Windows.Forms.Padding(4);
            this.start_values_box.Size = new System.Drawing.Size(152, 118);
            this.start_values_box.TabIndex = 34;
            this.start_values_box.TabStop = false;
            this.start_values_box.Visible = false;
            // 
            // y0
            // 
            this.y0.Location = new System.Drawing.Point(45, 58);
            this.y0.Margin = new System.Windows.Forms.Padding(4);
            this.y0.Name = "y0";
            this.y0.Size = new System.Drawing.Size(93, 25);
            this.y0.TabIndex = 3;
            // 
            // x0
            // 
            this.x0.Location = new System.Drawing.Point(47, 25);
            this.x0.Margin = new System.Windows.Forms.Padding(4);
            this.x0.Name = "x0";
            this.x0.Size = new System.Drawing.Size(92, 25);
            this.x0.TabIndex = 2;
            // 
            // y0_label
            // 
            this.y0_label.AutoSize = true;
            this.y0_label.Location = new System.Drawing.Point(13, 62);
            this.y0_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.y0_label.Name = "y0_label";
            this.y0_label.Size = new System.Drawing.Size(22, 17);
            this.y0_label.TabIndex = 1;
            this.y0_label.Text = "y0";
            // 
            // x0_label
            // 
            this.x0_label.AutoSize = true;
            this.x0_label.Location = new System.Drawing.Point(13, 28);
            this.x0_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.x0_label.Name = "x0_label";
            this.x0_label.Size = new System.Drawing.Size(22, 17);
            this.x0_label.TabIndex = 0;
            this.x0_label.Text = "x0";
            // 
            // paprams_box_button
            // 
            this.paprams_box_button.AutoSize = true;
            this.paprams_box_button.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paprams_box_button.Location = new System.Drawing.Point(1265, 5);
            this.paprams_box_button.Margin = new System.Windows.Forms.Padding(4);
            this.paprams_box_button.Name = "paprams_box_button";
            this.paprams_box_button.Size = new System.Drawing.Size(167, 44);
            this.paprams_box_button.TabIndex = 15;
            this.paprams_box_button.Text = "Исходные параметры";
            this.paprams_box_button.UseVisualStyleBackColor = true;
            this.paprams_box_button.Click += new System.EventHandler(this.paprams_box_button_Click_1);
            // 
            // save
            // 
            this.save.FlatAppearance.BorderSize = 0;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Image = ((System.Drawing.Image)(resources.GetObject("save.Image")));
            this.save.Location = new System.Drawing.Point(1304, 599);
            this.save.Margin = new System.Windows.Forms.Padding(4);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(80, 110);
            this.save.TabIndex = 31;
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // Kepler
            // 
            this.Kepler.BackColor = System.Drawing.Color.Transparent;
            this.Kepler.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Kepler.BackgroundImage")));
            this.Kepler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Kepler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Kepler.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Kepler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Kepler.Location = new System.Drawing.Point(939, 350);
            this.Kepler.Margin = new System.Windows.Forms.Padding(4);
            this.Kepler.Name = "Kepler";
            this.Kepler.Size = new System.Drawing.Size(249, 92);
            this.Kepler.TabIndex = 30;
            this.Kepler.UseVisualStyleBackColor = false;
            this.Kepler.Click += new System.EventHandler(this.Kepler_Click);
            // 
            // start_speed_button
            // 
            this.start_speed_button.AutoSize = true;
            this.start_speed_button.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_speed_button.Location = new System.Drawing.Point(1092, 5);
            this.start_speed_button.Margin = new System.Windows.Forms.Padding(4);
            this.start_speed_button.Name = "start_speed_button";
            this.start_speed_button.Size = new System.Drawing.Size(165, 43);
            this.start_speed_button.TabIndex = 17;
            this.start_speed_button.Text = "Начальные скорости";
            this.start_speed_button.UseVisualStyleBackColor = true;
            this.start_speed_button.Click += new System.EventHandler(this.start_speed_button_Click_1);
            // 
            // params_in_picture
            // 
            this.params_in_picture.Controls.Add(this.out_params);
            this.params_in_picture.Location = new System.Drawing.Point(944, 449);
            this.params_in_picture.Margin = new System.Windows.Forms.Padding(4);
            this.params_in_picture.Name = "params_in_picture";
            this.params_in_picture.Padding = new System.Windows.Forms.Padding(4);
            this.params_in_picture.Size = new System.Drawing.Size(352, 319);
            this.params_in_picture.TabIndex = 22;
            this.params_in_picture.TabStop = false;
            this.params_in_picture.Text = "Параметры и данные";
            // 
            // out_params
            // 
            this.out_params.AutoSize = true;
            this.out_params.Location = new System.Drawing.Point(25, 31);
            this.out_params.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.out_params.Name = "out_params";
            this.out_params.Size = new System.Drawing.Size(0, 17);
            this.out_params.TabIndex = 0;
            // 
            // params_watch
            // 
            this.params_watch.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.params_watch.Location = new System.Drawing.Point(1440, 5);
            this.params_watch.Margin = new System.Windows.Forms.Padding(4);
            this.params_watch.Name = "params_watch";
            this.params_watch.Size = new System.Drawing.Size(247, 44);
            this.params_watch.TabIndex = 18;
            this.params_watch.Text = "Параметры отображения";
            this.params_watch.UseVisualStyleBackColor = true;
            this.params_watch.Click += new System.EventHandler(this.params_watch_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1310, 465);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Загрузить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // start_params_box
            // 
            this.start_params_box.Controls.Add(this.G_label);
            this.start_params_box.Controls.Add(this.M2_label);
            this.start_params_box.Controls.Add(this.M1_label);
            this.start_params_box.Controls.Add(this.G);
            this.start_params_box.Controls.Add(this.M2);
            this.start_params_box.Controls.Add(this.M1);
            this.start_params_box.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_params_box.Location = new System.Drawing.Point(1265, 57);
            this.start_params_box.Margin = new System.Windows.Forms.Padding(4);
            this.start_params_box.Name = "start_params_box";
            this.start_params_box.Padding = new System.Windows.Forms.Padding(4);
            this.start_params_box.Size = new System.Drawing.Size(167, 123);
            this.start_params_box.TabIndex = 21;
            this.start_params_box.TabStop = false;
            this.start_params_box.Visible = false;
            // 
            // G_label
            // 
            this.G_label.AutoSize = true;
            this.G_label.Location = new System.Drawing.Point(13, 92);
            this.G_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.G_label.Name = "G_label";
            this.G_label.Size = new System.Drawing.Size(18, 17);
            this.G_label.TabIndex = 5;
            this.G_label.Text = "G";
            // 
            // M2_label
            // 
            this.M2_label.AutoSize = true;
            this.M2_label.Location = new System.Drawing.Point(9, 60);
            this.M2_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.M2_label.Name = "M2_label";
            this.M2_label.Size = new System.Drawing.Size(28, 17);
            this.M2_label.TabIndex = 4;
            this.M2_label.Text = "M2";
            // 
            // M1_label
            // 
            this.M1_label.AutoSize = true;
            this.M1_label.Location = new System.Drawing.Point(8, 27);
            this.M1_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.M1_label.Name = "M1_label";
            this.M1_label.Size = new System.Drawing.Size(28, 17);
            this.M1_label.TabIndex = 3;
            this.M1_label.Text = "M1";
            // 
            // G
            // 
            this.G.Location = new System.Drawing.Point(45, 85);
            this.G.Margin = new System.Windows.Forms.Padding(4);
            this.G.Name = "G";
            this.G.Size = new System.Drawing.Size(112, 25);
            this.G.TabIndex = 2;
            // 
            // M2
            // 
            this.M2.Location = new System.Drawing.Point(45, 53);
            this.M2.Margin = new System.Windows.Forms.Padding(4);
            this.M2.Name = "M2";
            this.M2.Size = new System.Drawing.Size(111, 25);
            this.M2.TabIndex = 1;
            // 
            // M1
            // 
            this.M1.Location = new System.Drawing.Point(45, 20);
            this.M1.Margin = new System.Windows.Forms.Padding(4);
            this.M1.Name = "M1";
            this.M1.Size = new System.Drawing.Size(111, 25);
            this.M1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "y, x **",
            "x, t",
            "x, s",
            "y, s",
            "y, t",
            "Vy, Vx **",
            "Vx, t",
            "Vy, t",
            "Vx, s",
            "Vy, s",
            "Vx, x",
            "Vy, y",
            "Vx, y",
            "Vy, x",
            "s, t",
            "q1, s",
            "q2, s ",
            "q2, q1 **",
            "w2, w1 **",
            "q1, t",
            "q2, t",
            "w1, q1",
            "w2, q2",
            "w1, q2",
            "w2, q1",
            "w1, s",
            "w2, s",
            "Fx, t",
            "Fy, t",
            "R, t",
            "tc,eps",
            "s, t (перевод)",
            "H, t",
            "eLRLx, t",
            "eLRLy, t",
            "l, t",
            "|F|, t",
            "|V|, t"});
            this.comboBox1.Location = new System.Drawing.Point(937, 303);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(111, 24);
            this.comboBox1.TabIndex = 29;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(937, 261);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Количество точек";
            // 
            // params_watch_box
            // 
            this.params_watch_box.AutoSize = true;
            this.params_watch_box.Controls.Add(this.cool_method_checkbox);
            this.params_watch_box.Controls.Add(this.middle_point_check_box);
            this.params_watch_box.Controls.Add(this.verle_explicit_checkbox);
            this.params_watch_box.Controls.Add(this.eiler_check_box);
            this.params_watch_box.Controls.Add(this.exact_solution_check_box);
            this.params_watch_box.Controls.Add(this.runge_check_box);
            this.params_watch_box.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.params_watch_box.Location = new System.Drawing.Point(1440, 55);
            this.params_watch_box.Margin = new System.Windows.Forms.Padding(4);
            this.params_watch_box.Name = "params_watch_box";
            this.params_watch_box.Padding = new System.Windows.Forms.Padding(4);
            this.params_watch_box.Size = new System.Drawing.Size(247, 229);
            this.params_watch_box.TabIndex = 28;
            this.params_watch_box.TabStop = false;
            this.params_watch_box.Visible = false;
            // 
            // cool_method_checkbox
            // 
            this.cool_method_checkbox.AutoSize = true;
            this.cool_method_checkbox.Location = new System.Drawing.Point(17, 170);
            this.cool_method_checkbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cool_method_checkbox.Name = "cool_method_checkbox";
            this.cool_method_checkbox.Size = new System.Drawing.Size(72, 21);
            this.cool_method_checkbox.TabIndex = 5;
            this.cool_method_checkbox.Text = "Метод";
            this.cool_method_checkbox.UseVisualStyleBackColor = true;
            this.cool_method_checkbox.CheckedChanged += new System.EventHandler(this.cool_method_checkbox_CheckedChanged);
            // 
            // middle_point_check_box
            // 
            this.middle_point_check_box.AutoSize = true;
            this.middle_point_check_box.Location = new System.Drawing.Point(17, 142);
            this.middle_point_check_box.Margin = new System.Windows.Forms.Padding(4);
            this.middle_point_check_box.Name = "middle_point_check_box";
            this.middle_point_check_box.Size = new System.Drawing.Size(166, 21);
            this.middle_point_check_box.TabIndex = 4;
            this.middle_point_check_box.Text = "Метод средней точки";
            this.middle_point_check_box.UseVisualStyleBackColor = true;
            this.middle_point_check_box.CheckedChanged += new System.EventHandler(this.middle_point_check_box_CheckedChanged);
            // 
            // verle_explicit_checkbox
            // 
            this.verle_explicit_checkbox.AutoSize = true;
            this.verle_explicit_checkbox.Location = new System.Drawing.Point(17, 82);
            this.verle_explicit_checkbox.Margin = new System.Windows.Forms.Padding(4);
            this.verle_explicit_checkbox.Name = "verle_explicit_checkbox";
            this.verle_explicit_checkbox.Size = new System.Drawing.Size(114, 21);
            this.verle_explicit_checkbox.TabIndex = 3;
            this.verle_explicit_checkbox.Text = "Метод Верле";
            this.verle_explicit_checkbox.UseVisualStyleBackColor = true;
            this.verle_explicit_checkbox.CheckedChanged += new System.EventHandler(this.verle_explicit_checkbox_CheckedChanged);
            // 
            // eiler_check_box
            // 
            this.eiler_check_box.AutoSize = true;
            this.eiler_check_box.Location = new System.Drawing.Point(17, 52);
            this.eiler_check_box.Margin = new System.Windows.Forms.Padding(4);
            this.eiler_check_box.Name = "eiler_check_box";
            this.eiler_check_box.Size = new System.Drawing.Size(121, 21);
            this.eiler_check_box.TabIndex = 2;
            this.eiler_check_box.Text = "Метод Эйлера";
            this.eiler_check_box.UseVisualStyleBackColor = true;
            this.eiler_check_box.CheckedChanged += new System.EventHandler(this.eiler_check_box_CheckedChanged_1);
            // 
            // exact_solution_check_box
            // 
            this.exact_solution_check_box.AutoSize = true;
            this.exact_solution_check_box.Checked = true;
            this.exact_solution_check_box.CheckState = System.Windows.Forms.CheckState.Checked;
            this.exact_solution_check_box.Location = new System.Drawing.Point(17, 21);
            this.exact_solution_check_box.Margin = new System.Windows.Forms.Padding(4);
            this.exact_solution_check_box.Name = "exact_solution_check_box";
            this.exact_solution_check_box.Size = new System.Drawing.Size(131, 21);
            this.exact_solution_check_box.TabIndex = 1;
            this.exact_solution_check_box.Text = "Точное решение";
            this.exact_solution_check_box.UseVisualStyleBackColor = true;
            this.exact_solution_check_box.CheckedChanged += new System.EventHandler(this.exact_solution_check_box_CheckedChanged_1);
            // 
            // runge_check_box
            // 
            this.runge_check_box.AutoSize = true;
            this.runge_check_box.Location = new System.Drawing.Point(17, 113);
            this.runge_check_box.Margin = new System.Windows.Forms.Padding(4);
            this.runge_check_box.Name = "runge_check_box";
            this.runge_check_box.Size = new System.Drawing.Size(154, 21);
            this.runge_check_box.TabIndex = 0;
            this.runge_check_box.Text = "Метод Рунге-Кутта";
            this.runge_check_box.UseVisualStyleBackColor = true;
            this.runge_check_box.CheckedChanged += new System.EventHandler(this.runge_check_box_CheckedChanged_1);
            // 
            // start_speed_box
            // 
            this.start_speed_box.Controls.Add(this.epsilon);
            this.start_speed_box.Controls.Add(this.label1);
            this.start_speed_box.Controls.Add(this.Vy0);
            this.start_speed_box.Controls.Add(this.Vx0);
            this.start_speed_box.Controls.Add(this.vx0_label);
            this.start_speed_box.Controls.Add(this.Vy0_label);
            this.start_speed_box.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_speed_box.Location = new System.Drawing.Point(1092, 57);
            this.start_speed_box.Margin = new System.Windows.Forms.Padding(4);
            this.start_speed_box.Name = "start_speed_box";
            this.start_speed_box.Padding = new System.Windows.Forms.Padding(4);
            this.start_speed_box.Size = new System.Drawing.Size(165, 129);
            this.start_speed_box.TabIndex = 23;
            this.start_speed_box.TabStop = false;
            this.start_speed_box.Visible = false;
            // 
            // epsilon
            // 
            this.epsilon.Location = new System.Drawing.Point(59, 89);
            this.epsilon.Margin = new System.Windows.Forms.Padding(4);
            this.epsilon.Name = "epsilon";
            this.epsilon.Size = new System.Drawing.Size(96, 25);
            this.epsilon.TabIndex = 15;
            this.epsilon.Text = "0,2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Eps";
            // 
            // Vy0
            // 
            this.Vy0.Location = new System.Drawing.Point(59, 52);
            this.Vy0.Margin = new System.Windows.Forms.Padding(4);
            this.Vy0.Name = "Vy0";
            this.Vy0.Size = new System.Drawing.Size(97, 25);
            this.Vy0.TabIndex = 13;
            // 
            // Vx0
            // 
            this.Vx0.Location = new System.Drawing.Point(57, 18);
            this.Vx0.Margin = new System.Windows.Forms.Padding(4);
            this.Vx0.Name = "Vx0";
            this.Vx0.Size = new System.Drawing.Size(99, 25);
            this.Vx0.TabIndex = 12;
            // 
            // vx0_label
            // 
            this.vx0_label.AutoSize = true;
            this.vx0_label.Location = new System.Drawing.Point(15, 27);
            this.vx0_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vx0_label.Name = "vx0_label";
            this.vx0_label.Size = new System.Drawing.Size(33, 17);
            this.vx0_label.TabIndex = 10;
            this.vx0_label.Text = "Vx0";
            // 
            // Vy0_label
            // 
            this.Vy0_label.AutoSize = true;
            this.Vy0_label.Location = new System.Drawing.Point(15, 60);
            this.Vy0_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Vy0_label.Name = "Vy0_label";
            this.Vy0_label.Size = new System.Drawing.Size(31, 17);
            this.Vy0_label.TabIndex = 11;
            this.Vy0_label.Text = "Vy0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(933, 230);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Число периодов в методах";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1757, 894);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Постановка задачи";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(963, 665);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1754, 894);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Задача Кеплера";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1763, 830);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(52, 59);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1067, 302);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(52, 380);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1065, 430);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(53, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(383, 54);
            this.label2.TabIndex = 1;
            this.label2.Text = "Задача Кеплера";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-6, 1);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1762, 923);
            this.tabControl1.TabIndex = 36;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1765, 874);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Кеплер Premium Edition";
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.cool_method_box.ResumeLayout(false);
            this.cool_method_box.PerformLayout();
            this.start_values_box.ResumeLayout(false);
            this.start_values_box.PerformLayout();
            this.params_in_picture.ResumeLayout(false);
            this.params_in_picture.PerformLayout();
            this.start_params_box.ResumeLayout(false);
            this.start_params_box.PerformLayout();
            this.params_watch_box.ResumeLayout(false);
            this.params_watch_box.PerformLayout();
            this.start_speed_box.ResumeLayout(false);
            this.start_speed_box.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox number_points_textbox;
        private ZedGraph.ZedGraphControl z1;
        private System.Windows.Forms.TextBox save_name;
        public System.Windows.Forms.TextBox points_count;
        public System.Windows.Forms.TextBox P_C;
        private System.Windows.Forms.CheckBox exact_points_checkbox;
        private System.Windows.Forms.GroupBox cool_method_box;
        private System.Windows.Forms.Button inaccuracy_button;
        private System.Windows.Forms.CheckBox invariant_checkbox;
        private System.Windows.Forms.CheckBox cool_method_4_checkbox;
        private System.Windows.Forms.CheckBox cool_method_3_checkbox;
        private System.Windows.Forms.CheckBox cool_method_2_checkbox;
        private System.Windows.Forms.CheckBox cool_method_1_checkbox;
        private System.Windows.Forms.TextBox s1_textBox;
        private System.Windows.Forms.Label s1_param_label;
        private System.Windows.Forms.Label b_param_label;
        private System.Windows.Forms.Label s_param_label;
        private System.Windows.Forms.TextBox b_textBox;
        private System.Windows.Forms.TextBox s_textBox;
        private System.Windows.Forms.Label save_label;
        private System.Windows.Forms.Button note_button;
        private System.Windows.Forms.Button start_params_box_button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox start_values_box;
        public System.Windows.Forms.TextBox y0;
        public System.Windows.Forms.TextBox x0;
        private System.Windows.Forms.Label y0_label;
        private System.Windows.Forms.Label x0_label;
        private System.Windows.Forms.Button paprams_box_button;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button Kepler;
        private System.Windows.Forms.Button start_speed_button;
        private System.Windows.Forms.GroupBox params_in_picture;
        private System.Windows.Forms.Label out_params;
        private System.Windows.Forms.Button params_watch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox start_params_box;
        private System.Windows.Forms.Label G_label;
        private System.Windows.Forms.Label M2_label;
        private System.Windows.Forms.Label M1_label;
        public System.Windows.Forms.TextBox G;
        public System.Windows.Forms.TextBox M2;
        public System.Windows.Forms.TextBox M1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox params_watch_box;
        private System.Windows.Forms.CheckBox cool_method_checkbox;
        private System.Windows.Forms.CheckBox middle_point_check_box;
        private System.Windows.Forms.CheckBox verle_explicit_checkbox;
        private System.Windows.Forms.CheckBox eiler_check_box;
        private System.Windows.Forms.CheckBox exact_solution_check_box;
        private System.Windows.Forms.CheckBox runge_check_box;
        private System.Windows.Forms.GroupBox start_speed_box;
        private System.Windows.Forms.TextBox epsilon;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox Vy0;
        public System.Windows.Forms.TextBox Vx0;
        private System.Windows.Forms.Label vx0_label;
        private System.Windows.Forms.Label Vy0_label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

