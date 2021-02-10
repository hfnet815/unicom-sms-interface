namespace 联通短信发送接口
{
    partial class PwdCheck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.passwordtext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_pwdOk = new System.Windows.Forms.Button();
            this.bt_pwdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passwordtext
            // 
            this.passwordtext.Location = new System.Drawing.Point(38, 43);
            this.passwordtext.Name = "passwordtext";
            this.passwordtext.Size = new System.Drawing.Size(164, 21);
            this.passwordtext.TabIndex = 0;
            this.passwordtext.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入授权密码：";
            // 
            // bt_pwdOk
            // 
            this.bt_pwdOk.Location = new System.Drawing.Point(38, 81);
            this.bt_pwdOk.Name = "bt_pwdOk";
            this.bt_pwdOk.Size = new System.Drawing.Size(62, 23);
            this.bt_pwdOk.TabIndex = 2;
            this.bt_pwdOk.Text = "确定";
            this.bt_pwdOk.UseVisualStyleBackColor = true;
            this.bt_pwdOk.Click += new System.EventHandler(this.bt_pwdOk_Click);
            // 
            // bt_pwdCancel
            // 
            this.bt_pwdCancel.Location = new System.Drawing.Point(138, 81);
            this.bt_pwdCancel.Name = "bt_pwdCancel";
            this.bt_pwdCancel.Size = new System.Drawing.Size(64, 23);
            this.bt_pwdCancel.TabIndex = 3;
            this.bt_pwdCancel.Text = "取消";
            this.bt_pwdCancel.UseVisualStyleBackColor = true;
            this.bt_pwdCancel.Click += new System.EventHandler(this.bt_pwdCancel_Click);
            // 
            // PwdCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 124);
            this.ControlBox = false;
            this.Controls.Add(this.bt_pwdCancel);
            this.Controls.Add(this.bt_pwdOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordtext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PwdCheck";
            this.Text = "验证";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordtext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_pwdOk;
        private System.Windows.Forms.Button bt_pwdCancel;
    }
}