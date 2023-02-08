namespace DB_CourseWork.UI
{
    partial class CheckFeesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._debtorGrid = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneTypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subscriberFullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isReducedRateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.accountBalanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this._phoneStatusesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._phonesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewComboBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._menuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this._updateDebtsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._calculateFeesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this._debtorGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._phoneStatusesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._phonesBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _debtorGrid
            // 
            this._debtorGrid.AllowUserToAddRows = false;
            this._debtorGrid.AllowUserToDeleteRows = false;
            this._debtorGrid.AllowUserToOrderColumns = true;
            this._debtorGrid.AllowUserToResizeRows = false;
            this._debtorGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._debtorGrid.AutoGenerateColumns = false;
            this._debtorGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._debtorGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._debtorGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._debtorGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.phoneTypeIdDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.subscriberFullNameDataGridViewTextBoxColumn,
            this.isReducedRateDataGridViewCheckBoxColumn,
            this.accountBalanceDataGridViewTextBoxColumn,
            this.CurrentStatus});
            this._debtorGrid.DataSource = this._phonesBindingSource;
            this._debtorGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this._debtorGrid.Location = new System.Drawing.Point(0, 30);
            this._debtorGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._debtorGrid.Name = "_debtorGrid";
            this._debtorGrid.ReadOnly = true;
            this._debtorGrid.RowHeadersWidth = 47;
            this._debtorGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this._debtorGrid.Size = new System.Drawing.Size(934, 489);
            this._debtorGrid.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Номер";
            this.numberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneTypeIdDataGridViewTextBoxColumn
            // 
            this.phoneTypeIdDataGridViewTextBoxColumn.DataPropertyName = "PhoneTypeId";
            this.phoneTypeIdDataGridViewTextBoxColumn.HeaderText = "Тип телефона";
            this.phoneTypeIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.phoneTypeIdDataGridViewTextBoxColumn.Name = "phoneTypeIdDataGridViewTextBoxColumn";
            this.phoneTypeIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.phoneTypeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Адрес";
            this.addressDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subscriberFullNameDataGridViewTextBoxColumn
            // 
            this.subscriberFullNameDataGridViewTextBoxColumn.DataPropertyName = "SubscriberFullName";
            this.subscriberFullNameDataGridViewTextBoxColumn.HeaderText = "ФИО абонента";
            this.subscriberFullNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.subscriberFullNameDataGridViewTextBoxColumn.Name = "subscriberFullNameDataGridViewTextBoxColumn";
            this.subscriberFullNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isReducedRateDataGridViewCheckBoxColumn
            // 
            this.isReducedRateDataGridViewCheckBoxColumn.DataPropertyName = "IsReducedRate";
            this.isReducedRateDataGridViewCheckBoxColumn.HeaderText = "Наличие льгот";
            this.isReducedRateDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.isReducedRateDataGridViewCheckBoxColumn.Name = "isReducedRateDataGridViewCheckBoxColumn";
            this.isReducedRateDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isReducedRateDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isReducedRateDataGridViewCheckBoxColumn.Visible = false;
            // 
            // accountBalanceDataGridViewTextBoxColumn
            // 
            this.accountBalanceDataGridViewTextBoxColumn.DataPropertyName = "AccountBalance";
            this.accountBalanceDataGridViewTextBoxColumn.HeaderText = "Баланс";
            this.accountBalanceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.accountBalanceDataGridViewTextBoxColumn.Name = "accountBalanceDataGridViewTextBoxColumn";
            this.accountBalanceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CurrentStatus
            // 
            this.CurrentStatus.DataPropertyName = "CurrentStatusId";
            this.CurrentStatus.DataSource = this._phoneStatusesBindingSource;
            this.CurrentStatus.DisplayMember = "Name";
            this.CurrentStatus.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.CurrentStatus.HeaderText = "Текущий статус";
            this.CurrentStatus.MinimumWidth = 6;
            this.CurrentStatus.Name = "CurrentStatus";
            this.CurrentStatus.ReadOnly = true;
            this.CurrentStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CurrentStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CurrentStatus.ValueMember = "Id";
            // 
            // _phoneStatusesBindingSource
            // 
            this._phoneStatusesBindingSource.DataSource = typeof(DB_CourseWork.Core.PhoneStatus);
            // 
            // _phonesBindingSource
            // 
            this._phonesBindingSource.DataSource = typeof(DB_CourseWork.Core.SubscriberPhone);
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "CurrentStatus";
            this.dataGridViewComboBoxColumn1.HeaderText = "Текущий статус";
            this.dataGridViewComboBoxColumn1.MinimumWidth = 6;
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.ReadOnly = true;
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn1.Width = 885;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.DataPropertyName = "CurrentStatus";
            this.dataGridViewComboBoxColumn2.HeaderText = "Текущий статус";
            this.dataGridViewComboBoxColumn2.MinimumWidth = 6;
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.ReadOnly = true;
            this.dataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn2.Width = 885;
            // 
            // dataGridViewComboBoxColumn3
            // 
            this.dataGridViewComboBoxColumn3.DataPropertyName = "CurrentStatus";
            this.dataGridViewComboBoxColumn3.HeaderText = "Текущий статус";
            this.dataGridViewComboBoxColumn3.MinimumWidth = 6;
            this.dataGridViewComboBoxColumn3.Name = "dataGridViewComboBoxColumn3";
            this.dataGridViewComboBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn3.Width = 885;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(933, 27);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _menuStrip
            // 
            this._menuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._updateDebtsMenuItem,
            this._calculateFeesMenuItem});
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(65, 23);
            this._menuStrip.Text = "Расчет";
            // 
            // _updateDebtsMenuItem
            // 
            this._updateDebtsMenuItem.Name = "_updateDebtsMenuItem";
            this._updateDebtsMenuItem.Size = new System.Drawing.Size(286, 24);
            this._updateDebtsMenuItem.Text = "Обновить задолженности";
            this._updateDebtsMenuItem.Click += new System.EventHandler(this.UpdateDebtsMenuItemClick);
            // 
            // _calculateFeesMenuItem
            // 
            this._calculateFeesMenuItem.Name = "_calculateFeesMenuItem";
            this._calculateFeesMenuItem.Size = new System.Drawing.Size(286, 24);
            this._calculateFeesMenuItem.Text = "Произвести расчет по тарифам";
            this._calculateFeesMenuItem.Click += new System.EventHandler(this.CalculateFeesMenuItemClick);
            // 
            // CheckFeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this._debtorGrid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CheckFeesForm";
            this.Text = "Расчет по тарифам и задолженности";
            ((System.ComponentModel.ISupportInitialize)(this._debtorGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._phoneStatusesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._phonesBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _debtorGrid;
        private System.Windows.Forms.BindingSource _phonesBindingSource;
        private System.Windows.Forms.BindingSource _phoneStatusesBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _updateDebtsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _calculateFeesMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneTypeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subscriberFullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReducedRateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountBalanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn CurrentStatus;
    }
}