using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 有序數組
{
    class LinkedList1<E>
    {
        private class Node
        {
            public E e;
            public Node next;
            public Node(E e,Node next)
            {
                this.e = e;
                this.next = next;
            }
            public Node(E e) : this(e, null)
            {

            }
            public override string ToString()
            {
                return this.e.ToString();
            }
        }
        private Node head;
        private int N;
        public LinkedList1()
        {
            this.head = null;
            this.N = 0;
        }
        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }
        public void Add(int index,E e)
        {
            if (index < 0 || index > N)
                throw new ArgumentException("索引越界");
            if (index == 0)
            {
                //Node newNode = new Node(e);
                //newNode.next = this.head;
                //this.head = newNode;

                this.head = new Node(e, this.head);
                N++;
            }
            else
            {
                Node pre = this.head;
                for (int i = 0; i < index - 1; i++)
                    pre = pre.next;
                //Node newNode = new Node(e);
                //newNode.next = pre.next;
                //pre.next = newNode;
                pre.next = new Node(e, pre.next);
                N++;
            }            
        }
        public void AddFirst(E e)
        {
            Add(0, e);
        }
        public void AddLast(E e)
        {
            this.Add(N, e);
        }
        public void RemoveE(E e)
        {
            if (IsEmpty)
                return;
            if(e.Equals(this.head.e))
            {
                N--;
                this.head = this.head.next;
            }
            else
            {
                Node pre = null;
                Node cur = this.head;
                while (cur != null)
                {
                    if (e.Equals(cur.e))
                        break;
                    pre = cur;
                    cur = cur.next;
                }
                if (cur != null)
                {
                    N--;
                    pre.next = pre.next.next;
                }
            }
        }
        //public void RemoveE(E e)
        //{
        //    Node pre = null;
        //    Node cur = this.head;
        //    while (cur != null)
        //    {
        //        if (e.Equals(cur.e))
        //            break;
        //        pre = cur;
        //        cur = cur.next;
        //    }
        //    if (cur!=null&&e.Equals(cur.e))
        //    {
        //        N--;
        //        if (pre == null)
        //            this.head = this.head.next;
        //        else                
        //            pre.next = pre.next.next;                
        //    }
        //}
        public E Remove(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("索引越界");
            N--;
            if (index == 0)
            {
                Node ret = this.head;
                this.head = this.head.next;
                return ret.e;
            }
            else
            {
                Node pre = this.head;
                for (int i = 0; i < index - 1; i++)
                    pre = pre.next;
                Node ret = pre.next;
                pre.next = pre.next.next;
                return ret.e;
            }
        }
        public E RemoveFirst()
        {
            return Remove(0);
        }
        public E RemoveLast()
        {
            return Remove(N - 1);
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            Node cur = this.head;
            while (cur != null)
            {
                builder.Append($"{cur}=>");
                cur = cur.next;
            }
            builder.Append("Null");
            return builder.ToString();
        }
        public E Get(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("索引越界");
            Node cur = this.head;
            for (int i = 0; i < index; i++)
                cur = cur.next;
            return cur.e;            
        }
        public E GetFirst()
        {
            return Get(0);
        }
        public E GetLast()
        {
            return Get(N - 1);
        }
    }
}
