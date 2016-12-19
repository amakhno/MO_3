using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] X0 = new double[] { 0, 0 };
            double eps = 0.1;
            double d = 2;
            double h = 0.2;
            double m = 0.5;
            Solver solver = new Solver(X0, eps, d, h, m, Function);
            Console.WriteLine("Answer: \n" + solver.ToString());
            Console.ReadKey();
        }

        static private double Function(double[] x)
        {
            return x[0] * x[0] - 1 * x[1] * x[0] + 3 * x[1] * x[1] - x[0];
        }
    }
}
