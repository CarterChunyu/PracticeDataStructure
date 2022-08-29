using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 有序數組
{
    class LinkedList1Queue<E> : IQueue<E>
    {
        private LinkedList1<E> l;
        public LinkedList1Queue()
        {
            this.l = new LinkedList1<E>();
        }
        public int Count { get { return l.Count; } }

        public bool IsEmpty { get { return l.IsEmpty; } }

        public E Dequeue()
        {
            return l.RemoveFirst();
        }

        public void Enqueue(E e)
        {
            l.AddLast(e);
        }

        public E Peek()
        {
            return l.GetFirst();
        }
    }
}
