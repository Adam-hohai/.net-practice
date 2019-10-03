using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp课后作业6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = 1, n2 = 2;
            //object n3 = 1, n4 = 2;
            string s1 = "aaa", s2 = "bbb";
            //object s3 = "aaa", s4 = "bbb";
            Console.WriteLine("不带框操作的加法1+2={0}", add(n1, n2));
            Console.WriteLine("带框操作的加法1+2={0}", add((object)n1, (object)n2));
            Console.WriteLine("不带框操作的连接aaa+bbb={0}", connect(s1, s2));
            Console.WriteLine("带框操作的连接aaa+bbb={0}", connect((object)s1, (object)s2));
            Console.ReadKey();
        }

        static int add(int a, int b)
        {
            return a + b;
        }

        //消框
        static int add(object a, object b)
        {
            return (int)a + (int)b; 
        }

        static string connect(string a, string b)
        {
            return a + b;
        }

        //消框
        static string connect(object a, object b)
        {
            return (string)a + (string)b;
        }
    }
}
