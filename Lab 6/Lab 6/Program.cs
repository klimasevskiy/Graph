using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Program
    {
        public static void Main(String[] args)
        {
            
             FileService f = new FileService();
              //int[,] result = f.ReadFile();
            /*
             iMatrix matrix = new iMatrix();
              int[,] IMatrix = matrix.createMatrix(f, result);
              iMatrix.printMatrix(IMatrix, f);
              f.WriteFileIncident(IMatrix);

              Console.WriteLine("\n");
            
              sMatrix sMatrix = new sMatrix();
              int[,] SumMatrix = sMatrix.CreateMatrix(f, result);
              sMatrix.printMatrix(SumMatrix, f);
              f.WriteFileSumij(SumMatrix);
              Console.WriteLine("\n");
              int[,] degs = CharchactGraf.FindInnerAndOut(sMatrix);

              for (int i = 1; i < f.GetN() + 1; i++)
              {
                  for (int j = 0; j < 3; j++)
                  {
                      Console.Write(degs[i, j] + " ");
                  }
                  Console.WriteLine();
          }
             */


            //   CharchactGraf.isVisyacha(sMatrix, degs);  // 7
            //   CharchactGraf.isIsolated(sMatrix, degs);  // 7



            //    DFS dfs = new DFS();  // 8
            //    dfs.Search(sMatrix, 4);
            //   dfs.PrintResult();

            //  Console.WriteLine();

            //   BFS bfs = new BFS();  // 9
            //  bfs.Search(sMatrix, 4);
            //   bfs.PrintResult();



            /* 10
                WeightMatrix w = new WeightMatrix();
                int[,] lab10graph = f.ReadFileWeight();
                int[,] lab10 = w.CreateMatrix(f, lab10graph);
                WeightMatrix.printMatrix(lab10, f);
            10*/


            /* 11
            Console.WriteLine();
            FloydPathMatrix floidlab11 = new FloydPathMatrix(w, lab10);
            // 11 */

            /* 12
            Console.WriteLine();
            DeixtraMatrix floidlab12 = new DeixtraMatrix(w,lab10);
            12*/

            //13
            int[,] WeightGraph = f.ReadFileWeight();

            sMatrix sMatrix = new sMatrix();
            int[,] SumMatrix = sMatrix.CreateMatrix(f, WeightGraph);
            sMatrix.printMatrix(SumMatrix, f);
            Console.WriteLine();

            GraphColor graphColor = new GraphColor(sMatrix);
            //13
            Console.WriteLine("____________________________________________________________");
            //14
            int[,] result = f.ReadFileRelations();
            int[,] matrix = sMatrix.CreateMatrix(f, result);
            sMatrix.printMatrix(matrix, f);
            Relations.printResult(sMatrix);
            //14


            Console.ReadKey();
        }
        
    }

}