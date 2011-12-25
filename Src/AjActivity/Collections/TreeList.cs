using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace AjActivity.Collections
{
    public class TreeList<T> : IEnumerable<T>
    {
        private long count;
        private ITreeListNode<T> root;

        public void Add(T element)
        {
            if (this.root == null)
            {
                this.root = new TreeListLeafNode<T>();
            }

            this.root = this.root.Add(element);
            count++;
        }

        public long Count { get { return this.count; } }

        public IEnumerator<T> GetEnumerator()
        {
            return this.root.Elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
