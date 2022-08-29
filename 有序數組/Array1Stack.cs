using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 有序數組
{
    class Array1Stack<E>:IStack<E>
    {
        private Array1<E> array1;
        public Array1Stack(int capacity)
        {
            this.array1 = new Array1<E>(capacity);
        }
        public Array1Stack() : this(10)
        {

        }
        public int Count { get { return this.array1.Count; } }

        public bool IsEmpty { get { return this.array1.IsEmpty; } }
        public bool Contains(E e)
        {
            return array1.Contains(e);
        }

        public void Push(E e)
        {
            this.array1.AddLast(e);
        }

        public E Pop()
        {
            return this.array1.RemoveLast();
        }

        public E Peek()
        {
            return array1.GetLast();
        }
    }
}
