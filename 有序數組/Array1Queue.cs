using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 有序數組
{
    class Array1Queue<E> : IQueue<E>
    {
        private Array1<E> array1;
        public Array1Queue(int capacity)
        {
            this.array1 = new Array1<E>(capacity);
        }
        public Array1Queue() : this(10)
        {

        }
        public int Count { get { return array1.Count; } }

        public bool IsEmpty { get { return array1.IsEmpty; } }

        public E Dequeue()
        {
            return array1.RemoveFirst();
        }

        public void Enqueue(E e)
        {
            array1.AddLast(e);
        }

        public E Peek()
        {
            return array1.GetFirst();
        }
    }
}
