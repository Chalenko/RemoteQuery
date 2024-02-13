using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteQuery
{
    public partial class MainForm : Form
    {
        DatabaseContext dbContext;
        IConnectionString connection;

        public MainForm()
        {
            InitializeComponent();
            dgvResult.DataSource = bsResult;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            dbContext = DatabaseContext.getInstance(getStringConnection());
            bsResult.DataSource = dbContext.LoadFromDatabase(tbQuery.Text, CommandType.Text);
            tcMain.SelectedTab = tpResult;
        }

        private string getStringConnection()
        {
            if (cmbConnectionType.Text == "SQL")
                connection = new SQLConnectionString() { ServerName = tbServerName.Text.Trim(), DBName = tbDBName.Text.Trim(), UserName = tbUserName.Text.Trim(), UserPassword = tbUserPassword.Text.Trim() };
            if (cmbConnectionType.Text == "Windows")
                connection = new WindowsConnectionString() { ServerName = tbServerName.Text.Trim(), DBName = tbDBName.Text.Trim(), UserName = tbUserName.Text.Trim(), UserPassword = tbUserPassword.Text.Trim() };
            return connection.GetConnectionString();
        }

        private void cmbConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConnectionType.SelectedItem.Equals("SQL"))
            {
                tbUserName.ReadOnly = false;
                tbUserName.Text = "";
                tbUserPassword.ReadOnly = false;
                tbUserPassword.Text = "";
            }
            if (cmbConnectionType.SelectedItem.Equals("Windows"))
            {
                tbUserName.ReadOnly = true;
                tbUserName.Text = string.Format("{0}\\{1}", Environment.UserDomainName, Environment.UserName);
                tbUserPassword.ReadOnly = true;
                tbUserPassword.Text = "";
            }
        }
    }
}
