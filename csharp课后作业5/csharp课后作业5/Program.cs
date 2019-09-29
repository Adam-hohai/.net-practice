using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp课后作业5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Console.Write("输入整型数组：");
            string input1 = Console.ReadLine();
            string[] input_split = input1.Split(' ');
            foreach (string s in input_split)
            {
                int a = Convert.ToInt32(s);
                list.Add(a);
            }
            foreach (int i in list)
                Console.Write("{0} ", i);
            
            Console.Write("\n1,增加:");
            string input2 = Console.ReadLine();
            list.Add(Convert.ToInt32(input2));
            foreach (int i in list)
                Console.Write("{0} ", i);

            Console.Write("\n2,删除：");
            string input3 = Console.ReadLine();
            list.Remove(Convert.ToInt32(input3));
            foreach (int i in list)
                Console.Write("{0} ", i);

            Console.Write("\n3,修改:");
            string input4 = Console.ReadLine();
            string[] input4_split = input4.Split(' ');
            list.Remove(Convert.ToInt32(input4_split[0]));
            list.Add(Convert.ToInt32(input4_split[1]));
            foreach (int i in list)
                Console.Write("{0} ", i);

            Console.Write("\n4,查找：");
            string input5 = Console.ReadLine();
            int result = list.IndexOf(Convert.ToInt32(input5));
            Console.WriteLine("第{0}个", result + 1);

            Console.ReadKey();
        }
    }
}
