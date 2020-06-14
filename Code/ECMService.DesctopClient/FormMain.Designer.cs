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
            this._btnGetDataFromManagerAllAndPoints = new System.Windows.Forms.Button();
            this._btnGetDataFromManagerByService = new System.Windows.Forms.Button();
            this._btnGetDataFromManagerByAllServices = new System.Windows.Forms.Button();
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
            this._btnGetDataFromManager.Location = new System.Drawing.Point(12, 291);
            this._btnGetDataFromManager.Name = "_btnGetDataFromManager";
            this._btnGetDataFromManager.Size = new System.Drawing.Size(132, 42);
            this._btnGetDataFromManager.TabIndex = 5;
            this._btnGetDataFromManager.Text = "Получить данные через менеджер";
            this._btnGetDataFromManager.UseVisualStyleBackColor = true;
            this._btnGetDataFromManager.Click += new System.EventHandler(this._btnGetDataFromManager_Click);
            // 
            // _btnGetDataFromManagerAllAndPoints
            // 
            this._btnGetDataFromManagerAllAndPoints.Location = new System.Drawing.Point(150, 291);
            this._btnGetDataFromManagerAllAndPoints.Name = "_btnGetDataFromManagerAllAndPoints";
            this._btnGetDataFromManagerAllAndPoints.Size = new System.Drawing.Size(132, 74);
            this._btnGetDataFromManagerAllAndPoints.TabIndex = 6;
            this._btnGetDataFromManagerAllAndPoints.Text = "Получить данные через менеджер для всех конечных точек";
            this._btnGetDataFromManagerAllAndPoints.UseVisualStyleBackColor = true;
            this._btnGetDataFromManagerAllAndPoints.Click += new System.EventHandler(this._btnGetDataFromManagerAllAndPoints_Click);
            // 
            // _btnGetDataFromManagerByService
            // 
            this._btnGetDataFromManagerByService.Location = new System.Drawing.Point(387, 291);
            this._btnGetDataFromManagerByService.Name = "_btnGetDataFromManagerByService";
            this._btnGetDataFromManagerByService.Size = new System.Drawing.Size(132, 74);
            this._btnGetDataFromManagerByService.TabIndex = 7;
            this._btnGetDataFromManagerByService.Text = "Получить данные через менеджер по сервису";
            this._btnGetDataFromManagerByService.UseVisualStyleBackColor = true;
            this._btnGetDataFromManagerByService.Click += new System.EventHandler(this._btnGetDataFromManagerByService_Click);
            // 
            // _btnGetDataFromManagerByAllServices
            // 
            this._btnGetDataFromManagerByAllServices.Location = new System.Drawing.Point(540, 291);
            this._btnGetDataFromManagerByAllServices.Name = "_btnGetDataFromManagerByAllServices";
            this._btnGetDataFromManagerByAllServices.Size = new System.Drawing.Size(132, 74);
            this._btnGetDataFromManagerByAllServices.TabIndex = 8;
            this._btnGetDataFromManagerByAllServices.Text = "Получить данные через менеджер по всем сервисам";
            this._btnGetDataFromManagerByAllServices.UseVisualStyleBackColor = true;
            this._btnGetDataFromManagerByAllServices.Click += new System.EventHandler(this._btnGetDataFromManagerByAllServices_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 450);
            this.Controls.Add(this._btnGetDataFromManagerByAllServices);
            this.Controls.Add(this._btnGetDataFromManagerByService);
            this.Controls.Add(this._btnGetDataFromManagerAllAndPoints);
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
        private System.Windows.Forms.Button _btnGetDataFromManagerAllAndPoints;
        private System.Windows.Forms.Button _btnGetDataFromManagerByService;
        private System.Windows.Forms.Button _btnGetDataFromManagerByAllServices;
    }
}

