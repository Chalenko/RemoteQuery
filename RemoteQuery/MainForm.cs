﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace RemoteQuery
{
    public partial class MainForm : Form
    {
        DatabaseContext dbContext;

        public MainForm()
        {
            InitializeComponent();
            dgvResult.DataSource = bsResult;
            cmbConnectionType.DisplayMember = nameof(ConnectionStringType.DisplayName);
            cmbConnectionType.Items.AddRange(new object[] {
                ConnectionStringType.SQLConnectionStringType,
                ConnectionStringType.WindowsConnectionStringType});
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            dbContext = DatabaseContext.getInstance(getStringConnection());
            bsResult.DataSource = dbContext.LoadFromDatabase(tbQuery.Text, CommandType.Text);
            tcMain.SelectedTab = tpResult;
        }

        private string getStringConnection()
        {
            return ((IConnectionStringType)cmbConnectionType.SelectedItem).GetConnectionString(tbServerName.Text.Trim(), tbDBName.Text.Trim(), tbUserName.Text.Trim(), tbUserPassword.Text.Trim());
        }

        private void cmbConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConnectionType.SelectedItem.Equals(ConnectionStringType.SQLConnectionStringType))
            {
                tbUserName.ReadOnly = false;
                tbUserName.Text = "";
                tbUserPassword.ReadOnly = false;
                tbUserPassword.Text = "";
            }
            if (cmbConnectionType.SelectedItem.Equals(ConnectionStringType.WindowsConnectionStringType))
            {
                tbUserName.ReadOnly = true;
                tbUserName.Text = string.Format("{0}\\{1}", Environment.UserDomainName, Environment.UserName);
                tbUserPassword.ReadOnly = true;
                tbUserPassword.Text = "";
            }
        }
    }
}
