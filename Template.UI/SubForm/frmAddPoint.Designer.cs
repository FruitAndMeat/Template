namespace Template.UI
{
    partial class frmAddPoint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.num_ZPostion = new System.Windows.Forms.NumericUpDown();
            this.num_YPostion = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.num_XPostion = new System.Windows.Forms.NumericUpDown();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_ZPostion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_YPostion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_XPostion)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(71, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(127, 26);
            this.txtName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "X轴：";
            // 
            // num_ZPostion
            // 
            this.num_ZPostion.DecimalPlaces = 2;
            this.num_ZPostion.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_ZPostion.Location = new System.Drawing.Point(71, 171);
            this.num_ZPostion.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.num_ZPostion.Name = "num_ZPostion";
            this.num_ZPostion.Size = new System.Drawing.Size(127, 26);
            this.num_ZPostion.TabIndex = 4;
            // 
            // num_YPostion
            // 
            this.num_YPostion.DecimalPlaces = 2;
            this.num_YPostion.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_YPostion.Location = new System.Drawing.Point(71, 130);
            this.num_YPostion.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.num_YPostion.Name = "num_YPostion";
            this.num_YPostion.Size = new System.Drawing.Size(127, 26);
            this.num_YPostion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Y轴：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Z轴：";
            // 
            // num_XPostion
            // 
            this.num_XPostion.DecimalPlaces = 2;
            this.num_XPostion.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_XPostion.Location = new System.Drawing.Point(71, 89);
            this.num_XPostion.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.num_XPostion.Name = "num_XPostion";
            this.num_XPostion.Size = new System.Drawing.Size(127, 26);
            this.num_XPostion.TabIndex = 2;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(15, 216);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 33);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(123, 216);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtID.Location = new System.Drawing.Point(71, 9);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(127, 26);
            this.txtID.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "ID：";
            // 
            // frmAddPoint
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(218, 258);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_ZPostion);
            this.Controls.Add(this.num_YPostion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.num_XPostion);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddPoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加修改点位";
            ((System.ComponentModel.ISupportInitialize)(this.num_ZPostion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_YPostion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_XPostion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_ZPostion;
        private System.Windows.Forms.NumericUpDown num_YPostion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_XPostion;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label5;
    }
}