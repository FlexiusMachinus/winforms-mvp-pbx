using System;
using System.Windows.Forms;

namespace DB_CourseWork
{
    public interface IDialogService
    {
        bool ShowDialogYesNo(string caption, string text);
        bool? ShowDialogYesNoCancel(string caption, string text);
        void ShowMessage(string caption, string text);
        void ShowError(string caption, string text);
    }
}
