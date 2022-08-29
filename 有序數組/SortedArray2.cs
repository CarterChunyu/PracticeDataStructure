using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 有序數組
{
    class SortedArray2<Key,Value> where Key:IComparable<Key>
    {
        private Key[] keys;
        private Value[] values;
        private int N;
        public SortedArray2(int capacity)
        {
            this.keys = new Key[capacity];
            this.values = new Value[capacity];
            this.N = 0;
        }
        public SortedArray2() : this(10)
        {

        }
        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }
        public int Rank(Key key)
        {
            int l = 0;
            int r = N - 1;
            while (l <= r)
            {
                int mid = (r - l) / 2 + l;
                if (key.CompareTo(keys[mid]) == 0)
                    return mid;
                else if (key.CompareTo(keys[mid]) < 0)
                    r = mid - 1;
                else //key.CompareTo(keys[mid])>0
                    l = mid + 1;
            }
            return l;
        }
        private void ResetCapacity(int capacity)
        {
            Key[] newKeys = new Key[capacity];
            Value[] newValues = new Value[capacity];
            for (int i = 0; i < N; i++)
            {
                newKeys[i] = keys[i];
                newValues[i] = values[i];
            }
            this.keys = newKeys;
            this.values = newValues;
        }
        public void Add(Key key,Value value)
        {
            int index = Rank(key);
            if(index==N||key.CompareTo(keys[index])<0)
            {
                if (this.N == this.keys.Length)
                    ResetCapacity(this.keys.Length * 2);
                for (int i = N - 1; i >= index; i--)
                {
                    keys[i + 1] = keys[i];
                    values[i + 1] = values[i];
                }
                keys[index] = key;
                values[index] = value;
                N++;
            }
        }
        public void Remove(Key key)
        {
            int index = Rank(key);
            if(index<N&&key.CompareTo(keys[index])==0)
            {
                for (int i = index; i <N-1 ; i++)
                {
                    keys[i] = keys[i + 1];
                    values[i] = values[i + 1];
                }
                keys[N - 1] = default(Key);
                values[N - 1] = default(Value);
                N--;
                if (this.N == this.keys.Length / 4)
                    ResetCapacity(this.keys.Length / 2);

            }
        }
        public bool Contains(Key key)
        {
            int index = Rank(key);
            if (index < N && key.CompareTo(keys[index]) == 0)
                return true;
            return false;
        }
        public Value Select(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("非法索引");
            return values[index];
        }
        public Value Min()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空數組");
            return values[0];
        }
        public Value Max()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空數組");
            return values[N - 1];
        }
        public Value Floor(Key key)
        {
            int index = Rank(key);
            if (index < N && key.CompareTo(keys[index]) == 0)
                return values[index];
            if (index == 0)
                throw new ArgumentException("非法索引");
            return values[index];
        }
        public Value Ceiling(Key key)
        {
            int index = Rank(key);
            if (index < N)
                return values[index];
            throw new ArgumentException("非法索引");
        }
        public Value Get(Key key)
        {
            int index = Rank(key);
            if (index < N && key.CompareTo(keys[index]) == 0)
                return values[index];
            throw new ArgumentException("非法索引");
        }
        public void Set(Key key,Value value)
        {
            int index = Rank(key);
            if (index < N && key.CompareTo(keys[index]) == 0)
                values[index] = value;
            else
                throw new ArgumentException("非法索引");
        }
    }
}
