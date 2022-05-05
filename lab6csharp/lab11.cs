using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6csharp
{
    internal class lab11
    {
        private int[,,] minWayMatrix;
        private int[,] WayMatrix;
        private static int inf = int.MaxValue;

        public static void FloydWayMatrix(lab10 lab10Matrix, int[,] weightMatrix)
        {
            int n = lab10Matrix.GetN();
            int[,,] matrix = new int[n + 1, n + 1, n + 1];
            for (int k = 1; k < n + 1; k++)
            {
                for (int i = 1; i < n + 1; i++)
                {
                    for (int j = 1; j < n + 1; j++)
                    {
                        matrix[k, i, j] = weightMatrix[i, j];
                    }
                }
                //nice 
            }



            int[,] W = new int[n + 1, n + 1];
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    if (i == j)
                    {
                        W[i, j] = 0;
                    }
                    else
                    {
                        W[i, j] = 1;
                    }
                }
            }

            for (int k = 2; k < n - 1; k++)
            {
                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j < n; j++)
                    {
                        if (matrix[k - 1, i, k] != inf && matrix[k - 1, k, j] != inf)
                        {
                            if ((matrix[k - 1, i, k] + matrix[k - 1, k, j]) < matrix[k - 1, i, j]) // da v mene na kompi micro poletiv (((
                            {
                                matrix[k, i, j] = (matrix[k - 1, i, k] + matrix[k - 1, k, j]);
                                W[i, j] = k;
                            }
                        }
                        else
                        {
                            matrix[k, i, j] = matrix[k - 1, i, j];
                            int x = 1;
                        }
                    }
                }
                for (int z = 1; z < n - 1; z++)
                {
                    for (int x = 1; x < n - 1; x++)
                    {
                        Console.WriteLine("K: " + k);
                        Console.WriteLine(matrix[k, z, x]);
                    }
                }
            }
        }
    }
}
