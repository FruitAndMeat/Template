using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Template.Models;
using Utils;

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
            this.Load += FrmActual_Load;
        }

        private void FrmActual_Load(object sender, EventArgs e) {
            //读取点位配置文件
            dgvPoint.DataSource = null;
            dgvPoint.DataSource = LoadPointConfig($"{AppDomain.CurrentDomain.BaseDirectory}AxisPoint.json");
            //读取参数配置文件
        }

        private void btn_AutoRun_Click(object sender, EventArgs e) {
            if (WritePointConfig()) {
                AppendLog(0, "写入配置文件成功");
            }
        }

        private bool WritePointConfig() {
            List<AxisPoint> points = new List<AxisPoint>();
            points.Add(new AxisPoint() {
                Id = 1,
                PointName = "起始点位",
                XAxisPostion = 300.23,
                YAxisPostion = 100.25,
                ZAxisPostion = 33.25
            });
            points.Add(new AxisPoint() {
                Id = 2,
                PointName = "取料点位",
                XAxisPostion = 323.23,
                YAxisPostion = 100.25,
                ZAxisPostion = 322.25
            });
            points.Add(new AxisPoint() {
                Id = 3,
                PointName = "加工点位",
                XAxisPostion = 124.23,
                YAxisPostion = 112.25,
                ZAxisPostion = 33.25
            });
           string result= JsonConvert.SerializeObject(points);
            FileHelper.WriteFile($"{AppDomain.CurrentDomain.BaseDirectory}AxisPoint.json", result);
            return true;
        }

        private List<AxisPoint> LoadPointConfig(string path) {
          string list=  FileHelper.ReadFile(path);
            
            return JsonConvert.DeserializeObject<List<AxisPoint>>(list);
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
