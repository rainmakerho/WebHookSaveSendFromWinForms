namespace WebHookRegister
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSecret = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWebHookUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegisterHook = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSendNotifyAll = new System.Windows.Forms.Button();
            this.txtNotifyBody = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtActionId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtActionFilter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtActionFilter);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSecret);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtWebHookUrl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUserId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnRegisterHook);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(882, 193);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "註冊新的 Web Hook";
            // 
            // txtSecret
            // 
            this.txtSecret.Location = new System.Drawing.Point(91, 104);
            this.txtSecret.Name = "txtSecret";
            this.txtSecret.Size = new System.Drawing.Size(779, 31);
            this.txtSecret.TabIndex = 13;
            this.txtSecret.Text = "lol655RMrm655rmrmokok123rainmaker655";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Secret:";
            // 
            // txtWebHookUrl
            // 
            this.txtWebHookUrl.Location = new System.Drawing.Point(91, 64);
            this.txtWebHookUrl.Name = "txtWebHookUrl";
            this.txtWebHookUrl.Size = new System.Drawing.Size(779, 31);
            this.txtWebHookUrl.TabIndex = 11;
            this.txtWebHookUrl.Text = "http://localhost:3979/api/webhooks/incoming/custom/lol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Url:";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(92, 27);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(184, 31);
            this.txtUserId.TabIndex = 9;
            this.txtUserId.Text = "rainmaker";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "UserId:";
            // 
            // btnRegisterHook
            // 
            this.btnRegisterHook.Location = new System.Drawing.Point(24, 141);
            this.btnRegisterHook.Name = "btnRegisterHook";
            this.btnRegisterHook.Size = new System.Drawing.Size(846, 43);
            this.btnRegisterHook.TabIndex = 7;
            this.btnRegisterHook.Text = "Register WebHook";
            this.btnRegisterHook.UseVisualStyleBackColor = true;
            this.btnRegisterHook.Click += new System.EventHandler(this.btnRegisterHook_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSendNotifyAll);
            this.groupBox2.Controls.Add(this.txtNotifyBody);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtActionId);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(0, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(882, 401);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "發送通知";
            // 
            // btnSendNotifyAll
            // 
            this.btnSendNotifyAll.Location = new System.Drawing.Point(10, 355);
            this.btnSendNotifyAll.Name = "btnSendNotifyAll";
            this.btnSendNotifyAll.Size = new System.Drawing.Size(860, 36);
            this.btnSendNotifyAll.TabIndex = 13;
            this.btnSendNotifyAll.Text = "發送通知";
            this.btnSendNotifyAll.UseVisualStyleBackColor = true;
            this.btnSendNotifyAll.Click += new System.EventHandler(this.btnSendNotifyAll_Click);
            // 
            // txtNotifyBody
            // 
            this.txtNotifyBody.Location = new System.Drawing.Point(96, 68);
            this.txtNotifyBody.Multiline = true;
            this.txtNotifyBody.Name = "txtNotifyBody";
            this.txtNotifyBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNotifyBody.Size = new System.Drawing.Size(775, 280);
            this.txtNotifyBody.TabIndex = 12;
            this.txtNotifyBody.Text = resources.GetString("txtNotifyBody.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "通知內容:";
            // 
            // txtActionId
            // 
            this.txtActionId.Location = new System.Drawing.Point(96, 25);
            this.txtActionId.Name = "txtActionId";
            this.txtActionId.Size = new System.Drawing.Size(775, 31);
            this.txtActionId.TabIndex = 10;
            this.txtActionId.Text = "lol_approve";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Action Id:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(297, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Actions Filter:";
            // 
            // txtActionFilter
            // 
            this.txtActionFilter.Location = new System.Drawing.Point(418, 27);
            this.txtActionFilter.Name = "txtActionFilter";
            this.txtActionFilter.Size = new System.Drawing.Size(184, 31);
            this.txtActionFilter.TabIndex = 15;
            this.txtActionFilter.Text = "lol_approve";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(608, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "(*表示任何通知都會被叫到)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 594);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Webhook Manager (Register & NotifyAll)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSecret;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWebHookUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegisterHook;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNotifyBody;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtActionId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSendNotifyAll;
        private System.Windows.Forms.TextBox txtActionFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

