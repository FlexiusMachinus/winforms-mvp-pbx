using System;
using DB_CourseWork.Presentation;
using Microsoft.Extensions.DependencyInjection;

namespace DB_CourseWork.UI
{
    public class PresenterProvider : IPresenterFactory
    {
        private readonly IServiceProvider _serviceProvider;

        // This class uses a service provider in order to resolve dependencies of presenters.
        // An instance of this class is created only once in the composition root, and it only
        // allows to create presenters (for navigation purposes), so it is not a service locator.
        public PresenterProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPresenter Create(Type presenterType)
        {
            var presenter = _serviceProvider.GetRequiredService(presenterType) as IPresenter;
            return presenter;
        }

        public IPresenter<T> Create<T>(Type presenterType)
        {
            var presenter = _serviceProvider.GetRequiredService(presenterType) as IPresenter<T>;
            return presenter;
        }
    }
}
