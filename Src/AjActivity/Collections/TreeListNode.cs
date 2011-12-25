using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace AjActivity.Collections
{
    public class TreeListNode<T> : ITreeListNode<T>
    {
        private ushort count;
        private ushort size;
        private ushort level;
        private ITreeListNode<T>[] subnodes;

        public TreeListNode()
            : this(256, 1)
        {
        }

        public TreeListNode(ITreeListNode<T> firstchild)
            : this(firstchild.Size, (ushort) (firstchild.Level + 1))
        {
            this.subnodes[this.count++] = firstchild;
        }

        public TreeListNode(ushort size, ushort level)
        {
            this.size = size;
            this.count = 0;
            this.level = level;

            if (level == 1)
                this.subnodes = new TreeListLeafNode<T>[size];
            else
                this.subnodes = new TreeListNode<T>[size];
        }

        public ushort Size { get { return this.size; } }

        public ushort Level { get { return this.level; } }

        public bool IsFull { get { return this.size == this.count; } }

        public IEnumerable<T> Elements
        {
            get {
                for (int k = 0; k < this.count; k++)
                    foreach (var element in this.subnodes[k].Elements)
                        yield return element;
            }
        }

        public ITreeListNode<T> Add(T element)
        {
            if (this.count == 0 || this.subnodes[this.count - 1].IsFull)
            {
                if (this.count == this.size)
                {
                    TreeListNode<T> parent = new TreeListNode<T>(this);

                    return parent.Add(element);
                }

                if (this.level == 1)
                    this.subnodes[this.count++] = new TreeListLeafNode<T>(this.size);
                else
                    this.subnodes[this.count++] = new TreeListNode<T>(this.size, (ushort)(this.level - 1));
            }

            this.subnodes[this.count-1].Add(element);
            return this;
        }
    }
}

