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

namespace Template.UI
{
    public partial class frmAddPoint : Form
    {
        public AxisPoint AxisPoint { get; set; }

        public frmAddPoint() {
            InitializeComponent();
        }
        public frmAddPoint(AxisPoint axisPoint) {
            InitializeComponent();

            if (axisPoint != null) {

                this.txtName.Text = axisPoint.PointName;
                this.txtID.Text = axisPoint.ID.ToString();
                this.num_XPostion.Value = Convert.ToDecimal(axisPoint.XAxisPostion);
                this.num_YPostion.Value = Convert.ToDecimal(axisPoint.YAxisPostion);
                this.num_ZPostion.Value = Convert.ToDecimal(axisPoint.ZAxisPostion);
            }
            
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            if (AxisPoint==null) {
                AxisPoint = new AxisPoint();
            }
            int id;
            if (int.TryParse(this.txtID.Text.Trim(),out id)) {
                AxisPoint.ID = id;
            }
            else { MessageBox.Show("请输入点位的ID号！");this.txtID.Focus();this.txtID.SelectAll();return; }

            if (!string.IsNullOrEmpty(this.txtName.Text) && this.txtName.Text.Trim().Length > 0) {
                AxisPoint.PointName = this.txtName.Text.Trim();
            }
            else { MessageBox.Show("请输入点位的名称！"); this.txtName.Focus(); this.txtName.SelectAll();return; }

            AxisPoint.XAxisPostion = Convert.ToDouble(this.num_XPostion.Value);
            AxisPoint.YAxisPostion = Convert.ToDouble(this.num_YPostion.Value);
            AxisPoint.ZAxisPostion = Convert.ToDouble(this.num_ZPostion.Value);

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult=DialogResult.Cancel;
        }
    }
}
