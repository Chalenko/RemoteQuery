using RemoteQuery.Model;
using RemoteQuery.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteQuery.WinForms
{
    public partial class MainForm : Form
    {
        private IDatabaseContext _dbContext;
        RemoteQuery.Model.RemoteQuery query;
        private IDbProvider _provider = new SQLProvider();

        public MainForm()
        {
            InitializeComponent();
            dgvResult.DataSource = bsResult;
            cmbConnectionType.DisplayMember = nameof(AuthenticationType.DisplayName);
            cmbConnectionType.Items.AddRange(_provider.AuthenticationTypes.ToArray());
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            _dbContext = _provider.GetDbContext(GetStringConnection());
            bsResult.DataSource = _dbContext.LoadFromDatabase(tbQuery.Text, CommandType.Text);
            tcMain.SelectedTab = tpResult;
        }

        private string GetStringConnection()
        {
            return ((IAuthenticationType)cmbConnectionType.SelectedItem).GetConnectionString(tbServerName.Text.Trim(), tbDBName.Text.Trim(), tbUserName.Text.Trim(), tbUserPassword.Text.Trim());
        }

        private void cmbConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var usernameState = ((IAuthenticationType)cmbConnectionType.SelectedItem).GetUserNameState();
            var passwordState = ((IAuthenticationType)cmbConnectionType.SelectedItem).GetUserPasswordState();

            tbUserName.ReadOnly = !usernameState.IsEditable;
            tbUserName.Text = usernameState.Name;
            tbUserPassword.ReadOnly = !passwordState.IsEditable;
            tbUserPassword.Text = passwordState.Password;
        }
    }
}
