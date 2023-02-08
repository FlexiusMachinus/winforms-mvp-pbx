using System;
using DB_CourseWork.Presentation;
using Microsoft.Extensions.DependencyInjection;

namespace DB_CourseWork.UI
{
    public class PresenterProvider : IPresenterFactory
    {
        private readonly IServiceProvider _serviceProvider;

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
