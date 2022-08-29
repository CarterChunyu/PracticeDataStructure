using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 有序數組
{
    interface ISet<E>
    {
        int Count { get; }
        bool IsEmpty { get; }
        bool Contains(E e);
        void Add(E e);
        void Remove(E e);
    }
}
