namespace MessengerClinet
{
    partial class FormClient
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            rtboxReceive = new RichTextBox();
            tboxSend = new TextBox();
            btnSend = new Button();
            groupBox1 = new GroupBox();
            btnClear = new Button();
            ssStrip = new StatusStrip();
            tsslStatus = new ToolStripStatusLabel();
            tspbProgress = new ToolStripProgressBar();
            tboxServerIP = new TextBox();
            label2 = new Label();
            btnConnect = new Button();
            groupBox1.SuspendLayout();
            ssStrip.SuspendLayout();
            SuspendLayout();
            // 
            // rtboxReceive
            // 
            rtboxReceive.BackColor = Color.WhiteSmoke;
            rtboxReceive.BorderStyle = BorderStyle.None;
            rtboxReceive.ForeColor = Color.RoyalBlue;
            rtboxReceive.Location = new Point(13, 22);
            rtboxReceive.Name = "rtboxReceive";
            rtboxReceive.ReadOnly = true;
            rtboxReceive.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtboxReceive.Size = new Size(355, 252);
            rtboxReceive.TabIndex = 1;
            rtboxReceive.Text = "";
            // 
            // tboxSend
            // 
            tboxSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tboxSend.BorderStyle = BorderStyle.None;
            tboxSend.Location = new Point(13, 309);
            tboxSend.Multiline = true;
            tboxSend.Name = "tboxSend";
            tboxSend.Size = new Size(355, 109);
            tboxSend.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSend.Enabled = false;
            btnSend.Location = new Point(293, 427);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 3;
            btnSend.Text = "发送";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(rtboxReceive);
            groupBox1.Controls.Add(btnSend);
            groupBox1.Controls.Add(tboxSend);
            groupBox1.Location = new Point(12, 53);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(381, 461);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "聊天区";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(293, 280);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 4;
            btnClear.Text = "清空";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // ssStrip
            // 
            ssStrip.Items.AddRange(new ToolStripItem[] { tsslStatus, tspbProgress });
            ssStrip.Location = new Point(0, 525);
            ssStrip.Name = "ssStrip";
            ssStrip.Size = new Size(405, 22);
            ssStrip.TabIndex = 4;
            ssStrip.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            tsslStatus.Name = "tsslStatus";
            tsslStatus.Size = new Size(80, 17);
            tsslStatus.Text = "请连接服务器";
            // 
            // tspbProgress
            // 
            tspbProgress.Name = "tspbProgress";
            tspbProgress.Size = new Size(100, 16);
            tspbProgress.Style = ProgressBarStyle.Marquee;
            tspbProgress.Value = 10;
            tspbProgress.Visible = false;
            // 
            // tboxServerIP
            // 
            tboxServerIP.Location = new Point(109, 15);
            tboxServerIP.Name = "tboxServerIP";
            tboxServerIP.Size = new Size(103, 23);
            tboxServerIP.TabIndex = 9;
            tboxServerIP.Text = "127.0.0.1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 18);
            label2.Name = "label2";
            label2.Size = new Size(91, 17);
            label2.TabIndex = 8;
            label2.Text = "服务器IP地址：";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(225, 15);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(101, 23);
            btnConnect.TabIndex = 10;
            btnConnect.Text = "连接服务器";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // FormClient
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 547);
            Controls.Add(btnConnect);
            Controls.Add(tboxServerIP);
            Controls.Add(label2);
            Controls.Add(ssStrip);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Messenger Client";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ssStrip.ResumeLayout(false);
            ssStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox rtboxReceive;
        private TextBox tboxSend;
        private Button btnSend;
        private GroupBox groupBox1;
        private StatusStrip ssStrip;
        private ToolStripStatusLabel tsslStatus;
        private ToolStripProgressBar tspbProgress;
        private TextBox tboxServerIP;
        private Label label2;
        private Button btnClear;
        private Button btnConnect;
    }
}