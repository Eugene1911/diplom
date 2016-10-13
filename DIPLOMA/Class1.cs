using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace DIPLOMA
{
    class Newton
    { 
        int N;
        Matrix x;
        Matrix input;
        Form1.Func[] f;
        Form1.DifFunc[] ff; 
        double eps;
        int itter = 0;
        public Newton(int NN, double epss, Matrix inp, Form1.Func[] f1, Form1.DifFunc[] f2)
        {
            f = f1;
            ff = f2;
            eps = epss;
            N = NN;
            input = inp;
            Matrix tmp = new Matrix(N, 1);
            for (int i = 0; i < N; i++)
            {
                tmp[i, 0] = input[i, 0];
            }
            x = tmp;
        }

        Matrix F()
        {
            Matrix M = new Matrix(N, 1);
            //double x1 = x[0, 0];
            //double x2 = x[1, 0];
            for (int i = 0; i < N; i++){
                M[i, 0] = f[i](input);
               // M[i, 0] = f[i](x1, x2);
            }
            return M;
        }

        Matrix FF()
        {
            Matrix M = new Matrix(N, N);
            for (int j = 0; j < N; j++)
            {
                for (int i = 0; i < N; i++)
                {
                    M[j, i] = ff[j*N + i](input);
                }
            }
            return M;
        }

        bool check (Matrix x_new)
        {
            itter++;
            for (int i = 0; i < N; i++)
            {
                
                if (Math.Abs(x_new[i, 0] - x[i, 0]) > eps)
                    return false;
            }
            return true;
        }
        
        public Matrix Method()
        {
            Matrix x_new = new Matrix(N, 1);
            if (N == 1)
            {
               // Matrix x_new = new Matrix(N, 1);
                do
                {
                    Matrix M = F();//new Matrix(N, 1);
                    Matrix MM = FF();//new Matrix(N, N);
                    Matrix MMM = new Matrix(1, 1);
                    MMM[0, 0] = M[0, 0] / MM[0, 0];
                    x_new = x - MMM;
                    x = x_new;
                } while (!check(x_new));

            }
            else
            {
             //   Matrix x_new = new Matrix(N, 1);
                do
                {
                    Matrix M = F();//new Matrix(N, 1);
                    Matrix MM = FF().Invert();//new Matrix(N, N);
                    
                    x_new = x - MM * M;
                    x = x_new;
                } while (!check(x_new));
            }
            for (int i = 0; i < N; i++)
            {
                input[i, 0] = x_new[i, 0];
            }
            return input;
        }
        
        public int itterations(){
            return itter;
        }
    }
}
