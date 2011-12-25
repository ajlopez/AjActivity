using System;
using System.Collections.Generic;
namespace AjActivity.Collections
{
    public interface ITreeListNode<T>
    {
        ITreeListNode<T> Add(T element);

        ushort Size { get; }

        ushort Level { get; }

        IEnumerable<T> Elements { get; }

        bool IsFull { get; }
    }
}
