namespace LanDevicesEnumerator
{
    partial class FormMain
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
            this._txtDevicesList = new System.Windows.Forms.TextBox();
            this._btnGetDevicesList = new System.Windows.Forms.Button();
            this._btnClearDevicesList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _txtDevicesList
            // 
            this._txtDevicesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDevicesList.Location = new System.Drawing.Point(0, 0);
            this._txtDevicesList.Multiline = true;
            this._txtDevicesList.Name = "_txtDevicesList";
            this._txtDevicesList.Size = new System.Drawing.Size(380, 241);
            this._txtDevicesList.TabIndex = 0;
            // 
            // _btnGetDevicesList
            // 
            this._btnGetDevicesList.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._btnGetDevicesList.AutoSize = true;
            this._btnGetDevicesList.Location = new System.Drawing.Point(31, 263);
            this._btnGetDevicesList.Name = "_btnGetDevicesList";
            this._btnGetDevicesList.Size = new System.Drawing.Size(157, 23);
            this._btnGetDevicesList.TabIndex = 1;
            this._btnGetDevicesList.Text = "Получить список устройств";
            this._btnGetDevicesList.UseVisualStyleBackColor = true;
            this._btnGetDevicesList.Click += new System.EventHandler(this._btnGetDevicesList_Click);
            // 
            // _btnClearDevicesList
            // 
            this._btnClearDevicesList.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._btnClearDevicesList.AutoSize = true;
            this._btnClearDevicesList.Location = new System.Drawing.Point(194, 263);
            this._btnClearDevicesList.Name = "_btnClearDevicesList";
            this._btnClearDevicesList.Size = new System.Drawing.Size(157, 23);
            this._btnClearDevicesList.TabIndex = 2;
            this._btnClearDevicesList.Text = "Очистить список устройств";
            this._btnClearDevicesList.UseVisualStyleBackColor = true;
            this._btnClearDevicesList.Click += new System.EventHandler(this._btnClearDevicesList_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 301);
            this.Controls.Add(this._btnClearDevicesList);
            this.Controls.Add(this._btnGetDevicesList);
            this.Controls.Add(this._txtDevicesList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(390, 331);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtDevicesList;
        private System.Windows.Forms.Button _btnGetDevicesList;
        private System.Windows.Forms.Button _btnClearDevicesList;
    }
}

