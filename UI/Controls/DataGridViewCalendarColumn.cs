using System;
using System.Windows.Forms;

namespace DB_CourseWork.UI
{
    /// <summary>
    /// Представляет столбец <see cref="DataGridView"/> для редактирования значений даты и времени.
    /// </summary>
    public class DataGridViewCalendarColumn : DataGridViewColumn
    {
        public DataGridViewCalendarColumn() : base(new DataGridViewCalendarCell())
        {
        }

        /// <summary>
        /// Шаблон для создания ячеек.
        /// </summary>
        public override DataGridViewCell CellTemplate
        {
            get => base.CellTemplate;
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewCalendarCell)))
                {
                    throw new InvalidCastException("CellTemplate must be a DataGridViewCalendarColumn");
                }

                base.CellTemplate = value;
            }
        }
    }
}
