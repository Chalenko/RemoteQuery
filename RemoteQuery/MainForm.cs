using System;
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
            var usernameState = ((IConnectionStringType)cmbConnectionType.SelectedItem).GetUserNameState();
            var passwordState = ((IConnectionStringType)cmbConnectionType.SelectedItem).GetUserPasswordState();

            tbUserName.ReadOnly = !usernameState.IsEditable;
            tbUserName.Text = usernameState.Name;
            tbUserPassword.ReadOnly = !passwordState.IsEditable;
            tbUserPassword.Text = passwordState.Password;
        }
    }
}
