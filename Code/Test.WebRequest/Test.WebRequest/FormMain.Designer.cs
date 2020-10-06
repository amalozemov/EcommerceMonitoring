namespace Test.WebRequest
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
            this.label1 = new System.Windows.Forms.Label();
            this._txtUrl = new System.Windows.Forms.TextBox();
            this._txtParams = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this._lblTimeRun = new System.Windows.Forms.Label();
            this._lblResult = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._txtPeriod = new System.Windows.Forms.TextBox();
            this._btnGo = new System.Windows.Forms.Button();
            this._btnStop = new System.Windows.Forms.Button();
            this._lblMaxTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Url";
            // 
            // _txtUrl
            // 
            this._txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtUrl.Location = new System.Drawing.Point(66, 37);
            this._txtUrl.Name = "_txtUrl";
            this._txtUrl.Size = new System.Drawing.Size(668, 20);
            this._txtUrl.TabIndex = 1;
            // 
            // _txtParams
            // 
            this._txtParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtParams.Location = new System.Drawing.Point(66, 87);
            this._txtParams.Name = "_txtParams";
            this._txtParams.Size = new System.Drawing.Size(668, 20);
            this._txtParams.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Параметры";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(659, 129);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Выполнить";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // _lblTimeRun
            // 
            this._lblTimeRun.AutoSize = true;
            this._lblTimeRun.Location = new System.Drawing.Point(63, 129);
            this._lblTimeRun.Name = "_lblTimeRun";
            this._lblTimeRun.Size = new System.Drawing.Size(108, 13);
            this._lblTimeRun.TabIndex = 5;
            this._lblTimeRun.Text = "Время выполнения:";
            // 
            // _lblResult
            // 
            this._lblResult.AutoSize = true;
            this._lblResult.Location = new System.Drawing.Point(66, 158);
            this._lblResult.Name = "_lblResult";
            this._lblResult.Size = new System.Drawing.Size(62, 13);
            this._lblResult.TabIndex = 6;
            this._lblResult.Text = "Результат:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Период (ms):";
            // 
            // _txtPeriod
            // 
            this._txtPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPeriod.Location = new System.Drawing.Point(165, 211);
            this._txtPeriod.Name = "_txtPeriod";
            this._txtPeriod.Size = new System.Drawing.Size(148, 20);
            this._txtPeriod.TabIndex = 8;
            this._txtPeriod.Text = "2000";
            // 
            // _btnGo
            // 
            this._btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnGo.Location = new System.Drawing.Point(579, 247);
            this._btnGo.Name = "_btnGo";
            this._btnGo.Size = new System.Drawing.Size(75, 23);
            this._btnGo.TabIndex = 9;
            this._btnGo.Text = "Старт";
            this._btnGo.UseVisualStyleBackColor = true;
            this._btnGo.Click += new System.EventHandler(this._btnGo_Click);
            // 
            // _btnStop
            // 
            this._btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnStop.Enabled = false;
            this._btnStop.Location = new System.Drawing.Point(660, 247);
            this._btnStop.Name = "_btnStop";
            this._btnStop.Size = new System.Drawing.Size(75, 23);
            this._btnStop.TabIndex = 10;
            this._btnStop.Text = "Стоп";
            this._btnStop.UseVisualStyleBackColor = true;
            this._btnStop.Click += new System.EventHandler(this._btnStop_Click);
            // 
            // _lblMaxTime
            // 
            this._lblMaxTime.AutoSize = true;
            this._lblMaxTime.Location = new System.Drawing.Point(66, 280);
            this._lblMaxTime.Name = "_lblMaxTime";
            this._lblMaxTime.Size = new System.Drawing.Size(144, 13);
            this._lblMaxTime.TabIndex = 11;
            this._lblMaxTime.Text = "Максимальное время (ms):";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._lblMaxTime);
            this.Controls.Add(this._btnStop);
            this.Controls.Add(this._btnGo);
            this.Controls.Add(this._txtPeriod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._lblResult);
            this.Controls.Add(this._lblTimeRun);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this._txtParams);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txtUrl);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtUrl;
        private System.Windows.Forms.TextBox _txtParams;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label _lblTimeRun;
        private System.Windows.Forms.Label _lblResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtPeriod;
        private System.Windows.Forms.Button _btnGo;
        private System.Windows.Forms.Button _btnStop;
        private System.Windows.Forms.Label _lblMaxTime;
    }
}

