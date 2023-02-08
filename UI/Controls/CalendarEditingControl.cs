using System;
using System.Windows.Forms;

namespace DB_CourseWork.UI
{
    /// <summary>
    /// Представляет элемент управления для выбора даты и времени.
    /// </summary>
    public class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        public CalendarEditingControl()
        {
            Format = DateTimePickerFormat.Custom;
            CustomFormat = "dd.MM.yyyy hh:mm";
        }

        public object EditingControlFormattedValue
        {
            get => Value.ToString();
            set
            {
                if (value is string str && DateTime.TryParse(str, out DateTime date))
                {
                    Value = date;
                }
            }
        }

        // Реализация интерфейсов DateTimePicker и IDataGridViewEditingControl
        public DataGridView EditingControlDataGridView { get; set; }
        public int EditingControlRowIndex { get; set; }
        public bool EditingControlValueChanged { get; set; }
        public bool RepositionEditingControlOnValueChange => false;
        public Cursor EditingPanelCursor => base.Cursor;
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context) => EditingControlFormattedValue;

        /// <summary>
        /// Изменяет элемент управления для согласования с заданным стилем ячейки.
        /// </summary>
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            CalendarForeColor = dataGridViewCellStyle.ForeColor;
            CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        /// <summary>
        /// Определяет, является ли заданная клавиша обычной клавишей ввода.
        /// </summary>
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;

                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        /// <summary>
        /// Подготавливает выбранную ячейку к редактированию.
        /// </summary>
        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }

        /// <summary>
        /// Вызывает необходимые события при изменении значения.
        /// </summary>
        protected override void OnValueChanged(EventArgs e)
        {
            EditingControlValueChanged = true;
            EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(e);
        }
    }
}
