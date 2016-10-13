using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using ZedGraph;
using System.Web.Script.Serialization;

namespace DIPLOMA
{
    public partial class Form3 : Form
    {
        Form1 F1;
        public Form3(Form1 F)
        {
            InitializeComponent();
            F1 = F;
        }
        bool[] c_m = new bool[]{false, false, false, false};
        bool t_flag = true, abs_flag = true;
        public void rename_axis(string ax_y, string ax_x)
        {
            z2.GraphPane.XAxis.Title.Text = ax_x;
            z2.GraphPane.YAxis.Title.Text = ax_y;
        }
        public void clear_graph()
        {
            // Если есть что удалять
            if (z2.GraphPane.CurveList.Count > 0)
            {


                // Удалим кривую по индексу
                for (int k = z2.GraphPane.CurveList.Count - 1; k >= 0; k--)
                {
                    z2.GraphPane.CurveList.RemoveAt(k);
                    //z1.GraphPane.CurveList.RemoveAt(1);
                }
                // Обновим график
                z2.AxisChange();
                z2.Invalidate();
                //}
            }
        }

        Color graphColor(int i)
        {
            switch (i)
            {
                case 0: return Color.Black;
                case 1: return Color.Red;
                case 2: return Color.Indigo;
                case 3: return Color.Green;
            }
            return Color.HotPink;
        }

        void draw_graph(double[][] s, Hashtable[] hashes, double[][] y, string name)
        {
            int first_per = Convert.ToInt32(per_1_textbox.Text);
            int last_per = Convert.ToInt32(periods_textBox.Text);
            int num_of_per = last_per - first_per + 1;
            int num_of_points = Convert.ToInt32(points_for_period.Text);
            int length = num_of_per * num_of_points;

            if (t_flag)
            {
                z2.GraphPane.Title.Text = name + "(t)";
                rename_axis(name, "t");
                for (int i = 0; i < 4; i++)
                {
                    if (c_m[i])
                    {
                        double[] temp = new double[length];
                        for (int j = 0; j < length; j++)
                        {
                            temp[j] = ((double[])hashes[i]["t"])[j + (first_per - 1) * num_of_points];
                        }

                        z2.GraphPane.AddCurve("", temp, y[i], graphColor(i), SymbolType.None);
                    }
                }
            }
            else
            {
                z2.GraphPane.Title.Text = name + "(s)";
                rename_axis(name, "s");
                for (int i = 0; i < 4; i++)
                {
                    if (c_m[i])
                    {
                        double[] temp = new double[length];
                        for (int j = 0; j < length; j++)
                        {
                            temp[j] = s[i][j + (first_per - 1) * num_of_points];
                        }
                        z2.GraphPane.AddCurve("", temp, y[i], graphColor(i), SymbolType.None);
                    }
                }
            }
            
        }

        void Initialize()
        {
            double vx0 = Convert.ToDouble(F1.Vx0.Text);
            double vy0 = Convert.ToDouble(F1.Vy0.Text);
            double X0 = Convert.ToDouble(F1.x0.Text);
            double Y0 = Convert.ToDouble(F1.y0.Text);
            F1.w10 = vx0 * X0 * Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, -0.5) + vy0 * Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, 0.5);
            F1.w20 = vx0 * Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, 0.5) - vy0 * X0 * Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, -0.5);
            F1.q10 = Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, 0.5);
            F1.q20 = X0 * Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, -0.5);
            F1.H = -(0.5 * (vx0 * vx0 + vy0 * vy0) - Convert.ToDouble(F1.G.Text) * (Convert.ToDouble(F1.M1.Text)
                + Convert.ToDouble(F1.M2.Text)) * Math.Pow(X0 * X0 + Y0 * Y0, -0.5));
            F1.compute_coefs();
        }

        void Super_Kepler()
        {
            Initialize();
            Hashtable[] hashes = new Hashtable[4];
            int begin = System.Convert.ToInt32(begin_textbox.Text);
            int end = System.Convert.ToInt32(end_textbox.Text);
            int step = System.Convert.ToInt32(step_textbox.Text);
            double[][] R = new double[4][];
            double[][] dR = new double[4][];
            double[][] max_dR = new double[4][];
            double[][] min_dR = new double[4][];
            double[][] s = new double[4][];
            double[] points_array = new double[(end - begin) / step + 1];
            double[][] log_dR_max = new double[4][];
            double[][] log_dR_min = new double[4][];
            double[] log_points = new double[(end - begin) / step + 1];
            int st = 0;

            for (int arr = 0; arr < 4; arr++){ 
                max_dR[arr] = new double[(end - begin) / step + 1];
                min_dR[arr] = new double[(end - begin) / step + 1];
                log_dR_max[arr] = new double[(end - begin) / step + 1];
                log_dR_min[arr] = new double[(end - begin) / step + 1];
            }
            if (log_checkBox.Checked)
            {
                for (int points = begin; points <= end; points += step)
                {
                    //double points = Math.Pow(10, l_points);
                    F1.points_count.Text = points.ToString();
                    for (int i = 0; i < 4; i++)
                    {
                        if (c_m[i])
                        {
                            hashes[i] = F1.cool_method("", i + 1);
                            s[i] = F1.T_to_S((double[])hashes[i]["t"]);
                            R[i] = new double[s[i].Length];
                            dR[i] = new double[s[i].Length];
                            for (int j = 0; j < s[i].Length; j++)
                            {
                                R[i][j] = F1.radius_count(F1.x(s[i][j]), F1.y(s[i][j]));
                                dR[i][j] = Math.Abs(R[i][j] - ((double[])hashes[i]["R"])[j]);
                            }
                            log_dR_max[i][st] = -Math.Log10(dR[i].Max());
                            log_dR_min[i][st] = -Math.Log10(dR[i].Min());
                        }
                    }
                    log_points[st] = Math.Log10(points);
                    st++;
                }
            }
            else
            {
                for (int points = begin; points <= end; points += step)
                {
                    F1.points_count.Text = points.ToString();
                    for (int i = 0; i < 4; i++)
                    {
                        if (c_m[i])
                        {
                            hashes[i] = F1.cool_method("", i + 1);
                            s[i] = F1.T_to_S((double[])hashes[i]["t"]);
                            R[i] = new double[s[i].Length];
                            dR[i] = new double[s[i].Length];
                            for (int j = 0; j < s[i].Length; j++)
                            {
                                R[i][j] = F1.radius_count(F1.x(s[i][j]), F1.y(s[i][j]));
                                dR[i][j] = Math.Abs(R[i][j] - ((double[])hashes[i]["R"])[j]);
                            }
                            max_dR[i][st] = dR[i].Max();
                            min_dR[i][st] = dR[i].Min();
                        }
                    }
                    points_array[st] = points;
                    st++;
                }
            }
            clear_graph();
            z2.IsShowPointValues = true;
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    z2.GraphPane.Title.Text = "max R(points)";
                    rename_axis("max R" , "points");
                    for (int i = 0; i < 4; i++)
                    if (c_m[i]) z2.GraphPane.AddCurve("", points_array, max_dR[i], graphColor(i), SymbolType.None);
                    break;
                case 1:
                    z2.GraphPane.Title.Text = "min R(points)";
                    rename_axis("min R", "points");
                    for (int i = 0; i < 4; i++)
                        if (c_m[i]) z2.GraphPane.AddCurve("", points_array, min_dR[i], graphColor(i), SymbolType.None);
                    break;
                case 2:
                    z2.GraphPane.Title.Text = "log max R(points)";
                    rename_axis("log max R", "points");
                    for (int i = 0; i < 4; i++)
                        if (c_m[i]) z2.GraphPane.AddCurve("", log_points, log_dR_max[i], graphColor(i), SymbolType.None);
                    break;
                case 3:
                    z2.GraphPane.Title.Text = "log min R(points)";
                    rename_axis("log min R", "points");
                    for (int i = 0; i < 4; i++)
                        if (c_m[i]) z2.GraphPane.AddCurve("", log_points, log_dR_min[i], graphColor(i), SymbolType.None);
                    break;
            }
            
            z2.AxisChange();
            z2.Invalidate();
        }

        delegate double f(double s);
        

        void init_divide(Hashtable[] h, double[][] a, double[][] da, double[][] s, string name,  f f)
        {
            int first_per = Convert.ToInt32(per_1_textbox.Text);
            int last_per = Convert.ToInt32(periods_textBox.Text);
            int num_of_per = last_per - first_per + 1;
            int num_of_points = Convert.ToInt32(points_for_period.Text);
            int length = num_of_per * num_of_points;
            for (int i = 0; i < 4; i++)
            {
                if (c_m[i])
                {
                    //a[i] = new double[s[i].Length];
                    //da[i] = new double[s[i].Length];
                    a[i] = new double[length];
                    da[i] = new double[length];
                    for (int j = 0; j < length; j++)
                    {
                        a[i][j] = f(s[i][j + (first_per - 1) * num_of_points]);
                        da[i][j] = Math.Abs(a[i][j] - ((double[])h[i][name])[j + (first_per - 1) * num_of_points]);
                    }
                }
            }
        }

        void init_divide_R(Hashtable[] h, double[][] a, double[][] da, double[][] s, double[][] X, double[][] Y)
        {
            int first_per = Convert.ToInt32(per_1_textbox.Text);
            int last_per = Convert.ToInt32(periods_textBox.Text);
            int num_of_per = last_per - first_per + 1;
            int num_of_points = Convert.ToInt32(points_for_period.Text);
            int length = num_of_per * num_of_points;
            for (int i = 0; i < 4; i++)
            {
                if (c_m[i])
                {
                    //a[i] = new double[s[i].Length];
                    //da[i] = new double[s[i].Length];
                    //X[i] = new double[s[i].Length];
                    //Y[i] = new double[s[i].Length];

                    a[i] = new double[length];
                    da[i] = new double[length];
                    X[i] = new double[length];
                    Y[i] = new double[length];

                    for (int j = 0; j < length; j++)
                    {
                        X[i][j] = F1.x(s[i][j + (first_per - 1) * num_of_points]);
                        Y[i][j] = F1.y(s[i][j + (first_per - 1) * num_of_points]);
                        a[i][j] = F1.radius_count(X[i][j], Y[i][j]);
                        if (abs_flag)
                            da[i][j] = Math.Abs(a[i][j] - ((double[])h[i]["R"])[j + (first_per - 1) * num_of_points]);
                        else
                            da[i][j] = a[i][j] - ((double[])h[i]["R"])[j + (first_per - 1) * num_of_points];                            
                    }
                    //double[] temp = new double[length];
                    //for (int j = 0; j < length; j++)
                    //{
                    //    temp[j] = s[i][j + (first_per - 1) * num_of_points];
                    //}
                    //s[i] = temp;
                }
            }
        }

        void max_per(int per_num, int points_num, double[] periods, double[][] max_periods, double[][] da, string name)
        {
            int first_per = Convert.ToInt32(per_1_textbox.Text);
            int last_per = Convert.ToInt32(periods_textBox.Text);
            int num_of_per = last_per - first_per + 1;
            int num_of_points = Convert.ToInt32(points_for_period.Text);
            int length = num_of_per * num_of_points;
            double[] temp = new double[points_num];
            double[] temp2 = new double[num_of_per];
            for (int i = 0; i < 4; i++)
            {
                if (c_m[i])
                {
                    for (int per = 0; per < num_of_per; per++)
                    {
                        for (int j = 0; j < points_num; j++)
                            temp[j] = da[i][j + per * num_of_points];
                        
                        max_periods[i][per] = temp.Max();
                    }
                    z2.GraphPane.Title.Text = "max" + name + "(periods)";
                    rename_axis("max" + name, "periods");

                    z2.GraphPane.AddCurve("", periods, max_periods[i], graphColor(i), SymbolType.None);
                }
            }
        }

        private void Kepler2_Click(object sender, EventArgs e)
        {
            if (points_checkbox.Checked)
            {
                Super_Kepler();
                return;
            }
           
            Initialize();
            Hashtable[] hashes = new Hashtable[4];
            //Hashtable midlle = new Hashtable();
            double[][] s = new double[4][];
            double[][] t = new double[4][];
            double[][] dt = new double[4][];
            double[][] dX = new double[4][];
            double[][] dY = new double[4][];
            double[][] dVx = new double[4][];
            double[][] dVy = new double[4][];
            double[][] X = new double[4][];
            double[][] Y = new double[4][];
            double[][] Vx = new double[4][];
            double[][] Vy = new double[4][];
            double[][] xAxis = new double[4][];
            double[][] R = new double[4][];
            double[][] dR = new double[4][];
            double[][] rel_R_max = new double[4][];
            double[][] rel_R_min = new double[4][];
            int first_per = Convert.ToInt32(per_1_textbox.Text);
            int last_per = Convert.ToInt32(periods_textBox.Text);
            int num_of_per = last_per - first_per + 1;
            int num_of_points = Convert.ToInt32(points_for_period.Text);
            int length = num_of_per * num_of_points;

            int per_num =  Convert.ToInt32(periods_textBox.Text);
            int points_num = Convert.ToInt32(points_for_period.Text);
            double[] periods = new double[num_of_per];
            double[][] max_periods = new double[4][];
            

            //hashes[0] = F1.cool_method("", 1);
            //hashes[1] = F1.cool_method("", 2);
            //hashes[2] = F1.cool_method("", 3);
            //hashes[3] = F1.cool_method("", 4);
         
            F1.points_count.Text = (per_num * points_num).ToString();
            F1.P_C.Text = periods_textBox.Text;
            if (max_checkBox.Checked)
                for (int per = 0; per < num_of_per; per++)
                    periods[per] = per + 1;
            for (int i = 0; i < 4; i++)
            {
                if (c_m[i])
                {
                    hashes[i] = F1.cool_method("", i + 1);
                    s[i] = F1.T_to_S((double[])hashes[i]["t"]);
                    max_periods[i] = new double[per_num];
                }
                                             
            }
            clear_graph();
            z2.IsShowPointValues = true;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    init_divide(hashes, X, dX, s, "X", F1.x);
                    if (max_checkBox.Checked)
                        max_per(per_num, points_num, periods, max_periods, dX, "dx");
                    else
                        draw_graph(s, hashes, dX, "dx");
                    break;
                
                case 1:
                    init_divide(hashes, Y, dY, s, "Y", F1.y);
                    if (max_checkBox.Checked)
                        max_per(per_num, points_num, periods, max_periods, dY, "dy");
                    else
                        draw_graph(s, hashes, dY, "dy");
                    break;
                case 2:
                    init_divide(hashes, Vx, dVx, s, "Vx", F1.Vx);
                    if (max_checkBox.Checked)
                        max_per(per_num, points_num, periods, max_periods, dVx, "dVx");
                    else
                        draw_graph(s, hashes, dVx, "dVx");
                    break;
                case 3:
                    init_divide(hashes, Vy, dVy, s, "Vy", F1.Vy);
                    if (max_checkBox.Checked)
                        max_per(per_num, points_num, periods, max_periods, dVy, "dVy");
                    else
                        draw_graph(s, hashes, dVy, "dVy");
                    break;
                case 4:
                    
                    init_divide(hashes, t, dt, s, "t", F1.t);
                    for (int i = 0; i < 4; i++)
                    {
                        if (c_m[i])
                        {
                            xAxis[i] = new double[s[i].Length];
                            for (int j = 0; j < s[i].Length; j++)
                                xAxis[i][j] = j;
                        }
                    }
                    z2.GraphPane.Title.Text = "dt(i)";
                    rename_axis("dt", "i");
                    for (int i = 0; i < 4; i++)
                    {
                        if (c_m[i]) z2.GraphPane.AddCurve("", xAxis[i], dt[i], graphColor(i), SymbolType.None);
                    }
                    break;
                case 5:
                    
                    init_divide(hashes, t, dt, s, "t", F1.t);
                    if (max_checkBox.Checked)
                        max_per(per_num, points_num, periods, max_periods, dt, "dt");
                    else
                        draw_graph(s, hashes, dt, "dt");
                    break;
                case 6:
                    init_divide_R(hashes, R, dR, s, X, Y);
                    if (max_checkBox.Checked)
                        max_per(per_num, points_num, periods, max_periods, dR, "dR");
                    else
                        draw_graph(s, hashes, dR, "dR");
                    break;
                case 7:
                    init_divide_R(hashes, R, dR, s, X, Y);
                   
                    for (int i = 0; i < 4; i++)
                    {
                        if (c_m[i])
                        {
                            rel_R_max[i] = new double[length];
                            for (int j = 0; j < length; j++)
                                rel_R_max[i][j] = dR[i][j] / R[i].Max();
                        }
                    }
                    if (max_checkBox.Checked)
                        max_per(per_num, points_num, periods, max_periods, rel_R_max, "rel R max");
                    else
                        draw_graph(s, hashes, rel_R_max, "rel R max");
                    break;
                case 8:
                    init_divide_R(hashes, R, dR, s, X, Y);

                    for (int i = 0; i < 4; i++)
                    {
                        if (c_m[i])
                        {
                            rel_R_min[i] = new double[length];
                            for (int j = 0; j < length; j++)
                                rel_R_min[i][j] = dR[i][j] / R[i].Min();
                        }
                    }
                    if (max_checkBox.Checked)
                        max_per(per_num, points_num, periods, max_periods, rel_R_min, "rel R min");
                    else
                        draw_graph(s, hashes, rel_R_min, "rel R min");
                    break;
                case 9:
                    abs_flag = false;
                    init_divide_R(hashes, R, dR, s, X, Y);
                    if (max_checkBox.Checked)
                        max_per(per_num, points_num, periods, max_periods, dR, "dR");
                    else
                        draw_graph(s, hashes, dR, "dR");
                    abs_flag = true;
                    break;
               
                    
            }           
            z2.AxisChange();
            z2.Invalidate();
        }

        private void inaccuracy_box_Enter(object sender, System.EventArgs e)
        {

        }

        private void cool_method_1_checkbox_CheckedChanged(object sender, System.EventArgs e)
        {
            c_m[0] = !c_m[0];
        }

        private void cool_method_2_checkbox_CheckedChanged(object sender, System.EventArgs e)
        {
            c_m[1] = !c_m[1];
        }

        private void cool_method_3_checkbox_CheckedChanged(object sender, System.EventArgs e)
        {
            c_m[2] = !c_m[2];
        }

        private void cool_method_4_checkbox_CheckedChanged(object sender, System.EventArgs e)
        {
            c_m[3] = !c_m[3];
        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            checkBox2.Checked = false;
            t_flag = false;
            points_groupBox.Visible = false;
        }

        private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
        {
            checkBox1.Checked = false;
            t_flag = true;
            points_groupBox.Visible = false;
        }

        private void points_checkbox_CheckedChanged(object sender, System.EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox1.Checked = false;
            points_groupBox.Visible = !points_groupBox.Visible;
        }

        private void log_checkBox_CheckedChanged(object sender, System.EventArgs e)
        {
            //if (log_checkBox.Checked)
            //{
            //    begin_textbox.Text = "10";
            //    end_textbox.Text = "1000";
            //    step_textbox.Text = "1";
            //}
            //else
            //{
            //    begin_textbox.Text = "10";
            //    end_textbox.Text = "500";
            //    step_textbox.Text = "10";

            //}
        }

        private void max_checkBox_CheckedChanged(object sender, System.EventArgs e)
        {

        }

      
        
    }
}
