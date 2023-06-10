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
            this.rtboxReceive = new System.Windows.Forms.RichTextBox();
            this.tboxSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.ssStrip = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tboxServerIP1 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnConnect1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddFriend = new System.Windows.Forms.Button();
            this.tboxFriName = new System.Windows.Forms.TextBox();
            this.listFriend = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.ssStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtboxReceive
            // 
            this.rtboxReceive.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtboxReceive.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtboxReceive.ForeColor = System.Drawing.Color.RoyalBlue;
            this.rtboxReceive.Location = new System.Drawing.Point(13, 22);
            this.rtboxReceive.Name = "rtboxReceive";
            this.rtboxReceive.ReadOnly = true;
            this.rtboxReceive.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtboxReceive.Size = new System.Drawing.Size(355, 252);
            this.rtboxReceive.TabIndex = 1;
            this.rtboxReceive.Text = "";
            // 
            // tboxSend
            // 
            this.tboxSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tboxSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxSend.Location = new System.Drawing.Point(13, 309);
            this.tboxSend.Multiline = true;
            this.tboxSend.Name = "tboxSend";
            this.tboxSend.Size = new System.Drawing.Size(355, 109);
            this.tboxSend.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(293, 427);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.rtboxReceive);
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Controls.Add(this.tboxSend);
            this.groupBox1.Location = new System.Drawing.Point(281, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 461);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "聊天区";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(293, 280);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ssStrip
            // 
            this.ssStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus,
            this.tspbProgress});
            this.ssStrip.Location = new System.Drawing.Point(0, 525);
            this.ssStrip.Name = "ssStrip";
            this.ssStrip.Size = new System.Drawing.Size(700, 22);
            this.ssStrip.TabIndex = 4;
            this.ssStrip.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(80, 17);
            this.tsslStatus.Text = "请连接服务器";
            // 
            // tspbProgress
            // 
            this.tspbProgress.Name = "tspbProgress";
            this.tspbProgress.Size = new System.Drawing.Size(100, 16);
            this.tspbProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.tspbProgress.Value = 10;
            this.tspbProgress.Visible = false;
            // 
            // tboxServerIP1
            // 
            this.tboxServerIP1.Location = new System.Drawing.Point(109, 15);
            this.tboxServerIP1.Name = "tboxServerIP1";
            this.tboxServerIP1.Size = new System.Drawing.Size(103, 23);
            this.tboxServerIP1.TabIndex = 9;
            this.tboxServerIP1.Text = "127.0.0.1";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(91, 17);
            this.label21.TabIndex = 8;
            this.label21.Text = "服务器IP地址：";
            // 
            // btnConnect1
            // 
            this.btnConnect1.Location = new System.Drawing.Point(225, 15);
            this.btnConnect1.Name = "btnConnect1";
            this.btnConnect1.Size = new System.Drawing.Size(101, 23);
            this.btnConnect1.TabIndex = 10;
            this.btnConnect1.Text = "连接服务器";
            this.btnConnect1.UseVisualStyleBackColor = true;
            this.btnConnect1.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddFriend);
            this.groupBox2.Controls.Add(this.tboxFriName);
            this.groupBox2.Controls.Add(this.listFriend);
            this.groupBox2.Location = new System.Drawing.Point(12, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 461);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "好友栏";
            // 
            // btnAddFriend
            // 
            this.btnAddFriend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFriend.Enabled = false;
            this.btnAddFriend.Location = new System.Drawing.Point(182, 427);
            this.btnAddFriend.Name = "btnAddFriend";
            this.btnAddFriend.Size = new System.Drawing.Size(75, 23);
            this.btnAddFriend.TabIndex = 5;
            this.btnAddFriend.Text = "添加";
            this.btnAddFriend.UseVisualStyleBackColor = true;
            // 
            // tboxFriName
            // 
            this.tboxFriName.Location = new System.Drawing.Point(6, 427);
            this.tboxFriName.Name = "tboxFriName";
            this.tboxFriName.Size = new System.Drawing.Size(153, 23);
            this.tboxFriName.TabIndex = 1;
            // 
            // listFriend
            // 
            this.listFriend.FormattingEnabled = true;
            this.listFriend.ItemHeight = 17;
            this.listFriend.Items.AddRange(new object[] {
            "公共聊天室"});
            this.listFriend.Location = new System.Drawing.Point(6, 22);
            this.listFriend.Name = "listFriend";
            this.listFriend.Size = new System.Drawing.Size(251, 395);
            this.listFriend.TabIndex = 0;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 547);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnConnect1);
            this.Controls.Add(this.tboxServerIP1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.ssStrip);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Messenger Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ssStrip.ResumeLayout(false);
            this.ssStrip.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private GroupBox groupBox2;
        private ListBox listFriend;
        private Button btnAddFriend;
        private TextBox tboxFriName;
        private TextBox tboxServerIP1;
        private Label label21;
        private Button btnConnect1;
    }
}