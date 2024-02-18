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
        DatabaseContext dbContext;

        public MainForm()
        {
            InitializeComponent();
            dgvResult.DataSource = bsResult;
            //CurrentUser.Instance.Login.ToString();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            dbContext = DatabaseContext.getInstance(getStringConnection());
            bsResult.DataSource = dbContext.LoadFromDatabase(tbQuery.Text, CommandType.Text);
            tcMain.SelectedTab = tpResult;
            //dgvResult.Columns["c"].Visible = false;
        }

        private string getStringConnection()
        {
            if (cmbConnectionType.Text == "SQL")
                return string.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}; Timeout=60000;", tbServerName.Text.Trim(), tbDBName.Text.Trim(), tbUserName.Text.Trim(), tbUserPassword.Text.Trim());
            if (cmbConnectionType.Text == "Windows")
                return string.Format("Data Source={0}; Initial Catalog={1}; Integrated Security=True; Timeout=60000;", tbServerName.Text.Trim(), tbDBName.Text.Trim());
            return "";
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
