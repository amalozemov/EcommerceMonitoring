namespace EntityFramework.DataFirst
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
            this.button1 = new System.Windows.Forms.Button();
            this._btnAddProduct = new System.Windows.Forms.Button();
            this._btnChangProduct = new System.Windows.Forms.Button();
            this._btnDeleteProduct = new System.Windows.Forms.Button();
            this._btnAddProduct2 = new System.Windows.Forms.Button();
            this._btnViewProducts2 = new System.Windows.Forms.Button();
            this._btnDeleteProduct2 = new System.Windows.Forms.Button();
            this._btnChangProduct2 = new System.Windows.Forms.Button();
            this._btnRollback = new System.Windows.Forms.Button();
            this._btnCommit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Просмотреть продукты";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _btnAddProduct
            // 
            this._btnAddProduct.Location = new System.Drawing.Point(87, 39);
            this._btnAddProduct.Name = "_btnAddProduct";
            this._btnAddProduct.Size = new System.Drawing.Size(112, 23);
            this._btnAddProduct.TabIndex = 1;
            this._btnAddProduct.Text = "Добавить продукт";
            this._btnAddProduct.UseVisualStyleBackColor = true;
            this._btnAddProduct.Click += new System.EventHandler(this._btnAddProduct_Click);
            // 
            // _btnChangProduct
            // 
            this._btnChangProduct.Location = new System.Drawing.Point(286, 39);
            this._btnChangProduct.Name = "_btnChangProduct";
            this._btnChangProduct.Size = new System.Drawing.Size(112, 23);
            this._btnChangProduct.TabIndex = 2;
            this._btnChangProduct.Text = "Изменить продукт";
            this._btnChangProduct.UseVisualStyleBackColor = true;
            this._btnChangProduct.Click += new System.EventHandler(this._btnChangProduct_Click);
            // 
            // _btnDeleteProduct
            // 
            this._btnDeleteProduct.Location = new System.Drawing.Point(286, 77);
            this._btnDeleteProduct.Name = "_btnDeleteProduct";
            this._btnDeleteProduct.Size = new System.Drawing.Size(112, 23);
            this._btnDeleteProduct.TabIndex = 3;
            this._btnDeleteProduct.Text = "Удалить продукт";
            this._btnDeleteProduct.UseVisualStyleBackColor = true;
            this._btnDeleteProduct.Click += new System.EventHandler(this._btnDeleteProduct_Click);
            // 
            // _btnAddProduct2
            // 
            this._btnAddProduct2.Location = new System.Drawing.Point(534, 204);
            this._btnAddProduct2.Name = "_btnAddProduct2";
            this._btnAddProduct2.Size = new System.Drawing.Size(112, 23);
            this._btnAddProduct2.TabIndex = 4;
            this._btnAddProduct2.Text = "Добавить продукт 2";
            this._btnAddProduct2.UseVisualStyleBackColor = true;
            this._btnAddProduct2.Click += new System.EventHandler(this._btnAddProduct2_Click);
            // 
            // _btnViewProducts2
            // 
            this._btnViewProducts2.Location = new System.Drawing.Point(522, 163);
            this._btnViewProducts2.Name = "_btnViewProducts2";
            this._btnViewProducts2.Size = new System.Drawing.Size(146, 23);
            this._btnViewProducts2.TabIndex = 5;
            this._btnViewProducts2.Text = "Просмотреть продукты 2";
            this._btnViewProducts2.UseVisualStyleBackColor = true;
            this._btnViewProducts2.Click += new System.EventHandler(this._btnViewProducts2_Click);
            // 
            // _btnDeleteProduct2
            // 
            this._btnDeleteProduct2.Location = new System.Drawing.Point(534, 262);
            this._btnDeleteProduct2.Name = "_btnDeleteProduct2";
            this._btnDeleteProduct2.Size = new System.Drawing.Size(112, 23);
            this._btnDeleteProduct2.TabIndex = 6;
            this._btnDeleteProduct2.Text = "Удалить продукт 2";
            this._btnDeleteProduct2.UseVisualStyleBackColor = true;
            this._btnDeleteProduct2.Click += new System.EventHandler(this._btnDeleteProduct2_Click);
            // 
            // _btnChangProduct2
            // 
            this._btnChangProduct2.Location = new System.Drawing.Point(534, 300);
            this._btnChangProduct2.Name = "_btnChangProduct2";
            this._btnChangProduct2.Size = new System.Drawing.Size(112, 23);
            this._btnChangProduct2.TabIndex = 7;
            this._btnChangProduct2.Text = "Изменить продукт 2";
            this._btnChangProduct2.UseVisualStyleBackColor = true;
            this._btnChangProduct2.Click += new System.EventHandler(this._btnChangProduct2_Click);
            // 
            // _btnRollback
            // 
            this._btnRollback.Location = new System.Drawing.Point(534, 354);
            this._btnRollback.Name = "_btnRollback";
            this._btnRollback.Size = new System.Drawing.Size(112, 23);
            this._btnRollback.TabIndex = 8;
            this._btnRollback.Text = "Отменить транзакцию";
            this._btnRollback.UseVisualStyleBackColor = true;
            this._btnRollback.Click += new System.EventHandler(this._btnRollback_Click);
            // 
            // _btnCommit
            // 
            this._btnCommit.Location = new System.Drawing.Point(534, 401);
            this._btnCommit.Name = "_btnCommit";
            this._btnCommit.Size = new System.Drawing.Size(112, 23);
            this._btnCommit.TabIndex = 9;
            this._btnCommit.Text = "Commit";
            this._btnCommit.UseVisualStyleBackColor = true;
            this._btnCommit.Click += new System.EventHandler(this._btnCommit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._btnCommit);
            this.Controls.Add(this._btnRollback);
            this.Controls.Add(this._btnChangProduct2);
            this.Controls.Add(this._btnDeleteProduct2);
            this.Controls.Add(this._btnViewProducts2);
            this.Controls.Add(this._btnAddProduct2);
            this.Controls.Add(this._btnDeleteProduct);
            this.Controls.Add(this._btnChangProduct);
            this.Controls.Add(this._btnAddProduct);
            this.Controls.Add(this.button1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button _btnAddProduct;
        private System.Windows.Forms.Button _btnChangProduct;
        private System.Windows.Forms.Button _btnDeleteProduct;
        private System.Windows.Forms.Button _btnAddProduct2;
        private System.Windows.Forms.Button _btnViewProducts2;
        private System.Windows.Forms.Button _btnDeleteProduct2;
        private System.Windows.Forms.Button _btnChangProduct2;
        private System.Windows.Forms.Button _btnRollback;
        private System.Windows.Forms.Button _btnCommit;
    }
}

