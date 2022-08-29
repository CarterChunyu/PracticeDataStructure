using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 有序數組
{
    class SortedArray1<Key> where Key:IComparable<Key>
    {
        private Key[] keys;
        private int N;

        public SortedArray1(int capacity)
        {
            this.keys = new Key[capacity];
            this.N = 0;
        }
        public SortedArray1() : this(10)
        {

        }
        public int Count { get { return this.N; } }
        public bool IsEmpty { get { return N == 0; } }

        public int Rank(Key key)
        {
            int l = 0;
            int r = N-1;
            while (l <= r)
            {
                int mid = (r - l) / 2 + l;
                if (key.CompareTo(keys[mid]) == 0)
                    return mid;
                else if (key.CompareTo(keys[mid]) < 0)
                    r = mid - 1;
                else // key.CompareTo(keys[mid])>0
                    l = mid + 1;
            }
            return l;
        }
        public void Add(Key key)
        {
            int index = Rank(key);
            // 索引不在陣列內 
            if (index >= N || key.CompareTo(keys[index]) != 0)
            {
                if (this.N == this.keys.Length)
                    ResetCapacity(2 * this.keys.Length);
                for (int i = N-1; i >= index; i--)                
                    keys[i + 1] = keys[i];
                keys[index] = key;
                N++;
            }            
        }
        private void ResetCapacity(int capacity)
        {
            Key[] newKeys = new Key[capacity];
            for (int i = 0; i < N; i++)
                newKeys[i] = keys[i];
            this.keys = newKeys;
        }

        public void Remove(Key key)
        {
            int index = Rank(key);
            if(index<N&&key.CompareTo(keys[index])==0)
            {
                for (int i = index; i < N-1; i++)
                    keys[i] = keys[i + 1];
                keys[N - 1] = default(Key);
                N--;
                if (this.N == this.keys.Length / 4)
                    ResetCapacity(this.keys.Length / 2);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"N: {this.N} Capacity:{this.keys.Length} {Environment.NewLine}");
            for (int i = 0; i < N; i++)
            {
                builder.Append(keys[i]);
                if (i < N - 1)
                    builder.Append(",");
            }
            return builder.ToString();
        }
        public bool Contains(Key key)
        {
            int index = Rank(key);
            if (index < N && key.CompareTo(keys[index]) == 0)
                return true;
            return false;
        }
        public Key Select(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("索引越界");
            return keys[index];
        }
        public Key Max()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空數組");
            return keys[N-1];
        }
        public Key Min()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空數組");
            return keys[0];
        }

        public Key Floor(Key key)
        {
            int index = Rank(key);
            if (index < N || key.CompareTo(keys[index]) == 0)
                return keys[index];
            if (index == 0)
                throw new ArgumentException("非法索引");
            return keys[index-1];
        }
        public Key Ceiling(Key key)
        {
            int index = Rank(key);
            if (index < N)
                return keys[index];
            throw new ArgumentException("非法索引");
        }



     
    }
}
