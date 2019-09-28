using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp课后作业1
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string[] b = a.Split(';');
            double sum = 0;
            foreach (string i in b)
            {
                int c = Convert.ToInt32(i);
                Console.WriteLine(c);
                sum += Math.Sqrt(c);
            }
            Console.WriteLine("平方根的和为{0}",sum);
            Console.ReadKey();
        }
    }
}
