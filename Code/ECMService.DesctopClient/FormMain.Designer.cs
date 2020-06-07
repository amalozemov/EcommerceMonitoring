namespace ECMService.DesctopClient
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
            this._btnStop = new System.Windows.Forms.Button();
            this._btnStart = new System.Windows.Forms.Button();
            this._btnGetDataFromManager = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnStop
            // 
            this._btnStop.Location = new System.Drawing.Point(328, 228);
            this._btnStop.Name = "_btnStop";
            this._btnStop.Size = new System.Drawing.Size(75, 23);
            this._btnStop.TabIndex = 4;
            this._btnStop.Text = "Stop";
            this._btnStop.UseVisualStyleBackColor = true;
            this._btnStop.Click += new System.EventHandler(this._btnStop_Click);
            // 
            // _btnStart
            // 
            this._btnStart.Location = new System.Drawing.Point(328, 199);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(75, 23);
            this._btnStart.TabIndex = 3;
            this._btnStart.Text = "Start";
            this._btnStart.UseVisualStyleBackColor = true;
            this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
            // 
            // _btnGetDataFromManager
            // 
            this._btnGetDataFromManager.Location = new System.Drawing.Point(328, 324);
            this._btnGetDataFromManager.Name = "_btnGetDataFromManager";
            this._btnGetDataFromManager.Size = new System.Drawing.Size(132, 42);
            this._btnGetDataFromManager.TabIndex = 5;
            this._btnGetDataFromManager.Text = "Получить данные через менеджер";
            this._btnGetDataFromManager.UseVisualStyleBackColor = true;
            this._btnGetDataFromManager.Click += new System.EventHandler(this._btnGetDataFromManager_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 450);
            this.Controls.Add(this._btnGetDataFromManager);
            this.Controls.Add(this._btnStop);
            this.Controls.Add(this._btnStart);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnStop;
        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.Button _btnGetDataFromManager;
    }
}

