using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class DeixtraMatrix
    {
        int[] minPath;
        int[] minWeight;

        public DeixtraMatrix(WeightMatrix wMatrix, int[,] weightMatrix)
        {
            for (int i = 1; i <= wMatrix.getN(); i++)
            {
                for (int j = 1; j <= wMatrix.getN(); j++)
                {
                    if (weightMatrix[i, j] < 0)
                    {
                        throw new Exception("Matrix element must be more that zero!");
                    }
                }
            }
            findTops(wMatrix, weightMatrix, 1);
            Console.WriteLine("Weight: ");
            printVector(minWeight);
            Console.WriteLine("Path: ");
            printVector(minPath);
        }
        private void findTops(WeightMatrix wMatrix, int[,] weightMatrix, int a)
        {
            HashSet<int> M = new HashSet<int>();
            int[] T = new int[wMatrix.getN() + 1];
            int[] P = new int[wMatrix.getN() + 1];

            M.Add(a);
            T[a] = 0;

            for (int i = 1; i < wMatrix.getN() + 1; i++)
            {
                P[i] = 0;
                if (i != a)
                {
                    T[i] = int.MaxValue;
                }
            }

            int x = a;
            for (int i = 1; i < wMatrix.getN() + 1; i++)
            {
                for (int v = 1; v < wMatrix.getN() + 1; v++)
                {
                    if (weightMatrix[x, v] > 0 && weightMatrix[x, v] != int.MaxValue)
                    {
                        if (!M.Contains(v))
                        {
                            if (T[v] > (T[x] + weightMatrix[x, v]))
                            {
                                T[v] = (T[x] + weightMatrix[x, v]);
                                P[v] = x;
                            }
                        }
                    }
                }

                int minWeight = int.MaxValue;
                int minTop = 0;
                for (int v = 1; v < wMatrix.getN() + 1; v++)
                {
                    if (!M.Contains(v))
                    {
                        if (T[v] < minWeight)
                        {
                            minWeight = T[v];
                            minTop = v;
                        }
                    }
                }
                M.Add(minTop);
                this.minWeight = T;
                this.minPath = P;
                x = minTop;
            }
        }

        public void printVector(int[] V)
        {
            for (int i = 1; i < V.Length; i++)
            {
                if (V[i] == int.MaxValue)
                {
                    Console.Write("{V" + i + ": " + "-" + "} ");
                }
                else
                {
                    Console.Write("{V" + i + ": " + V[i] + "} ");
                }
            }
            Console.WriteLine();
        }
    }
}
