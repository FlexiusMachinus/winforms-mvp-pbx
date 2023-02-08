namespace DB_CourseWork.UI
{
    partial class AddPaymentForm
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
            this._addButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._phoneCombobox = new System.Windows.Forms.ComboBox();
            this._amountTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.subscriberPhoneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.subscriberPhoneBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(75, 119);
            this._addButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(88, 27);
            this._addButton.TabIndex = 0;
            this._addButton.Text = "Добавить";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(171, 119);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(88, 27);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Отменить";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // _dateTimePicker
            // 
            this._dateTimePicker.CustomFormat = "dd.MM.yyyy hh:mm";
            this._dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dateTimePicker.Location = new System.Drawing.Point(154, 71);
            this._dateTimePicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._dateTimePicker.Name = "_dateTimePicker";
            this._dateTimePicker.Size = new System.Drawing.Size(181, 21);
            this._dateTimePicker.TabIndex = 2;
            // 
            // _phoneCombobox
            // 
            this._phoneCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this._phoneCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._phoneCombobox.DisplayMember = "Number";
            this._phoneCombobox.FormattingEnabled = true;
            this._phoneCombobox.Location = new System.Drawing.Point(154, 15);
            this._phoneCombobox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._phoneCombobox.Name = "_phoneCombobox";
            this._phoneCombobox.Size = new System.Drawing.Size(181, 23);
            this._phoneCombobox.TabIndex = 3;
            this._phoneCombobox.ValueMember = "Number";
            // 
            // _amountTextbox
            // 
            this._amountTextbox.Location = new System.Drawing.Point(154, 44);
            this._amountTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._amountTextbox.Name = "_amountTextbox";
            this._amountTextbox.Size = new System.Drawing.Size(181, 21);
            this._amountTextbox.TabIndex = 4;
            this._amountTextbox.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Телефон абонента";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Сумма платежа";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Дата платежа";
            // 
            // subscriberPhoneBindingSource
            // 
            this.subscriberPhoneBindingSource.DataSource = typeof(DB_CourseWork.Core.SubscriberPhone);
            // 
            // AddPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 170);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._amountTextbox);
            this.Controls.Add(this._phoneCombobox);
            this.Controls.Add(this._dateTimePicker);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._addButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AddPaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить платеж";
            ((System.ComponentModel.ISupportInitialize)(this.subscriberPhoneBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.DateTimePicker _dateTimePicker;
        private System.Windows.Forms.ComboBox _phoneCombobox;
        private System.Windows.Forms.TextBox _amountTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource subscriberPhoneBindingSource;
    }
}