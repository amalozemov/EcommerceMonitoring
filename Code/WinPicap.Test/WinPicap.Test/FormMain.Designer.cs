namespace WinPicap.Test
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
            this._btnStart = new System.Windows.Forms.Button();
            this._btnDevicesList = new System.Windows.Forms.Button();
            this._btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnStart
            // 
            this._btnStart.Location = new System.Drawing.Point(56, 63);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(75, 23);
            this._btnStart.TabIndex = 0;
            this._btnStart.Text = "Start";
            this._btnStart.UseVisualStyleBackColor = true;
            this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
            // 
            // _btnDevicesList
            // 
            this._btnDevicesList.Location = new System.Drawing.Point(56, 12);
            this._btnDevicesList.Name = "_btnDevicesList";
            this._btnDevicesList.Size = new System.Drawing.Size(167, 39);
            this._btnDevicesList.TabIndex = 1;
            this._btnDevicesList.Text = "Получить список устройств";
            this._btnDevicesList.UseVisualStyleBackColor = true;
            this._btnDevicesList.Click += new System.EventHandler(this._btnDevicesList_Click);
            // 
            // _btnStop
            // 
            this._btnStop.Location = new System.Drawing.Point(148, 63);
            this._btnStop.Name = "_btnStop";
            this._btnStop.Size = new System.Drawing.Size(75, 23);
            this._btnStop.TabIndex = 2;
            this._btnStop.Text = "Stop";
            this._btnStop.UseVisualStyleBackColor = true;
            this._btnStop.Click += new System.EventHandler(this._btnStop_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._btnStop);
            this.Controls.Add(this._btnDevicesList);
            this.Controls.Add(this._btnStart);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.Button _btnDevicesList;
        private System.Windows.Forms.Button _btnStop;
    }
}

