using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 有序數組
{
    class Array2<E>
    {
        private E[] data;
        private int N;
        private int first;
        private int last;

        public Array2(int capacity)
        {
            this.data = new E[capacity];
            this.N = 0;
            this.first = 0;
            this.last = 0;
        }
        public Array2() : this(10)
        {

        }
        public int Count { get { return N; } }
        public bool IsEmpty { get { return N == 0; } }
        private void ResetCapacity(int capacity)
        {
            E[] newData = new E[capacity];
            int index = this.first;
            for (int i = 0; i <N;i++)        
                newData[i] = this.data[(first + i) % this.data.Length];
            this.data = newData;
            this.first = 0;
            this.last = N;
        }
        public void AddLast(E e) // AddLast
        {
            if (N == this.data.Length)
                ResetCapacity(this.data.Length * 2);
            this.data[last] = e;
            N++;
            this.last = (this.last + 1) % this.data.Length;
        }
        public E RemoveFisrt()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空數組");
            E del = this.data[first];
            this.data[first] = default(E);
            first = (first + 1) % this.data.Length;
            N--;
            if (N == 0)
            {
                this.first = 0;
                this.last = 0;
            }
            if (this.N == this.data.Length / 4)
                ResetCapacity(this.data.Length / 2);
            return del;
        }
        public E GetFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException("空數組");
            return this.data[0];
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"N:{N} Capacity{this.data.Length} {Environment.NewLine}");
            for (int i = 0; i < N; i++)
            {
                //int index = (first + i) % this.data.Length;
                //builder.Append(this.data[index]);
                //if ((index + 1) % this.data.Length != last)
                //    builder.Append(",");
                builder.Append(this.data[(first + i) % this.data.Length]);
                if ((first + i + 1) % this.data.Length != last)
                    builder.Append(",");
            }
            return builder.ToString();
        }
    }
}
