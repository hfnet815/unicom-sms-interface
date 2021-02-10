namespace 联通短信发送接口
{
    partial class 联通短信发送接口
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(联通短信发送接口));
            this.SmsData = new System.Windows.Forms.TextBox();
            this.SmsSendText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.挂号日期 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_info = new System.Windows.Forms.TextBox();
            this.bt_manaulGetfeedback = new System.Windows.Forms.Button();
            this.tb_feedbackinfo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bt_Manaulgetstate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_manaulSendState = new System.Windows.Forms.TextBox();
            this.bt_manualSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_manaulPhonenumber = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.bt_edit = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SmsData
            // 
            this.SmsData.Location = new System.Drawing.Point(3, 259);
            this.SmsData.Multiline = true;
            this.SmsData.Name = "SmsData";
            this.SmsData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SmsData.Size = new System.Drawing.Size(520, 227);
            this.SmsData.TabIndex = 1;
            // 
            // SmsSendText
            // 
            this.SmsSendText.Location = new System.Drawing.Point(3, 492);
            this.SmsSendText.Multiline = true;
            this.SmsSendText.Name = "SmsSendText";
            this.SmsSendText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SmsSendText.Size = new System.Drawing.Size(520, 218);
            this.SmsSendText.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "发送短信";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(193, 155);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "获取发送状态";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(342, 155);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "获取反馈";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "接口地址：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(520, 21);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "http://27.221.101.37:81/sms.aspx?";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(57, 196);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(177, 21);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2020, 11, 11, 21, 24, 25, 0);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(265, 196);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(179, 21);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // 挂号日期
            // 
            this.挂号日期.AutoSize = true;
            this.挂号日期.Location = new System.Drawing.Point(1, 181);
            this.挂号日期.Name = "挂号日期";
            this.挂号日期.Size = new System.Drawing.Size(65, 12);
            this.挂号日期.TabIndex = 2;
            this.挂号日期.Text = "挂号日期：";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(56, 230);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "手动发送短信";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(179, 230);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(110, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "手动获取接收状态";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(322, 230);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(122, 23);
            this.button7.TabIndex = 7;
            this.button7.Text = "手动获取回复内容";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(549, 739);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.SmsData);
            this.tabPage1.Controls.Add(this.dateTimePicker2);
            this.tabPage1.Controls.Add(this.SmsSendText);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.挂号日期);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(541, 713);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "自动任务";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.tb_info);
            this.tabPage2.Controls.Add(this.bt_manaulGetfeedback);
            this.tabPage2.Controls.Add(this.tb_feedbackinfo);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.bt_Manaulgetstate);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.tb_manaulSendState);
            this.tabPage2.Controls.Add(this.bt_manualSend);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tb_manaulPhonenumber);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(541, 713);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "手动测试";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "状态信息：";
            // 
            // tb_info
            // 
            this.tb_info.Location = new System.Drawing.Point(54, 280);
            this.tb_info.Multiline = true;
            this.tb_info.Name = "tb_info";
            this.tb_info.Size = new System.Drawing.Size(386, 286);
            this.tb_info.TabIndex = 10;
            // 
            // bt_manaulGetfeedback
            // 
            this.bt_manaulGetfeedback.Location = new System.Drawing.Point(379, 194);
            this.bt_manaulGetfeedback.Name = "bt_manaulGetfeedback";
            this.bt_manaulGetfeedback.Size = new System.Drawing.Size(75, 23);
            this.bt_manaulGetfeedback.TabIndex = 9;
            this.bt_manaulGetfeedback.Text = "获取反馈";
            this.bt_manaulGetfeedback.UseVisualStyleBackColor = true;
            this.bt_manaulGetfeedback.Click += new System.EventHandler(this.bt_manaulGetfeedback_Click);
            // 
            // tb_feedbackinfo
            // 
            this.tb_feedbackinfo.Location = new System.Drawing.Point(138, 194);
            this.tb_feedbackinfo.Multiline = true;
            this.tb_feedbackinfo.Name = "tb_feedbackinfo";
            this.tb_feedbackinfo.Size = new System.Drawing.Size(210, 21);
            this.tb_feedbackinfo.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "反馈内容：";
            // 
            // bt_Manaulgetstate
            // 
            this.bt_Manaulgetstate.Location = new System.Drawing.Point(379, 124);
            this.bt_Manaulgetstate.Name = "bt_Manaulgetstate";
            this.bt_Manaulgetstate.Size = new System.Drawing.Size(75, 23);
            this.bt_Manaulgetstate.TabIndex = 6;
            this.bt_Manaulgetstate.Text = "获取状态";
            this.bt_Manaulgetstate.UseVisualStyleBackColor = true;
            this.bt_Manaulgetstate.Click += new System.EventHandler(this.bt_Manaulgetstate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "发送结果：";
            // 
            // tb_manaulSendState
            // 
            this.tb_manaulSendState.Location = new System.Drawing.Point(138, 121);
            this.tb_manaulSendState.Multiline = true;
            this.tb_manaulSendState.Name = "tb_manaulSendState";
            this.tb_manaulSendState.Size = new System.Drawing.Size(210, 26);
            this.tb_manaulSendState.TabIndex = 4;
            // 
            // bt_manualSend
            // 
            this.bt_manualSend.Location = new System.Drawing.Point(379, 16);
            this.bt_manualSend.Name = "bt_manualSend";
            this.bt_manualSend.Size = new System.Drawing.Size(75, 23);
            this.bt_manualSend.TabIndex = 3;
            this.bt_manualSend.Text = "发送";
            this.bt_manualSend.UseVisualStyleBackColor = true;
            this.bt_manualSend.Click += new System.EventHandler(this.bt_manualSend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "短信内容取自自动任务中的模板，号码一次一个。";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "手机号码：";
            // 
            // tb_manaulPhonenumber
            // 
            this.tb_manaulPhonenumber.Location = new System.Drawing.Point(138, 16);
            this.tb_manaulPhonenumber.Multiline = true;
            this.tb_manaulPhonenumber.Name = "tb_manaulPhonenumber";
            this.tb_manaulPhonenumber.Size = new System.Drawing.Size(210, 21);
            this.tb_manaulPhonenumber.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.bt_save);
            this.tabPage3.Controls.Add(this.bt_edit);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(541, 713);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "短信模板";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "短信内容：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 55);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(520, 159);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "尊敬的患者您好！感谢选择荣成市人民医院就诊，为给您提供更优质的医疗服务，请对本次诊疗服务（就诊环境、就医过程、服务态度等）进行评价：满意，请短信回复  “1”；不" +
    "满意，请短信回复“0”，或简要说明原因（30字以内），我们会及时落实、改进。";
            // 
            // bt_edit
            // 
            this.bt_edit.Location = new System.Drawing.Point(126, 238);
            this.bt_edit.Name = "bt_edit";
            this.bt_edit.Size = new System.Drawing.Size(75, 23);
            this.bt_edit.TabIndex = 13;
            this.bt_edit.Text = "编辑";
            this.bt_edit.UseVisualStyleBackColor = true;
            this.bt_edit.Click += new System.EventHandler(this.bt_edit_Click);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(254, 238);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(75, 23);
            this.bt_save.TabIndex = 14;
            this.bt_save.Text = "保存";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // 联通短信发送接口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 747);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "联通短信发送接口";
            this.Text = "联通短信发送接口";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox SmsData;
        private System.Windows.Forms.TextBox SmsSendText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label 挂号日期;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button bt_manaulGetfeedback;
        private System.Windows.Forms.TextBox tb_feedbackinfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bt_Manaulgetstate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_manaulSendState;
        private System.Windows.Forms.Button bt_manualSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_manaulPhonenumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_info;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_edit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
    }
}

