using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6csharp
{
    internal class IncidentMatrix
    {
        private int[,] matrix = null;
        private int n = 0;
        private int m = 0;

        public int[,] createMatrix(Graph graph, int[,] matrix)
        {
            int[] T = fillUp(graph.GetN());
            this.n = graph.GetN();
            this.m = graph.GetM();
            

            int[,] result = new int [graph.GetN() + 1, graph.GetM() + 1];
            
            for (int i = 1; i < graph.GetN() + 1; i++)
            {
                for(int j = 1; j < graph.GetM() + 1; j++)
                {
                    int v = matrix[j, 0];
                    int u = matrix[j, 1];

                    if(T[i] == v && v == u)
                    {
                        result[i, j] = 2;
                    }
                    else if(T[i] == v)
                    {
                        result[i, j] = 1;
                    }
                    else if(T[i] == u)
                    {
                        result[i, j] = - 1;
                    }
                    else
                    {
                        result[i, j] = 0;
                    }
                }
            }
            return result;
        }

        public int[] fillUp(int n)
        {
            int[] V = new int[n + 1];
            for(int i = 1; i < n + 1; i++)
            {
                V[i] = i;
            }
            return V;
        }

        public static void printMatrix(int[,] matrix, Graph graph)
        {
            Console.Write("   |");
            for (int j = 1; j < graph.GetM() + 1; j++)
            {
                Console.Write($"{j,2} |");
            }
            Console.WriteLine();
            for (int i = 1; i < graph.GetN() + 1; i++)
            {
                Console.Write($"{i,2} |");
                for (int j = 1; j < graph.GetM() + 1; j++)
                {
                    Console.Write($"{matrix[i, j],2} |");
                }
                Console.WriteLine();
            }
        }
        public int GetN()
        {
            return this.n;
        }
        public int GetM()
        {
            return this.m;
        }

        public int[,] GetMatrix()
        {
            return this.matrix;
        }

    }
}
