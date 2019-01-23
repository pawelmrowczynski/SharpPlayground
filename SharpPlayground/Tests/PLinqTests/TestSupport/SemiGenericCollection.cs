//#define NORMAL_LINQ

using System;
using System.Collections;
using System.Collections.Generic;

namespace PLinqTests
{
    internal class SemiGenericCollection : ICollection, IEnumerable<int>
    {
        private List<int> list;

        public SemiGenericCollection()
        {
            this.list = new List<int>();
        }

        public SemiGenericCollection(IEnumerable<int> items)
        {
            this.list = new List<int>(items);
        }

        public int Count => list.Count;

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void CopyTo(Array array, int index)
        {
            ((ICollection)list).CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}