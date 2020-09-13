namespace ECMonitoring.Service.Forms
{
    partial class FormServicesList
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
            this._btnServiceCreate = new System.Windows.Forms.ToolStripButton();
            this._btnServiceEdit = new System.Windows.Forms.ToolStripButton();
            this._btnRemoveService = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this._dgvServices = new System.Windows.Forms.DataGridView();
            this.toolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvServices)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnServiceCreate,
            this._btnServiceEdit,
            this._btnRemoveService});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip.Size = new System.Drawing.Size(577, 25);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            // 
            // _btnServiceCreate
            // 
            this._btnServiceCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnServiceCreate.Name = "_btnServiceCreate";
            this._btnServiceCreate.Size = new System.Drawing.Size(54, 22);
            this._btnServiceCreate.Text = "Создать";
            // 
            // _btnServiceEdit
            // 
            this._btnServiceEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnServiceEdit.Name = "_btnServiceEdit";
            this._btnServiceEdit.Size = new System.Drawing.Size(90, 22);
            this._btnServiceEdit.Text = "Редактировать";
            this._btnServiceEdit.Click += new System.EventHandler(this._btnServiceEdit_Click);
            // 
            // _btnRemoveService
            // 
            this._btnRemoveService.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnRemoveService.Name = "_btnRemoveService";
            this._btnRemoveService.Size = new System.Drawing.Size(55, 22);
            this._btnRemoveService.Text = "Удалить";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._dgvServices);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(577, 300);
            this.panel1.TabIndex = 5;
            // 
            // _dgvServices
            // 
            this._dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvServices.Location = new System.Drawing.Point(52, 50);
            this._dgvServices.Name = "_dgvServices";
            this._dgvServices.Size = new System.Drawing.Size(240, 150);
            this._dgvServices.TabIndex = 0;
            // 
            // FormServicesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 325);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormServicesList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список сервисов";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton _btnServiceCreate;
        private System.Windows.Forms.ToolStripButton _btnServiceEdit;
        private System.Windows.Forms.ToolStripButton _btnRemoveService;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView _dgvServices;
    }
}