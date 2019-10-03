using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp课后作业7
{
    class Program
    {
        static void Main(string[] args)
        {
            object o1 = 1, o2 = 2, o3 = "aaa", o4 = "bbb";
            Console.WriteLine("1，两个数据相加1+2={0}", addORconnect(o1, o2));
            Console.WriteLine("2,两个字符相加aaa+bbb={0}", addORconnect(o3, o4));
            Console.ReadKey();
        }

        static string addORconnect(object a, object b)
        {
            try
            {
                return Convert.ToString((int)a + (int)b); 
            }
            catch
            {
                return (string)a + (string)b;
            }
        }
    }
}
