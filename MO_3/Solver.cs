using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO_3
{
    class Solver
    {
        double[] X0;
        double eps;
        double d;
        double h;
        double m = 0.5;
        double[] X1;
        double[] XP;
        double[] Z;

        Func<double[], double> f;

        public Solver(double[] x0, double eps, double d, double h, double m, Func<double[], double> f)
        {
            X0 = x0;
            this.eps = eps;
            this.d = d;
            this.h = h;
            this.m = m;
            this.f = f;
        }

        public double[] Solve()
        {
            while (true)
            {
                X1 = (double[])X0.Clone();
                Z = (double[] )X1.Clone();
                for (int i = 0; i < X0.Length; i++)
                {
                    X1[i] += h;
                    if (f(Z) > f(X1))
                    {
                        Z = (double[])X1.Clone();
                        continue;
                    }
                    else
                    {
                        X1[i] -= 2 * h;
                        if (f(Z) < f(X1))
                        {
                            X1 = (double[])Z.Clone();
                        }
                        else
                        {
                            Z = (double[])X1.Clone();
                            continue;
                        }
                    }
                }
                if (!Enumerable.SequenceEqual(X1, X0))
                {
                    XP = GetXP();
                    if (f(XP) < f(X1))
                    {
                        X0 = (double[])XP.Clone();
                    }
                    else
                    {
                        X0 = (double[])X1.Clone();
                    }
                }
                else
                {
                    h /= d;
                }
                if (h < eps) break;
            }
            return X0;
        }

        private double[] GetXP()
        {
            XP = new double[X0.Length];
            for(int i = 0; i<X0.Length; i++)
            {
                XP[i] = X1[i] + m * (X1[i] - X0[i]);
            }
            return XP;
        }

        public override string ToString()
        {
            string result = "";
            var arrat = this.Solve();
            for(int i = 0; i<X0.Length; i++)
            {
                result += String.Format("X[{0}] = {1}\n", (i + 1), arrat[i]);
            }
            return result;
        }
    }
}
