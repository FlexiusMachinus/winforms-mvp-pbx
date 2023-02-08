using System;

namespace DB_CourseWork
{
    public interface INavigator
    {
        void Run<T>() where T : class, IPresenter;
        void Run<T, U>(U arg) where T : class, IPresenter<U>;
    }
}
