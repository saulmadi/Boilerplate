using System;

namespace Infrastructure
{
    public interface IBootstrapperTask<in T>
    {
        void Task(T configuration);
    }
}