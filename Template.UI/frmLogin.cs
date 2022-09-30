using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Template.DAL;
using Template.Models;
using Template.Models.Enum;
using Utils;

namespace Template.UI
{
    public partial class frmLogin : Form
    {
        UserAccountService userService=new UserAccountService();
        public frmLogin() {
            InitializeComponent();

            #region 添加事件
            this.btnLogin.Click += BtnLogin_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.Load += FrmLogin_Load;
           
            #endregion
        }

        

        private void FrmLogin_Load(object sender, EventArgs e) {
            //添加账户
            this.cmbAccount.Items.AddRange( Enum.GetNames(typeof(Rank)));
            this.cmbAccount.SelectedIndex = 0;
        }

        private  void BtnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BtnLogin_Click(object sender, EventArgs e) {
            //登录事件
            //检查是否输入密码
            string name = this.cmbAccount.Text.Trim();
            string password = this.txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(password)||password.Length==0) {
                MessageBox.Show("请输入密码。", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPassword.Focus();
                return;
            }

            Task.Run(() => {
                CheckLogin(name, password);
            });
        }

        void CheckLogin(string name,string password) {
            //封装对象
            UserAccount objUser = new UserAccount() { Name = name, Password = password };
            if (this.btnLogin.InvokeRequired) {
                this.btnLogin.Invoke(new Action(() => {
                    this.btnLogin.Enabled = false;
                }));
            }
            //尝试登录,查找用户是否存在,存在才继续查找
            bool IsExists = userService.CheckUserName(objUser);
            if (IsExists) {
                objUser = userService.GetUser(objUser);
                if (objUser != null) {
                    LogHelper.LogInfo($"用户[{objUser.Name}]登录系统");
                    //用户信息保存到公共参数。
                    Common.Argument.User = objUser;
                    DialogResult = DialogResult.OK;
                }
                else {
                    MessageBox.Show("登陆失败，请检查登录密码。", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (this.txtPassword.InvokeRequired) {
                        this.txtPassword.Invoke(new Action(() => {
                            this.txtPassword.Focus();
                        }));
                    }
                }
            }
            else {
                MessageBox.Show("登陆失败，未找到到该用户名。", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (this.cmbAccount.InvokeRequired) {
                    this.cmbAccount.Invoke(new Action(() => {
                        this.cmbAccount.Focus();
                    }));
                }
            }
            if (this.btnLogin.InvokeRequired) {
                this.btnLogin.Invoke(new Action(() => {
                    this.btnLogin.Enabled = true;
                }));
            }
            
        }
    }
}
