using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 有序數組
{
    class SortedArray1Set<E> : ISet<E> where E : IComparable<E>
    {
        private SortedArray1<E> SortedArray1;
        public SortedArray1Set(int capacity)
        {
            SortedArray1 = new SortedArray1<E>(capacity);
        }
        public SortedArray1Set() : this(10)
        {

        }
        public int Count { get { return this.SortedArray1.Count; } }
        public bool IsEmpty { get { return this.SortedArray1.IsEmpty; } }

        public void Add(E e)
        {
            this.SortedArray1.Add(e);
        }

        public bool Contains(E e)
        {
            return SortedArray1.Contains(e);
        }

        public void Remove(E e)
        {
            SortedArray1.Remove(e);
        }
    }
}
