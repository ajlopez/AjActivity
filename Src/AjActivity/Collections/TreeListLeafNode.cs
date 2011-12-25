namespace AjActivity.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;

    public class TreeListLeafNode<T> : ITreeListNode<T>
    {
        private ushort size;
        private ushort count;
        private T[] values;

        public TreeListLeafNode()
            : this(256)
        {
        }

        public TreeListLeafNode(ushort size)
        {
            this.count = 0;
            this.size = size;
            this.values = new T[size];
        }

        public ushort Size { get { return this.size; } }

        public ushort Level { get { return 0; } }

        public IEnumerable<T> Elements
        {
            get
            {
                for (int k = 0; k < this.count; k++)
                    yield return this.values[k];
            }
        }

        public bool IsFull { get { return this.size == this.count; } }

        public ITreeListNode<T> Add(T element)
        {
            if (this.count < this.size)
            {
                this.values[this.count++] = element;
                return this;
            }

            TreeListNode<T> parent = new TreeListNode<T>(this);

            return parent.Add(element);
        }
    }
}

