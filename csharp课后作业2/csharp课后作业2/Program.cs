using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp课后作业2
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = 0;
            int[] a = new int[] { 23, 34, 1, 32, 56, 44 };
            Array.Sort(a);
            foreach (int i in a)
            {
                Console.Write("{0} ",i);
            }
            Console.ReadKey();
        }
    }
}
