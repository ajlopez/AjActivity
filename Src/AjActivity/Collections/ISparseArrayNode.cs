namespace AjActivity.Collections
{
    using System;

    public interface ISparseArrayNode<T>
    {
        T GetValue(ulong position);
        ISparseArrayNode<T> SetValue(ulong position, T value);
    }
}
