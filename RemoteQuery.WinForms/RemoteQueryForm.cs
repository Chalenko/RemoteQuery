using RemoteQuery.Model;
using RemoteQuery.SQL;
using RemoteQuery.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteQuery.WinForms
{
    public partial class RemoteQueryForm : Form
    {
        //private IDatabaseContext _dbContext;
        //RemoteQuery.Model.RemoteQuery query;
        //private IDbProvider _provider = SQLProvider.Instance;
        private RemoteQueryViewModel _viewModel = new RemoteQueryViewModel();
        private readonly string _tsslblConnectionBaseText = "Соединение: ";

        public RemoteQueryForm()
        {
            InitializeComponent();

            this.cmbProvider.DisplayMember = nameof(RemoteQuery.Model.DbProvider.ProviderName);
            this.cmbConnectionType.DisplayMember = nameof(RemoteQuery.Model.AuthenticationType.DisplayName);

            //binding.FormatString = "C2";
            //binding.FormattingEnabled = true;

            bsProviders.DataSource = DbProvider.Items;
            //cmbProvider.DisplayMember = nameof(DbProvider.ProviderName);
            //cmbProvider.Items.AddRange(new object[] { SQLProvider.Instance });
            //cmbProvider.SelectedIndex = 0;

            //cmbConnectionType.DisplayMember = nameof(AuthenticationType.DisplayName);
            //cmbConnectionType.Items.AddRange(_provider.AuthenticationTypes.ToArray());
            Bind();
            Backbind();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //_dbContext = _provider.GetDbContext(GetStringConnection());
            //bsResult.DataSource = _dbContext.LoadFromDatabase(tbQuery.Text, CommandType.Text);
            //tcMain.SelectedTab = tpResult;
        }

        private string GetStringConnection()
        {
            return string.Empty;// ((IAuthenticationType)cmbConnectionType.SelectedItem).GetConnectionString(tbServerName.Text.Trim(), tbDBName.Text.Trim(), tbUserName.Text.Trim(), tbUserPassword.Text.Trim());
        }

        private void cmbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind();
            Backbind();
        }

        private void cmbConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind();
            Backbind();
            //var usernameState = ((IAuthenticationType)cmbConnectionType.SelectedItem).GetUserNameState();
            //var passwordState = ((IAuthenticationType)cmbConnectionType.SelectedItem).GetUserPasswordState();

            //tbUserName.ReadOnly = !usernameState.IsEditable;
            //tbUserName.Text = usernameState.Name;
            //tbUserPassword.ReadOnly = !passwordState.IsEditable;
            //tbUserPassword.Text = passwordState.Password;
        }

        private void Bind()
        {
            _viewModel.RemoteQuery.Provider = (IDbProvider)cmbProvider.SelectedItem;
            _viewModel.RemoteQuery.ConnectionType = (IAuthenticationType)cmbConnectionType.SelectedItem;
            _viewModel.RemoteQuery.ConnectionData.ServerName = tbServerName.Text;
            _viewModel.RemoteQuery.ConnectionData.DBName = tbDBName.Text;
        }

        private void Backbind()
        {
            bsConnectionType.DataSource = _viewModel.RemoteQuery.Provider?.AuthenticationTypes;
            tbUserName.Text = _viewModel.RemoteQuery.ConnectionType.GetUserNameState().Name;
            tbUserName.Enabled = _viewModel.RemoteQuery.ConnectionType.GetUserNameState().IsEditable;
            tbUserPassword.Text = _viewModel.RemoteQuery.ConnectionType.GetUserPasswordState().Password;
            tbUserPassword.Enabled = _viewModel.RemoteQuery.ConnectionType.GetUserPasswordState().IsEditable;
            tsslblConection.Text = 
                _viewModel.IsTestConnectionEnabled 
                ? string.Concat(_tsslblConnectionBaseText, _viewModel.RemoteQuery.ConnectionData.GetConnectionString()) 
                : string.Concat(_tsslblConnectionBaseText, string.Empty);
            btnConnect.Enabled = _viewModel.IsTestConnectionEnabled;
            btnExecute.Enabled = _viewModel.IsExecuteEnabled;
            
        }

        private void tbServerName_TextChanged(object sender, EventArgs e)
        {
            Bind();
            Backbind();
        }

        private void tbDBName_TextChanged(object sender, EventArgs e)
        {
            Bind();
            Backbind();
        }
    }
}
