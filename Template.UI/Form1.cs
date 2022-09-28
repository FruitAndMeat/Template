using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Template.UI.UserControls;
using static System.Net.Mime.MediaTypeNames;

namespace Template.UI
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
        }

        private void AddUserControl(UserControl userControl) {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e) {
            UC_Home uc=new UC_Home();
            AddUserControl(uc);
        }

        private void guna2Button2_Click(object sender, EventArgs e) {
            UC_Inbox uc = new UC_Inbox();
            AddUserControl(uc);
        }

        private void guna2Button3_Click(object sender, EventArgs e) {
            UC_Sent uc = new UC_Sent();
            AddUserControl(uc);
        }

        private void guna2Button4_Click(object sender, EventArgs e) {
            UC_Settings uc = new UC_Settings();
            AddUserControl(uc);
        }
    }
}
