namespace Template.UI
{
    partial class frmWriteParam
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
            this.num_Dist = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.num_JogSpeed = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Dist = new System.Windows.Forms.Label();
            this.lbl_JogSpeed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_WritrParam = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_Dist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_JogSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // num_Dist
            // 
            this.num_Dist.DecimalPlaces = 2;
            this.num_Dist.Location = new System.Drawing.Point(265, 42);
            this.num_Dist.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.num_Dist.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.num_Dist.Name = "num_Dist";
            this.num_Dist.Size = new System.Drawing.Size(79, 29);
            this.num_Dist.TabIndex = 31;
            this.num_Dist.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("黑体", 11F);
            this.label9.Location = new System.Drawing.Point(14, 49);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 15);
            this.label9.TabIndex = 30;
            this.label9.Text = "定长位移：";
            // 
            // num_JogSpeed
            // 
            this.num_JogSpeed.DecimalPlaces = 2;
            this.num_JogSpeed.Location = new System.Drawing.Point(265, 84);
            this.num_JogSpeed.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.num_JogSpeed.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.num_JogSpeed.Name = "num_JogSpeed";
            this.num_JogSpeed.Size = new System.Drawing.Size(79, 29);
            this.num_JogSpeed.TabIndex = 33;
            this.num_JogSpeed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 11F);
            this.label5.Location = new System.Drawing.Point(14, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 32;
            this.label5.Text = "点动速度：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 34;
            this.label1.Text = "当前值";
            // 
            // lbl_Dist
            // 
            this.lbl_Dist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Dist.Location = new System.Drawing.Point(109, 46);
            this.lbl_Dist.Name = "lbl_Dist";
            this.lbl_Dist.Size = new System.Drawing.Size(120, 27);
            this.lbl_Dist.TabIndex = 34;
            this.lbl_Dist.Text = "100.33";
            // 
            // lbl_JogSpeed
            // 
            this.lbl_JogSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_JogSpeed.Location = new System.Drawing.Point(109, 88);
            this.lbl_JogSpeed.Name = "lbl_JogSpeed";
            this.lbl_JogSpeed.Size = new System.Drawing.Size(120, 27);
            this.lbl_JogSpeed.TabIndex = 34;
            this.lbl_JogSpeed.Text = "232.51";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 34;
            this.label4.Text = "修改值";
            // 
            // btn_WritrParam
            // 
            this.btn_WritrParam.Location = new System.Drawing.Point(249, 125);
            this.btn_WritrParam.Name = "btn_WritrParam";
            this.btn_WritrParam.Size = new System.Drawing.Size(95, 36);
            this.btn_WritrParam.TabIndex = 35;
            this.btn_WritrParam.Text = "确认写入";
            this.btn_WritrParam.UseVisualStyleBackColor = true;
            this.btn_WritrParam.Click += new System.EventHandler(this.btn_WritrParam_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 21);
            this.label2.TabIndex = 34;
            this.label2.Text = "备注：单位分别为mm，mm/s。";
            // 
            // frmWriteParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 200);
            this.Controls.Add(this.btn_WritrParam);
            this.Controls.Add(this.lbl_JogSpeed);
            this.Controls.Add(this.lbl_Dist);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_JogSpeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.num_Dist);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmWriteParam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "写入参数";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.num_Dist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_JogSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown num_Dist;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown num_JogSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Dist;
        private System.Windows.Forms.Label lbl_JogSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_WritrParam;
        private System.Windows.Forms.Label label2;
    }
}