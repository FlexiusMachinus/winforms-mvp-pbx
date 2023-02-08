using System;
using System.Windows.Forms;

namespace DB_CourseWork.UI
{
    /// <summary>
    /// Представляет ячейку <see cref="DataGridView"/> для редактирования даты и времени.
    /// </summary>
    public class DataGridViewCalendarCell : DataGridViewTextBoxCell
    {
        public DataGridViewCalendarCell() : base()
        {

        }

        public override Type EditType => typeof(CalendarEditingControl);
        public override Type ValueType => typeof(DateTime);
        public override object DefaultNewRowValue => DateTime.Now;

        /// <summary>
        /// Присоединяет и инициализирует элемент управления.
        /// </summary>
        /// <param name="rowIndex">Индекс строки</param>
        /// <param name="initialFormattedValue">Начальное значение</param>
        /// <param name="cellStyle">Стиль ячейки</param>
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle cellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, cellStyle);
            CalendarEditingControl calendarControl = DataGridView.EditingControl as CalendarEditingControl;
            calendarControl.Value = (Value == null) ? (DateTime)DefaultNewRowValue : (DateTime)Value;
        }
    }
}
