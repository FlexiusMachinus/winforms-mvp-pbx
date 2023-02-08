namespace DB_CourseWork.UI
{
    partial class PaymentForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._accountingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._createReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._checkFeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._paymentsGrid = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this._phonesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeDataGridViewTextBoxColumn = new DB_CourseWork.UI.DataGridViewCalendarColumn();
            this._paymentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._delButton = new System.Windows.Forms.PictureBox();
            this._addButton = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._paymentsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._phonesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._paymentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._delButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._addButton)).BeginInit();
            this.SuspendLayout();
            // 
            // _dbToolStripMenuItem
            // 
            this._dbToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._saveToolStripMenuItem,
            this._closeToolStripMenuItem});
            this._dbToolStripMenuItem.Name = "_dbToolStripMenuItem";
            this._dbToolStripMenuItem.Size = new System.Drawing.Size(102, 23);
            this._dbToolStripMenuItem.Text = "База данных";
            // 
            // _saveToolStripMenuItem
            // 
            this._saveToolStripMenuItem.Name = "_saveToolStripMenuItem";
            this._saveToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this._saveToolStripMenuItem.Text = "Сохранить";
            this._saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
            // 
            // _closeToolStripMenuItem
            // 
            this._closeToolStripMenuItem.Name = "_closeToolStripMenuItem";
            this._closeToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this._closeToolStripMenuItem.Text = "Закрыть";
            this._closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItemClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._dbToolStripMenuItem,
            this._accountingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1026, 27);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _accountingToolStripMenuItem
            // 
            this._accountingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._createReportToolStripMenuItem,
            this._checkFeesToolStripMenuItem});
            this._accountingToolStripMenuItem.Name = "_accountingToolStripMenuItem";
            this._accountingToolStripMenuItem.Size = new System.Drawing.Size(96, 23);
            this._accountingToolStripMenuItem.Text = "Отчетность";
            // 
            // _createReportToolStripMenuItem
            // 
            this._createReportToolStripMenuItem.Name = "_createReportToolStripMenuItem";
            this._createReportToolStripMenuItem.Size = new System.Drawing.Size(321, 24);
            this._createReportToolStripMenuItem.Text = "Создать финансовый отчет";
            this._createReportToolStripMenuItem.Click += new System.EventHandler(this.CreateReportToolStripMenuItemClick);
            // 
            // _checkFeesToolStripMenuItem
            // 
            this._checkFeesToolStripMenuItem.Name = "_checkFeesToolStripMenuItem";
            this._checkFeesToolStripMenuItem.Size = new System.Drawing.Size(321, 24);
            this._checkFeesToolStripMenuItem.Text = "Расчет по тарифам и задолженности";
            this._checkFeesToolStripMenuItem.Click += new System.EventHandler(this.CheckFeesToolStripMenuItemClick);
            // 
            // _paymentsGrid
            // 
            this._paymentsGrid.AllowUserToAddRows = false;
            this._paymentsGrid.AllowUserToDeleteRows = false;
            this._paymentsGrid.AllowUserToOrderColumns = true;
            this._paymentsGrid.AllowUserToResizeRows = false;
            this._paymentsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._paymentsGrid.AutoGenerateColumns = false;
            this._paymentsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._paymentsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._paymentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._paymentsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.phoneIdDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.dateTimeDataGridViewTextBoxColumn});
            this._paymentsGrid.DataSource = this._paymentBindingSource;
            this._paymentsGrid.Location = new System.Drawing.Point(0, 30);
            this._paymentsGrid.Name = "_paymentsGrid";
            this._paymentsGrid.RowHeadersWidth = 47;
            this._paymentsGrid.Size = new System.Drawing.Size(1028, 444);
            this._paymentsGrid.TabIndex = 3;
            this._paymentsGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.PaymentGridDataError);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 115;
            // 
            // phoneIdDataGridViewTextBoxColumn
            // 
            this.phoneIdDataGridViewTextBoxColumn.DataPropertyName = "PhoneId";
            this.phoneIdDataGridViewTextBoxColumn.DataSource = this._phonesBindingSource;
            this.phoneIdDataGridViewTextBoxColumn.DisplayMember = "Number";
            this.phoneIdDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.phoneIdDataGridViewTextBoxColumn.HeaderText = "Абонентский телефон";
            this.phoneIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.phoneIdDataGridViewTextBoxColumn.Name = "phoneIdDataGridViewTextBoxColumn";
            this.phoneIdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.phoneIdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.phoneIdDataGridViewTextBoxColumn.ValueMember = "Id";
            // 
            // _phonesBindingSource
            // 
            this._phonesBindingSource.DataSource = typeof(DB_CourseWork.Core.SubscriberPhone);
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.amountDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // dateTimeDataGridViewTextBoxColumn
            // 
            this.dateTimeDataGridViewTextBoxColumn.DataPropertyName = "DateTime";
            this.dateTimeDataGridViewTextBoxColumn.HeaderText = "Дата и время";
            this.dateTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateTimeDataGridViewTextBoxColumn.Name = "dateTimeDataGridViewTextBoxColumn";
            this.dateTimeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dateTimeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _paymentBindingSource
            // 
            this._paymentBindingSource.DataSource = typeof(DB_CourseWork.Core.Payment);
            // 
            // _delButton
            // 
            this._delButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._delButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this._delButton.Image = global::DB_CourseWork.UI.Properties.Resources.del_icon;
            this._delButton.Location = new System.Drawing.Point(986, 483);
            this._delButton.Name = "_delButton";
            this._delButton.Size = new System.Drawing.Size(30, 30);
            this._delButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._delButton.TabIndex = 9;
            this._delButton.TabStop = false;
            this._delButton.Click += new System.EventHandler(this.DeleteButtonClick);
            // 
            // _addButton
            // 
            this._addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._addButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this._addButton.Image = global::DB_CourseWork.UI.Properties.Resources.add_icon;
            this._addButton.Location = new System.Drawing.Point(950, 483);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(30, 30);
            this._addButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._addButton.TabIndex = 8;
            this._addButton.TabStop = false;
            this._addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 522);
            this.Controls.Add(this._delButton);
            this.Controls.Add(this._addButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this._paymentsGrid);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "PaymentForm";
            this.Text = "Приложение учета абонентских платежей";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._paymentsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._phonesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._paymentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._delButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._addButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem _dbToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView _paymentsGrid;
        private System.Windows.Forms.ToolStripMenuItem _accountingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _createReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _checkFeesToolStripMenuItem;
        private System.Windows.Forms.BindingSource _phonesBindingSource;
        private System.Windows.Forms.BindingSource _paymentBindingSource;
        private System.Windows.Forms.PictureBox _addButton;
        private System.Windows.Forms.PictureBox _delButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn phoneIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private DataGridViewCalendarColumn dateTimeDataGridViewTextBoxColumn;
    }
}

