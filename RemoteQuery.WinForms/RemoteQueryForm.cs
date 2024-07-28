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
        private readonly string _tsslblStatusBaseText = "Состояние: ";

        public RemoteQueryForm()
        {
            InitializeComponent();

            dgvResult.DataSource = bsResult;
            bsProviders.DataSource = DbProvider.Items;

            BindConnectionData();
            Backbind();
        }

        private void BindConnectionData()
        {
            _viewModel.RemoteQuery.Provider = (IDbProvider)cmbProvider.SelectedItem;
            _viewModel.RemoteQuery.ConnectionType = (IAuthenticationType)cmbConnectionType.SelectedItem;
            _viewModel.RemoteQuery.ConnectionData.ServerName = tbServerName.Text;
            _viewModel.RemoteQuery.ConnectionData.DBName = tbDBName.Text;
            _viewModel.RemoteQuery.QueryText = tbQuery.Text;
        }

        private void BindQueryData()
        {
            _viewModel.RemoteQuery.QueryText = tbQuery.Text;
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
                ? string.Concat(_tsslblConnectionBaseText, _viewModel.ConnectionString) 
                : string.Concat(_tsslblConnectionBaseText, string.Empty);
            tsslblStatus.Text =
                _viewModel.IsTestConnectionEnabled
                ? string.Concat(_tsslblStatusBaseText, _viewModel.ConnectionStatus)
                : string.Concat(_tsslblStatusBaseText, string.Empty);
            btnConnect.Enabled = _viewModel.IsTestConnectionEnabled;
            btnExecute.Enabled = _viewModel.IsExecuteEnabled;
            //bsResult.DataSource = _viewModel.RemoteQuery.Result;
        }

        private void cmbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindConnectionData();
            Backbind();
        }

        private void cmbConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindConnectionData();
            Backbind();
        }

        private void tbServerName_TextChanged(object sender, EventArgs e)
        {
            BindConnectionData();
            Backbind();
        }

        private void tbDBName_TextChanged(object sender, EventArgs e)
        {
            BindConnectionData();
            Backbind();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            BindConnectionData();
            _viewModel.TryConnect();
            Backbind();
        }

        private void tbQuery_TextChanged(object sender, EventArgs e)
        {
            BindQueryData();
            Backbind();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //BindConnectionData();
            //BindQueryData();
            dgvResult.DataSource = _viewModel.DBContext.LoadFromDatabase(_viewModel.RemoteQuery.QueryText, CommandType.Text);
            //bsResult.DataSource = _viewModel.DBContext.LoadFromDatabase(_viewModel.RemoteQuery.QueryText, CommandType.Text);
            //_viewModel.ExecuteQuery();
            Backbind();
            //tcMain.SelectedTab = tpResult;
        }
    }
}
