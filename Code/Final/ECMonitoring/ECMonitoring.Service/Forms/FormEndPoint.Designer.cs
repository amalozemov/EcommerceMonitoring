namespace ECMonitoring.Service.Forms
{
    partial class FormEndPoint
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
            this._panControlls = new System.Windows.Forms.Panel();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._txtEndPointName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._txtNetworkName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._txtIp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._txtPort = new System.Windows.Forms.TextBox();
            this._cmbMonitorType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this._cmbRequesType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this._txtConnectorName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._chkIsDisabledEndPoint = new System.Windows.Forms.CheckBox();
            this._txtHostUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._txtHostPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._panControlls.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panControlls
            // 
            this._panControlls.Controls.Add(this._btnCancel);
            this._panControlls.Controls.Add(this._btnOk);
            this._panControlls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._panControlls.Location = new System.Drawing.Point(25, 404);
            this._panControlls.Name = "_panControlls";
            this._panControlls.Size = new System.Drawing.Size(297, 51);
            this._panControlls.TabIndex = 1;
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(221, 15);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 1;
            this._btnCancel.Text = "Отменить";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOk
            // 
            this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOk.Location = new System.Drawing.Point(134, 15);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 0;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название:";
            // 
            // _txtEndPointName
            // 
            this._txtEndPointName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtEndPointName.Location = new System.Drawing.Point(92, 19);
            this._txtEndPointName.Name = "_txtEndPointName";
            this._txtEndPointName.Size = new System.Drawing.Size(199, 20);
            this._txtEndPointName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Сетевое имя:";
            // 
            // _txtNetworkName
            // 
            this._txtNetworkName.Location = new System.Drawing.Point(92, 71);
            this._txtNetworkName.Name = "_txtNetworkName";
            this._txtNetworkName.Size = new System.Drawing.Size(131, 20);
            this._txtNetworkName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ip:";
            // 
            // _txtIp
            // 
            this._txtIp.Location = new System.Drawing.Point(92, 19);
            this._txtIp.Name = "_txtIp";
            this._txtIp.Size = new System.Drawing.Size(131, 20);
            this._txtIp.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Port:";
            // 
            // _txtPort
            // 
            this._txtPort.Location = new System.Drawing.Point(92, 45);
            this._txtPort.Name = "_txtPort";
            this._txtPort.Size = new System.Drawing.Size(131, 20);
            this._txtPort.TabIndex = 10;
            // 
            // _cmbMonitorType
            // 
            this._cmbMonitorType.FormattingEnabled = true;
            this._cmbMonitorType.Location = new System.Drawing.Point(92, 45);
            this._cmbMonitorType.Name = "_cmbMonitorType";
            this._cmbMonitorType.Size = new System.Drawing.Size(131, 21);
            this._cmbMonitorType.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Тип монитора:";
            // 
            // _cmbRequesType
            // 
            this._cmbRequesType.FormattingEnabled = true;
            this._cmbRequesType.Location = new System.Drawing.Point(92, 72);
            this._cmbRequesType.Name = "_cmbRequesType";
            this._cmbRequesType.Size = new System.Drawing.Size(131, 21);
            this._cmbRequesType.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Тип запроса:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Location = new System.Drawing.Point(26, 402);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 1);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Location = new System.Drawing.Point(26, 403);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 1);
            this.panel2.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this._txtConnectorName);
            this.groupBox1.Location = new System.Drawing.Point(25, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 56);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Коннектор";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Имя:";
            // 
            // _txtConnectorName
            // 
            this._txtConnectorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtConnectorName.Location = new System.Drawing.Point(44, 19);
            this._txtConnectorName.Name = "_txtConnectorName";
            this._txtConnectorName.Size = new System.Drawing.Size(247, 20);
            this._txtConnectorName.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this._chkIsDisabledEndPoint);
            this.groupBox2.Controls.Add(this._txtEndPointName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this._cmbMonitorType);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this._cmbRequesType);
            this.groupBox2.Location = new System.Drawing.Point(25, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 132);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Конечная точка";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this._txtHostPassword);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this._txtHostUserName);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this._txtPort);
            this.groupBox3.Controls.Add(this._txtIp);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this._txtNetworkName);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(25, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(297, 156);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Хост";
            // 
            // _chkIsDisabledEndPoint
            // 
            this._chkIsDisabledEndPoint.AutoSize = true;
            this._chkIsDisabledEndPoint.Location = new System.Drawing.Point(11, 101);
            this._chkIsDisabledEndPoint.Name = "_chkIsDisabledEndPoint";
            this._chkIsDisabledEndPoint.Size = new System.Drawing.Size(81, 17);
            this._chkIsDisabledEndPoint.TabIndex = 16;
            this._chkIsDisabledEndPoint.Text = "Отключить";
            this._chkIsDisabledEndPoint.UseVisualStyleBackColor = true;
            // 
            // _txtHostUserName
            // 
            this._txtHostUserName.Location = new System.Drawing.Point(92, 97);
            this._txtHostUserName.Name = "_txtHostUserName";
            this._txtHostUserName.Size = new System.Drawing.Size(131, 20);
            this._txtHostUserName.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Логин:";
            // 
            // _txtHostPassword
            // 
            this._txtHostPassword.Location = new System.Drawing.Point(92, 123);
            this._txtHostPassword.Name = "_txtHostPassword";
            this._txtHostPassword.Size = new System.Drawing.Size(131, 20);
            this._txtHostPassword.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Пароль:";
            // 
            // FormEndPoint
            // 
            this.AcceptButton = this._btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(347, 455);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._panControlls);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(357, 485);
            this.Name = "FormEndPoint";
            this.Padding = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormEndPoint";
            this._panControlls.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _panControlls;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtEndPointName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtNetworkName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtIp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _txtPort;
        private System.Windows.Forms.ComboBox _cmbMonitorType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _cmbRequesType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _txtConnectorName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox _chkIsDisabledEndPoint;
        private System.Windows.Forms.TextBox _txtHostPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox _txtHostUserName;
        private System.Windows.Forms.Label label8;
    }
}