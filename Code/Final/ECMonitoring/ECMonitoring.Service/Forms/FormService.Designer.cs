namespace ECMonitoring.Service.Forms
{
    partial class FormService
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
            this._btnApplay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._txtServiceName = new System.Windows.Forms.TextBox();
            this._txtSequnceNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._panServiceAttributes = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this._panGridWrapper = new System.Windows.Forms.Panel();
            this._dgvEndPointsList = new System.Windows.Forms.DataGridView();
            this.panInboundStreamsControls = new System.Windows.Forms.Panel();
            this._btnEditEndPoint = new System.Windows.Forms.Button();
            this.btnDeleteEndPoint = new System.Windows.Forms.Button();
            this._btnAddEndPoint = new System.Windows.Forms.Button();
            this._panControlls.SuspendLayout();
            this._panServiceAttributes.SuspendLayout();
            this._panGridWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvEndPointsList)).BeginInit();
            this.panInboundStreamsControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panControlls
            // 
            this._panControlls.Controls.Add(this._btnCancel);
            this._panControlls.Controls.Add(this._btnApplay);
            this._panControlls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._panControlls.Location = new System.Drawing.Point(15, 336);
            this._panControlls.Name = "_panControlls";
            this._panControlls.Size = new System.Drawing.Size(634, 59);
            this._panControlls.TabIndex = 0;
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(558, 18);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 1;
            this._btnCancel.Text = "Отменить";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnApplay
            // 
            this._btnApplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnApplay.Location = new System.Drawing.Point(471, 18);
            this._btnApplay.Name = "_btnApplay";
            this._btnApplay.Size = new System.Drawing.Size(75, 23);
            this._btnApplay.TabIndex = 0;
            this._btnApplay.Text = "Применить";
            this._btnApplay.UseVisualStyleBackColor = true;
            this._btnApplay.Click += new System.EventHandler(this._btnApplay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название:";
            // 
            // _txtServiceName
            // 
            this._txtServiceName.Location = new System.Drawing.Point(66, 16);
            this._txtServiceName.Name = "_txtServiceName";
            this._txtServiceName.Size = new System.Drawing.Size(211, 20);
            this._txtServiceName.TabIndex = 2;
            // 
            // _txtSequnceNumber
            // 
            this._txtSequnceNumber.Location = new System.Drawing.Point(357, 16);
            this._txtSequnceNumber.Name = "_txtSequnceNumber";
            this._txtSequnceNumber.Size = new System.Drawing.Size(73, 20);
            this._txtSequnceNumber.TabIndex = 4;
            this._txtSequnceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Порядок:";
            // 
            // _panServiceAttributes
            // 
            this._panServiceAttributes.Controls.Add(this.panel2);
            this._panServiceAttributes.Controls.Add(this.panel1);
            this._panServiceAttributes.Controls.Add(this.label3);
            this._panServiceAttributes.Controls.Add(this.label1);
            this._panServiceAttributes.Controls.Add(this._txtSequnceNumber);
            this._panServiceAttributes.Controls.Add(this._txtServiceName);
            this._panServiceAttributes.Controls.Add(this.label2);
            this._panServiceAttributes.Dock = System.Windows.Forms.DockStyle.Top;
            this._panServiceAttributes.Location = new System.Drawing.Point(15, 0);
            this._panServiceAttributes.Name = "_panServiceAttributes";
            this._panServiceAttributes.Size = new System.Drawing.Size(634, 87);
            this._panServiceAttributes.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 1);
            this.panel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 1);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Конечные точки:";
            // 
            // _panGridWrapper
            // 
            this._panGridWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._panGridWrapper.Controls.Add(this._dgvEndPointsList);
            this._panGridWrapper.Controls.Add(this.panInboundStreamsControls);
            this._panGridWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panGridWrapper.Location = new System.Drawing.Point(15, 87);
            this._panGridWrapper.Name = "_panGridWrapper";
            this._panGridWrapper.Size = new System.Drawing.Size(634, 249);
            this._panGridWrapper.TabIndex = 6;
            // 
            // _dgvEndPointsList
            // 
            this._dgvEndPointsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._dgvEndPointsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvEndPointsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvEndPointsList.Location = new System.Drawing.Point(0, 43);
            this._dgvEndPointsList.Name = "_dgvEndPointsList";
            this._dgvEndPointsList.Size = new System.Drawing.Size(632, 204);
            this._dgvEndPointsList.TabIndex = 6;
            // 
            // panInboundStreamsControls
            // 
            this.panInboundStreamsControls.BackColor = System.Drawing.SystemColors.Control;
            this.panInboundStreamsControls.Controls.Add(this._btnEditEndPoint);
            this.panInboundStreamsControls.Controls.Add(this.btnDeleteEndPoint);
            this.panInboundStreamsControls.Controls.Add(this._btnAddEndPoint);
            this.panInboundStreamsControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panInboundStreamsControls.Location = new System.Drawing.Point(0, 0);
            this.panInboundStreamsControls.Name = "panInboundStreamsControls";
            this.panInboundStreamsControls.Size = new System.Drawing.Size(632, 43);
            this.panInboundStreamsControls.TabIndex = 5;
            // 
            // _btnEditEndPoint
            // 
            this._btnEditEndPoint.AutoSize = true;
            this._btnEditEndPoint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._btnEditEndPoint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this._btnEditEndPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnEditEndPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._btnEditEndPoint.Location = new System.Drawing.Point(102, 9);
            this._btnEditEndPoint.Name = "_btnEditEndPoint";
            this._btnEditEndPoint.Size = new System.Drawing.Size(87, 25);
            this._btnEditEndPoint.TabIndex = 2;
            this._btnEditEndPoint.TabStop = false;
            this._btnEditEndPoint.Text = "Изменить";
            this._btnEditEndPoint.UseVisualStyleBackColor = true;
            this._btnEditEndPoint.Click += new System.EventHandler(this._btnEditEndPoint_Click);
            // 
            // btnDeleteEndPoint
            // 
            this.btnDeleteEndPoint.AutoSize = true;
            this.btnDeleteEndPoint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDeleteEndPoint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDeleteEndPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteEndPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteEndPoint.Location = new System.Drawing.Point(195, 9);
            this.btnDeleteEndPoint.Name = "btnDeleteEndPoint";
            this.btnDeleteEndPoint.Size = new System.Drawing.Size(87, 25);
            this.btnDeleteEndPoint.TabIndex = 3;
            this.btnDeleteEndPoint.TabStop = false;
            this.btnDeleteEndPoint.Text = "Удалить";
            this.btnDeleteEndPoint.UseVisualStyleBackColor = true;
            this.btnDeleteEndPoint.Click += new System.EventHandler(this.btnDeleteEndPoint_Click);
            // 
            // _btnAddEndPoint
            // 
            this._btnAddEndPoint.AutoSize = true;
            this._btnAddEndPoint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._btnAddEndPoint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this._btnAddEndPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._btnAddEndPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._btnAddEndPoint.Location = new System.Drawing.Point(9, 9);
            this._btnAddEndPoint.Name = "_btnAddEndPoint";
            this._btnAddEndPoint.Size = new System.Drawing.Size(87, 25);
            this._btnAddEndPoint.TabIndex = 1;
            this._btnAddEndPoint.TabStop = false;
            this._btnAddEndPoint.Text = "Добавить";
            this._btnAddEndPoint.UseVisualStyleBackColor = true;
            this._btnAddEndPoint.Click += new System.EventHandler(this._btnAddEndPoint_Click);
            // 
            // FormService
            // 
            this.AcceptButton = this._btnApplay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(664, 395);
            this.Controls.Add(this._panGridWrapper);
            this.Controls.Add(this._panServiceAttributes);
            this.Controls.Add(this._panControlls);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(490, 250);
            this.Name = "FormService";
            this.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormService";
            this._panControlls.ResumeLayout(false);
            this._panServiceAttributes.ResumeLayout(false);
            this._panServiceAttributes.PerformLayout();
            this._panGridWrapper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvEndPointsList)).EndInit();
            this.panInboundStreamsControls.ResumeLayout(false);
            this.panInboundStreamsControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _panControlls;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnApplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtServiceName;
        private System.Windows.Forms.TextBox _txtSequnceNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel _panServiceAttributes;
        private System.Windows.Forms.Panel _panGridWrapper;
        private System.Windows.Forms.Panel panInboundStreamsControls;
        private System.Windows.Forms.Button _btnEditEndPoint;
        private System.Windows.Forms.Button btnDeleteEndPoint;
        private System.Windows.Forms.Button _btnAddEndPoint;
        private System.Windows.Forms.DataGridView _dgvEndPointsList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}