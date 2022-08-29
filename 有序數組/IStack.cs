using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 有序數組
{
    interface IStack<E>
    {
        void Push(E e);
        E Pop();
        E Peek();
        int Count { get; }
        bool IsEmpty { get; }
    }
}
