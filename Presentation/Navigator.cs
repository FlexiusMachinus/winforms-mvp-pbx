using System;

namespace DB_CourseWork.Presentation
{
    public class Navigator : INavigator
    {
        private readonly IPresenterFactory _presenterFactory;

        public Navigator(IPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory;
        }

        public void Run<T>() where T : class, IPresenter => Run(typeof(T));
        public void Run<T, U>(U arg) where T : class, IPresenter<U> => Run(typeof(T), arg);

        public void Run(Type presenterType)
        {
            if (!typeof(IPresenter).IsAssignableFrom(presenterType))
            {
                throw new ArgumentException("Presenter type must implement IPresenter interface.");
            }

            IPresenter presenter = _presenterFactory.Create(presenterType);
            presenter.Run();
        }

        public void Run<T>(Type presenterType, T arg)
        {
            if (!typeof(IPresenter<T>).IsAssignableFrom(presenterType))
            {
                throw new ArgumentException($"Presenter type must implement IPresenter<{typeof(T)}> interface.");
            }

            IPresenter<T> presenter = _presenterFactory.Create<T>(presenterType);
            presenter.Run(arg);
        }
    }
}
