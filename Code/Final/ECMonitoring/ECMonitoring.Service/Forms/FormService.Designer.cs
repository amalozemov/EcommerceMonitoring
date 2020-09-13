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
            this._btnApplay = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._txtServiceName = new System.Windows.Forms.TextBox();
            this._txtSequnceNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._panServiceAttributes = new System.Windows.Forms.Panel();
            this._panGridWrapper = new System.Windows.Forms.Panel();
            this.panInboundStreamsControls = new System.Windows.Forms.Panel();
            this.btnStopInboundStream = new System.Windows.Forms.Button();
            this.btnStopAllInboundStream = new System.Windows.Forms.Button();
            this.btnAllStreamsList = new System.Windows.Forms.Button();
            this._dgvEndPointsList = new System.Windows.Forms.DataGridView();
            this._panControlls.SuspendLayout();
            this._panServiceAttributes.SuspendLayout();
            this._panGridWrapper.SuspendLayout();
            this.panInboundStreamsControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvEndPointsList)).BeginInit();
            this.SuspendLayout();
            // 
            // _panControlls
            // 
            this._panControlls.Controls.Add(this._btnCancel);
            this._panControlls.Controls.Add(this._btnApplay);
            this._panControlls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._panControlls.Location = new System.Drawing.Point(0, 336);
            this._panControlls.Name = "_panControlls";
            this._panControlls.Size = new System.Drawing.Size(664, 59);
            this._panControlls.TabIndex = 0;
            // 
            // _btnApplay
            // 
            this._btnApplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnApplay.Location = new System.Drawing.Point(481, 18);
            this._btnApplay.Name = "_btnApplay";
            this._btnApplay.Size = new System.Drawing.Size(75, 23);
            this._btnApplay.TabIndex = 0;
            this._btnApplay.Text = "Применить";
            this._btnApplay.UseVisualStyleBackColor = true;
            this._btnApplay.Click += new System.EventHandler(this._btnApplay_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(568, 18);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 1;
            this._btnCancel.Text = "Отменить";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название:";
            // 
            // _txtServiceName
            // 
            this._txtServiceName.Location = new System.Drawing.Point(81, 16);
            this._txtServiceName.Name = "_txtServiceName";
            this._txtServiceName.Size = new System.Drawing.Size(211, 20);
            this._txtServiceName.TabIndex = 2;
            // 
            // _txtSequnceNumber
            // 
            this._txtSequnceNumber.Location = new System.Drawing.Point(372, 16);
            this._txtSequnceNumber.Name = "_txtSequnceNumber";
            this._txtSequnceNumber.Size = new System.Drawing.Size(73, 20);
            this._txtSequnceNumber.TabIndex = 4;
            this._txtSequnceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Порядок:";
            // 
            // _panServiceAttributes
            // 
            this._panServiceAttributes.Controls.Add(this.label1);
            this._panServiceAttributes.Controls.Add(this._txtSequnceNumber);
            this._panServiceAttributes.Controls.Add(this._txtServiceName);
            this._panServiceAttributes.Controls.Add(this.label2);
            this._panServiceAttributes.Dock = System.Windows.Forms.DockStyle.Top;
            this._panServiceAttributes.Location = new System.Drawing.Point(0, 0);
            this._panServiceAttributes.Name = "_panServiceAttributes";
            this._panServiceAttributes.Size = new System.Drawing.Size(664, 60);
            this._panServiceAttributes.TabIndex = 5;
            // 
            // _panGridWrapper
            // 
            this._panGridWrapper.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._panGridWrapper.Controls.Add(this._dgvEndPointsList);
            this._panGridWrapper.Controls.Add(this.panInboundStreamsControls);
            this._panGridWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panGridWrapper.Location = new System.Drawing.Point(0, 60);
            this._panGridWrapper.Name = "_panGridWrapper";
            this._panGridWrapper.Size = new System.Drawing.Size(664, 276);
            this._panGridWrapper.TabIndex = 6;
            // 
            // panInboundStreamsControls
            // 
            this.panInboundStreamsControls.BackColor = System.Drawing.SystemColors.Control;
            this.panInboundStreamsControls.Controls.Add(this.btnStopInboundStream);
            this.panInboundStreamsControls.Controls.Add(this.btnStopAllInboundStream);
            this.panInboundStreamsControls.Controls.Add(this.btnAllStreamsList);
            this.panInboundStreamsControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panInboundStreamsControls.Location = new System.Drawing.Point(0, 0);
            this.panInboundStreamsControls.Name = "panInboundStreamsControls";
            this.panInboundStreamsControls.Size = new System.Drawing.Size(660, 30);
            this.panInboundStreamsControls.TabIndex = 5;
            // 
            // btnStopInboundStream
            // 
            this.btnStopInboundStream.AutoSize = true;
            this.btnStopInboundStream.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStopInboundStream.FlatAppearance.BorderSize = 0;
            this.btnStopInboundStream.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnStopInboundStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopInboundStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStopInboundStream.Location = new System.Drawing.Point(81, 3);
            this.btnStopInboundStream.Name = "btnStopInboundStream";
            this.btnStopInboundStream.Size = new System.Drawing.Size(87, 25);
            this.btnStopInboundStream.TabIndex = 2;
            this.btnStopInboundStream.TabStop = false;
            this.btnStopInboundStream.Text = "Изменить";
            this.btnStopInboundStream.UseVisualStyleBackColor = true;
            // 
            // btnStopAllInboundStream
            // 
            this.btnStopAllInboundStream.AutoSize = true;
            this.btnStopAllInboundStream.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStopAllInboundStream.FlatAppearance.BorderSize = 0;
            this.btnStopAllInboundStream.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnStopAllInboundStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopAllInboundStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStopAllInboundStream.Location = new System.Drawing.Point(164, 3);
            this.btnStopAllInboundStream.Name = "btnStopAllInboundStream";
            this.btnStopAllInboundStream.Size = new System.Drawing.Size(87, 25);
            this.btnStopAllInboundStream.TabIndex = 3;
            this.btnStopAllInboundStream.TabStop = false;
            this.btnStopAllInboundStream.Text = "Удалить";
            this.btnStopAllInboundStream.UseVisualStyleBackColor = true;
            // 
            // btnAllStreamsList
            // 
            this.btnAllStreamsList.AutoSize = true;
            this.btnAllStreamsList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAllStreamsList.FlatAppearance.BorderSize = 0;
            this.btnAllStreamsList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAllStreamsList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllStreamsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAllStreamsList.Location = new System.Drawing.Point(9, 3);
            this.btnAllStreamsList.Name = "btnAllStreamsList";
            this.btnAllStreamsList.Size = new System.Drawing.Size(87, 25);
            this.btnAllStreamsList.TabIndex = 1;
            this.btnAllStreamsList.TabStop = false;
            this.btnAllStreamsList.Text = "Добавить";
            this.btnAllStreamsList.UseVisualStyleBackColor = true;
            // 
            // _dgvEndPointsList
            // 
            this._dgvEndPointsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._dgvEndPointsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvEndPointsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvEndPointsList.Location = new System.Drawing.Point(0, 30);
            this._dgvEndPointsList.Name = "_dgvEndPointsList";
            this._dgvEndPointsList.Size = new System.Drawing.Size(660, 242);
            this._dgvEndPointsList.TabIndex = 6;
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
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormService";
            this._panControlls.ResumeLayout(false);
            this._panServiceAttributes.ResumeLayout(false);
            this._panServiceAttributes.PerformLayout();
            this._panGridWrapper.ResumeLayout(false);
            this.panInboundStreamsControls.ResumeLayout(false);
            this.panInboundStreamsControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvEndPointsList)).EndInit();
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
        private System.Windows.Forms.Button btnStopInboundStream;
        private System.Windows.Forms.Button btnStopAllInboundStream;
        private System.Windows.Forms.Button btnAllStreamsList;
        private System.Windows.Forms.DataGridView _dgvEndPointsList;
    }
}