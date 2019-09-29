using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp课后作业4
{
    class Program
    {
        static string[] array = new string[] { "12", "2233", "34", "35", "325" };
        static void Main(string[] args)
        {
            foreach (string s in array)
            {
                Console.Write("{0} ", s);
            }
            Console.Write("\n1,插入内容：");
            string input1 = Console.ReadLine();
            string[] array2 = add(input1);
            foreach (string s in array2)
            {
                Console.Write("{0} ", s);
            }

            Console.Write("\n2,删除内容：");
            string input2 = Console.ReadLine();
            string[] array3 = remove(input2);
            foreach (string s in array3)
            {
                Console.Write("{0} ", s);
            }

            Console.Write("\n3,修改内容:");
            string input3 = Console.ReadLine();
            string[] input3_split = input3.Split(' ');
            string[] array4 = update(input3_split[0], input3_split[1]);
            foreach (string s in array4)
            {
                Console.Write("{0} ", s);
            }

            Console.Write("\n4,查找内容：");
            string input4 = Console.ReadLine();
            int index = select(input4);
            Console.WriteLine("第{0}个", index + 1);

            Console.ReadKey();
        }

        static string[] add(string s1)
        {
            string[] s2 = new string[array.Length + 1];
            for (int i = 0; i < array.Length; i++ )
            {
                s2[i] = array[i];
            }
            s2[array.Length] = s1;
            return s2;
        }

        static string[] remove(string s1)
        {
            List<string> l = new List<string>();
            foreach(string s in array)
                l.Add(s);
            l.Remove(s1);
            string[] s2 = new string[array.Length - 1];
            for(int i = 0; i < s2.Length; i++)
                s2[i] = l[i];
            return s2;
        }

        static string[] update(string s1, string s2)
        {
            string[] s3 = new string[array.Length];
            int index = Array.IndexOf(array, s1);
            for (int i = 0; i < index; i++)
                s3[i] = array[i];
            s3[index] = s2;
            for (int i = index + 1; i < s3.Length; i++)
                s3[i] = array[i];
            return s3;
        }

        static int select(string s1)
        {
            int index = Array.IndexOf(array, s1);
            return index;
        }
    }
}
