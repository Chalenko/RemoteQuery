namespace RemoteQuery.WinForms
{
    partial class RemoteQueryForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.lblDBName = new System.Windows.Forms.Label();
            this.tbDBName = new System.Windows.Forms.TextBox();
            this.lblUserPassword = new System.Windows.Forms.Label();
            this.tbUserPassword = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lblServerName = new System.Windows.Forms.Label();
            this.tbServerName = new System.Windows.Forms.TextBox();
            this.lblConnectionType = new System.Windows.Forms.Label();
            this.cmbConnectionType = new System.Windows.Forms.ComboBox();
            this.bsConnectionType = new System.Windows.Forms.BindingSource(this.components);
            this.tbQuery = new System.Windows.Forms.TextBox();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpQuery = new System.Windows.Forms.TabPage();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.tpResult = new System.Windows.Forms.TabPage();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.bsResult = new System.Windows.Forms.BindingSource(this.components);
            this.cmbProvider = new System.Windows.Forms.ComboBox();
            this.bsProviders = new System.Windows.Forms.BindingSource(this.components);
            this.lblProvider = new System.Windows.Forms.Label();
            this.ssConnection = new System.Windows.Forms.StatusStrip();
            this.tsslblConection = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsConnectionType)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tpQuery.SuspendLayout();
            this.tpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProviders)).BeginInit();
            this.ssConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProvider
            // 
            this.lblProvider.AutoSize = true;
            this.lblProvider.Location = new System.Drawing.Point(18, 15);
            this.lblProvider.Name = "lblProvider";
            this.lblProvider.Size = new System.Drawing.Size(63, 13);
            this.lblProvider.TabIndex = 3;
            this.lblProvider.Text = "Провайдер";
            // 
            // cmbProvider
            // 
            this.cmbProvider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProvider.DataSource = this.bsProviders;
            this.cmbProvider.DisplayMember = "ProviderName";
            this.cmbProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvider.FormattingEnabled = true;
            this.cmbProvider.Location = new System.Drawing.Point(150, 12);
            this.cmbProvider.Name = "cmbProvider";
            this.cmbProvider.Size = new System.Drawing.Size(663, 21);
            this.cmbProvider.TabIndex = 2;
            this.cmbProvider.SelectedIndexChanged += new System.EventHandler(this.cmbProvider_SelectedIndexChanged);
            // 
            // bsProviders
            // 
            this.bsProviders.DataSource = typeof(RemoteQuery.Model.DbProvider);
            // 
            // gbConnection
            // 
            this.gbConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConnection.Controls.Add(this.lblDBName);
            this.gbConnection.Controls.Add(this.tbDBName);
            this.gbConnection.Controls.Add(this.lblUserPassword);
            this.gbConnection.Controls.Add(this.tbUserPassword);
            this.gbConnection.Controls.Add(this.lblUserName);
            this.gbConnection.Controls.Add(this.tbUserName);
            this.gbConnection.Controls.Add(this.lblServerName);
            this.gbConnection.Controls.Add(this.tbServerName);
            this.gbConnection.Controls.Add(this.lblConnectionType);
            this.gbConnection.Controls.Add(this.cmbConnectionType);
            this.gbConnection.Location = new System.Drawing.Point(12, 39);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(800, 156);
            this.gbConnection.TabIndex = 0;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Подключение";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(6, 23);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(44, 13);
            this.lblServerName.TabIndex = 0;
            this.lblServerName.Text = "Сервер";
            // 
            // tbServerName
            // 
            this.tbServerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbServerName.Location = new System.Drawing.Point(138, 20);
            this.tbServerName.Name = "tbServerName";
            this.tbServerName.Size = new System.Drawing.Size(656, 20);
            this.tbServerName.TabIndex = 1;
            this.tbServerName.TextChanged += new System.EventHandler(this.tbServerName_TextChanged);
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(6, 49);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(48, 13);
            this.lblDBName.TabIndex = 2;
            this.lblDBName.Text = "Имя БД";
            // 
            // tbDBName
            // 
            this.tbDBName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDBName.Location = new System.Drawing.Point(138, 46);
            this.tbDBName.Name = "tbDBName";
            this.tbDBName.Size = new System.Drawing.Size(656, 20);
            this.tbDBName.TabIndex = 3;
            this.tbDBName.TextChanged += new System.EventHandler(this.tbDBName_TextChanged);
            // 
            // lblConnectionType
            // 
            this.lblConnectionType.AutoSize = true;
            this.lblConnectionType.Location = new System.Drawing.Point(6, 75);
            this.lblConnectionType.Name = "lblConnectionType";
            this.lblConnectionType.Size = new System.Drawing.Size(96, 13);
            this.lblConnectionType.TabIndex = 4;
            this.lblConnectionType.Text = "Тип подключения";
            // 
            // cmbConnectionType
            // 
            this.cmbConnectionType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbConnectionType.DataSource = this.bsConnectionType;
            this.cmbConnectionType.DisplayMember = "DisplayName";
            this.cmbConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConnectionType.FormattingEnabled = true;
            this.cmbConnectionType.Location = new System.Drawing.Point(138, 72);
            this.cmbConnectionType.Name = "cmbConnectionType";
            this.cmbConnectionType.Size = new System.Drawing.Size(656, 21);
            this.cmbConnectionType.TabIndex = 5;
            this.cmbConnectionType.SelectedIndexChanged += new System.EventHandler(this.cmbConnectionType_SelectedIndexChanged);
            // 
            // bsConnectionType
            // 
            this.bsConnectionType.DataSource = typeof(RemoteQuery.Model.AuthenticationType);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(6, 102);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(103, 13);
            this.lblUserName.TabIndex = 6;
            this.lblUserName.Text = "Имя пользователя";
            // 
            // tbUserName
            // 
            this.tbUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserName.Location = new System.Drawing.Point(138, 99);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(656, 20);
            this.tbUserName.TabIndex = 7;
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.AutoSize = true;
            this.lblUserPassword.Location = new System.Drawing.Point(6, 128);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(45, 13);
            this.lblUserPassword.TabIndex = 8;
            this.lblUserPassword.Text = "Пароль";
            // 
            // tbUserPassword
            // 
            this.tbUserPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserPassword.Location = new System.Drawing.Point(138, 125);
            this.tbUserPassword.Name = "tbUserPassword";
            this.tbUserPassword.PasswordChar = '*';
            this.tbUserPassword.Size = new System.Drawing.Size(656, 20);
            this.tbUserPassword.TabIndex = 9;
            this.tbUserPassword.UseSystemPasswordChar = true;
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tpQuery);
            this.tcMain.Controls.Add(this.tpResult);
            this.tcMain.Location = new System.Drawing.Point(13, 201);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(800, 324);
            this.tcMain.TabIndex = 1;
            // 
            // tpQuery
            // 
            this.tpQuery.Controls.Add(this.btnConnect);
            this.tpQuery.Controls.Add(this.btnExecute);
            this.tpQuery.Controls.Add(this.tbQuery);
            this.tpQuery.Location = new System.Drawing.Point(4, 22);
            this.tpQuery.Name = "tpQuery";
            this.tpQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tpQuery.Size = new System.Drawing.Size(792, 298);
            this.tpQuery.TabIndex = 0;
            this.tpQuery.Text = "Запрос";
            this.tpQuery.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(556, 268);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(112, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Тест соединения";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(674, 268);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(112, 23);
            this.btnExecute.TabIndex = 1;
            this.btnExecute.Text = "Выполнить";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // tbQuery
            // 
            this.tbQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQuery.Location = new System.Drawing.Point(3, 6);
            this.tbQuery.Multiline = true;
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbQuery.Size = new System.Drawing.Size(783, 256);
            this.tbQuery.TabIndex = 0;
            this.tbQuery.TextChanged += new System.EventHandler(this.tbQuery_TextChanged);
            // 
            // tpResult
            // 
            this.tpResult.Controls.Add(this.dgvResult);
            this.tpResult.Location = new System.Drawing.Point(4, 22);
            this.tpResult.Name = "tpResult";
            this.tpResult.Padding = new System.Windows.Forms.Padding(3);
            this.tpResult.Size = new System.Drawing.Size(792, 298);
            this.tpResult.TabIndex = 1;
            this.tpResult.Text = "Результат";
            this.tpResult.UseVisualStyleBackColor = true;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(3, 3);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(786, 292);
            this.dgvResult.TabIndex = 0;
            // 
            // ssConnection
            // 
            this.ssConnection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblConection,
            this.tsslblStatus});
            this.ssConnection.Location = new System.Drawing.Point(0, 528);
            this.ssConnection.Name = "ssConnection";
            this.ssConnection.Size = new System.Drawing.Size(825, 22);
            this.ssConnection.TabIndex = 4;
            this.ssConnection.Text = "Status strip";
            // 
            // tsslblConection
            // 
            this.tsslblConection.Name = "tsslblConection";
            this.tsslblConection.Size = new System.Drawing.Size(80, 17);
            this.tsslblConection.Text = "Соединение: ";
            this.tsslblConection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslblStatus
            // 
            this.tsslblStatus.Name = "tsslblStatus";
            this.tsslblStatus.Size = new System.Drawing.Size(69, 17);
            this.tsslblStatus.Text = "Состояние:";
            // 
            // RemoteQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 550);
            this.Controls.Add(this.ssConnection);
            this.Controls.Add(this.lblProvider);
            this.Controls.Add(this.cmbProvider);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.gbConnection);
            this.Name = "RemoteQueryForm";
            this.Text = "Удаленный запрос";
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsConnectionType)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tpQuery.ResumeLayout(false);
            this.tpQuery.PerformLayout();
            this.tpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProviders)).EndInit();
            this.ssConnection.ResumeLayout(false);
            this.ssConnection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.Label lblUserPassword;
        private System.Windows.Forms.TextBox tbUserPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.TextBox tbServerName;
        private System.Windows.Forms.Label lblConnectionType;
        private System.Windows.Forms.ComboBox cmbConnectionType;
        private System.Windows.Forms.TextBox tbQuery;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpQuery;
        private System.Windows.Forms.TabPage tpResult;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.TextBox tbDBName;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.BindingSource bsResult;
        private System.Windows.Forms.ComboBox cmbProvider;
        private System.Windows.Forms.Label lblProvider;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.StatusStrip ssConnection;
        private System.Windows.Forms.ToolStripStatusLabel tsslblConection;
        private System.Windows.Forms.ToolStripStatusLabel tsslblStatus;
        private System.Windows.Forms.BindingSource bsProviders;
        private System.Windows.Forms.BindingSource bsConnectionType;
    }
}

