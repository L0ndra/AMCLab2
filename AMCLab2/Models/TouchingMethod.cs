using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMCLab2.Models;

namespace AMCLab2.Models
{
   public class TouchingMethod
    {
        private static double a = 0.25, b = 0.5;
        private double x0 = b;
        public Sol[] Table { get; set; }
        private double f(double x)
        {
            return x * x + 2 * Math.Sin(x) - 1;
        }
        private double df(double x)
        {
            return 2 * x + 2 * Math.Cos(x);
        }
        public TouchingMethod()
        {
            Table = new Sol[5];
            for (int i = 0; i < 5; i++)
            {
                Table[i] = new Sol();
            }
            Table[0].Eps = 0.01;
            for (int i = 1; i < 5; i++)
            {
                Table[i].Eps = Table[i-1].Eps / 1000;
            }
            for (int i = 0; i < 5; i++)
            {
                double eps = Table[i].Eps;
                double xn1 = x0;
                double xn = xn1 - f(xn1) / df(xn1);
                int n = 1;
                while (Math.Abs(f(xn)/2.42)> eps)
                {
                    xn1 = xn;
                    xn = xn1 - f(xn1) / df(xn1);
                    n++;
                }
                Table[i].X = xn;
                Table[i].Acc = Math.Abs(f(xn) / 2.42);
                Table[i].N = n;
            }
        }
    }
}
