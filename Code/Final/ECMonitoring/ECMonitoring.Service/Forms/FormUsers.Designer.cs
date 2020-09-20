namespace ECMonitoring.Service.Forms
{
    partial class FormUsers
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnUserCreate = new System.Windows.Forms.ToolStripButton();
            this.btnUserEdit = new System.Windows.Forms.ToolStripButton();
            this.btnUserChangePassword = new System.Windows.Forms.ToolStripButton();
            this.btnUserDelete = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._dgvUsers = new System.Windows.Forms.DataGridView();
            this.toolStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUserCreate,
            this.btnUserEdit,
            this.btnUserChangePassword,
            this.btnUserDelete});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip.Size = new System.Drawing.Size(595, 25);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnUserCreate
            // 
            this.btnUserCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUserCreate.Name = "btnUserCreate";
            this.btnUserCreate.Size = new System.Drawing.Size(54, 22);
            this.btnUserCreate.Text = "Создать";
            this.btnUserCreate.Click += new System.EventHandler(this.btnUserCreate_Click);
            // 
            // btnUserEdit
            // 
            this.btnUserEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUserEdit.Name = "btnUserEdit";
            this.btnUserEdit.Size = new System.Drawing.Size(90, 22);
            this.btnUserEdit.Text = "Редактировать";
            this.btnUserEdit.Click += new System.EventHandler(this.btnUserEdit_Click);
            // 
            // btnUserChangePassword
            // 
            this.btnUserChangePassword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUserChangePassword.Name = "btnUserChangePassword";
            this.btnUserChangePassword.Size = new System.Drawing.Size(93, 22);
            this.btnUserChangePassword.Text = "Сменить пароль";
            this.btnUserChangePassword.Click += new System.EventHandler(this.btnUserChangePassword_Click);
            // 
            // btnUserDelete
            // 
            this.btnUserDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUserDelete.Name = "btnUserDelete";
            this.btnUserDelete.Size = new System.Drawing.Size(55, 22);
            this.btnUserDelete.Text = "Удалить";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._dgvUsers);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 169);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пользователи";
            // 
            // _dgvUsers
            // 
            this._dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvUsers.Location = new System.Drawing.Point(3, 16);
            this._dgvUsers.Name = "_dgvUsers";
            this._dgvUsers.Size = new System.Drawing.Size(270, 141);
            this._dgvUsers.TabIndex = 0;
            // 
            // FormUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 194);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(605, 224);
            this.Name = "FormUsers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Пользователи";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnUserCreate;
        private System.Windows.Forms.ToolStripButton btnUserEdit;
        private System.Windows.Forms.ToolStripButton btnUserChangePassword;
        private System.Windows.Forms.ToolStripButton btnUserDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView _dgvUsers;
    }
}