namespace AjActivity.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SparseArrayNode<T> : ISparseArrayNode<T>
    {
        private ulong from;
        private ulong to;
        private ulong modulo;
        private ushort size;
        private ushort level;

        private ISparseArrayNode<T>[] subnodes;

        public SparseArrayNode(ulong value)
            : this(value, 1, 256)
        {
        }

        public SparseArrayNode(ulong value, ushort level, ushort size)
        {
            this.level = level;
            this.size = size;

            this.modulo = size;

            for (ushort k = 0; k < level; k++)
                this.modulo = this.modulo * size;

            this.from = value - (value % this.modulo);
            this.to = this.from + (this.modulo - 1);

            if (level == 1)
                subnodes = new SparseArrayLeafNode<T>[size];
            else
                subnodes = new SparseArrayNode<T>[size];
        }

        public ISparseArrayNode<T> SetValue(ulong position, T value)
        {
            if (this.from <= position && position <= this.to)
            {
                ushort nslot = this.GetSlotPosition(position);
                if (this.subnodes[nslot] == null)
                    if (this.level == 1)
                        this.subnodes[nslot] = new SparseArrayLeafNode<T>(position, this.size);
                    else
                        this.subnodes[nslot] = new SparseArrayNode<T>(position, (ushort) (this.level - 1), this.size);

                this.subnodes[nslot].SetValue(position, value);
                return this;
            }

            ISparseArrayNode<T> parent = new SparseArrayNode<T>(position, (ushort) (this.level + 1), this.size);

            return parent.SetValue(position, value);
        }

        public T GetValue(ulong position)
        {
            ushort nslot = this.GetSlotPosition(position);

            if (this.subnodes[nslot] == null)
                return default(T);

            return this.subnodes[nslot].GetValue(position);
        }

        internal void SetSlot(ulong position, ISparseArrayNode<T> subnode)
        {
            this.subnodes[this.GetSlotPosition(position)] = subnode;
        }

        private ushort GetSlotPosition(ulong position)
        {
            return (ushort)((position - this.from) / (this.modulo / this.size));
        }
    }
}

