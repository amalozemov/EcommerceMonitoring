namespace ECMService
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._lblHttpStatus = new System.Windows.Forms.Label();
            this._lblTcpStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._btnStart = new System.Windows.Forms.Button();
            this._btnStop = new System.Windows.Forms.Button();
            this._btnGetData = new System.Windows.Forms.Button();
            this._btnStopGetData = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._lblHttpStatus);
            this.groupBox1.Controls.Add(this._lblTcpStatus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сервис 1";
            // 
            // _lblHttpStatus
            // 
            this._lblHttpStatus.AutoSize = true;
            this._lblHttpStatus.Location = new System.Drawing.Point(139, 71);
            this._lblHttpStatus.Name = "_lblHttpStatus";
            this._lblHttpStatus.Size = new System.Drawing.Size(73, 13);
            this._lblHttpStatus.TabIndex = 3;
            this._lblHttpStatus.Text = "Пакеты TCP:";
            // 
            // _lblTcpStatus
            // 
            this._lblTcpStatus.AutoSize = true;
            this._lblTcpStatus.Location = new System.Drawing.Point(139, 36);
            this._lblTcpStatus.Name = "_lblTcpStatus";
            this._lblTcpStatus.Size = new System.Drawing.Size(73, 13);
            this._lblTcpStatus.TabIndex = 2;
            this._lblTcpStatus.Text = "Пакеты TCP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пакеты HTTP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пакеты TCP:";
            // 
            // _btnStart
            // 
            this._btnStart.Location = new System.Drawing.Point(54, 240);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(75, 23);
            this._btnStart.TabIndex = 1;
            this._btnStart.Text = "Start";
            this._btnStart.UseVisualStyleBackColor = true;
            this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
            // 
            // _btnStop
            // 
            this._btnStop.Location = new System.Drawing.Point(54, 269);
            this._btnStop.Name = "_btnStop";
            this._btnStop.Size = new System.Drawing.Size(75, 23);
            this._btnStop.TabIndex = 2;
            this._btnStop.Text = "Stop";
            this._btnStop.UseVisualStyleBackColor = true;
            this._btnStop.Click += new System.EventHandler(this._btnStop_Click);
            // 
            // _btnGetData
            // 
            this._btnGetData.Location = new System.Drawing.Point(246, 281);
            this._btnGetData.Name = "_btnGetData";
            this._btnGetData.Size = new System.Drawing.Size(100, 23);
            this._btnGetData.TabIndex = 3;
            this._btnGetData.Text = "Start GetData";
            this._btnGetData.UseVisualStyleBackColor = true;
            this._btnGetData.Click += new System.EventHandler(this._btnGetData_Click);
            // 
            // _btnStopGetData
            // 
            this._btnStopGetData.Location = new System.Drawing.Point(246, 310);
            this._btnStopGetData.Name = "_btnStopGetData";
            this._btnStopGetData.Size = new System.Drawing.Size(100, 23);
            this._btnStopGetData.TabIndex = 4;
            this._btnStopGetData.Text = "Stop GetData";
            this._btnStopGetData.UseVisualStyleBackColor = true;
            this._btnStopGetData.Click += new System.EventHandler(this._btnStopGetData_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 354);
            this.Controls.Add(this._btnStopGetData);
            this.Controls.Add(this._btnGetData);
            this.Controls.Add(this._btnStop);
            this.Controls.Add(this._btnStart);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label _lblHttpStatus;
        private System.Windows.Forms.Label _lblTcpStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.Button _btnStop;
        private System.Windows.Forms.Button _btnGetData;
        private System.Windows.Forms.Button _btnStopGetData;
    }
}

