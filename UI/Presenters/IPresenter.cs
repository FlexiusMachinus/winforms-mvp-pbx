using System;

namespace DB_CourseWork
{
    public interface IPresenter
    {
        void Run();
    }

    public interface IPresenter<T>
    {
        void Run(T arg);
    }
}
