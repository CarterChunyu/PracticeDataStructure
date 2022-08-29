using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 有序數組
{
    interface IDictionary<Key,Value>
    {
        int Count { get; }
        bool IsEmpty { get; }
        void Add(Key key, Value value);
        void Remove(Key key);
        bool Contais(Key key);
        Value Get(Key key);
        void Set(Key key, Value value);
    }
}
