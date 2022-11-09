using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Template.UI;

namespace Template.UI
{
    public partial class frmActual : Form
    {
        private System.Windows.Forms.Timer timer;

        private bool IsEmeStop;

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


        #region 自动运行步骤
        private void AutoProcess() {
            while (!IsEmeStop) {
                switch (Argument.CurrentRunStep) {
                    case RunStep.RunReady:
                        AppendLog(0, "机构已准备妥运行!");
                        Thread.Sleep(2000);
                        
                        AppendLog(0, "移动到取料位！");
                        break;
                    case RunStep.MoveToReclaimer:
                        //直接定位
                        
                        Argument.MotionPLC.PosAbsloute(Argument.Points[1]);
                        Thread.Sleep(1000);
                        //如果都为Done，再监测是否为当前位置.
                        while (!Argument.MotionPLC.AllPosDone) {
                            if (IsEmeStop) {
                                break;
                            }
                            Thread.Sleep(100);
                        }
                        break;
                    case RunStep.ReclaimerWait:
                        //Thread.Sleep(2000);
                        AppendLog(0, "移动到取料位完成！");
                        
                        break;
                    case RunStep.ReclaimerDown:
                        AppendLog(0, "开始取料！");
                        //Thread.Sleep(2000);
                        
                        break;
                    case RunStep.ReclaimerGrap:
                        //Thread.Sleep(2000);
                        
                        break;
                    case RunStep.ReclaimerUp:
                        
                        //Thread.Sleep(2000);
                        
                        break;
                    case RunStep.MoveToScaner:
                        AppendLog(0, "取料完成，前往扫码位！");
                        Argument.MotionPLC.PosAbsloute(Argument.Points[2]);
                        Thread.Sleep(1000);
                        //如果都为Done，再监测是否为当前位置.
                        while (!Argument.MotionPLC.AllPosDone) {
                            if (IsEmeStop) {
                                break;
                            }
                            Thread.Sleep(100);
                        }
                        break;
                    case RunStep.TriggerScan:
                        AppendLog(0, "移动到扫码位完成，准备扫码！");
                        AppendLog(0, "扫码完成，移动到加工位！");
                        //Thread.Sleep(2000);
                        
                        break;
                    case RunStep.MoveToProcess:
                        
                        Argument.MotionPLC.PosAbsloute(Argument.Points[3]);
                        Thread.Sleep(1000);
                        //如果都为Done，再监测是否为当前位置.
                       
                        break;
                    case RunStep.ProcessCheck:
                        AppendLog(0, "移动到加工位完成，等待加工！");
                        //Thread.Sleep(2000);

                        break;
                    case RunStep.ProcessDown1:
                        
                        //Thread.Sleep(2000);
                        
                        break;
                    case RunStep.ProcessPutDown:
                        //Thread.Sleep(2000);
                        
                        break;
                    case RunStep.ProcessUp1:
                        //Thread.Sleep(2000);
                        
                        break;
                    case RunStep.ProcessWait:
                        
                        //Thread.Sleep(2000);
                        
                        break;
                    case RunStep.ProcessDown2:
                        
                        //Thread.Sleep(2000);
                        
                        break;
                    case RunStep.ProcessGrab:
                        //Thread.Sleep(2000);
                        
                        break;
                    case RunStep.ProcessUp2:
                        //Thread.Sleep(2000);
                        
                        AppendLog(0, "加工完成，准备清洗！");
                        break;
                    case RunStep.MoveToClean:
                        
                        Argument.MotionPLC.PosAbsloute(Argument.Points[4]);
                        Thread.Sleep(1000);
                        //如果都为Done，再监测是否为当前位置.
                        while (!Argument.MotionPLC.AllPosDone) {
                            if (IsEmeStop) {
                                break;
                            }
                            Thread.Sleep(100);
                        }
                        break;
                    case RunStep.WaitClean:

                        //Thread.Sleep(5000);
                        AppendLog(0, "等待清洗作业技术！");
                        AppendLog(0, "清洗作业结束，准备出料！");
                        break;
                    case RunStep.MoveToOutlet:
                        
                        Argument.MotionPLC.PosAbsloute(Argument.Points[5]);
                        Thread.Sleep(1000);
                        //如果都为Done，再监测是否为当前位置.
                        while (!Argument.MotionPLC.AllPosDone) {
                            if (IsEmeStop) {
                                break;
                            }
                            Thread.Sleep(100);
                        }
                        break;
                    case RunStep.OutletWait:
                        //Thread.Sleep(2000);
                        
                        break;
                    case RunStep.OutletDown:
                        //Thread.Sleep(2000);
                        
                        break;
                    case RunStep.OutletPutDown:
                        //Thread.Sleep(2000);
                        
                        break;
                    case RunStep.OutletUp:
                        AppendLog(0,"出料运行完成！");
                        Argument.CurrentRunStep=RunStep.RunReady;
                        break;
                    default:
                        break;
                }
                Argument.CurrentRunStep++;
                
            }
            
        } 
        #endregion
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
            Thread autoThread=new Thread(AutoProcess);
            autoThread.IsBackground = true;
            autoThread.Start();
            AppendLog(0, "开始自动运行!");
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
            AppendLog(0, "开始复位！");
            IsEmeStop = false;
        }
        #endregion

        private void btn_EmeStop_Click(object sender, EventArgs e) {
            AppendLog(0, "触发了急停！");
            IsEmeStop = true;
        }

        private void btn_Pause_Click(object sender, EventArgs e) {

        }
    }
}
