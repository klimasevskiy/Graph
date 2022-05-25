using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class GraphColor
    {
        Dictionary<int, int> colorsDict = new Dictionary<int, int>();
        public Dictionary<int, int> getColorsDict()
        {
            return colorsDict;
        }
        public GraphColor(sMatrix matrix)
        {
            ColorGraph(matrix);
        }
        public void ColorGraph(sMatrix matrix)
        {
            Queue<int> tops = SortDeg(matrix);
            Dictionary<int, int> colors = new Dictionary<int, int>();
            
            int[,] sumMatrix = matrix.GetMatrix();

            int color = 0;
            while(tops.Count != 0)
            {
                color++;
                int top = tops.Dequeue();
                colors.Add(top, color);
            
                bool canBeColored;
                foreach(int elem in tops)
                {
                    canBeColored = true;
                    foreach(int e in colors.Keys)
                    {
                        if (colors[e] == color)
                        {
                            if (sumMatrix[elem, e] == 1 || sumMatrix[e, elem] == 1)
                            {
                                canBeColored = false;
                                //break;
                            }
                        }
                    }
                    if(canBeColored)
                    {
                        //Console.WriteLine("Elem:" + elem + "Color:" + color);
                        colors.Add(elem, color);
                        tops = new Queue<int>(tops.Where(x => x != elem));
                    }
                }
            }
            var colorsDict = colors.ToLookup(x => x.Value, x => x.Key).Where(x => x.Count() > 0);
            foreach (var item in colorsDict)
            {
                var keys = item.Aggregate("", (s, v) => s + ", " + v);
                var message = "The following tops have the color " + item.Key + ":" + keys;
                Console.WriteLine(message);
            }
        }
        public Queue<int> SortDeg(sMatrix matrix)
        {
            CharchactGraf stat = new CharchactGraf();
            Queue<int> queue = new Queue<int>();

            int[,] degs = CharchactGraf.FindInnerAndOut(matrix);

            int[,] deg = new int[matrix.GetN() + 1, 2];

            for (int i = 1; i < matrix.GetN() + 1; i++)
            {
                deg[i, 0] = i;
                deg[i, 1] = degs[i, 1] + degs[i, 2];
            }

            while (queue.Count() != matrix.GetN())
            {
                int max = -1;
                int maxTop = 0;

                for (int i = 1; i < matrix.GetN()+1; i++)
                {
                    if (!queue.Contains(i))
                    {
                        if (deg[i, 1] > max)
                        {
                            maxTop = deg[i, 0];
                            max = deg[i, 1];
                        }
                    }

                }
                if (maxTop != 0)
                {
                    queue.Enqueue(maxTop);
                }
            }
            return queue;
        }
    }
}