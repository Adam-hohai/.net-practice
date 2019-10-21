using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 矩阵
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array1 = new int[2, 4] { { -1, 2, 3, 9 }, { 5, 6, 7, 8 } };
            int[,] array2 = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            int[,] array3 = new int[2, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8, } };
            int[,] absarray, multarray;
            
            matrix m1 = new matrix(array1);
            matrix m2 = new matrix(array2);
            matrix m3 = new matrix(array3);

            //打印
            Console.WriteLine("数组1");
            m1.printarray();
            Console.WriteLine();
            Console.WriteLine("数组2");
            m2.printarray();
            Console.WriteLine();
            Console.WriteLine("数组3");
            m3.printarray();
            Console.WriteLine();

            //转置
            Console.WriteLine("数组1转置");
            int[,] tr = new int[m1.arraytr().GetLength(0), m1.arraytr().GetLength(1)];
            for (int i = 0; i < tr.GetLength(0); i++)
            {
                for (int j = 0; j < tr.GetLength(1); j++)
                {
                    tr[i, j] = m1.arraytr()[i, j];
                    Console.Write(tr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //max
            Console.WriteLine("数组1最大");
            Console.WriteLine("最大值是{0}", m1.Max());
            Console.WriteLine();

            //min
            Console.WriteLine("数组1最小");
            Console.WriteLine("最小值是{0}", m1.Min());
            Console.WriteLine();

            //平均值测试
            Console.WriteLine("数组1平均值");
            matrix.average(array1);
            Console.WriteLine("平均值" + matrix.avgdata);
            Console.WriteLine();

            //鞍点判断
            Console.WriteLine("数组1鞍点");
            if (m1.saddle() != null)
                 {
                     Console.WriteLine("鞍点" + m1.saddle());
                 }
            else
                 Console.WriteLine("无鞍点");
            Console.WriteLine();

            //绝对值测试
            Console.WriteLine("数组1绝对值");
            matrix.abs(array1);
            absarray = matrix.absdata;
            for (int i = 0; i < absarray.GetLength(0); i++)
            {
                for (int j = 0; j < absarray.GetLength(1); j++)
                {
                    Console.Write("{0} ", absarray[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //叉乘测试
            Console.WriteLine("1和2叉乘");
            matrix.multiply(array1, array2);
            multarray = matrix.multdata;
            for (int i = 0; i < multarray.GetLength(0); i++)
            {
                for (int j = 0; j < multarray.GetLength(1); j++)
                {
                    Console.Write("{0} ", multarray[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //运算符重载测试
            Console.WriteLine("1和3相加");
            matrix m4 = m1 + m3;
            m4.printarray();
            Console.WriteLine();

            Console.WriteLine("1和3点乘");
            matrix m5 = m1 * m3;
            m5.printarray();
            Console.WriteLine();

            Console.ReadKey();
        }
    }

    class matrix
    {
        int[,] data;
        public static int[,] absdata, multdata;
        public static float avgdata;
        public matrix(int[,] array)
        {
            data = new int[array.GetLength(0), array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    data[i, j] = array[i, j];
                }
            }
        }

        /**
         * 打印**/
        public void printarray()
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    Console.Write("{0} ", data[i, j]);
                }
                Console.WriteLine();
            }
        }

        /**
         * 转置**/
        public int[,] arraytr()
        {
            int[,] temp = new int[data.GetLength(1), data.GetLength(0)];
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    temp[i, j] = data[j, i];
                }
            }
            return temp;
        }

        /**
         * 求矩阵最大值**/
        public int Max()
        {
            int max = data[0, 0];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (data[i, j] > max)
                    {
                        max = data[i, j];
                    }
                }
            }

            return max;
        }

        /**
         * 求矩阵最小值**/
        public int Min()
        {
            int min = data[0, 0];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (data[i, j] < min)
                    {
                        min = data[i, j];
                    }
                }
            }

            return min;
        }

        /**
         * 求矩阵鞍点
         * 先求一行最大再在此列中比较**/
        public string saddle()
        {
            string point = null;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                int rowmax = data[i, 0];
                int column = 0;
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (data[i, j] > rowmax)
                    {
                        rowmax = data[i, j];
                        column = j;
                    }
                }
                for (int k = 0; k < data.GetLength(0); k++)
                {

                    if (data[k, column] < rowmax)
                    {
                        point = null;
                        break;
                    }
                    point = Convert.ToString(rowmax);
                }
                if (point != null)
                    break;
            }
            return point;
        }

        /**
         * 求矩阵绝对值
         * 要求静态实现**/
        public static void abs(int[,] array)
        {
            absdata = new int[array.GetLength(0), array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    absdata[i, j] = Math.Abs(array[i, j]);
                }
            }
        }

        /**
         * 求矩阵平均值
         * 静态实现**/
        public static void average(int[,] array)
        {
            float sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += array[i, j];
                }
            }
            avgdata = sum / (array.GetLength(0) * array.GetLength(1));
        }

        /**
         * 实现矩阵叉乘
         * 静态实现**/
        public static void multiply(int[,] array1, int[,] array2)
        {
            //判断两个矩阵是否满足条件
            if (array1.GetLength(1) != array2.GetLength(0))
                return;
            multdata = new int[array1.GetLength(0), array2.GetLength(1)];
            for (int i = 0; i < multdata.GetLength(0); i++)
            {
                for (int j = 0; j < multdata.GetLength(1); j++)
                {
                    for (int k = 0; k < array1.GetLength(1); k++)
                    {
                        multdata[i, j] += array1[i, k] * array2[k, j];
                    }
                }
            }
        }

        /**
         * 运算符*重载,参数必须是类的引用
         * 矩阵点乘**/
        public static matrix operator *(matrix a, matrix b)
        {
            int[,] c = new int[a.data.GetLength(0), a.data.GetLength(1)];
            matrix m = new matrix(c);
            if ((a.data.GetLength(0) == b.data.GetLength(0) && a.data.GetLength(1) == b.data.GetLength(1)) == false)
                return m;
            for (int i = 0; i < m.data.GetLength(0); i++)
            {
                for (int j = 0; j < m.data.GetLength(1); j++)
                {
                    m.data[i, j] = a.data[i, j] * b.data[i, j];
                }
            }
            return m;
        }

        /**
         * 运算符+重载
         * 矩阵相加**/
        public static matrix operator +(matrix a, matrix b)
        {
            int[,] c = new int[a.data.GetLength(0), a.data.GetLength(1)];
            matrix m = new matrix(c);
            if ((a.data.GetLength(0) == b.data.GetLength(0) && a.data.GetLength(1) == b.data.GetLength(1)) == false)
                return m;
            for (int i = 0; i < m.data.GetLength(0); i++)
            {
                for (int j = 0; j < m.data.GetLength(1); j++)
                {
                    m.data[i, j] = a.data[i, j] + b.data[i, j];
                }
            }
            return m;
        }
    }
}
