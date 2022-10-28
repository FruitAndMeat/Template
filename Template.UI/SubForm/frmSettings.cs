using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Template.Models;
using Template.UI.Common;

namespace Template.UI
{
    public partial class frmSettings : Form {
        public frmSettings() {
            InitializeComponent();
        }
        private List<AxisPoint> dataSource = new List<AxisPoint>();

        private void btn_Save_Click(object sender, EventArgs e) {
            
        }

        private void frmSettings_Load(object sender, EventArgs e) {
            dataSource=Argument.Points;
            RefreshDGV(); 
            
        }
        //添加
        private void button2_Click(object sender, EventArgs e) {
            frmAddPoint frmAddPoint = new frmAddPoint();
            var result = frmAddPoint.ShowDialog();
            if (result == DialogResult.OK) {
                dataSource.Add(frmAddPoint.AxisPoint);
                RefreshDGV();
            }
        }
        //删除所选
        private void button1_Click(object sender, EventArgs e) {
            if (this.dgvPoints.CurrentRow == null) {
                return;
            }
            int index = this.dgvPoints.CurrentRow.Index;
            dataSource.RemoveAt(index);
            RefreshDGV();
        }
        //保存修改
        private void button3_Click(object sender, EventArgs e) {
            var result = MessageBox.Show("该操作无法撤销，确定提交吗？", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
            if (result == DialogResult.Yes) {
                Argument.Points = dataSource;
                MessageBox.Show("修改成功！重启生效。", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
            else {
                return;
            }
        }
        //刷新 加载数据源
        private void button4_Click(object sender, EventArgs e) {
            RefreshDGV();
        }
        //修改点位信息
        private void button5_Click(object sender, EventArgs e) {
            if (this.dgvPoints.CurrentRow == null) {
                return;
            }
            int index = this.dgvPoints.CurrentRow.Index;
            frmAddPoint frmAddPoint = new frmAddPoint(dataSource[index]);
            var result = frmAddPoint.ShowDialog();
            if (result == DialogResult.OK) {
                dataSource[index] = frmAddPoint.AxisPoint;
                RefreshDGV();
            }
        }
        private void RefreshDGV() {
            this.dgvPoints.DataSource = new List<AxisPoint>();
            if (dataSource != null&& dataSource.Count>0) {
                this.dgvPoints.DataSource = dataSource;
            }
            
        }

    }
}
