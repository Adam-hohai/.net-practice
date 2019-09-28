using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp课后作业3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("输入字符串:");
            string a = Console.ReadLine();
            Console.Write("删除单词:");
            string b = Console.ReadLine();
            int c = a.IndexOf(b);
            a = a.Remove(c, b.Length);
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
