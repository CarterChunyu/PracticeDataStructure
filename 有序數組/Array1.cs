using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 有序數組
{
    class Array1<E>
    {
        private E[] data;
        private int N;

        public Array1(int capacity)
        {
            this.data = new E[capacity];
            this.N = 0;
        }
        public Array1() : this(10)
        {

        }
        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }
        private void ResetCapacity(int capacity)
        {
            E[] newData = new E[capacity];
            for (int i = 0; i < N; i++)
                newData[i] = this.data[i];
            this.data = newData;            
        }
        public void Add(int index,E e)
        {
            if (index < 0 || index > N)
                throw new ArgumentException("非法索引");
            if (N == this.data.Length)
                ResetCapacity(this.data.Length * 2);
            for (int i = N - 1; i >= index; i++)
                this.data[i + 1] = this.data[i];
            this.data[index] = e;
            N++;           
        }
        public void AddFirst(E e)
        {
            Add(0, e);
        }
        public void AddLast(E e)
        {
            Add(N, e);
        }
        public void RemoveE(E e)
        {
            int index = -1;
            for (int i = 0; i < N; i++)
            {
                if (e.Equals(this.data[i]))
                    index = i;
            }
            if (index != -1)
            {
                for (int i = index; i < N-1; i++)                
                    this.data[i] = this.data[i + 1];
                this.data[N-1] = default(E);
                N--;
            }
        }
        public E Remove(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("非法索引");
            E ret = this.data[index];
            for (int i = index; i < N - 1; i++)
                this.data[i] = this.data[i + 1];
            this.data[N - 1] = default(E);
            N--;
            if (N == this.data.Length / 4)
                ResetCapacity(this.data.Length / 2);
            return ret;
        }
        public E RemoveFirst()
        {
            return Remove(0);
        }
        public E RemoveLast()
        {
            return Remove(N - 1);
        }
        public bool Contains(E e)
        {
            for (int i = 0; i < N; i++)
            {
                if (e.Equals(this.data[i]))
                    return true;
            }
            return false;
        }
        public E Get(int index)
        {
            if (index < 0 || index >= N)
                throw new ArgumentException("索引越界");
            return this.data[index];
        }
        public E GetFirst()
        {
            return Get(0);
        }
        public E GetLast()
        {
            return Get(N - 1);
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"N: {this.N} Capacity: {this.data.Length} {Environment.NewLine}");
            for (int i = 0; i < N; i++)
            {
                builder.Append($"{this.data[i]}");
                if (i < N - 1)
                    builder.Append(",");
            }
            return builder.ToString();
        }
    }
}
