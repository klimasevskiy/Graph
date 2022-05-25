using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
  internal class FloydPathMatrix
    { 
      public FloydPathMatrix(WeightMatrix w, int[,] weightMatrix)
        {
            int n = w.getN();
            int[,,] A = new int[n + 1, n + 1, n + 1];
            int[,] P = createPathMatrix(n);

            for(int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    A[0, i, j] = weightMatrix[i, j];
                }
            } 

            for (int k = 1; k <= n; k++)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if (A[k - 1, i, k] != int.MaxValue && A[k - 1, k, j] != int.MaxValue)
                        {
                            if (A[k-1, i ,k] + A[k - 1,k, j] < A[k - 1, i, j])
                            {
                                A[k, i, j] = A[k - 1, i, k] + A[k - 1, k, j];
                                P[i, j] = k;
                            }
                            else
                            {
                                A[k, i, j] = A[k - 1, i, j];
                            }
                        } 
                        else
                        {
                            A[k, i, j] = A[k - 1, i, j];
                        }
                    }
                }
                Console.WriteLine();
                printMatrix(A, n, k);
            }
            Console.WriteLine();
            Console.WriteLine("Path matrix:");
            printPathMatrix(P, n);
        }
       
        private int[,] createPathMatrix(int n)
        {
            int[,] T = new int[n + 1, n + 1];
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i == j)
                    {
                        T[i, j] = 0;
                    }
                    else
                    {
                        T[i, j] = i;
                    }
                }
            }
            return T;
        }

        public static void printPathMatrix(int[,] matrix, int n)
        {
            Console.Write("   |");
            for (int j = 1; j < n + 1; j++)
            {
                Console.Write($"{j,2} |");
            }
            Console.WriteLine();

            for (int i = 1; i < n + 1; i++)
            {
                Console.Write($"{i,2} |");
                for (int j = 1; j < n + 1; j++)
                {
                    if (matrix[i, j] == int.MaxValue)
                    {
                        Console.Write(" - |");
                    }
                    else
                        Console.Write($"{matrix[i, j],2} |");
                }
                Console.WriteLine();
            }
        }

        public static void printMatrix(int[,,] matrix, int n, int k)
        {
            Console.Write("   |");
            for (int j = 1; j < n + 1; j++)
            {
                Console.Write($"{j,2} |");
            }
            Console.WriteLine();

            for (int i = 1; i < n + 1; i++)
            {
                Console.Write($"{i,2} |");
                for (int j = 1; j < n + 1; j++)
                {
                    if (matrix[k, i, j] == int.MaxValue)
                    {
                        Console.Write(" - |");
                    }
                    else
                        Console.Write($"{matrix[k, i, j],2} |");
                }
                Console.WriteLine();
            }
        }
    }
}
// 11