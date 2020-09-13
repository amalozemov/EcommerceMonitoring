namespace ECMonitoring.Service.Forms
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._mnuApp = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuAppExit = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuRun = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuStop = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuServices = new System.Windows.Forms.ToolStripMenuItem();
            this.разделительToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this._mnuUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mnuAbuotProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this._lblAmountEndPointsDes = new System.Windows.Forms.Label();
            this._lblCoreStatus = new System.Windows.Forms.Label();
            this._lblAmountEndPoints = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this._lblHostStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this._lblAmountEndServices = new System.Windows.Forms.Label();
            this._lblAmountEndServicesDes = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuApp,
            this.управлениеToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(488, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _mnuApp
            // 
            this._mnuApp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuAppExit});
            this._mnuApp.Name = "_mnuApp";
            this._mnuApp.Size = new System.Drawing.Size(82, 20);
            this._mnuApp.Text = "Приложение";
            // 
            // _mnuAppExit
            // 
            this._mnuAppExit.Name = "_mnuAppExit";
            this._mnuAppExit.Size = new System.Drawing.Size(107, 22);
            this._mnuAppExit.Text = "Выход";
            this._mnuAppExit.Click += new System.EventHandler(this._mnuAppExit_Click);
            // 
            // управлениеToolStripMenuItem
            // 
            this.управлениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сервисToolStripMenuItem,
            this._mnuServices,
            this.разделительToolStripMenuItem,
            this._mnuUsers});
            this.управлениеToolStripMenuItem.Name = "управлениеToolStripMenuItem";
            this.управлениеToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.управлениеToolStripMenuItem.Text = "Управление";
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuRun,
            this._mnuStop});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.сервисToolStripMenuItem.Text = "Ядро";
            // 
            // _mnuRun
            // 
            this._mnuRun.Name = "_mnuRun";
            this._mnuRun.Size = new System.Drawing.Size(99, 22);
            this._mnuRun.Text = "Пуск";
            this._mnuRun.Click += new System.EventHandler(this._mnuRun_Click);
            // 
            // _mnuStop
            // 
            this._mnuStop.Name = "_mnuStop";
            this._mnuStop.Size = new System.Drawing.Size(99, 22);
            this._mnuStop.Text = "Стоп";
            this._mnuStop.Click += new System.EventHandler(this._mnuStop_Click);
            // 
            // _mnuServices
            // 
            this._mnuServices.Name = "_mnuServices";
            this._mnuServices.Size = new System.Drawing.Size(146, 22);
            this._mnuServices.Text = "Сервисы";
            this._mnuServices.Click += new System.EventHandler(this._mnuServices_Click);
            // 
            // разделительToolStripMenuItem
            // 
            this.разделительToolStripMenuItem.Name = "разделительToolStripMenuItem";
            this.разделительToolStripMenuItem.Size = new System.Drawing.Size(143, 6);
            // 
            // _mnuUsers
            // 
            this._mnuUsers.Name = "_mnuUsers";
            this._mnuUsers.Size = new System.Drawing.Size(146, 22);
            this._mnuUsers.Text = "Пользователи";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuAbuotProgram});
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // _mnuAbuotProgram
            // 
            this._mnuAbuotProgram.Name = "_mnuAbuotProgram";
            this._mnuAbuotProgram.Size = new System.Drawing.Size(137, 22);
            this._mnuAbuotProgram.Text = "Информация";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(-4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ядро:";
            // 
            // _lblAmountEndPointsDes
            // 
            this._lblAmountEndPointsDes.AutoSize = true;
            this._lblAmountEndPointsDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._lblAmountEndPointsDes.Location = new System.Drawing.Point(-4, 0);
            this._lblAmountEndPointsDes.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this._lblAmountEndPointsDes.Name = "_lblAmountEndPointsDes";
            this._lblAmountEndPointsDes.Size = new System.Drawing.Size(134, 20);
            this._lblAmountEndPointsDes.TabIndex = 2;
            this._lblAmountEndPointsDes.Text = "Конечных точек:";
            // 
            // _lblCoreStatus
            // 
            this._lblCoreStatus.AutoSize = true;
            this._lblCoreStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this._lblCoreStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._lblCoreStatus.Location = new System.Drawing.Point(94, 0);
            this._lblCoreStatus.Name = "_lblCoreStatus";
            this._lblCoreStatus.Size = new System.Drawing.Size(82, 20);
            this._lblCoreStatus.TabIndex = 3;
            this._lblCoreStatus.Text = "Работает";
            this._lblCoreStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _lblAmountEndPoints
            // 
            this._lblAmountEndPoints.AutoSize = true;
            this._lblAmountEndPoints.Dock = System.Windows.Forms.DockStyle.Right;
            this._lblAmountEndPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._lblAmountEndPoints.Location = new System.Drawing.Point(149, 0);
            this._lblAmountEndPoints.Name = "_lblAmountEndPoints";
            this._lblAmountEndPoints.Size = new System.Drawing.Size(27, 20);
            this._lblAmountEndPoints.TabIndex = 4;
            this._lblAmountEndPoints.Text = "45";
            this._lblAmountEndPoints.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this._lblCoreStatus);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 27);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this._lblAmountEndPoints);
            this.panel2.Controls.Add(this._lblAmountEndPointsDes);
            this.panel2.Location = new System.Drawing.Point(13, 124);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 27);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this._lblHostStatus);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(13, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(176, 27);
            this.panel3.TabIndex = 7;
            // 
            // _lblHostStatus
            // 
            this._lblHostStatus.AutoSize = true;
            this._lblHostStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this._lblHostStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._lblHostStatus.Location = new System.Drawing.Point(94, 0);
            this._lblHostStatus.Name = "_lblHostStatus";
            this._lblHostStatus.Size = new System.Drawing.Size(82, 20);
            this._lblHostStatus.TabIndex = 3;
            this._lblHostStatus.Text = "Работает";
            this._lblHostStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(-4, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Хост:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this._lblAmountEndServices);
            this.panel4.Controls.Add(this._lblAmountEndServicesDes);
            this.panel4.Location = new System.Drawing.Point(13, 94);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(176, 27);
            this.panel4.TabIndex = 8;
            // 
            // _lblAmountEndServices
            // 
            this._lblAmountEndServices.AutoSize = true;
            this._lblAmountEndServices.Dock = System.Windows.Forms.DockStyle.Right;
            this._lblAmountEndServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._lblAmountEndServices.Location = new System.Drawing.Point(149, 0);
            this._lblAmountEndServices.Name = "_lblAmountEndServices";
            this._lblAmountEndServices.Size = new System.Drawing.Size(27, 20);
            this._lblAmountEndServices.TabIndex = 4;
            this._lblAmountEndServices.Text = "45";
            this._lblAmountEndServices.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _lblAmountEndServicesDes
            // 
            this._lblAmountEndServicesDes.AutoSize = true;
            this._lblAmountEndServicesDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._lblAmountEndServicesDes.Location = new System.Drawing.Point(-4, 0);
            this._lblAmountEndServicesDes.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this._lblAmountEndServicesDes.Name = "_lblAmountEndServicesDes";
            this._lblAmountEndServicesDes.Size = new System.Drawing.Size(86, 20);
            this._lblAmountEndServicesDes.TabIndex = 2;
            this._lblAmountEndServicesDes.Text = "Сервисов:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 158);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _mnuApp;
        private System.Windows.Forms.ToolStripMenuItem _mnuAppExit;
        private System.Windows.Forms.ToolStripMenuItem управлениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mnuServices;
        private System.Windows.Forms.ToolStripMenuItem _mnuRun;
        private System.Windows.Forms.ToolStripMenuItem _mnuStop;
        private System.Windows.Forms.ToolStripSeparator разделительToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mnuUsers;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mnuAbuotProgram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lblAmountEndPointsDes;
        private System.Windows.Forms.Label _lblCoreStatus;
        private System.Windows.Forms.Label _lblAmountEndPoints;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label _lblHostStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label _lblAmountEndServices;
        private System.Windows.Forms.Label _lblAmountEndServicesDes;
    }
}