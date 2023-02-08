using System;

namespace DB_CourseWork.Presentation
{
    public interface IPresenterFactory
    {
        IPresenter Create(Type presenterType);
        IPresenter<T> Create<T>(Type presenterType);
    }
}
