using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace краскал
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader T = new StreamReader("1.txt");
            int a = Convert.ToInt32(T.ReadLine());
            int[,] A = new int[a, 2];
            int b = Convert.ToInt32(T.ReadLine());
            int[,] B = new int[b, 4];
            for (int i = 0; i < a; i++) { A[i, 0] = i + 1; }
            for (int i = 0; i < b; i++)
            {
                B[i, 0] = Convert.ToInt32(T.ReadLine());
                B[i, 1] = Convert.ToInt32(T.ReadLine());
                B[i, 2] = Convert.ToInt32(T.ReadLine());
                Console.Clear();
            }
            int sum = 0; int x = 1000; int n = 0; int p = 0; int max; int min;
            for (int h = 0; h < a - 1; h++)
            {
                x = 1000;
                for (int i = 0; i < b; i++)
                {
                    if ((x > B[i, 2]) && (B[i, 3] != 1) && (A[B[i, 0] - 1, 1] != A[B[i, 1] - 1, 1]))
                    {
                        x = B[i, 2];
                        n = i;

                    }
                }
                B[n, 3] = 1;
                if (A[B[n, 0] - 1, 1] + A[B[n, 1] - 1, 1] == 0)
                {
                    p++;
                    A[B[n, 0] - 1, 1] = p;
                    A[B[n, 1] - 1, 1] = p;
                }
                else
                {
                    max = Math.Max(A[B[n, 0] - 1, 1], A[B[n, 1] - 1, 1]);
                    min = Math.Min(A[B[n, 0] - 1, 1], A[B[n, 1] - 1, 1]);
                    if (min != 0)
                    {
                        for (int t = 0; t < a; t++)
                        {
                            if (A[t, 1] == min)
                            {
                                A[t, 1] = max;
                            }
                        }
                    }
                    else
                    {
                        A[B[n, 0] - 1, 1] = max;
                        A[B[n, 1] - 1, 1] = max;
                    }
                }
            }
            for (int i = 0; i < b; i++)
            {
                if (B[i, 3] == 1) { sum = sum + B[i, 2]; }
            }
            for (int i = 0; i < b; i++)
            {
                if (B[i, 3] == 1)
                {
                    Console.WriteLine("{0}-{1}", B[i, 0], B[i, 1]);
                }
            }
            Console.WriteLine(sum);
        }
    }
}
