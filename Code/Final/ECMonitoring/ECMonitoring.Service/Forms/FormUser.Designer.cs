namespace ECMonitoring.Service.Forms
{
    partial class FormUser
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
            this.panel1 = new System.Windows.Forms.Panel();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnApplay = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this._txtNewPassword = new System.Windows.Forms.TextBox();
            this._lblNewPassword = new System.Windows.Forms.Label();
            this._txtPassword = new System.Windows.Forms.TextBox();
            this._lblName = new System.Windows.Forms.Label();
            this._lblPassword = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._panControlls.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panControlls
            // 
            this._panControlls.Controls.Add(this.panel1);
            this._panControlls.Controls.Add(this._btnCancel);
            this._panControlls.Controls.Add(this._btnApplay);
            this._panControlls.Controls.Add(this.panel3);
            this._panControlls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._panControlls.Location = new System.Drawing.Point(0, 137);
            this._panControlls.Name = "_panControlls";
            this._panControlls.Size = new System.Drawing.Size(450, 50);
            this._panControlls.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 1);
            this.panel1.TabIndex = 9;
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(374, 15);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 1;
            this._btnCancel.Text = "Отменить";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnApplay
            // 
            this._btnApplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnApplay.Location = new System.Drawing.Point(287, 15);
            this._btnApplay.Name = "_btnApplay";
            this._btnApplay.Size = new System.Drawing.Size(75, 23);
            this._btnApplay.TabIndex = 0;
            this._btnApplay.Text = "Применить";
            this._btnApplay.UseVisualStyleBackColor = true;
            this._btnApplay.Click += new System.EventHandler(this._btnApplay_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(450, 1);
            this.panel3.TabIndex = 10;
            // 
            // tlpMain
            // 
            this.tlpMain.AutoSize = true;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this._txtNewPassword, 1, 2);
            this.tlpMain.Controls.Add(this._lblNewPassword, 0, 2);
            this.tlpMain.Controls.Add(this._txtPassword, 1, 1);
            this.tlpMain.Controls.Add(this._lblName, 0, 0);
            this.tlpMain.Controls.Add(this._lblPassword, 0, 1);
            this.tlpMain.Controls.Add(this._txtName, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMain.Location = new System.Drawing.Point(0, 15);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(450, 90);
            this.tlpMain.TabIndex = 6;
            // 
            // _txtNewPassword
            // 
            this._txtNewPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtNewPassword.Location = new System.Drawing.Point(94, 65);
            this._txtNewPassword.Margin = new System.Windows.Forms.Padding(5);
            this._txtNewPassword.Name = "_txtNewPassword";
            this._txtNewPassword.Size = new System.Drawing.Size(351, 20);
            this._txtNewPassword.TabIndex = 2;
            this._txtNewPassword.UseSystemPasswordChar = true;
            // 
            // _lblNewPassword
            // 
            this._lblNewPassword.AutoSize = true;
            this._lblNewPassword.Dock = System.Windows.Forms.DockStyle.Right;
            this._lblNewPassword.Location = new System.Drawing.Point(3, 63);
            this._lblNewPassword.Margin = new System.Windows.Forms.Padding(3);
            this._lblNewPassword.Name = "_lblNewPassword";
            this._lblNewPassword.Size = new System.Drawing.Size(83, 24);
            this._lblNewPassword.TabIndex = 13;
            this._lblNewPassword.Text = "Новый пароль:";
            this._lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtPassword
            // 
            this._txtPassword.AcceptsReturn = true;
            this._txtPassword.CausesValidation = false;
            this._txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtPassword.Location = new System.Drawing.Point(94, 35);
            this._txtPassword.Margin = new System.Windows.Forms.Padding(5);
            this._txtPassword.Name = "_txtPassword";
            this._txtPassword.Size = new System.Drawing.Size(351, 20);
            this._txtPassword.TabIndex = 1;
            this._txtPassword.UseSystemPasswordChar = true;
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Dock = System.Windows.Forms.DockStyle.Right;
            this._lblName.Location = new System.Drawing.Point(54, 3);
            this._lblName.Margin = new System.Windows.Forms.Padding(3);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(32, 24);
            this._lblName.TabIndex = 11;
            this._lblName.Text = "Имя:";
            this._lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _lblPassword
            // 
            this._lblPassword.AutoSize = true;
            this._lblPassword.Dock = System.Windows.Forms.DockStyle.Right;
            this._lblPassword.Location = new System.Drawing.Point(38, 33);
            this._lblPassword.Margin = new System.Windows.Forms.Padding(3);
            this._lblPassword.Name = "_lblPassword";
            this._lblPassword.Size = new System.Drawing.Size(48, 24);
            this._lblPassword.TabIndex = 10;
            this._lblPassword.Text = "Пароль:";
            this._lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _txtName
            // 
            this._txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtName.Location = new System.Drawing.Point(94, 5);
            this._txtName.Margin = new System.Windows.Forms.Padding(5);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(351, 20);
            this._txtName.TabIndex = 0;
            // 
            // FormUser
            // 
            this.AcceptButton = this._btnApplay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(450, 187);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this._panControlls);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(460, 217);
            this.Name = "FormUser";
            this.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormUser";
            this._panControlls.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _panControlls;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnApplay;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TextBox _txtNewPassword;
        private System.Windows.Forms.Label _lblNewPassword;
        private System.Windows.Forms.TextBox _txtPassword;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.Label _lblPassword;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
    }
}