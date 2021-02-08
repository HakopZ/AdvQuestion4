using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvQuestion5
{
    public class Rectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Rectangle(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public static class Program
    {
        static bool CheckFit(Rectangle rec1, Rectangle rec2) => rec1.X < rec2.X && rec1.Y < rec2.Y;
        static int HowManyFit(List<Rectangle> envelopes)
        {
            envelopes.Sort((f1, f2) => f1.X == f2.X ? f1.Y.CompareTo(f2.Y) : f1.X.CompareTo(f2.X));

            return 0;
        }
        //Memoized Solution(A little better than factorial, don't know O(?)
        static int HowManyFitNaiveish(List<Rectangle> envelopes)
        {
            envelopes.Sort((f1, f2) => f1.X == f2.X ? f1.Y.CompareTo(f2.Y) : f1.X.CompareTo(f2.X));
            return Recurse(envelopes, 0, new int[envelopes.Count]);
        }
        static int Recurse(List<Rectangle> envelopes, int index, int[] memoized)
        {
            if (memoized[index] > 0)
            {
                return memoized[index];
            }
            if (index == envelopes.Count - 1)
            {
                memoized[index] = 1;
                return 1;
            }
            int max = 1;
            for (int i = index + 1; i < envelopes.Count; i++)
            {

                max = Math.Max(max, Recurse(envelopes, i, memoized) + (CheckFit(envelopes[index], envelopes[i]) ? 1 : 0));
                memoized[index] = max;
            }
            return max;

        }
        //O(n^2) solution???
        public static int MaxEnvelopes(List<Rectangle> envelopes)
        {
            if (envelopes.Count == 0) return 0;
            if (envelopes.Count == 1) return 1;
            envelopes.Sort((f1, f2) => f1.X == f2.X ? f1.Y.CompareTo(f2.Y) : f1.X.CompareTo(f2.X));
            int[] d = new int[envelopes.Count];
            d[0] = 1;
            for (int i = 1; i < envelopes.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (CheckFit(envelopes[j], envelopes[i]))
                    {
                        if (d[j] + 1 > d[i])
                        {
                            d[i] = d[j] + 1;
                        }
                    }
                }
            }
            return d.Max();

        }

        

        static void Main(string[] args)
        {
            List<Rectangle> temp = new List<Rectangle>()
            {
                new Rectangle(50, 50),
                new Rectangle(25, 50),
                new Rectangle(20, 18),
                new Rectangle(15, 5)
            };
            Console.WriteLine(MaxEnvelopes(temp));
            Console.ReadKey();
        }
    }
}
