using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.btnLogin.Click += BtnLogin_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.linklblAbout.LinkClicked += LinklblAbout_LinkClicked;
            this.linkLblHelp.LinkClicked += LinkLblHelp_LinkClicked;
            this.FormClosed += Form1_FormClosed;
        }

        

        private void LinkLblHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            MessageBox.Show("打开了帮助文件或网页！");
        }

        private void LinklblAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            MessageBox.Show("打开了公司网页");
        }

        private void Form1_Load(object sender, EventArgs e) {
            InitCombox();
        }

        private void BtnLogin_Click(object sender, EventArgs e) {
            //登录事件
            MessageBox.Show("验证登录");

            
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            Utils.LogHelper.LogInfo("软件关闭退出。");
        }


        /// <summary>
        /// 初始化账户下拉框选项。
        /// </summary>
        private void InitCombox (){
            this.cmbAccount.Items.AddRange(new string[] { "操作员", "调试员", "工程师", "管理员" });
        }
    }
}
