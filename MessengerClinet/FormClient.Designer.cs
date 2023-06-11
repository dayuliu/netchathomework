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
            tboxServerIP1 = new TextBox();
            label21 = new Label();
            groupBox2 = new GroupBox();
            btnAddFriend = new Button();
            tboxFriName = new TextBox();
            listFriend = new ListBox();
            groupBox1.SuspendLayout();
            ssStrip.SuspendLayout();
            groupBox2.SuspendLayout();
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
            groupBox1.Location = new Point(281, 61);
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
            ssStrip.ImageScalingSize = new Size(20, 20);
            ssStrip.Items.AddRange(new ToolStripItem[] { tsslStatus, tspbProgress });
            ssStrip.Location = new Point(0, 541);
            ssStrip.Name = "ssStrip";
            ssStrip.Size = new Size(700, 22);
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
            tspbProgress.Size = new Size(100, 17);
            tspbProgress.Style = ProgressBarStyle.Marquee;
            tspbProgress.Value = 10;
            tspbProgress.Visible = false;
            // 
            // tboxServerIP1
            // 
            tboxServerIP1.Location = new Point(109, 15);
            tboxServerIP1.Name = "tboxServerIP1";
            tboxServerIP1.Size = new Size(103, 23);
            tboxServerIP1.TabIndex = 9;
            tboxServerIP1.Text = "127.0.0.1";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(12, 18);
            label21.Name = "label21";
            label21.Size = new Size(91, 17);
            label21.TabIndex = 8;
            label21.Text = "服务器IP地址：";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAddFriend);
            groupBox2.Controls.Add(tboxFriName);
            groupBox2.Controls.Add(listFriend);
            groupBox2.Location = new Point(12, 61);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(263, 461);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "好友栏";
            // 
            // btnAddFriend
            // 
            btnAddFriend.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddFriend.Location = new Point(182, 427);
            btnAddFriend.Name = "btnAddFriend";
            btnAddFriend.Size = new Size(75, 23);
            btnAddFriend.TabIndex = 5;
            btnAddFriend.Text = "添加";
            btnAddFriend.UseVisualStyleBackColor = true;
            btnAddFriend.Click += btnAddFriend_Click;
            // 
            // tboxFriName
            // 
            tboxFriName.Location = new Point(6, 427);
            tboxFriName.Name = "tboxFriName";
            tboxFriName.Size = new Size(153, 23);
            tboxFriName.TabIndex = 1;
            // 
            // listFriend
            // 
            listFriend.FormattingEnabled = true;
            listFriend.ItemHeight = 17;
            listFriend.Location = new Point(6, 22);
            listFriend.Name = "listFriend";
            listFriend.Size = new Size(251, 395);
            listFriend.TabIndex = 0;
            listFriend.SelectedIndexChanged += listFriend_SelectedIndexChanged;
            listFriend.SelectedValueChanged += listFriend_SelectedValueChanged;
            // 
            // FormClient
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 563);
            Controls.Add(groupBox2);
            Controls.Add(tboxServerIP1);
            Controls.Add(label21);
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
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
        private GroupBox groupBox2;
        private ListBox listFriend;
        private Button btnAddFriend;
        private TextBox tboxFriName;
        private TextBox tboxServerIP1;
        private Label label21;
    }
}
