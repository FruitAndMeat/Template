using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Template.UI
{
    public partial class frmMain : Form
    {
        private static List<Form> forms;
        private Point point;
        public frmMain() {
            InitializeComponent();

            #region 添加标题栏事件

            #region 标题栏移动窗口
            this.panelTitle.MouseDown += (o, e) => {
                point = new Point(e.X, e.Y);
            };

            this.panelTitle.MouseMove += (o, e) => {
                if (e.Button == MouseButtons.Left) {
                    this.Location = new Point(this.Location.X + e.X - point.X, this.Location.Y + e.Y - point.Y);
                }
            };
                #endregion

            this.btnClose.Click += (o, e) => { this.Close(); };
            this.btnMaximum.Click +=(o, e) => { FormMaximized(); };
            this.btnMinimum.Click += (o, e) => { this.WindowState = FormWindowState.Minimized; };
            this.panelTitle.MouseDoubleClick += (o, e) => { FormMaximized(); };

            this.Load += FrmMain_Load;
            #endregion
        }

        private void FrmMain_Load(object sender, EventArgs e) {
            forms = new List<Form>();
            forms.Add(new frmActual());
            forms.Add(new frmReport());
            forms.Add(new frmRecord());
            forms.Add(new frmMessage());
            forms.Add(new frmAlarm());
            forms.Add(new frmSettings());
        }

        #region 私有方法
        /// <summary>
        /// 将窗体变为全屏，并且不遮挡任务栏
        /// </summary>
        void FormMaximized() {
            if (this.WindowState == FormWindowState.Normal) {
                //重新设定窗体大小,否则会遮挡任务栏
                this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.WindowState = FormWindowState.Maximized;
            }
            else {
                this.WindowState = FormWindowState.Normal;
            }
        }

        void CloseForm(Form form) {

        }

        void OpenForm(string formName) {
            bool b = false;
            foreach (Form item in panelMain.Controls) {
                if (item.Name == formName) {
                    b = true;
                    break;
                }
            }
            if (!b) {
                Form form = forms.Find((t) => t.Name == formName);
                panelMain.Controls.Clear();
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                form.FormBorderStyle = FormBorderStyle.None;
                panelMain.Controls.Add(form);
                form.Show();
            }
        }

        #endregion

        #region TabControl控件选项卡自定义
        //private void tabControl1_DrawItem(object sender, DrawItemEventArgs e) {
        //    SolidBrush brush = new SolidBrush(Color.Black);
        //    RectangleF rectangleF = (RectangleF)tabControl1.GetTabRect(e.Index);
        //    StringFormat stringFormat = new StringFormat(StringFormatFlags.DirectionVertical);
        //    stringFormat.LineAlignment = StringAlignment.Center;
        //    stringFormat.Alignment=StringAlignment.Center;

        //    e.Graphics.DrawString(tabControl1.Controls[e.Index].Text,SystemInformation.MenuFont,brush,rectangleF,stringFormat); 
        //} 
        #endregion

        private void btnActual_Click(object sender, EventArgs e) {
            OpenForm("frmActual");
        }

        private void btnReport_Click(object sender, EventArgs e) {
            OpenForm("frmReport");
        }

        private void btnRecord_Click(object sender, EventArgs e) {
            OpenForm("frmRecord");
        }

        private void btnAlarm_Click(object sender, EventArgs e) {
            OpenForm("frmAlarm");
        }

        private void btnMessage_Click(object sender, EventArgs e) {
            OpenForm("frmMessage");
        }

        private void btnSettings_Click(object sender, EventArgs e) {
            OpenForm("frmSettings");
        }
    }
}
