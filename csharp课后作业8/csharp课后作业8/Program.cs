using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp课后作业8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[, ,] array = new int[,,] { { { 1, 2 }, { 1, 2 } }, { { 1, 2 }, { 1, 2 } }, { { 1, 2 }, { 1, 2 } } };
            Console.WriteLine("第一页第一行第一列和第二页第二行第二列相加为{0}", add(array[0, 0, 0], array[1, 1, 1]));
            Console.WriteLine("第一页第一行第一列和第二页第二行第二列和第三页第二行第二列相加为{0}", add(array[0, 0, 0], array[1, 1, 1], array[2, 1, 1]));
            Console.ReadKey();
        }

        static int add(params int[] num)
        {
            int sum = 0;
            foreach (int i in num)
                sum += i;
            return sum;
        }
    }
}
