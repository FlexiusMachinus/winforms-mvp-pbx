using System;

namespace DB_CourseWork.Presentation
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
