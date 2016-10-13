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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            G.Text = "1";
            M1.Text = "1";
            M2.Text = "1";
            x0.Text = "1";
            y0.Text = "1";
            Vx0.Text = "0,1";
            Vy0.Text = "0,2";
            string path = @"..\\..\\saved files";
            folderBrowserDialog1.SelectedPath = Path.GetFullPath(path);
            // points_count.Text = "200";
        }
        public double H, Ap, Am, Bp, Bm, Cp, Cm, A0, C0, B0,
            ds,
            w10, w20, q10, q20;
        string face_graph = "none";
        bool r_k = false; // runge-kutta explicit
        bool e_m = false; //eiler explicit
        bool v_e_m = false; //verle explicit
        bool e_s = true; // exact solution
        bool m_p = false; //middle point
        bool c_m = false; //cool_method
        public bool c_m_1 = false;
        public bool c_m_2 = false;
        public bool c_m_3 = false;
        public bool c_m_4 = false;
        bool e_p = false; //точки точного решения
        bool invars = false; //пересчет инвариантов для cool_method
        bool inaccuracy = false; //вывод погрешностей cool_method
        public bool check_scale = false;
        private String filepath;
        private String mydocpath = "..\\..\\saved files";
        private String save_text;
        private bool change_velocity_on_click = false;
        private bool change_begin_coords_on_click = false;
        double[] t_cmp;

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {//функция не нужна
            z1.GraphPane.GetImage(100,100,1).Save("C:/Users/Эрик/Desktop/Фоточки/" + save_name.Text +".bmp");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //z1.GraphPane.GetImage(1000, 1000, 1).Save("C:/Users/Эрик/Desktop/Фоточки/" + save_name.Text + ".bmp");
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                String foldername = this.folderBrowserDialog1.SelectedPath;
                load_data(foldername + "\\data");
            }
        }

        
        private void paprams_box_button_Click_1(object sender, EventArgs e)
        {
            start_params_box.Visible = !start_params_box.Visible;
        }

        public void draw_circle(double R)
        {
            double[] x = new double[402];
            double[] y = new double[402];
            int i;
            for (i = 0; i <= 200; i++)
            {
                x[i] = (-R + R * (double)i / 100);
                y[i] = Math.Sqrt((R * R - x[i] * x[i]));
            }

            for (i = 201; i <= 401; i++)
            {
                x[i] = (-R + R * (double)(i - 201) / 100);
                y[i] = -Math.Sqrt((R * R - x[i] * x[i]));
            }
            z1.GraphPane.AddCurve("", x, y, Color.Blue, SymbolType.None).Line.Width = 2;

            z1.AxisChange();
            z1.Invalidate();

        }
        public void clear_graph()
        {
            // Если есть что удалять
            if (z1.GraphPane.CurveList.Count > 0)
            {


                // Удалим кривую по индексу
                for (int k = z1.GraphPane.CurveList.Count - 1; k >= 0; k--)
                {
                    z1.GraphPane.CurveList.RemoveAt(k);
                    //z1.GraphPane.CurveList.RemoveAt(1);
                }
                // Обновим график
                z1.AxisChange();
                z1.Invalidate();
                //}
            }
        }

        //обработка кнопок
        private void start_params_box_button_Click_1(object sender, EventArgs e) 
        {
            change_begin_coords_on_click = true;
            change_velocity_on_click = false;
            start_values_box.Visible = !start_values_box.Visible;

            if (start_values_box.Visible)
            {
                //удаление всех кривых 
                clear_graph();
                z1.IsShowPointValues = true;
                z1.GraphPane.Title.Text = "Начальные данные";
                draw_circle(Math.Sqrt(1));
                z1.AxisChange();
                z1.Invalidate();
                face_graph = "s_data";
            }
            else { clear_graph(); face_graph = "none"; }
        }

        private void start_speed_button_Click_1(object sender, EventArgs e)
        {
            change_begin_coords_on_click = false;
            change_velocity_on_click = true;
            start_speed_box.Visible = !start_speed_box.Visible;


            if (start_speed_box.Visible)
            {
                //удаление всех кривых 
                clear_graph();
                z1.IsShowPointValues = true;
                z1.GraphPane.Title.Text = "Начальные скорости";
                draw_exscentre();
                draw_circle(Math.Sqrt
                                    (2 * Convert.ToDouble(G.Text) * (Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text))
                                    / Math.Sqrt(Math.Pow(Convert.ToDouble(x0.Text), 2) + Math.Pow(Convert.ToDouble(y0.Text), 2))));
                z1.AxisChange();
                z1.Invalidate();
                draw_circle(Math.Sqrt
                                    (Convert.ToDouble(G.Text) * (Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text))
                                    / Math.Sqrt(Math.Pow(Convert.ToDouble(x0.Text), 2) + Math.Pow(Convert.ToDouble(y0.Text), 2))));
                z1.AxisChange();
                z1.Invalidate();
                face_graph = "s_speed";



            }
            else { clear_graph(); face_graph = "none"; }
        }

        //эксцентриситет
        public void draw_exscentre()
        {
            double[] x = new double[800];
            double[] xc = new double[800];
            double[] y = new double[800];
            int i = 0;
            double C = Math.Sqrt(Convert.ToDouble(G.Text) * (Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text))
                                    / Math.Sqrt(Math.Pow(Convert.ToDouble(x0.Text), 2) + Math.Pow(Convert.ToDouble(y0.Text), 2)));
            double eps = Convert.ToDouble(epsilon.Text);
            if (eps <= 1)
            {

                x[0] = -Math.Sqrt(2 - 2 * Math.Sqrt(1 - eps * eps));//* C;
                x[799] = Math.Sqrt(2 - 2 * Math.Sqrt(1 - eps * eps)); //* C;
                // double ddddd = Math.Sqrt(Math.Pow(xc[i], 4) - 4 * xc[i] * xc[i] + 4 * eps * eps);
                //double ddd = Math.Pow(xc[i], 4) - 4 * xc[i] * xc[i] + 4 * eps * eps;

                y[0] = Math.Sqrt((2 - x[i] * x[i] + Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;
                i = 799;
                y[799] = Math.Sqrt((2 - x[i] * x[i] + Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;
                xc[0] = x[0] * C;
                xc[799] = x[799] * C;
                for (i = 1; i < 799; i++)
                {
                    x[i] = x[i - 1] + (x[799] - x[0]) / 800;
                    y[i] = Math.Sqrt((2 - x[i] * x[i] + Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;
                    xc[i] = x[i] * C;

                }

                z1.GraphPane.AddCurve("", xc, y, Color.Aqua,SymbolType.None).Line.Width = 2;


                i = 0;
                y[0] = -Math.Sqrt((2 - x[i] * x[i] + Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;
                i = 799;
                y[799] = -Math.Sqrt((2 - x[i] * x[i] + Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;

                for (i = 1; i < 799; i++)
                {
                    //x[i] = x[i - 1] + (x[799] - x[0]) / 800;
                    y[i] = -Math.Sqrt((2 - x[i] * x[i] + Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;
                    // xc[i] = x[i] * C; 
                }

                z1.GraphPane.AddCurve("", xc, y, Color.Aqua, SymbolType.None).Line.Width = 2;

                i = 0;
                y[0] = -Math.Sqrt((2 - x[i] * x[i] - Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;
                i = 799;
                y[799] = -Math.Sqrt((2 - x[i] * x[i] - Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;

                for (i = 1; i < 799; i++)
                {
                    // x[i] = x[i - 1] + (x[799] - x[0]) / 800;
                    y[i] = -Math.Sqrt((2 - x[i] * x[i] - Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;
                    //xc[i] = x[i] * C; 
                }

                z1.GraphPane.AddCurve("", xc, y, Color.Aqua, SymbolType.None).Line.Width = 2;


                i = 0;
                y[0] = Math.Sqrt((2 - x[i] * x[i] - Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;
                i = 799;
                y[799] = Math.Sqrt((2 - x[i] * x[i] - Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;

                for (i = 1; i < 799; i++)
                {
                    // x[i] = x[i - 1] + (x[799] - x[0]) / 800;
                    y[i] = Math.Sqrt((2 - x[i] * x[i] - Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;
                    // xc[i] = x[i] * C;
                }

                z1.GraphPane.AddCurve("", xc, y, Color.Aqua, SymbolType.None).Line.Width = 2;
            }
            else
            {
                x[0] = -Math.Sqrt(9) * C;
                x[799] = Math.Sqrt(9) * C;
                i = 0;
                y[0] = Math.Sqrt((2 - x[i] * x[i] + Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;
                i = 799;
                y[799] = Math.Sqrt((2 - x[i] * x[i] + Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;
                xc[0] = x[0] * C;
                xc[799] = x[799] * C;
                for (i = 1; i < 799; i++)
                {
                    x[i] = x[i - 1] + (x[799] - x[0]) / 800;
                    y[i] = Math.Sqrt((2 - x[i] * x[i] + Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;
                    xc[i] = x[i] * C;
                }

                z1.GraphPane.AddCurve("", xc, y, Color.Aqua, SymbolType.None).Line.Width = 2;

                i = 0;
                y[0] = -Math.Sqrt((2 - x[i] * x[i] + Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;
                i = 799;
                y[799] = -Math.Sqrt((2 - x[i] * x[i] + Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;
                for (i = 1; i < 799; i++)
                {
                    // x[i] = x[i - 1] + (x[799] - x[0]) / 800;
                    y[i] = -Math.Sqrt((2 - x[i] * x[i] + Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;

                }

                z1.GraphPane.AddCurve("", xc, y, Color.Aqua, SymbolType.None).Line.Width = 2;


                i = 0;
                y[0] = -Math.Sqrt((2 - x[i] * x[i] - Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;
                i = 799;
                y[799] = -Math.Sqrt((2 - x[i] * x[i] - Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;

                for (i = 1; i < 799; i++)
                {
                    //  x[i] = x[i - 1] + (x[799] - x[0]) / 800;
                    y[i] = -Math.Sqrt((2 - x[i] * x[i] - Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;

                }

                z1.GraphPane.AddCurve("", xc, y, Color.Aqua, SymbolType.None).Line.Width = 2;


                i = 0;
                y[0] = Math.Sqrt((2 - x[i] * x[i] - Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;
                i = 799;
                y[799] = Math.Sqrt((2 - x[i] * x[i] - Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;


                for (i = 1; i < 799; i++)
                {
                    // x[i] = x[i - 1] + (x[799] - x[0]) / 800;
                    y[i] = Math.Sqrt((2 - x[i] * x[i] - Math.Sqrt(Math.Pow(x[i], 4) - 4 * x[i] * x[i] + 4 * eps * eps)) / 2) * C;

                }

                z1.GraphPane.AddCurve("", xc, y, Color.Aqua, SymbolType.None).Line.Width = 2;
            }
        }

        //подсчет входных параметров
        private void z1_MouseClick_1(object sender, MouseEventArgs e)
        {
            double x, y;

            // Пересчитываем пиксели в координаты на графике
            // У ZedGraph есть несколько перегруженных методов ReverseTransform.
            z1.GraphPane.ReverseTransform(e.Location, out x, out y);
            switch (face_graph)
            {
                case "s_data": if (change_begin_coords_on_click)
                    {
                        x0.Text = (x).ToString(); y0.Text = (y).ToString(); 
                    }
                    break;
                case "s_speed": if (change_velocity_on_click)
                    {
                        Vx0.Text = (x).ToString(); Vy0.Text = (y).ToString();
                        double vx0 = Convert.ToDouble(Vx0.Text);
                        double vy0 = Convert.ToDouble(Vy0.Text);
                        double X0 = Convert.ToDouble(x0.Text);
                        double Y0 = Convert.ToDouble(y0.Text);

                        w10 = vx0 * X0 * Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, -0.5) + vy0 * Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, 0.5);
                        w20 = vx0 * Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, 0.5) - vy0 * X0 * Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, -0.5);
                        q10 = Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, 0.5);
                        q20 = X0 * Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, -0.5);
                        //H = -(0.5 * (w10 * w10 + w20 * w20) - 2 * Convert.ToDouble(G.Text) * (Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text)) * Math.Pow(q10 * q10 + q20 * q20, -1));
                        H = -(0.5 * (vx0 * vx0 + vy0 * vy0) - Convert.ToDouble(G.Text) * (Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text)) * Math.Pow(X0 * X0 + Y0 * Y0, -0.5));
                        out_params.Text = "H*=" + H.ToString() + "\n";
                        double C = Math.Sqrt(Convert.ToDouble(G.Text) * (Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text))
                                        / Math.Sqrt(Math.Pow(Convert.ToDouble(x0.Text), 2) + Math.Pow(Convert.ToDouble(y0.Text), 2)));
                        double X = vx0 / C, Y = vy0 / C;
                        double EpsW = Math.Sqrt(1 + (X * X + Y * Y - 2) * Y * Y);
                        out_params.Text += "Eps=" + EpsW.ToString() + "\n";
                    }
                    break;
            }
        }

        private void params_watch_Click_1(object sender, EventArgs e)
        {
            params_watch_box.Visible = !params_watch_box.Visible;
        }

        public double radius_count(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }

        // основной расчет 
        public void kepler_build()
        {
            try
            {
                // Ось X будет пересекаться с осью Y на уровне Y = 0
                z1.GraphPane.XAxis.Cross = 0.0;

                // Ось Y будет пересекаться с осью X на уровне X = 0
                z1.GraphPane.YAxis.Cross = 0.0;

                // Отключим отображение первых и последних меток по осям
                z1.GraphPane.XAxis.Scale.IsSkipFirstLabel = true;
                z1.GraphPane.XAxis.Scale.IsSkipLastLabel = true;

                // Отключим отображение меток в точке пересечения с другой осью
                z1.GraphPane.XAxis.Scale.IsSkipCrossLabel = true;


                // Отключим отображение первых и последних меток по осям
                z1.GraphPane.YAxis.Scale.IsSkipFirstLabel = true;

                // Отключим отображение меток в точке пересечения с другой осью
                z1.GraphPane.YAxis.Scale.IsSkipLastLabel = true;
                z1.GraphPane.YAxis.Scale.IsSkipCrossLabel = true;

                // Спрячем заголовки осей
                z1.GraphPane.XAxis.Title.IsVisible = false;
                z1.GraphPane.YAxis.Title.IsVisible = false;

                change_begin_coords_on_click = false;
                change_velocity_on_click = false;
                double vx0 = Convert.ToDouble(Vx0.Text);
                double vy0 = Convert.ToDouble(Vy0.Text);
                double X0 = Convert.ToDouble(x0.Text);
                double Y0 = Convert.ToDouble(y0.Text);
              
                
                w10 = vx0 * X0 * Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, -0.5) + vy0 * Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, 0.5);
                w20 = vx0 * Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, 0.5) - vy0 * X0 * Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, -0.5);
                q10 = Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, 0.5);
                q20 = X0 * Math.Pow(Math.Pow(X0 * X0 + Y0 * Y0, 0.5) + Y0, -0.5);
                H = -(0.5 * (vx0 * vx0 + vy0 * vy0) - Convert.ToDouble(G.Text) * (Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text)) * Math.Pow(X0 * X0 + Y0 * Y0, -0.5));
                out_params.Text = "H*=" + H.ToString() + "\n";
                double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
                double g = Convert.ToDouble(G.Text);
                double L = ((0.5 * (w10 * q20 - w20 * q10)) * (Convert.ToDouble(M1.Text) * Convert.ToDouble(M2.Text))) / M;
                double l = X0 * vy0 - Y0 * vx0;
                out_params.Text += "L=" + L.ToString() + "\n";
                out_params.Text += "l=" + l + "\n";
                double r0 = Math.Sqrt(X0 * X0 + Y0 * Y0);
                double ex0 = vy0 * vy0 * X0 - vx0 * vy0 * Y0 - g * M * X0 / r0;
                double ey0 = vx0 * vx0 * Y0 - vx0 * vy0 * X0 - g * M * Y0 / r0;
                out_params.Text += "eLRLx=" + ex0.ToString() + "\n";
                out_params.Text += "eLRLy=" + ey0.ToString() + "\n";
                double C = Math.Sqrt(g * M / Math.Sqrt( X0 * X0 + Y0 * Y0));
                double X = vx0 / C, Y = vy0 / C;
                double EpsW = Math.Sqrt(1 + (X * X + Y * Y - 2) * Y * Y);
                out_params.Text += "Eps=" + EpsW.ToString() + "\n";
                double r_min = l * l / (g * M * (1 + EpsW));
                out_params.Text += "r_min=" + r_min.ToString() + "\n";
                double x_min = ex0 * l * l / (g * g * M * M * EpsW * (1 + EpsW));
                double y_min = ey0 * l * l / (g * g * M * M * EpsW * (1 + EpsW));
                out_params.Text += "x_min=" + x_min.ToString() + "\n";
                out_params.Text += "y_min=" + y_min.ToString() + "\n";
                double r_c = l * l / (g * M);
                double x_c = ey0 * l * l / (g * g * M * M * EpsW);
                double y_c = - ex0 * l * l / (g * g * M * M * EpsW);
                out_params.Text += "r_c=" + r_c.ToString() + "\n";
                out_params.Text += "x_c=" + x_c.ToString() + "\n";
                out_params.Text += "y_c=" + y_c.ToString() + "\n";
                double vx_min = -ey0 * (1 + EpsW) / (l * EpsW);
                double vy_min = ex0 * (1 + EpsW) / (l * EpsW);
                double abs_v = g * M * (1 + EpsW) / Math.Abs(l);
                out_params.Text += "Vx_min=" + vx_min.ToString() + "\n";
                out_params.Text += "Vy_min=" + vy_min.ToString() + "\n";
                out_params.Text += "abs_V=" + abs_v.ToString() + "\n";
                compute_coefs();

                z1.IsShowPointValues = true;
                int points_number = Convert.ToInt32(number_points_textbox.Text);
                double[] a = new double[points_number];
                double[] b = new double[points_number];
                double[] c = new double[points_number];
              
     
                clear_graph();
                double Tp = r0;
                if (H != 0) Tp =  Math.PI / Math.Pow(2 * Math.Abs(H), 0.5);//Tp = 2 * Math.PI * g * M * Math.Pow(2 * Math.Abs(H), -1.5); //Tp = (2 * Math.PI) / Math.Pow(2 * Math.Abs(H), 0.5);
                double dT = Tp / points_number;
                double dT2 = 2 * Tp / points_number;
                double T = 0;

                //варианты графиков
                switch (comboBox1.SelectedIndex)
                {
                    case 0: z1.GraphPane.Title.Text= "y(x)";
                        rename_axis("y", "x");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = x(T + i * dT);
                            b[i] = y(T + i * dT);

                        }
                            if (r_k) r_k_f_old("0011");
                            if (e_m) e_m_f_old("0011");
                            if (v_e_m) verle_explicit_old("0011");
                            if (m_p) middle_point_method_old("0011");
                            if (c_m) {
                                if (c_m_1) cool_method("0011", 1);
                                if (c_m_2) cool_method("0011", 2);
                                if (c_m_3) cool_method("0011", 3);
                                if (c_m_4) cool_method("0011", 4);
                            }
                        break;
                    case 1: z1.GraphPane.Title.Text= "x(t)";
                        rename_axis("x", "t");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = t(T + i * dT);
                            b[i] = x(T + i * dT);
                            
                        }
                        break;
                    case 2: z1.GraphPane.Title.Text= "x(s)";
                        rename_axis("x", "s");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = T + i * dT;
                            b[i] = x(T + i * dT);
                           
                        }
                        break;
                    case 3: z1.GraphPane.Title.Text= "y(s)";
                        rename_axis("y", "s");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = T + i * dT;
                            b[i] = y(T + i * dT);
                            
                        }
                        break;
                    case 4: z1.GraphPane.Title.Text= "y(t)";
                        rename_axis("y", "t");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = t(T + i * dT);
                            b[i] = y(T + i * dT);
                           
                        }
                        break;
                    case 5: z1.GraphPane.Title.Text= "Vy(Vx)";
                        rename_axis("Vy", "Vx");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = Vx(T + i * dT);
                            b[i] = Vy(T + i * dT);
                           
                            
                        }
                        if (r_k) r_k_f_old("1100");
                        if (e_m) e_m_f_old("1100");
                        if (v_e_m) verle_explicit_old("1100");
                        if (m_p) middle_point_method_old("1100");
                        if (c_m)
                        {
                            if (c_m_1) cool_method("1100", 1);
                            if (c_m_2) cool_method("1100", 2);
                            if (c_m_3) cool_method("1100", 3);
                            if (c_m_4) cool_method("1100", 4);
                        }
                        break;
                    case 6: z1.GraphPane.Title.Text= "Vx(t)";
                        rename_axis("Vx", "t");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = t(T + i * dT);
                            b[i] = Vx(T + i * dT);
                           
                        }
                        break;
                    case 7: z1.GraphPane.Title.Text= "Vy(t)";
                        rename_axis("Vy", "t");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = t(T + i * dT);
                            b[i] = Vy(T + i * dT);
                         
                        }
                        break;
                    case 8: z1.GraphPane.Title.Text= "Vx(s)";
                        rename_axis("Vx", "s");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = T + i * dT;
                            b[i] = Vx(T + i * dT);
                           
                        }
                        break;
                    case 9: z1.GraphPane.Title.Text= "Vy(s)";
                        rename_axis("Vy", "s");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = T + i * dT;
                            b[i] = Vy(T + i * dT);
                           
                        }
                        break;
                    case 10: z1.GraphPane.Title.Text= "Vx(x)";
                        rename_axis("Vx", "x");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = x(T + i * dT);
                            b[i] = Vx(T + i * dT);
                           
                        }
                        break;
                    case 11: z1.GraphPane.Title.Text= "Vy(y)";
                        rename_axis("Vy", "y");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = y(T + i * dT);
                            b[i] = Vy(T + i * dT);
                           
                        }
                        break;
                    case 12: z1.GraphPane.Title.Text= "Vx(y)";
                        rename_axis("Vx", "y");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = y(T + i * dT);
                            b[i] = Vx(T + i * dT);
                            
                        }
                        break;
                    case 13: z1.GraphPane.Title.Text= "Vy(x)";
                        rename_axis("Vy", "x");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = x(T + i * dT);
                            b[i] = Vy(T + i * dT);
                           
                        }
                        break;
                    case 14: z1.GraphPane.Title.Text= "s(t)";
                        rename_axis("s", "t");

                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = T + i * dT;//(double)i / 10;
                            b[i] = t(T + i * dT);
                            
                        }
                        break;
                    case 15: z1.GraphPane.Title.Text= "q1(s)";
                        rename_axis("q1", "s");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = T + i * dT2;
                            b[i] = q1(T + i * dT2);
                           
                        }
                        break;
                    case 16: z1.GraphPane.Title.Text= "q2(s)";
                        rename_axis("q2", "s");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = T + i * dT2;
                            b[i] = q2(T + i * dT2);
                            
                        }
                        break;
                    case 17: z1.GraphPane.Title.Text= "q2(q1)";
                        rename_axis("q2", "q1");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = q1(T + i * dT2);
                            b[i] = q2(T + i * dT2);
                            
                        }
                        if (r_k) r_k_f_new("0011");
                        if (e_m) e_m_f_new("0011");
                        if (v_e_m) verle_explicit_new("0011", b, a);
                        break;
                    case 18: z1.GraphPane.Title.Text= "w2(w1)";
                        rename_axis("w2", "w1");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = w1(T + i * dT2);
                            b[i] = w2(T + i * dT2);
                           
                            
                        }
                        if (r_k) r_k_f_new("1100");
                        if (e_m) e_m_f_new("1100");
                        if (v_e_m) verle_explicit_new("1100", b, a);// здесь b и a  нужны только для корректного вызова
                        break;
                    case 19: z1.GraphPane.Title.Text= "q1(t)";
                        rename_axis("q1", "t");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = t(T + i * dT2);
                            b[i] = q1(T + i * dT2);
                           
                        }
                        break;
                    case 20: z1.GraphPane.Title.Text= "q2(t)";
                        rename_axis("q2", "t");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = t(T + i * dT2);
                            b[i] = q2(T + i * dT2);
                            
                        }
                        break;
                    case 21: z1.GraphPane.Title.Text= "w1(q1)";
                        rename_axis("w1", "q1");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = q1(T + i * dT2);
                            b[i] = w1(T + i * dT2);
                            
                        }
                        break;
                    case 22: z1.GraphPane.Title.Text= "w2(q2)";
                        rename_axis("w2", "q2");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = q2(T + i * dT2);
                            b[i] = w2(T + i * dT2);
                            
                        }
                        break;
                    case 23: z1.GraphPane.Title.Text= "w1(q2)";
                        rename_axis("w1", "q2");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = q2(T + i * dT2);
                            b[i] = w1(T + i * dT2);
                           
                        }
                        break;
                    case 24: z1.GraphPane.Title.Text= "w2(q1)";
                        rename_axis("w2", "q1");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = q1(T + i * dT2);
                            b[i] = w2(T + i * dT2);
                           
                        }
                        break;
                    case 25: z1.GraphPane.Title.Text= "w1(s)";
                        rename_axis("w1", "s");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = T + i * dT2;
                            b[i] = w1(T + i * dT2);
                           
                        }
                        break;
                    case 26: z1.GraphPane.Title.Text= "w2(s)";
                        rename_axis("w2", "s");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = T + i * dT2;
                            b[i] = w2(T + i * dT2);
                           
                        }
                        break;
                    case 27: z1.GraphPane.Title.Text= "Fx(t)";
                        rename_axis("Fx", "t");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = t(T + i * dT);
                            b[i] = Fx(T + i * dT);
                           
                        }
                        break;
                    case 28: z1.GraphPane.Title.Text= "Fy(t)";
                        rename_axis("Fy", "t");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = t(T + i * dT);
                            b[i] = Fy(T + i * dT);
                            
                        }
                        break;
                    case 29: z1.GraphPane.Title.Text = "R(t)";
                        rename_axis("R", "t");
                        for (int i = 0; i < points_number; i++)
                        {

                            b[i] = radius_count(x(T + i * dT), y(T + i * dT));//T + i * dT;
                            a[i] = t(T + i * dT);
                            
                        }
                        break;
                    case 30: z1.GraphPane.Title.Text = "tc(eps)";
                        rename_axis("tc", "eps");
                        double x_eps = 0;
                        
                        double end = 1.5;
                        double h = end / points_number;
                        for (int i = 0; i < points_number; i++)
                        {
                            x_eps += h;
                            a[i] = x_eps;
                            if (x_eps > 1.00 - 0.001 && x_eps < 1.00 + 0.001) {
                                b[i] = 4 / 3 * Math.Abs(l * l * l) / (g * g * M * M);
                            }
                                
                            else
                                if (x_eps < 1) b[i] = 2 * Math.Abs(l * l * l) * (Math.Acos(x_eps) - x_eps * Math.Sqrt(1 - x_eps * x_eps)) / (g * g * M * M * Math.Pow(1 - x_eps * x_eps, 1.5));
                                else b[i] = -2 * Math.Abs(l * l * l) * (Math.Log(x_eps + Math.Sqrt(x_eps * x_eps - 1)) - x_eps * Math.Sqrt(x_eps * x_eps - 1)) / (g * g * M * M * Math.Pow(x_eps * x_eps - 1, 1.5));
                        }
                        break;

                    case 31: z1.GraphPane.Title.Text = "t(s)";
                        rename_axis("t", "s");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = T + i * dT;
                            b[i] = t(T + i * dT);
                        }
                        c = T_to_S(b);
                        z1.GraphPane.AddCurve("", c, b, Color.Red, SymbolType.None).Line.Width = 2;
                        break;
                    case 32: z1.GraphPane.Title.Text = "H(t)";
                        rename_axis("H", "t");
                        for (int i = 0; i < points_number; i++)
                        {

                            //b[i] = H;
                            //a[i] = t(T + i * dT);

                        }
                        if (r_k) r_k_f_old("2000");
                        if (e_m) e_m_f_old("2000");
                        if (v_e_m) verle_explicit_old("2000");
                        if (m_p) middle_point_method_old("2000");
                        if (c_m)
                        {
                            if (c_m_1) cool_method("2000", 1);
                            if (c_m_2) cool_method("2000", 2);
                            if (c_m_3) cool_method("2000", 3);
                            if (c_m_4) cool_method("2000", 4);
                        }
                        break;
                    case 33: z1.GraphPane.Title.Text = "eLRLx(t)";
                        rename_axis("eLRLx", "t");
                        //for (int i = 0; i < points_number; i++)
                        //{

                        //    b[i] = ex0;
                        //    a[i] = t(T + i * dT);

                        //}
                        if (r_k) r_k_f_old("0200");
                        if (e_m) e_m_f_old("0200");
                        if (v_e_m) verle_explicit_old("0200");
                        if (m_p) middle_point_method_old("0200");
                        if (c_m)
                        {
                            if (c_m_1) cool_method("0200", 1);
                            if (c_m_2) cool_method("0200", 2);
                            if (c_m_3) cool_method("0200", 3);
                            if (c_m_4) cool_method("0200", 4);
                        }
                        break;
                    case 34: z1.GraphPane.Title.Text = "eLRLy(t)";
                        rename_axis("eLRLy", "t");
                        //for (int i = 0; i < points_number; i++)
                        //{

                        //    //b[i] = ey0;
                        //    //a[i] = t(T + i * dT);

                        //}
                        if (r_k) r_k_f_old("0020");
                        if (e_m) e_m_f_old("0020");
                        if (v_e_m) verle_explicit_old("0020");
                        if (m_p) middle_point_method_old("0020");
                        if (c_m)
                        {
                            if (c_m_1) cool_method("0020", 1);
                            if (c_m_2) cool_method("0020", 2);
                            if (c_m_3) cool_method("0020", 3);
                            if (c_m_4) cool_method("0020", 4);
                        }
                        break;
                    case 35: z1.GraphPane.Title.Text = "l(t)";
                        rename_axis("l", "t");
                        //for (int i = 0; i < points_number; i++)
                        //{

                        //    //b[i] = l;
                        //    //a[i] = t(T + i * dT);

                        //}
                        if (r_k) r_k_f_old("0002");
                        if (e_m) e_m_f_old("0002");
                        if (v_e_m) verle_explicit_old("0002");
                        if (m_p) middle_point_method_old("0002");
                        if (c_m)
                        {
                            if (c_m_1) cool_method("0002", 1);
                            if (c_m_2) cool_method("0002", 2);
                            if (c_m_3) cool_method("0002", 3);
                            if (c_m_4) cool_method("0002", 4);
                        }
                        break;
                    case 36: z1.GraphPane.Title.Text = "|F|(t)";
                        rename_axis("|F|", "t");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = t(T + i * dT);
                            b[i] = Math.Abs(Fy(T + i * dT) * Fy(T + i * dT) + Fx(T + i * dT) * Fx(T + i * dT));
                        }
                        break;
                    case 37: z1.GraphPane.Title.Text = "|V|(t)";
                        rename_axis("|V|", "t");
                        for (int i = 0; i < points_number; i++)
                        {
                            a[i] = t(T + i * dT);
                            b[i] = Math.Abs(Vy(T + i * dT) * Vy(T + i * dT) + Vx(T + i * dT) * Vx(T + i * dT));
                        }
                        break;
                }

                if (e_s) 
                    if (e_p) z1.GraphPane.AddCurve("", a, b, Color.Green, SymbolType.Circle).Line.Width = 2;
                    else z1.GraphPane.AddCurve("", a, b, Color.Green, SymbolType.None).Line.Width = 2;
                z1.AxisChange();
                z1.Invalidate();


            }
            catch (OverflowException) { }
        }
        public void rename_axis(string ax_y, string ax_x)
        {
            z1.GraphPane.XAxis.Title.Text = ax_x;
            z1.GraphPane.YAxis.Title.Text = ax_y;
        }

        //расчеты функций
        public double t(double s)
        {
            if (H == 0)
            {
                return (A0) * s + (B0) * s * s + (C0) * s * s * s;
            }
            else if (H > 0)
            {
                return (Ap) * s + (Bp) * Math.Sin(2 * Math.Pow(2 * H, 0.5) * s) + (Cp) * (Math.Cos(2 * Math.Pow(2 * H, 0.5) * s) - 1);
            }
            else
            {
                return (Am) * s + (Bm) * (Math.Exp(-Math.Pow(-2 * H, 0.5) * s) - 1) + (Cm) * (Math.Exp(Math.Pow(-2 * H, 0.5) * s) - 1);
            }
        }

        public double w1(double s)
        {
            if (H == 0)
            {
                return w10;
            }
            else if (H > 0)
            {
                return -q10 * Math.Pow(2 * H, 0.5) * Math.Sin(Math.Pow(2 * H, 0.5) * s) + w10 * Math.Cos(Math.Pow(2 * H, 0.5) * s);
            }
            else
            {
                //return 0.5 * (w10 - q10 * (Math.Pow(-2 * H, 0.5)) * Math.Exp(-Math.Pow(-2 * H, 0.5) * s) + (w10 + q10 * Math.Pow(-2 * H, 0.5)) * Math.Exp(Math.Pow(-2 * H, 0.5) * s));
                return w10 * Math.Cosh(Math.Sqrt(-2 * H) * s) + q10 * Math.Sqrt(-2 * H) * Math.Sinh(Math.Sqrt(-2 * H) * s);
            }
        }

        public double w2(double s)
        {
            if (H == 0)
            {
                return w20;
            }
            else if (H > 0)
            {
                return -q20 * Math.Pow(2 * H, 0.5) * Math.Sin(Math.Pow(2 * H, 0.5) * s) + w20 * Math.Cos(Math.Pow(2 * H, 0.5) * s);
            }
            else
            {
                //return 0.5 * (w20 - q20 * (Math.Pow(-2 * H, 0.5)) * Math.Exp(-Math.Pow(-2 * H, 0.5) * s) + (w20 + q20 * Math.Pow(-2 * H, 0.5)) * Math.Exp(Math.Pow(-2 * H, 0.5) * s));
               return w20 * Math.Cosh(Math.Sqrt(-2 * H) * s) + q20 * Math.Sqrt(-2 * H) * Math.Sinh(Math.Sqrt(-2 * H) * s);
            }

        }

        public double q1(double s)
        {
            if (H == 0)
            {
                return w10 * s + q10;
            }
            else if (H > 0)
            {
                return w10 * Math.Pow(2 * H, -0.5) * Math.Sin(Math.Pow(2 * H, 0.5) * s) + q10 * Math.Cos(Math.Pow(2 * H, 0.5) * s);
            }
            else
            {
                //return 0.5 * (q10 - w10 * (Math.Pow(-2 * H, 0.5)) * Math.Exp(-Math.Pow(-2 * H, 0.5) * s) + (q20 + w20 * Math.Pow(-2 * H, 0.5)) * Math.Exp(Math.Pow(-2 * H, 0.5) * s));
                return q10 * Math.Cosh(Math.Sqrt(-2 * H) * s) + w10 * Math.Sqrt(-2 * H) * Math.Sinh(Math.Sqrt(-2 * H) * s);
            }
        }

        public double q2(double s)
        {
            if (H == 0)
            {
                return w20 * s + q20;
            }
            else if (H > 0)
            {
                return w20 * Math.Pow(2 * H, -0.5) * Math.Sin(Math.Pow(2 * H, 0.5) * s) + q20 * Math.Cos(Math.Pow(2 * H, 0.5) * s);
            }
            else
            {
                //return 0.5 * (q20 - w20 * (Math.Pow(-2 * H, 0.5)) * Math.Exp(-Math.Pow(-2 * H, 0.5) * s) + (q20 + w20 * Math.Pow(-2 * H, 0.5)) * Math.Exp(Math.Pow(-2 * H, 0.5) * s));
                return q20 * Math.Cosh(Math.Sqrt(-2 * H) * s) + w20 * Math.Sqrt(-2 * H) * Math.Sinh(Math.Sqrt(-2 * H) * s);
            }
        }

        public double x(double s)
        {
            return q1(s) * q2(s);
        }

        public double y(double s)
        {
            return 0.5 * (q1(s) * q1(s) - q2(s) * q2(s));
        }

        public double Vx(double s)
        {
            return (q1(s) * w2(s) + q2(s) * w1(s)) * Math.Pow((q1(s) * q1(s) + q2(s) * q2(s)), -1);
        }
        
        public double Vy(double s)
        {
            return (q1(s) * w1(s) - q2(s) * w2(s)) * Math.Pow((q1(s) * q1(s) + q2(s) * q2(s)), -1);
        }

        public double Fx(double s)
        {
            return -Convert.ToDouble(G.Text) * (Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text)) * Math.Pow(x(s) * x(s) + y(s) * y(s), -1.5) * x(s);
        }
        public double Fy(double s)
        {
            return -Convert.ToDouble(G.Text) * (Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text)) * Math.Pow(x(s) * x(s) + y(s) * y(s), -1.5) * y(s);
        }
        //подсчет коэффициентов
        public void compute_coefs()
        {
            if (H > 0)
            {
                Ap = 0.5 * (0.5 * (w10 * w10 + w20 * w20) / H + (q10 * q10 + q20 * q20));
                Bp = 0.25 * Math.Pow(2 * H, -0.5) * (q10 * q10 + q20 * q20 - (0.5 / H) * (w10 * w10 + w20 * w20));
                Cp = -(0.25 / H) * (w10 * q10 + w20 * q20);
            }
            if (H == 0)
            {
                A0 = q10 * q10 + q20 * q20;
                B0 = (w10 * q10 + w20 * q20);
                C0 = (1 / 3) * (w10 * w10 + w20 * w20);
            }
            if (H < 0)
            {
                Am = 0.5 * (q10 * q10 + q20 * q20) + (1 / H) * (w10 * w10 + w20 * w20);
                Bm = -(1 / 16) * Math.Pow(-2 * H, -1) * (q10 * q10 + q20 * q20 - 2 * (1 / H) * (w10 * w10 + w20 * w20) - 2 * Math.Pow(-2 * H, -0.5) * (w10 * q10 + w20 * q20));
                Cm = (1 / 16) * Math.Pow(-2 * H, -1) * (q10 * q10 + q20 * q20 - 2 * (1 / H) * (w10 * w10 + w20 * w20) + 2 * Math.Pow(-2 * H, -0.5) * (w10 * q10 + w20 * q20));
            }
        }

        ////////////////////////////////////////////////////////
        //Методы
        void r_k_f_new(string gr)
        {
            double k1, k2, k3, k4,
                       l1, l2, l3, l4,
                       p1, p2, p3, p4,
                       o1, o2, o3, o4,
                       _M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);

            int count = Convert.ToInt32(points_count.Text);
            double Td = Convert.ToDouble(P_C.Text) * 2 * Math.PI * Math.Pow(2 * Math.Abs(H), -0.5);
            double h = Td / count;
            double[] y1 = new double[count];
            double[] y2 = new double[count];
            double[] y3 = new double[count];
            double[] y4 = new double[count];
            int i = 0;
            y1[0] = w10;
            y2[0] = w20;
            y3[0] = q10;
            y4[0] = q20;
            double t = h;
            for (i = 1; i < count; i++)
            {

                k1 = -2 * H * y3[i - 1];
                l1 = -2 * H * y4[i - 1];
                p1 = y1[i - 1];
                o1 = y2[i - 1];

                k2 = -2 * H * (y3[i - 1] + (h / 2) * p1);
                l2 = -2 * H * (y4[i - 1] + (h / 2) * o1);
                p2 = y1[i - 1] + (h / 2) * k1;
                o2 = y2[i - 1] + (h / 2) * l2;

                k3 = -2 * H * (y3[i - 1] + (h / 2) * p2);
                l3 = -2 * H * (y4[i - 1] + (h / 2) * o2);
                p3 = y1[i - 1] + (h / 2) * k2;
                o3 = y2[i - 1] + (h / 2) * l2;

                k4 = -2 * H * (y3[i - 1] + h * p3);
                l4 = -2 * H * (y4[i - 1] + h * o3);
                p4 = y1[i - 1] + h * k3;
                o4 = y2[i - 1] + h * l3;
                y1[i] = y1[i - 1] + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4);
                y2[i] = y2[i - 1] + (h / 6) * (l1 + 2 * l2 + 2 * l3 + l4);
                y3[i] = y3[i - 1] + (h / 6) * (p1 + 2 * p2 + 2 * p3 + p4);
                y4[i] = y4[i - 1] + (h / 6) * (o1 + 2 * o2 + 2 * o3 + o4);


            }

            z1.IsShowPointValues = true;

            switch (gr)
            {
                case "1100":
                
                      

                    double[] yyy = new double[1]; yyy[0] = y2[0];
                    double[] yxx = new double[1]; yxx[0] = y1[0];
                    z1.GraphPane.AddCurve("", yxx, yyy, Color.Black).Line.IsVisible = false;
                    z1.GraphPane.AddCurve("", y1, y2, Color.Black);

                    break;
                case "0011":
                   
                        

                    double[] yy = new double[1]; yy[0] = y4[0];
                    double[] yx = new double[1]; yx[0] = y3[0];
                    z1.GraphPane.AddCurve("", yx, yy, Color.Black).Line.IsVisible = false;
                    z1.GraphPane.AddCurve("", y3, y4, Color.Black);

                    break;
            }
            z1.AxisChange();
            z1.Invalidate();
        }
      
        void verle_explicit_old(string gr)
        {
            double _M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);

            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * _M * Math.Pow(2 * Math.Abs(H), -1.5);
            //double T = Math.PI * Math.Pow(2 * H, -0.5);
            double h = T / count;
            double[] Xnew = new double[count];
            double[] Ynew = new double[count];
            double[] Vxnew = new double[count];
            double[] Vynew = new double[count];
            double[] l = new double[count];
            double[] eX = new double[count];
            double[] eY = new double[count];
            double[] HH = new double[count];
            double[] t = new double[count];
            
            Vxnew[0] = Convert.ToDouble(Vx0.Text);
            Vynew[0] = Convert.ToDouble(Vy0.Text);
            Xnew[0] = Convert.ToDouble(x0.Text);
            Ynew[0] = Convert.ToDouble(y0.Text);


            l[0] = Xnew[0] * Vynew[0] - Ynew[0] * Vxnew[0];
            eX[0] = Vynew[0] * l[0] - g * _M * Xnew[0] / radius_count(Xnew[0], Ynew[0]);
            eY[0] = -Vxnew[0] * l[0] - g * _M * Ynew[0] / radius_count(Xnew[0], Ynew[0]);
            HH[0] = -0.5 * (Vxnew[0] * Vxnew[0] + Vynew[0] * Vynew[0]) + g * _M / radius_count(Xnew[0], Ynew[0]);
            t[0] = 0; 
            
            for (int i = 1; i < Xnew.Length; i++)
            {
                double r = radius_count(Xnew[i - 1], Ynew[i - 1]);

                Xnew[i] = Xnew[i - 1] + h * Vxnew[i - 1] - 0.5 * h * h * g * _M * Xnew[i - 1] / (r * r * r);
                Ynew[i] = Ynew[i - 1] + h * Vynew[i - 1] - 0.5 * h * h * g * _M * Ynew[i - 1] / (r * r * r);
                double rr = radius_count(Xnew[i], Ynew[i]);
                Vxnew[i] = Vxnew[i - 1] - 0.5 * h * g * _M * (Xnew[i - 1] / (r * r * r) + Xnew[i] / (rr * rr * rr));
                Vynew[i] = Vynew[i - 1] - 0.5 * h * g * _M * (Ynew[i - 1] / (r * r * r) + Ynew[i] / (rr * rr * rr));
                l[i] = Math.Abs(Xnew[i] * Vynew[i] - Ynew[i] * Vxnew[i] - l[0]);
                eX[i] = Math.Abs(Vynew[i] * l[i] - g * _M * Xnew[i] / rr - eX[0]);
                eY[i] = Math.Abs(-Vxnew[i] * l[i] - g * _M * Ynew[i] / rr - eY[0]);
                HH[i] = Math.Abs(-0.5 * (Vxnew[i] * Vxnew[i] + Vynew[i] * Vynew[i]) + g * _M / rr - HH[0]);
                t[i] = h * i;

            }
            z1.IsShowPointValues = true;

            HH[0] = 0;
            l[0] = 0;
            eX[0] = 0;
            eY[0] = 0;
            switch (gr)
            {
                case "1100":
                
                       
                    double[] yyy = new double[1]; yyy[0] = Vynew[0];
                    double[] yxx = new double[1]; yxx[0] = Vxnew[0];
                    z1.GraphPane.AddCurve("", yxx, yyy, Color.DarkSalmon).Line.IsVisible = false;
                    z1.GraphPane.AddCurve("", Vxnew, Vynew, Color.DarkOrange).Line.IsVisible = false;
                    
                    break;
                case "0011":
             
                      
                    double[] yy = new double[1]; yy[0] = Ynew[0];
                    double[] yx = new double[1]; yx[0] = Xnew[0];
                    z1.GraphPane.AddCurve("", yx, yy, Color.DarkSalmon).Line.IsVisible = false;
                    z1.GraphPane.AddCurve("", Xnew, Ynew, Color.DarkOrange).Line.IsVisible = false;
                    
                    break;
                case "2000":
                    z1.GraphPane.AddCurve("", t, HH, Color.DarkOrange, SymbolType.None).Line.Width = 3;
                    break;
                case "0200":
                    z1.GraphPane.AddCurve("", t, eX, Color.DarkOrange, SymbolType.None).Line.Width = 3;
                    break;
                case "0020":
                    z1.GraphPane.AddCurve("", t, eY, Color.DarkOrange, SymbolType.None).Line.Width = 3;
                    break;
                case "0002":
                    z1.GraphPane.AddCurve("", t, l, Color.DarkOrange, SymbolType.None).Line.Width = 3;
                    break;
            }

            z1.AxisChange();
            z1.Invalidate();

        }

        void verle_explicit_new(string gr, double[] exact_solution_copy, double[] exact_solution_copy_x)
        {
            double _M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);

            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
            //double T = 2 * Math.PI * g * _M * Math.Pow(2 * H, -1.5);
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * Math.Pow(2 * Math.Abs(H), -0.5);
            double h = T / count;
            double[] q1 = new double[count];
            double[] q2 = new double[count];
            double[] w1 = new double[count];
            double[] w2 = new double[count];
            double[] tmp = new double[Convert.ToInt32(number_points_textbox.Text)];
            q1[0] = q10;
            q2[0] = q20;
            w1[0] = w10;
            w2[0] = w20;

            for (int i = 0; i < q1.Length - 1; i++)
            {
                q1[i + 1] = q1[i] + h * w1[i] - h * h * H * q1[i];
                q2[i + 1] = q2[i] + h * w2[i] - h * h * H * q2[i];
                w1[i + 1] = w1[i] - h * H * (q1[i] + q1[i + 1]);
                w2[i + 1] = w2[i] - h * H * (q2[i] + q2[i + 1]);
                tmp[i] = Math.Abs(q2[i] - exact_solution_copy[i]);
            }

            z1.IsShowPointValues = true;
            switch (gr)
            {
                case "0011":
                    double[] yyy = new double[1]; yyy[0] = q1[0];
                    double[] yxx = new double[1]; yxx[0] = q2[0];
                    z1.GraphPane.AddCurve("", yxx, yyy, Color.DarkSalmon).Line.IsVisible = false;
                    z1.GraphPane.AddCurve("", q1, q2, Color.DarkOrange).Line.IsVisible = false;
                    //if (exact_solution_copy.Length > 0)
                    //{
                    //    z2.GraphPane.AddCurve("", exact_solution_copy_x, tmp, Color.DarkGray).Line.IsVisible = false;
                    //    z2.AxisChange();
                    //    z2.Invalidate();
                    //}
                    break;

                case "1100":
                    double[] yy = new double[1]; yy[0] = w1[0];
                    double[] yx = new double[1]; yx[0] = w2[0];
                    z1.GraphPane.AddCurve("", yx, yy, Color.DarkSalmon).Line.IsVisible = false;
                    z1.GraphPane.AddCurve("", w1, w2, Color.DarkOrange).Line.IsVisible = false;
                    
                    break;
            }

            z1.AxisChange();
            z1.Invalidate();
        }


        double Q1(int num, double H, double h)
        {
            double s = Convert.ToDouble(s_textBox.Text);
            double s1 = Convert.ToDouble(s1_textBox.Text);
            double b = Convert.ToDouble(b_textBox.Text);
            double c = - 0.5 / Math.Sqrt(6 * b);
            double lambda = 2 * Math.Sqrt(2 * Math.Abs(H));
            switch (num)
            {
                case 1 : return 1 / (1 + 2 * H * h * h);
                case 2 : return (1 - 2 * s * s * H * h * h) / (1 + 2 * ( 1 - 2 * s * s) * H * h * h + 4 * Math.Pow(s * h, 4) * H * H);
                case 3 : double temp = 1 - 2 * b;
                    double delta3 = 1 + 2 * H * h * h * (1 - 8 * c * c + 16 * temp * c * s1 - 8 * temp * s1 * s1) 
                        + 32 * Math.Pow(h, 4) * H * H * (-c * c * (temp - 2 * c * c)
                    + 2 * temp * c * (1 - 4 * c * c) * s1 - temp * (1 - 4 * (3 - 4 * b) * c * c) * s1 * s1 - 8 * temp * temp * c * s1 * s1 * s1
                    + 2 * temp * temp * s1 * s1 * s1 * s1) + 16 * Math.Pow(h, 6) * Math.Pow(2 * H, 3) * temp * temp * Math.Pow(c - s1, 4);
                    return (1 + 16 * h * h * H * (-c * c * (1 - b) + temp * (2 * c - s1) * s1) + 16 * Math.Pow(h, 4) * Math.Pow(2 * H * (c - s1), 2)
                                * temp * (c * c - temp * (2 * c - s1) * s1)) / delta3;
                case 4: if (H > 0) return Math.Sin(lambda * h) / (lambda * h);
                    if (H == 0) return 1;
                    else return Math.Sinh(lambda * h) / (lambda * h);
            }
            return 0;
        }
        double Q2(int num, double H, double h)
        {
            double lambda = 2 * Math.Sqrt(2 * Math.Abs(H));
            switch (num)
            {
                case 4: if (H > 0) return 2 * (1 - Math.Cos(lambda * h)) / (lambda * lambda * h * h);
                    if (H == 0) return 1;
                    else return 2 * (Math.Cosh(lambda * h) - 1) / (lambda * lambda * h * h);                    
                default: return 2 * Math.Pow(Q1(num, H, h), 2) / (1 + Math.Sqrt(1 - 8 * H * h * h * Math.Pow(Q1(num, H, h), 2))); 
            }
        }
        double Q3(int num, double H, double h)
        {
            double lambda = 2 * Math.Sqrt(2 * Math.Abs(H));
            switch (num)
            {
                case 4: if (H > 0) return 8 * (1 - Math.Sin(lambda * h) / (lambda * h)) / (lambda * lambda * h * h);
                    if (H == 0) return 4/3;
                    else return 8 * (Math.Sinh(lambda * h) / (lambda * h) - 1) / (lambda * lambda * h * h);
                default: return (1 - Q1(num, H, h)) / (H * h * h);
            }
        }

        double max_difference(double[] a, double[] b)
        {
            if (a.Length != b.Length) return -1;
            double tmp = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (tmp < Math.Abs(a[i] - b[i]))
                    tmp = Math.Abs(a[i] - b[i]);
            }
            return tmp;
        }

        public Hashtable cool_method(string gr, int num)
        {
            //int num = Convert.ToInt32(cool_method_comboBox.Text);
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
           // double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * M * Math.Pow(2 * Math.Abs(H), -1.5);
            double T = Convert.ToDouble(P_C.Text) * Math.PI * Math.Pow(2 * Math.Abs(H), -0.5);
            double h = T / count;
            double[] X = new double[count];
            double[] Y = new double[count];
            double[] Vx = new double[count];
            double[] Vy = new double[count];
            double[] R = new double[count];
            double[] l = new double[count];
            double[] eX = new double[count];
            double[] eY = new double[count];
            double[] t = new double[count];
            double[] HH = new double[count];
         //   t_cmp = new double[count];
            Vx[0] = Convert.ToDouble(Vx0.Text);
            Vy[0] = Convert.ToDouble(Vy0.Text);
            X[0] = Convert.ToDouble(x0.Text);
            Y[0] = Convert.ToDouble(y0.Text);
            
            l[0] = X[0] * Vy[0] - Y[0] * Vx[0];
            eX[0] = Vy[0] * l[0] - g * M * X[0] / radius_count(X[0], Y[0]);//R[0];
            eY[0] = -Vx[0] * l[0] - g * M * Y[0] / radius_count(X[0], Y[0]);// R[0];
            R[0] = radius_count(X[0], Y[0]);//(l[0] * l[0] - eX[0] * X[0] - eY[0] * Y[0]) / (g * M);
            t[0] = 0;
            HH[0] = -(0.5 * (Vx[0] * Vx[0] + Vy[0] * Vy[0]) - g * M / radius_count(X[0], Y[0]));

            if (invars)
                for (int i = 1; i < X.Length; i++)
                {
                    X[i] = X[i - 1] + 2 * R[i - 1] * Vx[i - 1] * Q1(num, HH[i - 1], h) * h - 2 * (2 * HH[i - 1] * X[i - 1] + eX[i - 1]) * Q2(num, HH[i - 1], h) * h * h;
                    Y[i] = Y[i - 1] + 2 * R[i - 1] * Vy[i - 1] * Q1(num, HH[i - 1], h) * h - 2 * (2 * HH[i - 1] * Y[i - 1] + eY[i - 1]) * Q2(num, HH[i - 1], h) * h * h;
                    t[i] = t[i - 1] + 2 * R[i - 1] * Q1(num, HH[i - 1], h) * h + 2 * (X[i - 1] * Vx[i - 1] + Y[i - 1] * Vy[i - 1]) * Q2(num, HH[i - 1], h) * h * h + g * M * Q3(num, HH[i - 1], h) * h * h * h;
                    R[i] = (l[i - 1] * l[i - 1] - eX[i - 1] * X[i] - eY[i - 1] * Y[i]) / (g * M);
                    Vx[i] = -(l[i - 1] * l[i - 1] * eY[i - 1] - eX[i - 1] * eY[i - 1] * X[i] + (g * g * M * M - eY[i - 1] * eY[i - 1]) * Y[i]) / (g * M * l[i - 1] * R[i]);
                    Vy[i] = (l[i - 1] * l[i - 1] * eX[i - 1] - eX[i - 1] * eY[i - 1] * Y[i] + (g * g * M * M - eX[i - 1] * eX[i - 1]) * X[i]) / (g * M * l[i - 1] * R[i]);
                    l[i] = X[i] * Vy[i] - Y[i] * Vx[i];
                    eX[i] = Vy[i] * l[i] - g * M * X[i] / R[i];
                    eY[i] = -Vx[i] * l[i] - g * M * Y[i] / R[i];
                    HH[i] = -0.5 * (Vx[i] * Vx[i] + Vy[i] * Vy[i]) + g * M / R[i];
                 //   t_cmp[i] = t[i];
               }
            else
                for (int i = 1; i < X.Length; i++)
                {
                    X[i] = X[i - 1] + 2 * R[i - 1] * Vx[i - 1] * Q1(num, HH[0], h) * h - 2 * (2 * HH[0] * X[i - 1] + eX[0]) * Q2(num, HH[0], h) * h * h;
                    Y[i] = Y[i - 1] + 2 * R[i - 1] * Vy[i - 1] * Q1(num, HH[0], h) * h - 2 * (2 * HH[0] * Y[i - 1] + eY[0]) * Q2(num, HH[0], h) * h * h;
                    t[i] = t[i - 1] + 2 * R[i - 1] * Q1(num, HH[0], h) * h + 2 * (X[i - 1] * Vx[i - 1] + Y[i - 1] * Vy[i - 1]) * Q2(num, HH[0], h) * h * h + g * M * Q3(num, HH[0], h) * h * h * h;                    
                    R[i] = (l[0] * l[0] - eX[0] * X[i] - eY[0] * Y[i]) / (g * M);
                    Vx[i] = -(l[0] * l[0] * eY[0] - eX[0] * eY[0] * X[i] + (g * g * M * M - eY[0] * eY[0]) * Y[i]) / (g * M * l[0] * R[i]);
                    Vy[i] = (l[0] * l[0] * eX[0] - eX[0] * eY[0] * Y[i] + (g * g * M * M - eX[0] * eX[0]) * X[i]) / (g * M * l[0] * R[i]);
                    l[i] = Math.Abs(X[i] * Vy[i] - Y[i] * Vx[i] - l[0]);
                    eX[i] = Math.Abs(Vy[i] * l[i] - g * M * X[i] / radius_count(X[i], Y[i]) - eX[0]);
                    eY[i] = Math.Abs(-Vx[i] * l[i] - g * M * Y[i] / radius_count(X[i], Y[i]) - eY[0]);
                    HH[i] = Math.Abs(-0.5 * (Vx[i] * Vx[i] + Vy[i] * Vy[i]) + g * M / radius_count(X[i], Y[i]) - HH[0]);                     
                }

            HH[0] = 0;
            l[0] = 0;
            eX[0] = 0;
            eY[0] = 0;
            z1.IsShowPointValues = true;


            switch (gr)
            {
                case "1100":
                    double[] yyy = new double[1]; yyy[0] = Vy[0];
                    double[] yxx = new double[1]; yxx[0] = Vx[0];
                    switch (num) {
                        case 1: z1.GraphPane.AddCurve("", Vx, Vy, Color.DarkBlue).Line.IsVisible = false;
                            break;
                        case 2: z1.GraphPane.AddCurve("", Vx, Vy, Color.Chocolate).Line.IsVisible = false;
                            break;
                        case 3: z1.GraphPane.AddCurve("", Vx, Vy, Color.Blue).Line.IsVisible = false;
                            break;
                        case 4: z1.GraphPane.AddCurve("", Vx, Vy, Color.DeepPink).Line.IsVisible = false;
                            break;
                    }
                    z1.GraphPane.AddCurve("", yxx, yyy, Color.DarkGray).Line.IsVisible = false;

                    break;
                case "0011":


                    double[] yy = new double[1]; yy[0] = Y[0];
                    double[] yx = new double[1]; yx[0] = X[0];
                    
                    switch (num)
                    {
                        case 1: z1.GraphPane.AddCurve("", X, Y, Color.DarkBlue).Line.IsVisible = false;
                            break;
                        case 2: z1.GraphPane.AddCurve("", X, Y, Color.Chocolate).Line.IsVisible = false;
                            break;
                        case 3: z1.GraphPane.AddCurve("", X, Y, Color.Blue).Line.IsVisible = false;
                            break;
                        case 4: z1.GraphPane.AddCurve("", X, Y, Color.DeepPink).Line.IsVisible = false;
                            break;
                    }
                    z1.GraphPane.AddCurve("", yx, yy, Color.DarkGray).Line.IsVisible = false;

                    break;
                case "2000":
                    switch (num)
                    {
                        case 1: z1.GraphPane.AddCurve("", t, HH, Color.DarkBlue, SymbolType.None).Line.Width = 3; 
                            break;
                        case 2: z1.GraphPane.AddCurve("", t, HH, Color.Chocolate, SymbolType.None).Line.Width = 3;
                            break;
                        case 3: z1.GraphPane.AddCurve("", t, HH, Color.Blue, SymbolType.None).Line.Width = 3; 
                            break;
                        case 4: z1.GraphPane.AddCurve("", t, HH, Color.DeepPink, SymbolType.None).Line.Width = 3; 
                            break;
                    }
                    break;
                case "0200":
                    switch (num)
                    {
                        case 1: z1.GraphPane.AddCurve("", t, eX, Color.DarkBlue, SymbolType.None).Line.Width = 3;
                            break;
                        case 2: z1.GraphPane.AddCurve("", t, eX, Color.Chocolate, SymbolType.None).Line.Width = 3; 
                            break;
                        case 3: z1.GraphPane.AddCurve("", t, eX, Color.Blue, SymbolType.None).Line.Width = 3; 
                            break;
                        case 4: z1.GraphPane.AddCurve("", t, eX, Color.DeepPink, SymbolType.None).Line.Width = 3;
                            break;
                    }
                    break;
                case "0020":
                    switch (num)
                    {
                        case 1: z1.GraphPane.AddCurve("", t, eY, Color.DarkBlue, SymbolType.None).Line.Width = 3;
                            break;
                        case 2: z1.GraphPane.AddCurve("", t, eY, Color.Chocolate, SymbolType.None).Line.Width = 3;
                            break;
                        case 3: z1.GraphPane.AddCurve("", t, eY, Color.Blue, SymbolType.None).Line.Width = 3;
                            break;
                        case 4: z1.GraphPane.AddCurve("", t, eY, Color.DeepPink, SymbolType.None).Line.Width = 3;
                            break;
                    }
                    break;
                case "0002":
                    switch (num)
                    {
                        case 1: z1.GraphPane.AddCurve("", t, l, Color.DarkBlue, SymbolType.None).Line.Width = 3;
                            break;
                        case 2: z1.GraphPane.AddCurve("", t, l, Color.Chocolate, SymbolType.None).Line.Width = 3;
                            break;
                        case 3: z1.GraphPane.AddCurve("", t, l, Color.Blue, SymbolType.None).Line.Width = 3;
                            break;
                        case 4: z1.GraphPane.AddCurve("", t, l, Color.DeepPink, SymbolType.None).Line.Width = 3;
                            break;
                    }
                    break;
                default: break;
            }

            z1.AxisChange();
            z1.Invalidate();
            Hashtable aaa = new Hashtable();
            aaa.Add("X", X);
            aaa.Add ("Y", Y);
            aaa.Add ("Vx", Vx);
            aaa.Add ("Vy", Vy);
            aaa.Add ("t", t);
            aaa.Add ("R", R);
            aaa.Add ("l", l);
            aaa.Add ("eX", eX);
            aaa.Add ("eY", eY);
            aaa.Add ("H", HH);
           // double ff = ((Double[])aaa["X"])[0];
            return aaa;
        }

        //_____метод средней точки___(Рунге-Кутта)____
        private double ro(Matrix x) // x = [0 x, 1 y, 2 Vx, 3 Vy, 4 Kvx, 5 Kvy] - столбец
        {
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * M * Math.Pow(2 * Math.Abs(H), -1.5);
            double h = T / count;
            return Math.Pow(Math.Pow(x[0,0] + 0.5 * h * x[2,0] + 0.25 * h * h * x[4,0], 2) + Math.Pow(x[1,0] + 0.5 * h * x[3,0] + 0.25 * h * h * x[5,0], 2), 0.5);
        }
        public delegate double Func (Matrix x);
        public delegate double DifFunc (Matrix x);


        public double F1(Matrix x) // x = [x, y, Vx, Vy, Kvx, Kvy] - столбец 
        {
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            int count = Convert.ToInt32(points_count.Text); 
            double g = Convert.ToDouble(G.Text); 
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * M * Math.Pow(2 * Math.Abs(H), -1.5); 
            double h = T / count;
            return x[4, 0] + g * M * Math.Pow(ro(x), -3) * (x[0, 0] + 0.5 * h * x[2, 0] + 0.25 * h * h * x[4, 0]);
        }

        public double F2(Matrix x) // x = [x, y, Vx, Vy, Kvx, Kvy] - столбец 
        {
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            int count = Convert.ToInt32(points_count.Text); 
            double g = Convert.ToDouble(G.Text); 
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * M * Math.Pow(2 * Math.Abs(H), -1.5); 
            double h = T / count;
            return x[5, 0] + g * M * Math.Pow(ro(x), -3) * (x[1, 0] + 0.5 * h * x[3, 0] + 0.25 * h * h * x[5, 0]);

}

        public double dF1_dKvx(Matrix x) // x = [0 x, 1 y, 2 Vx, 3 Vy, 4 Kvx, 5 Kvy] - столбец
        {   
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * M * Math.Pow(2 * Math.Abs(H), -1.5);
            double h = T / count;
            return 1 + 0.25 * h * h * g * M * Math.Pow(ro(x), -3) * (1 - 3 * Math.Pow(ro(x), -2) * Math.Pow((x[0, 0] + 0.5 * h * x[2, 0] + 0.25 * h * h * x[4, 0]), 2));            
        }

        public double dF1_dKvy(Matrix x) // x = [0 x, 1 y, 2 Vx, 3 Vy, 4 Kvx, 5 Kvy] - столбец
        {
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * M * Math.Pow(2 * Math.Abs(H), -1.5);
            double h = T / count;
            return - 0.25 * h * h * 6 * g * M * Math.Pow(ro(x), -5) * (x[1, 0] + 0.5 * h * x[3, 0] + 0.25 * h * h * x[5, 0]) * (x[0, 0] + 0.5 * h * x[2, 0] + 0.25 * h * h * x[4, 0]);
        }

        public double dF2_dKvx(Matrix x) // x = [0 x, 1 y, 2 Vx, 3 Vy, 4 Kvx, 5 Kvy] - столбец
        {
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * M * Math.Pow(2 * Math.Abs(H), -1.5);
            double h = T / count;
            return -0.25 * h * h * 6 * g * M * Math.Pow(ro(x), -5) * (x[0, 0] + 0.5 * h * x[3, 0] + 0.25 * h * h * x[4, 0]) * (x[1, 0] + 0.5 * h * x[3, 0] + 0.25 * h * h * x[5, 0]);
        }

        public double dF2_dKvy(Matrix x) // x = [0 x, 1 y, 2 Vx, 3 Vy, 4 Kvx, 5 Kvy] - столбец
        {
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * M * Math.Pow(2 * Math.Abs(H), -1.5);
            double h = T / count;
            return 1 + 0.25 * h * h * g * M * Math.Pow(ro(x), -3) * (1 - 3 * Math.Pow(ro(x), -2) * Math.Pow((x[1, 0] + 0.5 * h * x[3, 0] + 0.25 * h * h * x[5, 0]), 2));
        }

        public Hashtable middle_point_method_old (string gr)
        {
            double _M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * _M * Math.Pow(2 * Math.Abs(H), -1.5);
            //double T = Math.PI * Math.Pow(2 * H, -0.5);
            double h = T / count;
            int[] newton_itt = new int[count];
            double[] X = new double[count];
            double[] Y = new double[count];
            double[] Vx = new double[count];
            double[] Vy = new double[count];
            double[] l = new double[count];
            double[] eX = new double[count];
            double[] eY = new double[count];
            double[] HH = new double[count];
            double[] t = new double[count];
            Matrix Kv = new Matrix(2, 1);
            Matrix ToNewton = new Matrix(6, 1);
            Func[] functions = new Func[2];
            DifFunc[] dif_functions = new DifFunc[4];
            Vx[0] = Convert.ToDouble(Vx0.Text);
            Vy[0] = Convert.ToDouble(Vy0.Text);
            X[0] = Convert.ToDouble(x0.Text);
            Y[0] = Convert.ToDouble(y0.Text);

            l[0] = X[0] * Vy[0] - Y[0] * Vx[0];
            eX[0] = Vy[0] * l[0] - g * _M * X[0] / radius_count(X[0], Y[0]);
            eY[0] = -Vx[0] * l[0] - g * _M * Y[0] / radius_count(X[0], Y[0]);
            HH[0] = -0.5 * (Vx[0] * Vx[0] + Vy[0] * Vy[0]) + g * _M / radius_count(X[0], Y[0]);
            t[0] = 0; 

            functions[0] = F1;
            functions[1] = F2;
            dif_functions[0] = dF1_dKvx;
            dif_functions[1] = dF1_dKvy;
            dif_functions[2] = dF2_dKvx;
            dif_functions[3] = dF2_dKvy;

            for (int i = 0; i < X.Length - 1; i++)
            {
                double ro = Math.Pow(Math.Pow(X[i] + 0.5 * h * Vx[i], 2) + (Math.Pow(Y[i] + 0.5 * h * Vy[i], 2)), 0.5);
                double Kvx0 = -g * _M * (X[i] + 0.5 * h * Vx[i]) * Math.Pow(ro, -3);
                double Kvy0 = -g * _M * (Y[i] + 0.5 * h * Vy[i]) * Math.Pow(ro, -3);

                ToNewton[0, 0] = X[i];
                ToNewton[1, 0] = Y[i];
                ToNewton[2, 0] = Vx[i];
                ToNewton[3, 0] = Vy[i];
                ToNewton[4, 0] = Kvx0;
                ToNewton[5, 0] = Kvy0;
                //Kv[0, 0] = Kvx0;
                //Kv[1, 0] = Kvy0;

                Newton n = new Newton(2, 0.1, ToNewton, functions, dif_functions);
                ToNewton = n.Method();
                newton_itt[i] = n.itterations();
                
                Kv[0, 0] = ToNewton[4, 0];
                Kv[1, 0] = ToNewton[5, 0];

                Vx[i + 1] = Vx[i] + h * Kv[0, 0];
                Vy[i + 1] = Vy[i] + h * Kv[1, 0];
                X[i + 1] = X[i] + h * Vx[i] + 0.5 * h * h * Kv[0, 0];
                Y[i + 1] = Y[i] + h * Vy[i] + 0.5 * h * h * Kv[1, 0];
                
                l[i + 1] = Math.Abs(X[i + 1] * Vy[i + 1] - Y[i + 1] * Vx[i + 1] - l[0]);
                eX[i + 1] = Math.Abs(Vy[i + 1] * l[i + 1] - g * _M * X[i + 1] / radius_count(X[i + 1], Y[i + 1]) - eX[0]);
                eY[i + 1] = Math.Abs(-Vx[i + 1] * l[i + 1] - g * _M * Y[i + 1] / radius_count(X[i + 1], Y[i + 1]) - eY[0]);
                HH[i + 1] = Math.Abs(-0.5 * (Vx[i + 1] * Vx[i + 1] + Vy[i + 1] * Vy[i + 1]) + g * _M / radius_count(X[i + 1], Y[i + 1]) - HH[0]);
                t[i + 1] = h * (i + 1); 
            }
            HH[0] = 0;
            l[0] = 0;
            eX[0] = 0;
            eY[0] = 0;
            switch (gr)
                {
                    case "1100":

                        double[] yyy = new double[1]; yyy[0] = Vy[0];
                        double[] yxx = new double[1]; yxx[0] = Vx[0];
                        z1.GraphPane.AddCurve("", yxx, yyy, Color.Beige).Line.IsVisible = false;
                        z1.GraphPane.AddCurve("", Vx, Vy, Color.BurlyWood).Line.IsVisible = false; break;
                    case "0011":

                        double[] yy = new double[1]; yy[0] = Y[0];
                        double[] yx = new double[1]; yx[0] = X[0];
                        z1.GraphPane.AddCurve("", yx, yy, Color.Beige).Line.IsVisible = false;
                        z1.GraphPane.AddCurve("", X, Y, Color.BurlyWood); break;

                    case "2000":
                        z1.GraphPane.AddCurve("", t, HH, Color.BurlyWood, SymbolType.None).Line.Width = 3;
                        break;
                    case "0200":
                        z1.GraphPane.AddCurve("", t, eX, Color.BurlyWood, SymbolType.None).Line.Width = 3;
                        break;
                    case "0020":
                        z1.GraphPane.AddCurve("", t, eY, Color.BurlyWood, SymbolType.None).Line.Width = 3;
                        break;
                    case "0002":
                        z1.GraphPane.AddCurve("", t, l, Color.BurlyWood, SymbolType.None).Line.Width = 3;
                        break;
                    default: break;
                }
                z1.AxisChange();
                z1.Invalidate();

                Hashtable aaa = new Hashtable();
                aaa.Add("X", X);
                aaa.Add("Y", Y);
                aaa.Add("Vx", Vx);
                aaa.Add("Vy", Vy);
                aaa.Add("itt", newton_itt);
                return aaa;
        }

        double coef_A()
        {
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            double g = Convert.ToDouble(G.Text);

            return g * M / H;
        }

        double coef_B()
        {
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            double g = Convert.ToDouble(G.Text);
            double vx0 = Convert.ToDouble(Vx0.Text);
            double vy0 = Convert.ToDouble(Vy0.Text);
            double X0 = Convert.ToDouble(x0.Text);
            double Y0 = Convert.ToDouble(y0.Text);
            double r0 = radius_count(X0, Y0);
            
            return 0.5 * r0 / Math.Sqrt(2 * H) * (1 - (vx0 * vx0 + vy0 * vy0) / (2 * H));
        }

        double coef_C()
        {
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            double g = Convert.ToDouble(G.Text);
            double vx0 = Convert.ToDouble(Vx0.Text);
            double vy0 = Convert.ToDouble(Vy0.Text);
            double X0 = Convert.ToDouble(x0.Text);
            double Y0 = Convert.ToDouble(y0.Text);
            double r0 = radius_count(X0, Y0);

            return -(vx0 * X0 + vy0 * Y0) / (2 * H);
        }

        public double F_H0 (Matrix s) // s = [0 s, 1 t] - столбец
        {
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * M * Math.Pow(2 * Math.Abs(H), -1.5);
            //double h = T / count;
            double vx0 = Convert.ToDouble(Vx0.Text);
            double vy0 = Convert.ToDouble(Vy0.Text);
            double X0 = Convert.ToDouble(x0.Text);
            double Y0 = Convert.ToDouble(y0.Text);
            double r0 = radius_count(X0, Y0);
            return 2 * r0 * s[0, 0] + 2 * (vx0 * X0 + vy0 * Y0) * s[0, 0] * s[0, 0] + 2 / 3 * r0 * (vx0 * vx0 + vy0 * vy0) * s[0, 0] * s[0, 0] * s[0, 0] - s[1, 0];
        }

        public double F_H0_minus(Matrix s) // s = [0 s, 1 t] - столбец
        {
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * M * Math.Pow(2 * Math.Abs(H), -1.5);
            double h = T / count;
            double vx0 = Convert.ToDouble(Vx0.Text);
            double vy0 = Convert.ToDouble(Vy0.Text);
            double X0 = Convert.ToDouble(x0.Text);
            double Y0 = Convert.ToDouble(y0.Text);
            double r0 = radius_count(X0, Y0);
            return coef_A() * s[0, 0] + coef_B() * Math.Sinh(2 * Math.Sqrt(-2 * H) * s[0, 0])
                + coef_C() * (Math.Cosh(2 * Math.Sqrt(-2 * H) * s[0, 0]) - 1) - s[1, 0];
        }

        public double F_H0_plus(Matrix s) // s = [0 s, 1 t] - столбец
        {
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * M * Math.Pow(2 * Math.Abs(H), -1.5);
            //double h = T / count;
            double vx0 = Convert.ToDouble(Vx0.Text);
            double vy0 = Convert.ToDouble(Vy0.Text);
            double X0 = Convert.ToDouble(x0.Text);
            double Y0 = Convert.ToDouble(y0.Text);
           // double r0 = radius_count(X0, Y0);
            return coef_A() * s[0, 0] + coef_B() * Math.Sin(2 * Math.Sqrt(2 * H) * s[0, 0])
                + coef_C() * (Math.Cos(2 * Math.Sqrt(2 * H) * s[0, 0]) - 1) - s[1, 0];
        }

        public double dF_H0 (Matrix s) // s = [0 s, 1 t] - столбец
        {
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * M * Math.Pow(2 * Math.Abs(H), -1.5);
            double h = T / count;
            double vx0 = Convert.ToDouble(Vx0.Text);
            double vy0 = Convert.ToDouble(Vy0.Text);
            double X0 = Convert.ToDouble(x0.Text);
            double Y0 = Convert.ToDouble(y0.Text);
            double r0 = radius_count(X0, Y0);
            return 2 * r0 + 4 * (vx0 * X0 + vy0 * Y0) * s[0, 0] + 2 * r0 * (vx0 * vx0 + vy0 * vy0) * s[0, 0] * s[0, 0] ;
        }

        public double dF_H0_minus(Matrix s) // s = [0 s, 1 t] - столбец
        {
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * M * Math.Pow(2 * Math.Abs(H), -1.5);
            double h = T / count;
            double vx0 = Convert.ToDouble(Vx0.Text);
            double vy0 = Convert.ToDouble(Vy0.Text);
            double X0 = Convert.ToDouble(x0.Text);
            double Y0 = Convert.ToDouble(y0.Text);
            double r0 = radius_count(X0, Y0);
            return coef_A()  + coef_B() * Math.Cosh(2 * Math.Sqrt(-2 * H) * s[0, 0]) + coef_C() * Math.Sinh(2 * Math.Sqrt(-2 * H) * s[0, 0]);
        }

        public double dF_H0_plus(Matrix s) // s = [0 s, 1 t] - столбец
        {
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * M * Math.Pow(2 * Math.Abs(H), -1.5);
            double h = T / count;
            double vx0 = Convert.ToDouble(Vx0.Text);
            double vy0 = Convert.ToDouble(Vy0.Text);
            double X0 = Convert.ToDouble(x0.Text);
            double Y0 = Convert.ToDouble(y0.Text);
            double r0 = radius_count(X0, Y0);
            return coef_A() + coef_B() * Math.Cos(2 * Math.Sqrt(2 * H) * s[0, 0]) * 2 * Math.Sqrt(2 * H) - coef_C() * Math.Sin(2 * Math.Sqrt(2 * H) * s[0, 0]) * 2 * Math.Sqrt(2 * H);
        }

        public double[] T_to_S(double[] t)
        {
            int[] newton_itt = new int[t.Length];
            double M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);
            double g = Convert.ToDouble(G.Text);
            double[] s = new double[t.Length]; 
            Matrix ToNewton = new Matrix(2, 1);
            Func[] functions = new Func[1];
            DifFunc[] dif_functions = new DifFunc[1];
            if (H > 0)
            {
                functions[0] = F_H0_plus;
                dif_functions[0] = dF_H0_plus;
            }
            if (H == 0)
            {
                functions[0] = F_H0;
                dif_functions[0] = dF_H0;
            }
            if (H < 0)
            {
                functions[0] = F_H0_minus;
                dif_functions[0] = dF_H0_minus;
            }


            ToNewton[0, 0] = t[0] * H / (g * M);
            ToNewton[1, 0] = t[0];// *H / (g * M);
            Newton n = new Newton(1, 0.00001, ToNewton, functions, dif_functions);
            ToNewton = n.Method();
            newton_itt[0] = n.itterations();
            s[0] = ToNewton[0, 0];
            for (int i = 1; i < t.Length; i++)
            {
                ToNewton[0, 0] = s[i - 1]; // t[i] * H / (g * M);
                ToNewton[1, 0] = t[i];// *H / (g * M);
                n = new Newton(1, 0.00001, ToNewton, functions, dif_functions);
                ToNewton = n.Method();
                newton_itt[i] = n.itterations();
                s[i] = ToNewton[0, 0]; 
            }
            return s;
        }

        void e_m_f_old(string gr)
        {

            double _M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);

            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * _M * Math.Pow(2 * Math.Abs(H), -1.5);
            double h = T / count;
            double[] y1 = new double[count];
            double[] y2 = new double[count];
            double[] y3 = new double[count];
            double[] y4 = new double[count];
            double[] l = new double[count];
            double[] eX = new double[count];
            double[] eY = new double[count];
            double[] HH = new double[count];
            double[] t = new double[count];
            int i = 0;
            y1[0] = Convert.ToDouble(Vx0.Text);
            y2[0] = Convert.ToDouble(Vy0.Text);
            y3[0] = Convert.ToDouble(x0.Text);
            y4[0] = Convert.ToDouble(y0.Text);

            l[0] = y3[0] * y2[0] - y4[0] * y1[0];
            eX[0] = y2[0] * l[0] - g * _M * y3[0] / radius_count(y3[0], y4[0]);
            eY[0] = -y1[0] * l[0] - g * _M * y4[0] / radius_count(y3[0], y4[0]);
            HH[0] = -0.5 * (y1[0] * y1[0] + y2[0] * y2[0]) + g * _M / radius_count(y3[0], y4[0]);
            t[0] = 0; 

            for (i = 1; i < count; i++)
            {
                //метод Эйлера
                y1[i] = y1[i - 1] + h * (-g * _M * Math.Pow(y3[i - 1] * y3[i - 1] + y4[i - 1] * y4[i - 1], -1.5) * y3[i - 1]);
                y2[i] = y2[i - 1] + h * (-g * _M * Math.Pow(y3[i - 1] * y3[i - 1] + y4[i - 1] * y4[i - 1], -1.5) * y4[i - 1]);
                y3[i] = y3[i - 1] + h * y1[i - 1];
                y4[i] = y4[i - 1] + h * y2[i - 1];
                l[i] = Math.Abs(y3[i] * y2[i] - y4[i] * y1[i] - l[0]);
                eX[i] = Math.Abs(y2[i] * l[i] - g * _M * y3[i] / radius_count(y3[i], y4[i]) - eX[0]);
                eY[i] = Math.Abs(-y1[i] * l[i] - g * _M * y4[i] / radius_count(y3[i], y4[i]) - eY[0]);
                HH[i] = Math.Abs(-0.5 * (y1[i] * y1[i] + y2[i] * y2[i]) + g * _M / radius_count(y3[i], y4[i]) - HH[0]);
                t[i] = h * i; 
            }
            HH[0] = 0;
            l[0] = 0;
            eX[0] = 0;
            eY[0] = 0;
            z1.IsShowPointValues = true;
            switch (gr)
            {
                case "1100":
           
                 
                    double[] yyy = new double[1]; yyy[0] = y2[0];
                    double[] yxx = new double[1]; yxx[0] = y1[0];
                    z1.GraphPane.AddCurve("", yxx, yyy, Color.DarkSalmon).Line.IsVisible = false;
                    z1.GraphPane.AddCurve("", y1, y2, Color.DarkOrange).Line.IsVisible = false; ;

                    break;
                case "0011":
               
     
                    double[] yy = new double[1]; yy[0] = y4[0];
                    double[] yx = new double[1]; yx[0] = y3[0];
                    z1.GraphPane.AddCurve("", yx, yy, Color.DarkSalmon).Line.IsVisible = false;
                    z1.GraphPane.AddCurve("", y3, y4, Color.DarkOrange ).Line.IsVisible = false;

                    break;
                case "2000":
                    z1.GraphPane.AddCurve("", t, HH, Color.DarkOrange, SymbolType.None).Line.Width = 3;
                    break;
                case "0200":
                    z1.GraphPane.AddCurve("", t, eX, Color.DarkOrange, SymbolType.None).Line.Width = 3;
                    break;
                case "0020":
                    z1.GraphPane.AddCurve("", t, eY, Color.DarkOrange, SymbolType.None).Line.Width = 3;
                    break;
                case "0002":
                    z1.GraphPane.AddCurve("", t, l, Color.DarkOrange, SymbolType.None).Line.Width = 3;
                    break;
            }

            z1.AxisChange();
            z1.Invalidate();
        }

        void r_k_f_old(string gr)
        {
            double k1, k2, k3, k4,
                   l1, l2, l3, l4,
                   p1, p2, p3, p4,
                   o1, o2, o3, o4,
                   _M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);

            int count = Convert.ToInt32(points_count.Text);
            double g = Convert.ToDouble(G.Text);
            double T = Convert.ToDouble(P_C.Text) * 2 * Math.PI * g * _M * Math.Pow(2 * Math.Abs(H), -1.5);
            //double T = Math.PI * Math.Pow(2 * H, -0.5);
            double h = T / count;
            double[] y1 = new double[count];
            double[] y2 = new double[count];
            double[] y3 = new double[count];
            double[] y4 = new double[count];
            double[] l = new double[count];
            double[] eX = new double[count];
            double[] eY = new double[count];
            double[] HH = new double[count];
            double[] t = new double[count];
            int i = 0;
            y1[0] = Convert.ToDouble(Vx0.Text);
            y2[0] = Convert.ToDouble(Vy0.Text);
            y3[0] = Convert.ToDouble(x0.Text);
            y4[0] = Convert.ToDouble(y0.Text);

            l[0] = y3[0] * y2[0] - y4[0] * y1[0];
            eX[0] = y2[0] * l[0] - g * _M * y3[0] / radius_count(y3[0], y4[0]);
            eY[0] = -y1[0] * l[0] - g * _M * y4[0] / radius_count(y3[0], y4[0]);
            HH[0] = -0.5 * (y1[0] * y1[0] + y2[0] * y2[0]) + g * _M / radius_count(y3[0], y4[0]);
            t[0] = 0; 
           
            for (i = 1; i < count; i++)
            {
                k1 = -g * _M * Math.Pow(y3[i - 1] * y3[i - 1] + y4[i - 1] * y4[i - 1], -1.5) * y3[i - 1];
                l1 = -g * _M * Math.Pow(y3[i - 1] * y3[i - 1] + y4[i - 1] * y4[i - 1], -1.5) * y4[i - 1];
                p1 = y1[i - 1];
                o1 = y2[i - 1];

                k2 = -g * _M * Math.Pow(Math.Pow(y3[i - 1] + (h / 2) * p1, 2) + Math.Pow(y4[i - 1] + (h / 2) * o1, 2), -1.5) * (y3[i - 1] + (h / 2) * p1);
                l2 = -g * _M * Math.Pow(Math.Pow(y3[i - 1] + (h / 2) * p1, 2) + Math.Pow(y4[i - 1] + (h / 2) * o1, 2), -1.5) * (y4[i - 1] + (h / 2) * o1);
                p2 = y1[i - 1] + (h / 2) * k1;
                o2 = y2[i - 1] + (h / 2) * l1;

                k3 = -g * _M * Math.Pow(Math.Pow(y3[i - 1] + (h / 2) * p2, 2) + Math.Pow(y4[i - 1] + (h / 2) * o2, 2), -1.5) * (y3[i - 1] + (h / 2) * p2);
                l3 = -g * _M * Math.Pow(Math.Pow(y3[i - 1] + (h / 2) * p2, 2) + Math.Pow(y4[i - 1] + (h / 2) * o2, 2), -1.5) * (y4[i - 1] + (h / 2) * o2);
                p3 = y1[i - 1] + (h / 2) * k2;
                o3 = y2[i - 1] + (h / 2) * l2;


                k4 = -g * _M * Math.Pow(Math.Pow(y3[i - 1] + h * p3, 2) + Math.Pow(y4[i - 1] + h * o3, 2), -1.5) * (y3[i - 1] + h * p3);
                l4 = -g * _M * Math.Pow(Math.Pow(y3[i - 1] + h * p3, 2) + Math.Pow(y4[i - 1] + h * o3, 2), -1.5) * (y4[i - 1] + h * o3);
                p4 = y1[i - 1] + h * k3;
                o4 = y2[i - 1] + h * l3;

                y1[i] = y1[i - 1] + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4);
                y2[i] = y2[i - 1] + (h / 6) * (l1 + 2 * l2 + 2 * l3 + l4);
                y3[i] = y3[i - 1] + (h / 6) * (p1 + 2 * p2 + 2 * p3 + p4);
                y4[i] = y4[i - 1] + (h / 6) * (o1 + 2 * o2 + 2 * o3 + o4);

                l[i] = Math.Abs(y3[i] * y2[i] - y4[i] * y1[i] - l[0]);
                eX[i] = Math.Abs(y2[i] * l[i] - g * _M * y3[i] / radius_count(y3[i], y4[i]) - eX[0]);
                eY[i] = Math.Abs(-y1[i] * l[i] - g * _M * y4[i] / radius_count(y3[i], y4[i]) - eY[0]);
                HH[i] = Math.Abs(-0.5 * (y1[i] * y1[i] + y2[i] * y2[i]) + g * _M / radius_count(y3[i], y4[i]) - HH[0]);
                t[i] = h * i; 
            }

            z1.IsShowPointValues = true;
            HH[0] = 0;
            l[0] = 0;
            eX[0] = 0;
            eY[0] = 0;
            switch (gr)
            {
                case "1100":
              
                 
                    double[] yyy = new double[1]; yyy[0] = y2[0];
                    double[] yxx = new double[1]; yxx[0] = y1[0];
                    z1.GraphPane.AddCurve("", yxx, yyy, Color.Black ).Line.IsVisible = false;
                    z1.GraphPane.AddCurve("", y1, y2, Color.Black).Line.IsVisible = false; break;
                case "0011":
         
           
                    double[] yy = new double[1]; yy[0] = y4[0];
                    double[] yx = new double[1]; yx[0] = y3[0];
                    z1.GraphPane.AddCurve("", yx, yy, Color.Black ).Line.IsVisible = false;
                    z1.GraphPane.AddCurve("", y3, y4, Color.Black ); break;
                case "2000":
                    z1.GraphPane.AddCurve("", t, HH, Color.Black, SymbolType.None).Line.Width = 3;
                    break;
                case "0200":
                    z1.GraphPane.AddCurve("", t, eX, Color.Black, SymbolType.None).Line.Width = 3;
                    break;
                case "0020":
                    z1.GraphPane.AddCurve("", t, eY, Color.Black, SymbolType.None).Line.Width = 3;
                    break;
                case "0002":
                    z1.GraphPane.AddCurve("", t, l, Color.Black, SymbolType.None).Line.Width = 3;
                    break;
            }
            z1.AxisChange();
            z1.Invalidate();
        }

        void e_m_f_new(string gr)
        {
            double _M = Convert.ToDouble(M1.Text) + Convert.ToDouble(M2.Text);

            int count = Convert.ToInt32(points_count.Text);
            //double T = 2*Math.PI*g*Math.Pow(2*H,-1.5);
            double Td = Convert.ToDouble(P_C.Text) * 2 * Math.PI *  Math.Pow(2 * Math.Abs(H), -0.5);
            double h = Td / count;
            double[] y1 = new double[count];
            double[] y2 = new double[count];
            double[] y3 = new double[count];
            double[] y4 = new double[count];
            int i = 0;
            y1[0] = w10;
            y2[0] = w20;
            y3[0] = q10;
            y4[0] = q20;
            double t = h;
            for (i = 1; i < count; i++)
            {
                y1[i] = y1[i - 1] + h * (-2 * H * y3[i - 1]);
                y2[i] = y2[i - 1] + h * (-2 * H * y4[i - 1]);
                y3[i] = y3[i - 1] + h * y1[i - 1];
                y4[i] = y4[i - 1] + h * y2[i - 1];
            }

            z1.IsShowPointValues = true;


            switch (gr)
            {
                case "1100":
                 
                     
                    double[] ysyy = new double[1]; ysyy[0] = y2[0];
                    double[] yxx = new double[1]; yxx[0] = y1[0];
                    z1.GraphPane.AddCurve("", yxx, ysyy, Color.Brown ).Line.IsVisible = false;
                    z1.GraphPane.AddCurve("", y1, y2, Color.Brown ).Line.IsVisible = false; break;
                case "0011":
                  
                       
                    double[] yy = new double[1]; yy[0] = y4[0];
                    double[] yx = new double[1]; yx[0] = y3[0];
                    z1.GraphPane.AddCurve("", yx, yy, Color.Brown ).Line.IsVisible = false;
                    z1.GraphPane.AddCurve("", y3, y4, Color.Brown ).Line.IsVisible = false; break;
            }
            z1.AxisChange();
            z1.Invalidate();
        }

        ////////////////////////////////////////////////////////////////////////////////////   

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            kepler_build();
            
        }

        private void runge_check_box_CheckedChanged_1(object sender, EventArgs e)
        {
            r_k = !r_k;
        }

        private void exact_solution_check_box_CheckedChanged_1(object sender, EventArgs e)
        {
            e_s = !e_s;
        }

        private void eiler_check_box_CheckedChanged_1(object sender, EventArgs e)
        {
            e_m = !e_m;
        }
        
        private void verle_explicit_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            v_e_m = !v_e_m;
        }

        private void middle_point_check_box_CheckedChanged(object sender, EventArgs e)
        {
            m_p = !m_p;

        }

        private void cool_method_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            c_m = !c_m;
            cool_method_box.Visible = !cool_method_box.Visible;
        }

        private void cool_method_1_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            c_m_1 = !c_m_1;
        }

        private void cool_method_2_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            c_m_2 = !c_m_2;
        }

        private void cool_method_3_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            c_m_3 = !c_m_3;
        }

        private void cool_method_4_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            c_m_4 = !c_m_4;
        }
       
        string note_text = "";
        
        //заметки и сохранение в файл
        private void note_button_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.ShowDialog();
            note_text = F2.note_Box.Text;
        }     
       
        private string[] parse_file_data(String data)
        {
            string[] parse_result = new string[7];
            int j = 0;
            string tmp = "";
            for (int i = 0; i < data.Length; i++)
            {

                if (data[i] == ';' || i == data.Length - 1)
                {
                    if (i == data.Length - 1)
                    {
                        tmp += data[i];
                    }
                    parse_result[j] = tmp;

                    Console.WriteLine(tmp);
                    tmp = "";
                    j++;
                }
                else
                {
                    tmp += data[i];
                }


            }

            return parse_result;
        }
           
        bool rewrite_path = false;
        
        private void save_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            Directory.CreateDirectory(mydocpath);
            string path = @"..\\..\\saved files";
            mydocpath = Path.GetFullPath(path);
            Hashtable saved = new Hashtable();
            saved.Add("M1", M1.Text); saved.Add("M2", M2.Text);
            saved.Add("Vx0", Vx0.Text); saved.Add("Vy0", Vy0.Text);
            saved.Add("G", G.Text);
            saved.Add("x0", x0.Text); saved.Add("y0", y0.Text);
            var serializer = new JavaScriptSerializer();
            save_text = serializer.Serialize(saved);
            if (save_name.Text != "")
            {
                filepath = mydocpath + "\\" + save_name.Text;
                if (Directory.Exists(filepath))
                {
                    save_label.ForeColor = System.Drawing.Color.Yellow;
                    save_label.Text = "Данные с таким названием существуют, нажмите на сохранение еще раз, чтобы перезаписать!";
                    if (rewrite_path)
                    {
                        DirectoryInfo d = new DirectoryInfo(filepath);
                        d.Delete(true);
                    }
                    else
                    {
                        rewrite_path = true;
                        return;
                    }
                }
                rewrite_path = false;
                DirectoryInfo di = Directory.CreateDirectory(filepath);
                Console.WriteLine(note_text);
                File.AppendAllText(filepath + "\\notes.txt",note_text);
                File.AppendAllText(filepath + "\\data.txt", save_text);
                z1.GraphPane.GetImage(1000, 1000, 1).Save(filepath + "\\pic.bmp");
                save_label.ForeColor = System.Drawing.Color.Green;
                save_label.Text = "СОХРАНЕНО";
                timer1.Tick += timer1_Tick;
                timer1.Interval = 5000;
                timer1.Start();
            }
            else
            {
                save_label.ForeColor = System.Drawing.Color.Red;
                save_label.Text = "Придумайте название данным!";

            }
        }
        
        private void load_data(String data)
        {
            
            try
            {
                var serializer = new JavaScriptSerializer();
                String json = File.ReadAllText(data + ".txt");
                Hashtable result = serializer.Deserialize<Hashtable>(json);
                M1.Text = Convert.ToString(result["M1"]);
                M2.Text = Convert.ToString(result["M2"]);
                x0.Text = Convert.ToString(result["x0"]);
                y0.Text = Convert.ToString(result["y0"]);
                G.Text = Convert.ToString(result["G"]);
                Vx0.Text = Convert.ToString(result["Vx0"]);
                Vy0.Text = Convert.ToString(result["Vy0"]);
                comboBox1.SelectedIndex = 0;
                kepler_build();
            }
            catch
            {
                save_label.ForeColor = System.Drawing.Color.Green;
                save_label.Text = "Файл поврежден или некорректно указан";
                timer1.Tick += timer1_Tick;
                timer1.Interval = 5000;
                timer1.Start();
            }
           
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            save_label.Text = "";
            save_name.Text = "";
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            File.WriteAllText(filepath, save_text);
            save_label.ForeColor = System.Drawing.Color.Green;
            save_label.Text = "Файл перезаписан";
            timer2.Enabled = false;
        }    

        private void Kepler_Click(object sender, EventArgs e)
        {
            kepler_build();
        } 

        private void exact_points_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            e_p = !e_p;
        }

        private void invariant_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            invars = !invars; 
        }

        private void inaccuracy_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            inaccuracy = !inaccuracy;
        }

        private void inaccuracy_button_Click(object sender, EventArgs e)
        {
            Form3 F3 = new Form3(this);
            F3.ShowDialog();
        }              

    }
}
