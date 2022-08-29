using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 有序數組
{
    class SortedArrayDictionary<Key, Value> : IDictionary<Key, Value> where Key : IComparable<Key>
    {
        private SortedArray2<Key, Value> sortedArray2;
        public SortedArrayDictionary(int capacity)
        {
            this.sortedArray2 = new SortedArray2<Key, Value>(capacity);
        }
        public SortedArrayDictionary() : this(10)
        {

        }
        public int Count { get { return this.sortedArray2.Count; } }

        public bool IsEmpty { get { return this.sortedArray2.IsEmpty; } }

        public void Add(Key key, Value value)
        {
            this.sortedArray2.Add(key, value);
        }

        public bool Contais(Key key)
        {
            return sortedArray2.Contains(key);
        }

        public Value Get(Key key)
        {
            return sortedArray2.Get(key);
        }

        public void Remove(Key key)
        {
            sortedArray2.Remove(key);
        }

        public void Set(Key key, Value value)
        {
            sortedArray2.Set(key, value);
        }
    }
}
