using System.IO;
using System;

namespace lab6csharp
{
    internal class Program
    {
        public static void Main(String[] args)
        {
            Graph g = new Graph();
            int[,] result = g.ReadFile();

            Console.WriteLine("___LAB 10___");
            lab10 w = new lab10();
            int[,] WeightGraph = g.ReadFileLab10();
            int[,] weightMatrix = w.CreateMatrix(g, WeightGraph);
            lab10.printMatrix(weightMatrix, g);

            Console.WriteLine("\n___LAB 11___");
            Console.WriteLine();
            lab11 floidlab11 = new lab11(w, weightMatrix);

            Console.WriteLine("\n___LAB 12___");
            Console.WriteLine();
            lab12 deixtraMatrix = new lab12(w, weightMatrix);
        }
    }
}
