namespace AjActivity.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SparseArray<T>
    {
        private ISparseArrayNode<T> root;
        private ushort size;

        public SparseArray()
            : this(256)
        {
        }

        public SparseArray(ushort size)
        {
            this.size = size;
        }

        public T this[ulong index]
        {
            get
            {
                if (this.root == null)
                    return default(T);

                return this.root.GetValue(index);
            }

            set
            {
                if (this.root == null)
                    this.root = new SparseArrayLeafNode<T>(index, this.size);

                this.root = this.root.SetValue(index, value);
            }
        }
    }
}
