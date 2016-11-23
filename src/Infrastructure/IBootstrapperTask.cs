using System;

namespace Infrastructure
{
    public interface IBootstrapperTask<in T>
    {
        Action<T> Task { get; }
    }
}