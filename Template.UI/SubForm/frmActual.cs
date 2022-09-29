using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Template.UI
{
    public partial class frmActual : Form
    {


        /// <summary>
        /// 当前系统时间
        /// </summary>
        private string CurrentTime {
            get { return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"); }

        }
        public frmActual() {
            InitializeComponent();
        }

        private void btn_AutoRun_Click(object sender, EventArgs e) {
            AddLog(0, "板卡未检测到，请检查！");
        }


        #region 更新日志通用方法

        private void AddLog(int index, string log) {
            if (this.lstInfo.InvokeRequired) {
                Invoke(new Action(() => {
                    ListViewItem lst = new ListViewItem("   " + CurrentTime, index);
                    lst.SubItems.Add(log);
                    lstInfo.Items.Insert(index, lst);
                }));
            }
            else {
                ListViewItem lst = new ListViewItem("   " + CurrentTime, index);
                lst.SubItems.Add(log);
                lstInfo.Items.Insert(index, lst);
            }
        }
        #endregion
    }
}
