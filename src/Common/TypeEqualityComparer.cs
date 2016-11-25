using System.Collections.Generic;

namespace Common
{
    internal class TypeEqualityComparer : IEqualityComparer<object>
    {
        bool IEqualityComparer<object>.Equals(object x, object y)
        {
            return x.GetType() == y.GetType();
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }
    }
}