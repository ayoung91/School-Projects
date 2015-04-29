using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BGSU_LDAP_LOGIN;

namespace CustomersFinal
{
    public partial class frmLogin : Form
    {
        //private ldap_login myLogin = new ldap_login("bgsu", "LDAP://bgsu.edu");
        private BGSU_Authentication myLogin = new BGSU_Authentication("bgsu", "LDAP://bgsu.edu");

        private string _username, _password;
        private int _retrycount;
        private bool _valid_loign;
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            _retrycount = 0;
            _valid_loign = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            _retrycount++;
            _username = this.txtUsername.Text;
            _password = this.txtPassword.Text;

            myLogin.UserName = _username;
            myLogin.Password = _password;
            _valid_loign = myLogin.IsLoginValid();

            if (_valid_loign)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (this._retrycount > 3)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                else
                {
                    this.lblResults.Text = "Login Attempt " + this._retrycount.ToString() + " Failed";
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmLogin_Load_1(object sender, EventArgs e)
        {

        }
    }
}
