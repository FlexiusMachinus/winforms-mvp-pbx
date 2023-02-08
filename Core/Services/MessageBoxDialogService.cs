using System;
using System.Windows.Forms;

namespace DB_CourseWork
{
    public class MessageBoxDialogService : IDialogService
    {
        public bool ShowDialogYesNo(string caption, string text)
        {
            DialogResult result = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return (result == DialogResult.Yes);
        }

        public bool? ShowDialogYesNoCancel(string caption, string text)
        {
            DialogResult result = MessageBox.Show(text, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel) return null;
            return (result == DialogResult.Yes);
        }

        public void ShowError(string caption, string text)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowMessage(string caption, string text)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
