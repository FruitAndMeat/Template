using System;
using System.Drawing;
using System.Windows.Forms;
using Template.UI.Common;

namespace Template.UI
{
    public partial class frmActual : Form
    {
        private System.Windows.Forms.Timer timer;

        /// <summary>运行步骤</summary>
        private enum RunStep {

        }

        /// <summary>
        /// 当前系统时间
        /// </summary>
        private string CurrentTime {
            get { return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"); }

        }
        public frmActual() {
            InitializeComponent();
            this.Load += FrmActual_Load;
        }

        private void FrmActual_Load(object sender, EventArgs e) {
            //读取点位配置文件
            dgvPoint.DataSource = Argument.Points;


            //初始化timer
            timer = new System.Windows.Forms.Timer() { Interval = 500 };
            timer.Tick += UpdateData;
            timer.Start();
        }
        //更新显示数据
        private void UpdateData(object sender, EventArgs e) {
            if (Argument.MotionPLC.IsConnected) {
                this.lbl_XReady.BackColor = Argument.MotionPLC.XAxis.Enable ? Color.Green : Color.Red;
                this.lbl_XHomed.BackColor = Argument.MotionPLC.XAxis.Homed ? Color.Green : Color.Red;
                this.lbl_XMaxLim.BackColor = Argument.MotionPLC.XAxis.MaxLimited ? Color.Green : Color.Red;
                this.lbl_XMinLim.BackColor = Argument.MotionPLC.XAxis.MinLimited ? Color.Green : Color.Red;
                this.lbl_XAxisSpeed.Text = Argument.MotionPLC.XAxis.CurrentSpeed.ToString("F2");
                this.lbl_XAxisPosition.Text = Argument.MotionPLC.XAxis.CurrentPostion.ToString("F2");
                this.lbl_XError.Text = Argument.MotionPLC.XAxis.ErrorId.ToString();

                this.lbl_YReady.BackColor = Argument.MotionPLC.YAxis.Enable ? Color.Green : Color.Red;
                this.lbl_YHomed.BackColor = Argument.MotionPLC.YAxis.Homed ? Color.Green : Color.Red;
                this.lbl_YMaxLim.BackColor = Argument.MotionPLC.YAxis.MaxLimited ? Color.Green : Color.Red;
                this.lbl_YMinLim.BackColor = Argument.MotionPLC.YAxis.MinLimited ? Color.Green : Color.Red;
                this.lbl_YAxisSpeed.Text = Argument.MotionPLC.YAxis.CurrentSpeed.ToString("F2");
                this.lbl_YAxisPosition.Text = Argument.MotionPLC.YAxis.CurrentPostion.ToString("F2");
                this.lbl_YError.Text = Argument.MotionPLC.YAxis.ErrorId.ToString();

                this.lbl_ZReady.BackColor = Argument.MotionPLC.ZAxis.Enable ? Color.Green : Color.Red;
                this.lbl_ZHomed.BackColor = Argument.MotionPLC.ZAxis.Homed ? Color.Green : Color.Red;
                this.lbl_ZMaxLim.BackColor = Argument.MotionPLC.ZAxis.MaxLimited ? Color.Green : Color.Red;
                this.lbl_ZMinLim.BackColor = Argument.MotionPLC.ZAxis.MinLimited ? Color.Green : Color.Red;
                this.lbl_ZAxisSpeed.Text = Argument.MotionPLC.ZAxis.CurrentSpeed.ToString("F2");
                this.lbl_ZAxisPosition.Text = Argument.MotionPLC.ZAxis.CurrentPostion.ToString("F2");
                this.lbl_ZError.Text = Argument.MotionPLC.ZAxis.ErrorId.ToString();

                this.lbl_Dist.Text = Argument.MotionPLC.Distence.ToString("F2") + " mm";
                this.lbl_JogSpeed.Text = Argument.MotionPLC.JogSpeed.ToString("F2") + " mm/s";
            }
        }



        #region 私有方法
        /// <summary>
        /// 更新listview日志的通用方法
        /// </summary>
        /// <param name="imageindex">ico索引</param>
        /// <param name="log">日志信息</param>
        /// <param name="index">插入集合位置的索引，默认为0，即最上方</param>
        private void AppendLog(int imageindex, string log, int index = 0) {
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

        private void SetControlEnable(bool enable) {
            foreach (Control c in groupBox1.Controls) {
                if (c is Button) {
                    c.Enabled = enable;
                }
            }
        }
#if false

        /// <summary>
        /// 设置bool值
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="value">值</param>
        void SetBoolValue(int address, bool value) {
            Argument.MotionPLC.WriteBoolData.Enqueue(new WriteBool() { StartAddress = address, Value = value });
        }

        /// <summary>
        /// 按钮根据Tag的地址，实现点击效果。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCick(object sender, EventArgs e) {
            if (sender is Button) {
                string tag = ((Button)sender).Tag.ToString();
                if (!string.IsNullOrWhiteSpace(tag)) {
                    SetBoolValue(Convert.ToInt32(tag), true);
                    SetBoolValue(Convert.ToInt32(tag), false);
                }
            }
        }
        /// <summary>
        /// 按钮根据Tag的地址，实现按下置1。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMouseDownToTrue(object sender, MouseEventArgs e) {
            if (sender is Button) {
                string tag = ((Button)sender).Tag.ToString();
                if (!string.IsNullOrWhiteSpace(tag)) {
                    SetBoolValue(Convert.ToInt32(tag), true);
                }
            }
        }
        /// <summary>
        /// 按钮根据Tag的地址，实现松开置0。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMouseUpToFalse(object sender, MouseEventArgs e) {
            if (sender is Button) {
                string tag = ((Button)sender).Tag.ToString();
                if (!string.IsNullOrWhiteSpace(tag)) {
                    SetBoolValue(Convert.ToInt32(tag), false);
                }
            }
        } 
#endif
        #endregion


        //写入参数
        private void btn_WriteParam_Click(object sender, EventArgs e) {
            //打开写入参数的窗体
            frmWriteParam frm = new frmWriteParam(this.lbl_Dist.Text, this.lbl_JogSpeed.Text);
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK) {
                AppendLog(0, "修改参数成功!");
            }
        }



        #region 手动模式按钮事件
        private void btn_XZero_Click(object sender, EventArgs e) {
            Argument.MotionPLC.Homeing(1);
        }

        private void btn_YZero_Click(object sender, EventArgs e) {
            Argument.MotionPLC.Homeing(2);
        }

        private void btn_ZZero_Click(object sender, EventArgs e) {
            Argument.MotionPLC.Homeing(3);
        }

        private void btn_Stop_Click(object sender, EventArgs e) {
            Argument.MotionPLC.StopAxis();
        }

        private void btn_Reset_Click(object sender, EventArgs e) {
            Argument.MotionPLC.ResetAxis();
        }

        private void btn_XForward_MouseDown(object sender, MouseEventArgs e) {
            Argument.MotionPLC.JogForwardStart(1);
        }

        private void btn_XForward_MouseUp(object sender, MouseEventArgs e) {
            Argument.MotionPLC.JogForwardEnd(1);
        }

        private void btn_XBack_MouseDown(object sender, MouseEventArgs e) {
            Argument.MotionPLC.JogBackwardStart(1);
        }

        private void btn_XBack_MouseUp(object sender, MouseEventArgs e) {
            Argument.MotionPLC.JogBackwardEnd(1);
        }

        private void btn_YForward_MouseDown(object sender, MouseEventArgs e) {
            Argument.MotionPLC.JogForwardStart(2);
        }

        private void btn_YForward_MouseUp(object sender, MouseEventArgs e) {
            Argument.MotionPLC.JogForwardEnd(2);
        }

        private void btn_YBack_MouseDown(object sender, MouseEventArgs e) {
            Argument.MotionPLC.JogBackwardStart(2);
        }

        private void btn_YBack_MouseUp(object sender, MouseEventArgs e) {
            Argument.MotionPLC.JogBackwardEnd(2);
        }

        private void btn_ZForward_MouseDown(object sender, MouseEventArgs e) {
            Argument.MotionPLC.JogForwardStart(3);
        }

        private void btn_ZForward_MouseUp(object sender, MouseEventArgs e) {
            Argument.MotionPLC.JogForwardEnd(3);
        }

        private void btn_ZBack_MouseDown(object sender, MouseEventArgs e) {
            Argument.MotionPLC.JogBackwardStart(3);
        }

        private void btn_ZBack_MouseUp(object sender, MouseEventArgs e) {
            Argument.MotionPLC.JogBackwardEnd(3);
        }
        #endregion

        #region 系统模式按钮事件
        //根据点位数据自动运行
        private void btn_AutoRun_Click(object sender, EventArgs e) {
            //状态机模式
        }
        //手自动切换
        private void btn_Auto_Click(object sender, EventArgs e) {
            //当前为手动模式，切换为自动模式
            if (btn_Auto.Text == "手动模式") {
                SetControlEnable(false);
                AppendLog(0, "切换为自动模式。");
                Argument.AutoMode = true;
                btn_Auto.Text = "自动模式";
            }
            //当前为自动模式，点击后切换为手动模式
            else if (btn_Auto.Text == "自动模式") {
                SetControlEnable(true);
                AppendLog(0, "切换为手动模式。");
                Argument.AutoMode = false;
                btn_Auto.Text = "手动模式";
            }
        }
        //系统回零 包括回原点，数据清零
        private void btn_Home_Click(object sender, EventArgs e) {

        }
        #endregion
    }
}
