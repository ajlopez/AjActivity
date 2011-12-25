namespace AjActivity.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SparseArray<T>
    {
        ISparseArrayNode<T> root;

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
                    this.root = new SparseArrayLeafNode<T>(index);

                this.root = this.root.SetValue(index, value);
            }
        }
    }
}
