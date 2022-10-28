using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Template.UI.Common;

namespace Template.UI
{
    public partial class frmWriteParam : Form
    {
        public frmWriteParam(string Dist,string JogSpeed) {
            InitializeComponent();
            this.lbl_Dist.Text=Dist;
            this.lbl_JogSpeed.Text = JogSpeed;
        }

        private void btn_WritrParam_Click(object sender, EventArgs e) {
            Argument.MotionPLC.ModifyParam(Convert.ToDouble(num_Dist.Value),Convert.ToDouble(num_JogSpeed.Value));
            MessageBox.Show("写入成功");
            this.DialogResult = DialogResult.OK;
        }
    }
}
