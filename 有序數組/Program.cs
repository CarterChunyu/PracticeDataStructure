using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace 有序數組
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array1Queue<int> a1 = new Array1Queue<int>();
            //Console.WriteLine(TestQueue(a1));

            //Array2Queue<int> a2 = new Array2Queue<int>();
            //Console.WriteLine(TestQueue(a2));

            //LinkedList1Queue<int> l1 = new LinkedList1Queue<int>();
            //Console.WriteLine(TestQueue(l1));

            LinkedList2Queue<int> l2 = new LinkedList2Queue<int>();
            Console.WriteLine(TestQueue(l2));

        }
        static long TestStack(IStack<int> stack)
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            for (int i = 0; i < 100000; i++)
                stack.Push(i);
            for (int i = 0; i < 100000; i++)
                stack.Pop();
            t.Stop();
            return t.ElapsedMilliseconds; 
        }
        static long TestQueue(IQueue<int> queue)
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            for (int i = 0; i < 100000; i++)
                queue.Enqueue(i);
            for (int i = 0; i < 100000; i++)
                queue.Dequeue();
            t.Stop();
            return t.ElapsedMilliseconds;           
        }   
    }
    class SetTest
    {
        public static long TestSet(ISet<string> set,List<string> words)
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            foreach (var word in words)
            {
                set.Add(word);
            }
            t.Stop();
            return t.ElapsedMilliseconds;
        }
    }
    class DictionayTest
    {
        public static long TestDictionary(IDictionary<string,int> dic,List<string> words)
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            foreach (var word in words)
            {
                if (!dic.Contais(word))
                    dic.Add(word, 1);
                else
                    dic.Set(word, dic.Get(word) + 1);
            }
            t.Stop();
            return t.ElapsedMilliseconds;
        }
    }
}
