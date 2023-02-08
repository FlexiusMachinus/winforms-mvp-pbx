using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity.Validation;
using System.ComponentModel;

namespace DB_CourseWork
{
    public class PaymentPresenter : IPresenter
    {
        private readonly IPaymentView _view;
        private readonly IPaymentService _paymentService;
        private readonly INavigator _navigator;

        public PaymentPresenter(IPaymentView view, IPaymentService paymentService, INavigator navigator)
        {
            _view = view;
            _paymentService = paymentService;
            _navigator = navigator;

            _view.Exit += OnExit;
            _view.SaveChanges += OnSaveChanges;
            _view.AddPayment += OnAddPayment;
            _view.DeletePayments += OnDeletePayments;
            _view.CreateReport += OnCreateReport;
            _view.CheckFees += OnCheckFees;

            BindDataSources();
        }

        public void BindDataSources()
        {
            _view.PaymentsDataSource = _paymentService.GetAllPayments();
            _view.PhonesDataSource = _paymentService.GetAllSubscriberPhones();
        }

        public void Run()
        {
            _view.Show();
        }

        public void OnDeletePayments(object sender, EventArgs e)
        {
            IEnumerable<int> ids = _view.SelectedPayments;
            if (ids.Any() && _view.ConfirmDelete())
            {
                _paymentService.RemovePaymentsByIds(ids);
            }
        }

        public void OnSaveChanges(object sender, EventArgs e)
        {
            TrySaveChanges();
        }

        public void OnExit(object sender, CancelEventArgs e)
        {
            if (_paymentService.CheckChanges())
            {
                bool? result = _view.ConfirmExit();
                e.Cancel = (result == null || (result == true && !TrySaveChanges()));
            }
        }

        public void OnAddPayment(object sender, EventArgs e)
        {
            _navigator.Run<AddPaymentPresenter, IView>(_view);
        }

        public void OnCreateReport(object sender, EventArgs e)
        {
            _navigator.Run<ReportPresenter>();
        }

        public void OnCheckFees(object sender, EventArgs e)
        {
            _navigator.Run<CheckFeesPresenter, IView>(_view);
        }

        private bool TrySaveChanges()
        {
            try
            {
                _paymentService.SaveChanges();
                _view.ShowMessage("Изменения успешно сохранены.");
            }
            catch (DataException ex)
            {
                string errorMessage;
                if (ex is DbEntityValidationException validationEx)
                {
                    DbValidationError error = validationEx.EntityValidationErrors.First().ValidationErrors.First();
                    errorMessage = error.ErrorMessage;
                }
                else
                {
                    Exception inner = ex;
                    while (inner.InnerException != null)
                    {
                        inner = inner.InnerException;
                    }
                    errorMessage = inner.ToString();
                }

                _view.ShowError(errorMessage);
                return false;
            }

            return true;
        }
    }
}
