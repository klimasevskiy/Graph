using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6csharp
{
    internal class DFS
    {
        string[,] result = null;
        int n = 0;
        public string[,] Search(SumMatrix sMatrix, int[,] matrix, int point)
        {
            Stack<int> stack = new Stack<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();

            this.n = sMatrix.GetN();

            String[,] Table = new string[n * 2 + 1, 3];

            dict.Add(point, 1);
            stack.Push(point);
            Table[1, 0] = stack.Peek().ToString();
            Table[1, 1] = 1.ToString();
            string joinedString = String.Join(",", stack);
            Table[1, 2] = joinedString;

            int numeration = 2;
            bool isFind = false;
            int top;

            for (int r = 2; stack.Count > 0; r++)
            {
                top = stack.Peek();
                isFind = false;
                for (int i = 1; i < n + 1; i++)
                {
                    if (matrix[top, i] == 1 && top != i)
                    {
                        if (!dict.ContainsKey(i))
                        {
                            dict.Add(i, numeration);
                            numeration++;
                            stack.Push(i);
                            Table[r, 0] = i.ToString();
                            Table[r, 1] = numeration.ToString();
                            isFind = true;
                            break;
                        }
                    }
                }

                if(!isFind)
                {
                    Table[r, 0] = "-";
                    Table[r, 1] = "-";
                    stack.Pop();
                }
                joinedString = String.Join(",", stack);
                Table[r, 2] = joinedString;
            }
            this.result = Table;
            return Table;
         }

        public void PrintTable()
        {
            for(int i = 0; i < this.n * 2 + 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{this.result[i, j],20}");
                }
                Console.WriteLine();
            }
        }
    }
}
