using System;

namespace DB_CourseWork
{
    public interface IDialogView : IView
    {
        void ShowDialog(IView parentView);
    }
}
