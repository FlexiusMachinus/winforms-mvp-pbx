namespace DB_CourseWork.UI
{
    partial class ReportForm
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
            this._createButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._monthPicker = new System.Windows.Forms.DateTimePicker();
            this._periodLabel = new System.Windows.Forms.Label();
            this._periodUnderline = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._paymentsSplitContainer = new System.Windows.Forms.SplitContainer();
            this._totalPaymentsLabel = new System.Windows.Forms.Label();
            this._expandPaymentsButton = new System.Windows.Forms.Button();
            this._paymentsPanel = new System.Windows.Forms.Panel();
            this._paymentsLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._debtSplitContainer = new System.Windows.Forms.SplitContainer();
            this._totalDebtsLabel = new System.Windows.Forms.Label();
            this._expandDebtsButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this._debtPanel = new System.Windows.Forms.Panel();
            this._debtsLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._paymentsSplitContainer)).BeginInit();
            this._paymentsSplitContainer.Panel1.SuspendLayout();
            this._paymentsSplitContainer.Panel2.SuspendLayout();
            this._paymentsSplitContainer.SuspendLayout();
            this._paymentsPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._debtSplitContainer)).BeginInit();
            this._debtSplitContainer.Panel1.SuspendLayout();
            this._debtSplitContainer.Panel2.SuspendLayout();
            this._debtSplitContainer.SuspendLayout();
            this._debtPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _createButton
            // 
            this._createButton.Location = new System.Drawing.Point(124, 497);
            this._createButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._createButton.Name = "_createButton";
            this._createButton.Size = new System.Drawing.Size(140, 27);
            this._createButton.TabIndex = 0;
            this._createButton.Text = "Сформировать";
            this._createButton.UseVisualStyleBackColor = true;
            this._createButton.Click += new System.EventHandler(this.CreateButtonClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(54, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Отчет о финансовых результатах\r\nза период ";
            // 
            // _monthPicker
            // 
            this._monthPicker.CustomFormat = "MMMM yyyy";
            this._monthPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._monthPicker.Location = new System.Drawing.Point(123, 470);
            this._monthPicker.Name = "_monthPicker";
            this._monthPicker.Size = new System.Drawing.Size(140, 21);
            this._monthPicker.TabIndex = 3;
            this._monthPicker.ValueChanged += new System.EventHandler(this.MonthPickerValueChanged);
            // 
            // _periodLabel
            // 
            this._periodLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._periodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.163636F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._periodLabel.Location = new System.Drawing.Point(153, 33);
            this._periodLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._periodLabel.Name = "_periodLabel";
            this._periodLabel.Size = new System.Drawing.Size(191, 15);
            this._periodLabel.TabIndex = 4;
            this._periodLabel.Text = "01.12.2022 - 31.12.2022";
            this._periodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _periodUnderline
            // 
            this._periodUnderline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._periodUnderline.AutoSize = true;
            this._periodUnderline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._periodUnderline.Location = new System.Drawing.Point(153, 37);
            this._periodUnderline.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._periodUnderline.Name = "_periodUnderline";
            this._periodUnderline.Size = new System.Drawing.Size(193, 18);
            this._periodUnderline.TabIndex = 5;
            this._periodUnderline.Text = "                                     ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Пополнения по тарифам";
            // 
            // _paymentsSplitContainer
            // 
            this._paymentsSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._paymentsSplitContainer.IsSplitterFixed = true;
            this._paymentsSplitContainer.Location = new System.Drawing.Point(3, 3);
            this._paymentsSplitContainer.Name = "_paymentsSplitContainer";
            this._paymentsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _paymentsSplitContainer.Panel1
            // 
            this._paymentsSplitContainer.Panel1.Controls.Add(this._totalPaymentsLabel);
            this._paymentsSplitContainer.Panel1.Controls.Add(this._expandPaymentsButton);
            this._paymentsSplitContainer.Panel1.Controls.Add(this.label4);
            this._paymentsSplitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // _paymentsSplitContainer.Panel2
            // 
            this._paymentsSplitContainer.Panel2.Controls.Add(this._paymentsPanel);
            this._paymentsSplitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._paymentsSplitContainer.Panel2Collapsed = true;
            this._paymentsSplitContainer.Panel2MinSize = 1;
            this._paymentsSplitContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._paymentsSplitContainer.Size = new System.Drawing.Size(381, 50);
            this._paymentsSplitContainer.SplitterDistance = 25;
            this._paymentsSplitContainer.SplitterWidth = 1;
            this._paymentsSplitContainer.TabIndex = 10;
            // 
            // _totalPaymentsLabel
            // 
            this._totalPaymentsLabel.Location = new System.Drawing.Point(244, 4);
            this._totalPaymentsLabel.Name = "_totalPaymentsLabel";
            this._totalPaymentsLabel.Size = new System.Drawing.Size(137, 16);
            this._totalPaymentsLabel.TabIndex = 8;
            this._totalPaymentsLabel.Text = "0";
            this._totalPaymentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _expandPaymentsButton
            // 
            this._expandPaymentsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._expandPaymentsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._expandPaymentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._expandPaymentsButton.Location = new System.Drawing.Point(1, 1);
            this._expandPaymentsButton.Name = "_expandPaymentsButton";
            this._expandPaymentsButton.Size = new System.Drawing.Size(22, 22);
            this._expandPaymentsButton.TabIndex = 7;
            this._expandPaymentsButton.Text = "+";
            this._expandPaymentsButton.UseVisualStyleBackColor = true;
            this._expandPaymentsButton.Click += new System.EventHandler(this.ExpandFeesButtonClick);
            // 
            // _paymentsPanel
            // 
            this._paymentsPanel.AutoScroll = true;
            this._paymentsPanel.Controls.Add(this._paymentsLabel);
            this._paymentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._paymentsPanel.Location = new System.Drawing.Point(0, 0);
            this._paymentsPanel.MinimumSize = new System.Drawing.Size(379, 158);
            this._paymentsPanel.Name = "_paymentsPanel";
            this._paymentsPanel.Size = new System.Drawing.Size(379, 158);
            this._paymentsPanel.TabIndex = 0;
            // 
            // _paymentsLabel
            // 
            this._paymentsLabel.AutoSize = true;
            this._paymentsLabel.Location = new System.Drawing.Point(3, 9);
            this._paymentsLabel.Name = "_paymentsLabel";
            this._paymentsLabel.Size = new System.Drawing.Size(0, 16);
            this._paymentsLabel.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this._paymentsSplitContainer);
            this.flowLayoutPanel1.Controls.Add(this._debtSplitContainer);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 70);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(385, 385);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // _debtSplitContainer
            // 
            this._debtSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._debtSplitContainer.IsSplitterFixed = true;
            this._debtSplitContainer.Location = new System.Drawing.Point(3, 59);
            this._debtSplitContainer.Name = "_debtSplitContainer";
            this._debtSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _debtSplitContainer.Panel1
            // 
            this._debtSplitContainer.Panel1.Controls.Add(this._totalDebtsLabel);
            this._debtSplitContainer.Panel1.Controls.Add(this._expandDebtsButton);
            this._debtSplitContainer.Panel1.Controls.Add(this.label8);
            this._debtSplitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // _debtSplitContainer.Panel2
            // 
            this._debtSplitContainer.Panel2.Controls.Add(this._debtPanel);
            this._debtSplitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._debtSplitContainer.Panel2Collapsed = true;
            this._debtSplitContainer.Panel2MinSize = 1;
            this._debtSplitContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._debtSplitContainer.Size = new System.Drawing.Size(381, 50);
            this._debtSplitContainer.SplitterDistance = 25;
            this._debtSplitContainer.SplitterWidth = 1;
            this._debtSplitContainer.TabIndex = 11;
            // 
            // _totalDebtsLabel
            // 
            this._totalDebtsLabel.Location = new System.Drawing.Point(244, 4);
            this._totalDebtsLabel.Name = "_totalDebtsLabel";
            this._totalDebtsLabel.Size = new System.Drawing.Size(137, 16);
            this._totalDebtsLabel.TabIndex = 8;
            this._totalDebtsLabel.Text = "0";
            this._totalDebtsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _expandDebtsButton
            // 
            this._expandDebtsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._expandDebtsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this._expandDebtsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._expandDebtsButton.Location = new System.Drawing.Point(1, 1);
            this._expandDebtsButton.Name = "_expandDebtsButton";
            this._expandDebtsButton.Size = new System.Drawing.Size(22, 22);
            this._expandDebtsButton.TabIndex = 7;
            this._expandDebtsButton.Text = "+";
            this._expandDebtsButton.UseVisualStyleBackColor = true;
            this._expandDebtsButton.Click += new System.EventHandler(this.ExpandDebtsButtonClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Задолженности";
            // 
            // _debtPanel
            // 
            this._debtPanel.AutoScroll = true;
            this._debtPanel.Controls.Add(this._debtsLabel);
            this._debtPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._debtPanel.Location = new System.Drawing.Point(0, 0);
            this._debtPanel.MinimumSize = new System.Drawing.Size(379, 158);
            this._debtPanel.Name = "_debtPanel";
            this._debtPanel.Size = new System.Drawing.Size(379, 158);
            this._debtPanel.TabIndex = 0;
            // 
            // _debtsLabel
            // 
            this._debtsLabel.AutoSize = true;
            this._debtsLabel.Location = new System.Drawing.Point(3, 9);
            this._debtsLabel.Name = "_debtsLabel";
            this._debtsLabel.Size = new System.Drawing.Size(0, 16);
            this._debtsLabel.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(0, 462);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(578, 2);
            this.label10.TabIndex = 12;
            this.label10.Text = "label10";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 536);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this._periodLabel);
            this.Controls.Add(this._monthPicker);
            this.Controls.Add(this._createButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._periodUnderline);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ReportForm";
            this.Text = "Финансовый отчет";
            this.Shown += new System.EventHandler(this.ReportFormShown);
            this._paymentsSplitContainer.Panel1.ResumeLayout(false);
            this._paymentsSplitContainer.Panel1.PerformLayout();
            this._paymentsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._paymentsSplitContainer)).EndInit();
            this._paymentsSplitContainer.ResumeLayout(false);
            this._paymentsPanel.ResumeLayout(false);
            this._paymentsPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this._debtSplitContainer.Panel1.ResumeLayout(false);
            this._debtSplitContainer.Panel1.PerformLayout();
            this._debtSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._debtSplitContainer)).EndInit();
            this._debtSplitContainer.ResumeLayout(false);
            this._debtPanel.ResumeLayout(false);
            this._debtPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _createButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker _monthPicker;
        private System.Windows.Forms.Label _periodLabel;
        private System.Windows.Forms.Label _periodUnderline;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer _paymentsSplitContainer;
        private System.Windows.Forms.Button _expandPaymentsButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel _paymentsPanel;
        private System.Windows.Forms.Label _paymentsLabel;
        private System.Windows.Forms.Label _totalPaymentsLabel;
        private System.Windows.Forms.SplitContainer _debtSplitContainer;
        private System.Windows.Forms.Label _totalDebtsLabel;
        private System.Windows.Forms.Button _expandDebtsButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel _debtPanel;
        private System.Windows.Forms.Label _debtsLabel;
        private System.Windows.Forms.Label label10;
    }
}