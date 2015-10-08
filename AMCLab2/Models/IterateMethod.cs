using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCLab2.Models
{
    public class IterateMethod
    {
        private static double a = 0.25, b = 0.5;
        private double x0 = (b + a) / 2;
        private double q = 0.12;
        public Sol[] Table { get; set; } 
        public class Sol
        {
            public double Eps { get; set; }
            public double X { get; set; }
            public double Acc { get; set; }
            public double N { get; set; }
        }
        private double Func(double x)
        {
            return x - 0.36 * (x * x + 2 * Math.Sin(x) - 1);
        }
        public IterateMethod()
        {
            Table = new Sol[5];
            for(int i=0;i<5;i++)
            {
                Table[i] = new Sol();
            }
            Table[0].Eps = 0.01;
            for(int i=1;i<5;i++)
            {
                Table[i].Eps = Table[i].Eps / 1000;
            }
            for(int i=0;i<5;i++)
            {
                double eps = Table[i].Eps;
                double xn1 = x0;
                double xn = Func(xn1);
                double n = 1;
                while(Math.Abs(xn-xn1)*q*(1-q)>eps)
                {
                    xn1 = xn;
                    xn = Func(xn1);
                    n++;
                }
                Table[i].X = xn;
                Table[i].Acc = Math.Abs(xn - xn1) * q * (1 - q);
                Table[i].N = n;
            }
        }

    }
}
