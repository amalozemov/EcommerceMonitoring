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
            this._panControlls.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panControlls
            // 
            this._panControlls.Controls.Add(this._btnCancel);
            this._panControlls.Controls.Add(this._btnOk);
            this._panControlls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._panControlls.Location = new System.Drawing.Point(0, 191);
            this._panControlls.Name = "_panControlls";
            this._panControlls.Size = new System.Drawing.Size(347, 51);
            this._panControlls.TabIndex = 1;
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(262, 15);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 1;
            this._btnCancel.Text = "Отменить";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOk
            // 
            this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOk.Location = new System.Drawing.Point(175, 15);
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
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название:";
            // 
            // _txtEndPointName
            // 
            this._txtEndPointName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtEndPointName.Location = new System.Drawing.Point(99, 22);
            this._txtEndPointName.Name = "_txtEndPointName";
            this._txtEndPointName.Size = new System.Drawing.Size(211, 20);
            this._txtEndPointName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Сетевое имя:";
            // 
            // _txtNetworkName
            // 
            this._txtNetworkName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNetworkName.Location = new System.Drawing.Point(99, 47);
            this._txtNetworkName.Name = "_txtNetworkName";
            this._txtNetworkName.Size = new System.Drawing.Size(211, 20);
            this._txtNetworkName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ip:";
            // 
            // _txtIp
            // 
            this._txtIp.Location = new System.Drawing.Point(99, 72);
            this._txtIp.Name = "_txtIp";
            this._txtIp.Size = new System.Drawing.Size(88, 20);
            this._txtIp.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Port:";
            // 
            // _txtPort
            // 
            this._txtPort.Location = new System.Drawing.Point(99, 97);
            this._txtPort.Name = "_txtPort";
            this._txtPort.Size = new System.Drawing.Size(88, 20);
            this._txtPort.TabIndex = 10;
            // 
            // _cmbMonitorType
            // 
            this._cmbMonitorType.FormattingEnabled = true;
            this._cmbMonitorType.Location = new System.Drawing.Point(99, 122);
            this._cmbMonitorType.Name = "_cmbMonitorType";
            this._cmbMonitorType.Size = new System.Drawing.Size(131, 21);
            this._cmbMonitorType.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Тип монитора:";
            // 
            // _cmbRequesType
            // 
            this._cmbRequesType.FormattingEnabled = true;
            this._cmbRequesType.Location = new System.Drawing.Point(99, 148);
            this._cmbRequesType.Name = "_cmbRequesType";
            this._cmbRequesType.Size = new System.Drawing.Size(131, 21);
            this._cmbRequesType.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 152);
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
            this.panel1.Location = new System.Drawing.Point(1, 189);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 1);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Location = new System.Drawing.Point(1, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(347, 1);
            this.panel2.TabIndex = 16;
            // 
            // FormEndPoint
            // 
            this.AcceptButton = this._btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(347, 242);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._cmbRequesType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._cmbMonitorType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._txtPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._txtIp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txtNetworkName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._txtEndPointName);
            this.Controls.Add(this._panControlls);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(357, 272);
            this.Name = "FormEndPoint";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormEndPoint";
            this._panControlls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}