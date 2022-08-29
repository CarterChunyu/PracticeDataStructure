using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 有序數組
{
    class LinkedList1Stack<E> : IStack<E>
    {
        private LinkedList1<E> l;
        public LinkedList1Stack()
        {
            this.l = new LinkedList1<E>();
        }
        public int Count { get { return l.Count; } }

        public bool IsEmpty { get { return l.IsEmpty; } }

        public E Peek()
        {
            return l.GetFirst();
        }

        public E Pop()
        {
            return l.RemoveLast();
        }

        public void Push(E e)
        {
            l.AddFirst(e);
        }
    }
}
