using System;

namespace DB_CourseWork.Presentation
{
    public interface INavigator
    {
        void Run<T>() where T : class, IPresenter;
        void Run<T, U>(U arg) where T : class, IPresenter<U>;
        void Run(Type presenterType);
        void Run<T>(Type presenterType, T arg);
    }
}
