using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class WeightMatrix
    {
        private int[,] matrix;
        private int n = 0; 
        private int m = 0; 
        int inf = int.MaxValue;

        public int[,] getMatrix() 
        {
            return this.matrix; 
        }

        public int[,] CreateMatrix(FileService file, int[,] result) 
        {
            int[] V = fillTops(file.GetN());
            this.n = file.GetN(); 
            this.m = file.GetM(); 

            int inf = int.MaxValue;

            int iter = 0;   

            int[,] matrix = new int[n + 1, n + 1];  

            bool isEqual = false;  
            for (int i = 1; i < n + 1; i++)  
            {
                for (int j = 1; j < n + 1; j++)  
                {
                    isEqual = false; 
                    int[] T = { V[i], V[j] };   
                    for (int l = 1; l < m + 1; l++) 
                    {
                        if ((T[0] == result[l, 0]) && (T[1] == result[l, 1])) 
                        {
                            isEqual = true;  
                            iter = l;  
                            break;  
                        }
                    }
                    if (isEqual)  
                    {
                        matrix[i, j] = result[iter, 2];  
                    }
                    else if (i == j) 
                    {
                        matrix[i, j] = 0;  
                    }
                    else
                    {
                        matrix[i, j] = inf; 
                    }
                }
            }
            this.matrix = matrix;  
            return matrix;  
        }

        public int[] fillTops(int n)  
        {
            int[] V = new int[n + 1];  
            for (int i = 1; i < n + 1; i++)  
            {
                V[i] = i;  
            }
            return V;  
        }

        public static void printMatrix(int[,] matrix, FileService file)
        {
            Console.Write("   |");
            for (int j = 1; j < file.GetN() + 1; j++)
            {
                Console.Write($"{j,2} |");
            }
            Console.WriteLine();
            for (int i = 1; i < file.GetN() + 1; i++)
            {
                Console.Write($"{i,2} |");
                for (int j = 1; j < file.GetN() + 1; j++)
                {
                    if (matrix[i, j] == int.MaxValue )
                    {
                        Console.Write(" x |");
                    }
                    else
                        Console.Write($"{matrix[i, j],2} |");
                }
                Console.WriteLine();
            }
        }

        public int getN()
        {
            return this.n;
        }
    }
}

// 10