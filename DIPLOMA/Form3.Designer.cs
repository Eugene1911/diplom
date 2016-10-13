namespace DIPLOMA
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.inaccuracy_box = new System.Windows.Forms.GroupBox();
            this.periods_groupBox = new System.Windows.Forms.GroupBox();
            this.per_1_textbox = new System.Windows.Forms.TextBox();
            this.max_checkBox = new System.Windows.Forms.CheckBox();
            this.points_for_period = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.periods_textBox = new System.Windows.Forms.TextBox();
            this.points_groupBox = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.log_checkBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.step_textbox = new System.Windows.Forms.TextBox();
            this.end_textbox = new System.Windows.Forms.TextBox();
            this.begin_textbox = new System.Windows.Forms.TextBox();
            this.points_checkbox = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cool_method_4_checkbox = new System.Windows.Forms.CheckBox();
            this.cool_method_3_checkbox = new System.Windows.Forms.CheckBox();
            this.cool_method_2_checkbox = new System.Windows.Forms.CheckBox();
            this.cool_method_1_checkbox = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.z2 = new ZedGraph.ZedGraphControl();
            this.Kepler2 = new System.Windows.Forms.Button();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.inaccuracy_box.SuspendLayout();
            this.periods_groupBox.SuspendLayout();
            this.points_groupBox.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inaccuracy_box
            // 
            this.inaccuracy_box.Controls.Add(this.periods_groupBox);
            this.inaccuracy_box.Controls.Add(this.points_groupBox);
            this.inaccuracy_box.Controls.Add(this.points_checkbox);
            this.inaccuracy_box.Controls.Add(this.checkBox2);
            this.inaccuracy_box.Controls.Add(this.checkBox1);
            this.inaccuracy_box.Controls.Add(this.cool_method_4_checkbox);
            this.inaccuracy_box.Controls.Add(this.cool_method_3_checkbox);
            this.inaccuracy_box.Controls.Add(this.cool_method_2_checkbox);
            this.inaccuracy_box.Controls.Add(this.cool_method_1_checkbox);
            this.inaccuracy_box.Controls.Add(this.comboBox1);
            this.inaccuracy_box.Location = new System.Drawing.Point(710, 183);
            this.inaccuracy_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inaccuracy_box.Name = "inaccuracy_box";
            this.inaccuracy_box.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inaccuracy_box.Size = new System.Drawing.Size(416, 454);
            this.inaccuracy_box.TabIndex = 44;
            this.inaccuracy_box.TabStop = false;
            this.inaccuracy_box.Text = "Погрешности";
            this.inaccuracy_box.Enter += new System.EventHandler(this.inaccuracy_box_Enter);
            // 
            // periods_groupBox
            // 
            this.periods_groupBox.Controls.Add(this.per_1_textbox);
            this.periods_groupBox.Controls.Add(this.max_checkBox);
            this.periods_groupBox.Controls.Add(this.points_for_period);
            this.periods_groupBox.Controls.Add(this.label5);
            this.periods_groupBox.Controls.Add(this.label4);
            this.periods_groupBox.Controls.Add(this.periods_textBox);
            this.periods_groupBox.Location = new System.Drawing.Point(6, 194);
            this.periods_groupBox.Name = "periods_groupBox";
            this.periods_groupBox.Size = new System.Drawing.Size(204, 185);
            this.periods_groupBox.TabIndex = 20;
            this.periods_groupBox.TabStop = false;
            this.periods_groupBox.Text = "периоды";
            // 
            // per_1_textbox
            // 
            this.per_1_textbox.Location = new System.Drawing.Point(10, 53);
            this.per_1_textbox.Name = "per_1_textbox";
            this.per_1_textbox.Size = new System.Drawing.Size(100, 22);
            this.per_1_textbox.TabIndex = 5;
            this.per_1_textbox.Text = "1";
            // 
            // max_checkBox
            // 
            this.max_checkBox.AutoSize = true;
            this.max_checkBox.Location = new System.Drawing.Point(139, 59);
            this.max_checkBox.Name = "max_checkBox";
            this.max_checkBox.Size = new System.Drawing.Size(55, 21);
            this.max_checkBox.TabIndex = 4;
            this.max_checkBox.Text = "max";
            this.max_checkBox.UseVisualStyleBackColor = true;
            this.max_checkBox.CheckedChanged += new System.EventHandler(this.max_checkBox_CheckedChanged);
            // 
            // points_for_period
            // 
            this.points_for_period.Location = new System.Drawing.Point(9, 142);
            this.points_for_period.Name = "points_for_period";
            this.points_for_period.Size = new System.Drawing.Size(100, 22);
            this.points_for_period.TabIndex = 3;
            this.points_for_period.Text = "200";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "точек на период";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "количество периодов";
            // 
            // periods_textBox
            // 
            this.periods_textBox.Location = new System.Drawing.Point(9, 85);
            this.periods_textBox.Name = "periods_textBox";
            this.periods_textBox.Size = new System.Drawing.Size(100, 22);
            this.periods_textBox.TabIndex = 0;
            this.periods_textBox.Text = "1";
            // 
            // points_groupBox
            // 
            this.points_groupBox.CausesValidation = false;
            this.points_groupBox.Controls.Add(this.comboBox2);
            this.points_groupBox.Controls.Add(this.log_checkBox);
            this.points_groupBox.Controls.Add(this.label3);
            this.points_groupBox.Controls.Add(this.label2);
            this.points_groupBox.Controls.Add(this.label1);
            this.points_groupBox.Controls.Add(this.step_textbox);
            this.points_groupBox.Controls.Add(this.end_textbox);
            this.points_groupBox.Controls.Add(this.begin_textbox);
            this.points_groupBox.Location = new System.Drawing.Point(216, 119);
            this.points_groupBox.Name = "points_groupBox";
            this.points_groupBox.Size = new System.Drawing.Size(194, 222);
            this.points_groupBox.TabIndex = 19;
            this.points_groupBox.TabStop = false;
            this.points_groupBox.Text = "Сетка точек";
            this.points_groupBox.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "R max",
            "R min",
            "log R max",
            "log R min"});
            this.comboBox2.Location = new System.Drawing.Point(117, 44);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(71, 24);
            this.comboBox2.TabIndex = 7;
            // 
            // log_checkBox
            // 
            this.log_checkBox.AutoSize = true;
            this.log_checkBox.Location = new System.Drawing.Point(139, 17);
            this.log_checkBox.Name = "log_checkBox";
            this.log_checkBox.Size = new System.Drawing.Size(49, 21);
            this.log_checkBox.TabIndex = 6;
            this.log_checkBox.Text = "log";
            this.log_checkBox.UseVisualStyleBackColor = true;
            this.log_checkBox.CheckedChanged += new System.EventHandler(this.log_checkBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "шаг";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "конец";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "начало";
            // 
            // step_textbox
            // 
            this.step_textbox.Location = new System.Drawing.Point(6, 158);
            this.step_textbox.Name = "step_textbox";
            this.step_textbox.Size = new System.Drawing.Size(100, 22);
            this.step_textbox.TabIndex = 2;
            this.step_textbox.Text = "10";
            // 
            // end_textbox
            // 
            this.end_textbox.Location = new System.Drawing.Point(3, 95);
            this.end_textbox.Name = "end_textbox";
            this.end_textbox.Size = new System.Drawing.Size(103, 22);
            this.end_textbox.TabIndex = 1;
            this.end_textbox.Text = "500";
            // 
            // begin_textbox
            // 
            this.begin_textbox.Location = new System.Drawing.Point(3, 41);
            this.begin_textbox.Name = "begin_textbox";
            this.begin_textbox.Size = new System.Drawing.Size(103, 22);
            this.begin_textbox.TabIndex = 0;
            this.begin_textbox.Text = "10";
            // 
            // points_checkbox
            // 
            this.points_checkbox.AutoSize = true;
            this.points_checkbox.Location = new System.Drawing.Point(219, 80);
            this.points_checkbox.Name = "points_checkbox";
            this.points_checkbox.Size = new System.Drawing.Size(148, 21);
            this.points_checkbox.TabIndex = 18;
            this.points_checkbox.Text = "количество точек";
            this.points_checkbox.UseVisualStyleBackColor = true;
            this.points_checkbox.CheckedChanged += new System.EventHandler(this.points_checkbox_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(333, 41);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(34, 21);
            this.checkBox2.TabIndex = 17;
            this.checkBox2.Text = "t";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(290, 41);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(37, 21);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "s";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cool_method_4_checkbox
            // 
            this.cool_method_4_checkbox.AutoSize = true;
            this.cool_method_4_checkbox.Location = new System.Drawing.Point(172, 136);
            this.cool_method_4_checkbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cool_method_4_checkbox.Name = "cool_method_4_checkbox";
            this.cool_method_4_checkbox.Size = new System.Drawing.Size(38, 21);
            this.cool_method_4_checkbox.TabIndex = 15;
            this.cool_method_4_checkbox.Text = "4";
            this.cool_method_4_checkbox.UseVisualStyleBackColor = true;
            this.cool_method_4_checkbox.CheckedChanged += new System.EventHandler(this.cool_method_4_checkbox_CheckedChanged);
            // 
            // cool_method_3_checkbox
            // 
            this.cool_method_3_checkbox.AutoSize = true;
            this.cool_method_3_checkbox.Location = new System.Drawing.Point(172, 103);
            this.cool_method_3_checkbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cool_method_3_checkbox.Name = "cool_method_3_checkbox";
            this.cool_method_3_checkbox.Size = new System.Drawing.Size(38, 21);
            this.cool_method_3_checkbox.TabIndex = 14;
            this.cool_method_3_checkbox.Text = "3";
            this.cool_method_3_checkbox.UseVisualStyleBackColor = true;
            this.cool_method_3_checkbox.CheckedChanged += new System.EventHandler(this.cool_method_3_checkbox_CheckedChanged);
            // 
            // cool_method_2_checkbox
            // 
            this.cool_method_2_checkbox.AutoSize = true;
            this.cool_method_2_checkbox.Location = new System.Drawing.Point(172, 72);
            this.cool_method_2_checkbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cool_method_2_checkbox.Name = "cool_method_2_checkbox";
            this.cool_method_2_checkbox.Size = new System.Drawing.Size(38, 21);
            this.cool_method_2_checkbox.TabIndex = 13;
            this.cool_method_2_checkbox.Text = "2";
            this.cool_method_2_checkbox.UseVisualStyleBackColor = true;
            this.cool_method_2_checkbox.CheckedChanged += new System.EventHandler(this.cool_method_2_checkbox_CheckedChanged);
            // 
            // cool_method_1_checkbox
            // 
            this.cool_method_1_checkbox.AutoSize = true;
            this.cool_method_1_checkbox.Location = new System.Drawing.Point(172, 38);
            this.cool_method_1_checkbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cool_method_1_checkbox.Name = "cool_method_1_checkbox";
            this.cool_method_1_checkbox.Size = new System.Drawing.Size(38, 21);
            this.cool_method_1_checkbox.TabIndex = 12;
            this.cool_method_1_checkbox.Text = "1";
            this.cool_method_1_checkbox.UseVisualStyleBackColor = true;
            this.cool_method_1_checkbox.CheckedChanged += new System.EventHandler(this.cool_method_1_checkbox_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "dx",
            "dy",
            "dVx",
            "dVy",
            "dt, i",
            "dt",
            "dR",
            "rel R max",
            "rel R min",
            "no abs dR"});
            this.comboBox1.Location = new System.Drawing.Point(6, 38);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // z2
            // 
            this.z2.BackColor = System.Drawing.Color.White;
            this.z2.Location = new System.Drawing.Point(13, 62);
            this.z2.Margin = new System.Windows.Forms.Padding(5);
            this.z2.Name = "z2";
            this.z2.ScrollGrace = 0D;
            this.z2.ScrollMaxX = 0D;
            this.z2.ScrollMaxY = 0D;
            this.z2.ScrollMaxY2 = 0D;
            this.z2.ScrollMinX = 0D;
            this.z2.ScrollMinY = 0D;
            this.z2.ScrollMinY2 = 0D;
            this.z2.Size = new System.Drawing.Size(689, 589);
            this.z2.TabIndex = 45;
            // 
            // Kepler2
            // 
            this.Kepler2.BackColor = System.Drawing.Color.White;
            this.Kepler2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Kepler2.BackgroundImage")));
            this.Kepler2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Kepler2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Kepler2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Kepler2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Kepler2.Location = new System.Drawing.Point(730, 62);
            this.Kepler2.Margin = new System.Windows.Forms.Padding(4);
            this.Kepler2.Name = "Kepler2";
            this.Kepler2.Size = new System.Drawing.Size(249, 92);
            this.Kepler2.TabIndex = 46;
            this.Kepler2.UseVisualStyleBackColor = false;
            this.Kepler2.Click += new System.EventHandler(this.Kepler2_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.White;
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(13, 11);
            this.toolStripContainer1.ContentPanel.Visible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(43, 601);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(13, 36);
            this.toolStripContainer1.TabIndex = 47;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1138, 708);
            this.Controls.Add(this.Kepler2);
            this.Controls.Add(this.z2);
            this.Controls.Add(this.inaccuracy_box);
            this.Controls.Add(this.toolStripContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form3";
            this.ShowInTaskbar = false;
            this.Text = "Погрешности";
            this.TransparencyKey = System.Drawing.Color.Blue;
            this.inaccuracy_box.ResumeLayout(false);
            this.inaccuracy_box.PerformLayout();
            this.periods_groupBox.ResumeLayout(false);
            this.periods_groupBox.PerformLayout();
            this.points_groupBox.ResumeLayout(false);
            this.points_groupBox.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox inaccuracy_box;
        private ZedGraph.ZedGraphControl z2;
        private System.Windows.Forms.Button Kepler2;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox cool_method_1_checkbox;
        private System.Windows.Forms.CheckBox cool_method_2_checkbox;
        private System.Windows.Forms.CheckBox cool_method_3_checkbox;
        private System.Windows.Forms.CheckBox cool_method_4_checkbox;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox points_groupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox step_textbox;
        private System.Windows.Forms.TextBox end_textbox;
        private System.Windows.Forms.TextBox begin_textbox;
        private System.Windows.Forms.CheckBox points_checkbox;
        private System.Windows.Forms.CheckBox log_checkBox;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox periods_textBox;
        private System.Windows.Forms.GroupBox periods_groupBox;
        private System.Windows.Forms.TextBox points_for_period;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox max_checkBox;
        private System.Windows.Forms.TextBox per_1_textbox;
    }
}