using System;
using Microsoft.Extensions.DependencyInjection;

namespace DB_CourseWork
{
    public class Navigator : INavigator
    {
        private readonly IServiceProvider _provider;

        public Navigator(IServiceProvider serviceProvider)
        {
            _provider = serviceProvider;
        }

        public void Run<T>() where T : class, IPresenter => Run(typeof(T));
        public void Run<T, U>(U arg) where T : class, IPresenter<U> => Run(typeof(T), arg);

        public void Run(Type presenterType)
        {
            if (!typeof(IPresenter).IsAssignableFrom(presenterType))
            {
                throw new ArgumentException("Presenter type must implement IPresenter interface.");
            }

            var presenter = ActivatorUtilities.CreateInstance(_provider, presenterType) as IPresenter;
            presenter.Run();
        }

        public void Run<T>(Type presenterType, T arg)
        {
            if (!typeof(IPresenter<T>).IsAssignableFrom(presenterType))
            {
                throw new ArgumentException($"Presenter type must implement IPresenter<{typeof(T)}> interface.");
            }

            var presenter = ActivatorUtilities.CreateInstance(_provider, presenterType) as IPresenter<T>;
            presenter.Run(arg);
        }
    }
}
