using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Relations
    {
        private class Reflexive
        {
            public static bool isReflexive(sMatrix s)
            {
                int[,] matrix = s.GetMatrix();
                bool result = true;
                for (int i = 1; i < s.GetN() + 1; i++)
                {
                    if (matrix[i, i] == 0)
                    {
                        result = false;
                        break;
                    }
                }
                return result;
            }
        }
        private class Asymetric
        {
            private static int[,] Transpose(sMatrix s)
            {
                int[,] a = s.GetMatrix();
                int tmp = 0;
                for (int i = 1; i < s.GetN(); i++)
                {
                    for (int j = 1; j < i; j++)
                    {
                        tmp = a[i, j];
                        a[i, j] = a[j, i];
                        a[j, i] = tmp;
                    }
                }
                return a;
            }
            public static bool isAsymetric(sMatrix s)
            {
                bool result = false;
                int[,] matrix = s.GetMatrix();

                for (int i = 1; i < s.GetN() + 1; i++)
                {
                    for (int j = 1; j < s.GetN(); j++)
                    {
                        if (matrix[i, j] != matrix[j, i])
                        {
                            result = true;
                            break;
                        }
                    }
                }
                return result;
            }
        }


        public static void printResult(sMatrix s)
        {
            Console.WriteLine("Is Reflexive? " + Reflexive.isReflexive(s));
            Console.WriteLine("Is Asymetric? " + Asymetric.isAsymetric(s));
        }
    }
}
