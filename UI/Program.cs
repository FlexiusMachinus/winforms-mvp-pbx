using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using DB_CourseWork.Core;
using DB_CourseWork.Core.Data;
using DB_CourseWork.Presentation;

namespace DB_CourseWork.UI
{
    internal static class Program
    {
        private static readonly ApplicationContext _context = new ApplicationContext();

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var provider = services.BuildServiceProvider())
            {
                var presenter = ActivatorUtilities.CreateInstance<PaymentPresenter>(provider);
                presenter.Run();
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services
                .AddSingleton(sp => sp)
                .AddSingleton(_context)
                //.AddPbxTriggers()
                .AddScoped<PbxContext>()
                .AddScoped<IPresenterFactory, PresenterProvider>()
                .AddScoped<INavigator, Navigator>()
                .AddTransient<ISubscriberPhoneService, SubscriberPhoneService>()
                .AddTransient<IPhoneStatusService, PhoneStatusService>()
                .AddTransient<IPaymentService, PaymentService>()
                .AddTransient<IReportService, ReportService>()
                .AddTransient<IFeeService, FeeService>()
                .AddTransient<ReportPresenter>()
                .AddTransient<CheckFeesPresenter>()
                .AddTransient<AddPaymentPresenter>()
                .AddTransient<IPaymentView, PaymentForm>()
                .AddTransient<IReportView, ReportForm>()
                .AddTransient<ICheckFeesView, CheckFeesForm>()
                .AddTransient<IAddPaymentView, AddPaymentForm>();
        }
    }
}
