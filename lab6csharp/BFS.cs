using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6csharp
{
    internal class BFS
    {
        string[,] result = null;
        int n = 0;
        public string[,] Search(SumMatrix sMatrix, int[,] matrix, int point)
        {
            Queue<int> queue = new Queue<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();

            this.n = sMatrix.GetN();

            String[,] Table = new string[n * 2 + 1, 3];

            dict.Add(point, 1);
            queue.Enqueue(point);
            Table[1, 0] = queue.Peek().ToString();
            Table[1, 1] = 1.ToString();
            string joinedString = String.Join(",", queue);
            Table[1, 2] = joinedString;

            int numeration = 2;
            bool isFind = false;
            int top;

            for (int r = 2; queue.Count > 0; r++)
            {
                top = queue.Peek();
                isFind = false;
                for (int i = 1; i < n + 1; i++)
                {
                    if (matrix[top, i] == 1 && top != i)
                    {
                        if (!dict.ContainsKey(i))
                        {
                            dict.Add(i, numeration);
                            numeration++;
                            queue.Enqueue(i);
                            Table[r, 0] = i.ToString();
                            Table[r, 1] = numeration.ToString();
                            isFind = true;
                            break;
                        }
                    }
                }

                if (!isFind)
                {
                    Table[r, 0] = "-";
                    Table[r, 1] = "-";
                    queue.Dequeue();
                }
                joinedString = String.Join(",", queue);
                Table[r, 2] = joinedString;
            }
            this.result = Table;
            return Table;
        }

        public void PrintTable()
        {
            for (int i = 0; i < this.n * 2 + 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{this.result[i, j], 20}");
                }
                Console.WriteLine();
            }
        }
    }
}
