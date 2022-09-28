using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Template.Models.Enum;

namespace Template.UI
{
    public partial class frmLogin : Form
    {
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

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BtnLogin_Click(object sender, EventArgs e) {
            //登录事件

            MessageBox.Show("登录成功","温馨提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
