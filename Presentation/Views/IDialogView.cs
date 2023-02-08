using System;

namespace DB_CourseWork.Presentation
{
    public interface IDialogView : IView
    {
        void ShowDialog(IView parentView);
    }
}
