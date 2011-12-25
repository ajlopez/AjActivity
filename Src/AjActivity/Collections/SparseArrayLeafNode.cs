namespace AjActivity.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SparseArrayLeafNode<T> : ISparseArrayNode<T>
    {
        private ulong from;
        private ushort size;
        private T[] values;

        public SparseArrayLeafNode(ulong index)
            : this(index, 256)
        {
        }

        public SparseArrayLeafNode(ulong index, ushort size)
        {
            this.from = index - (index % size);
            this.size = size;
            this.values = new T[size];
        }

        public ISparseArrayNode<T> SetValue(ulong position, T value)
        {
            if (this.from <= position && position <= this.from + (ushort) (this.size-1))
            {
                this.values[position - this.from] = value;
                return this;
            }

            SparseArrayNode<T> parent = new SparseArrayNode<T>(position, 1, this.size);

            parent.SetSlot(this.from, this);

            return parent.SetValue(position, value);
        }

        public T GetValue(ulong position)
        {
            return this.values[position - this.from];
        }
    }
}

