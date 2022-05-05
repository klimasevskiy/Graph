using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6csharp
{
    internal class GraphStat
    {
        public static int[,] FindArc(SumMatrix sMatrix, int[,] matrix)
        {
            int n = sMatrix.GetN();
            int m = sMatrix.GetM();

            int arcOut = 0;
            int arcIn = 0;

            int[,] result = new int[n + 1, 3];

            for(int i = 1; i < n + 1; i++)
            {
                arcOut = 0;
                arcIn = 0;
                for(int j = 1; j < n + 1; j++)
                {
                    if(matrix[i, j] == 1)
                    {
                        arcOut += matrix[i, j];
                        arcIn += matrix[j, i];
                    }
                }
                result[i, 0] = i;
                result[i, 1] = arcOut;
                result[i, 2] = arcIn;
            }
            return result;
        }

        public static int isHomogeneous(SumMatrix sMatrix, int[,] arcMatrix)
        {
            for(int i = 1; i < sMatrix.GetN(); i++)
            {
                if((i + 1) < sMatrix.GetN())
                {
                    if(!(arcMatrix[i, 1] == arcMatrix[i+1, 1]))
                    {
                        return 0;
                    }

                    if(!(arcMatrix[i, 2] == arcMatrix[i + 1, 2]))
                    {
                        return 0;
                    }
                }
            }
            return arcMatrix[1, 1];
        }

        public static void isIsolated(SumMatrix sMatrix, int[,] arcMatrix)
        {
            bool isolated = false;
            for(int i = 1; i < sMatrix.GetN() + 1; i++)
            {
                if(arcMatrix[i, 1] == 0 && arcMatrix[i, 2] == 0)
                {
                    Console.WriteLine($"{i, 2} is isolated");
                    isolated = true;
                }
            }
            if(!isolated)
            {
                Console.WriteLine("there is no isolated tops");
            }
        }

        public static void isHanging(SumMatrix sMatrix, int[,] arcMatrix)
        {
            bool hanging = false;
            for (int i = 1; i < sMatrix.GetN() + 1; i++)
            {
                if (arcMatrix[i, 1] == 1 && arcMatrix[i, 2] == 0)
                {
                    Console.WriteLine($"{i,2} is hanging");
                    hanging = true;
                }
            }
            if (!hanging)
            {
                Console.WriteLine("there is no hanging tops");
            }
        }
    }
}
