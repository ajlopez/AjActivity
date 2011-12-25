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
        private ushort nodesize;
        private ITreeListNode<T> root;

        public TreeList()
            : this(256)
        {
        }

        public TreeList(ushort nodesize)
        {
            this.nodesize = nodesize;
        }

        public void Add(T element)
        {
            if (this.root == null)
            {
                this.root = new TreeListLeafNode<T>(this.nodesize);
            }

            this.root = this.root.Add(element);
            count++;
        }

        public long Count { get { return this.count; } }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.root == null)
            {
                this.root = new TreeListLeafNode<T>(this.nodesize);
            }

            return this.root.Elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
