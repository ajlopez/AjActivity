using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjActivity.Collections
{
    public class TreeList<T>
    {
        private long count;

        public void Add(T element)
        {
            count++;
        }

        public long Count { get { return this.count; } }
    }
}
