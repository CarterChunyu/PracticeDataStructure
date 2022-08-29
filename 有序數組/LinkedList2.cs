using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 有序數組
{
    class LinkedList2<E>
    {
        private class Node
        {
            public E e;
            public Node Next;
            public Node(E e,Node next)
            {
                this.e = e;
                this.Next = next;
            }
            public Node(E e) : this(e, null)
            {

            }
            public override string ToString()
            {
                return e.ToString();
            }
        }
        private int N;
        private Node head;
        private Node tail;

      
        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }
        public void AddLast(E e)
        {
            if (IsEmpty)
            {
                Node node = new Node(e);
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.tail.Next = new Node(e);
                this.tail = this.tail.Next;
            }
            N++;
        }
        public E RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空鍊表");          
            Node del = this.head;
            if (N == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else            
                this.head = this.head.Next;
            return del.e;
        }
        public bool Contains(E e)
        {
            Node cur = this.head;
            while (cur != null)
            {
                if (e.Equals(cur.e))
                    return true;
            }
            return false;
        }
        public E GetFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空鍊表");
            return this.head.e;
        }
    }
}
