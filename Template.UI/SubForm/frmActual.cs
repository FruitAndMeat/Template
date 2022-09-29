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
            AppendLog(0, "板卡未检测到，请检查!");
        }


        #region 更新日志通用方法
        /// <summary>
        /// 更新listview日志的通用方法
        /// </summary>
        /// <param name="imageindex">ico索引</param>
        /// <param name="log">日志信息</param>
        /// <param name="index">插入集合位置的索引，默认为0，即最上方</param>
        private void AppendLog(int imageindex, string log,int index=0) {
            if (this.lstInfo.InvokeRequired) {
                Invoke(new Action(() => {
                    ListViewItem lst = new ListViewItem("   " + CurrentTime, imageindex);
                    lst.SubItems.Add(log);
                    lstInfo.Items.Insert(index, lst);
                }));
            }
            else {
                ListViewItem lst = new ListViewItem("   " + CurrentTime, imageindex);
                lst.SubItems.Add(log);
                lstInfo.Items.Insert(index, lst);
            }
        }
        #endregion
    }
}
