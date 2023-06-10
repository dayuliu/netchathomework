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
            rtboxReceive.Location = new Point(34, 51);
            rtboxReceive.Margin = new Padding(8, 8, 8, 8);
            rtboxReceive.Name = "rtboxReceive";
            rtboxReceive.ReadOnly = true;
            rtboxReceive.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtboxReceive.Size = new Size(912, 577);
            rtboxReceive.TabIndex = 1;
            rtboxReceive.Text = "";
            // 
            // tboxSend
            // 
            tboxSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tboxSend.BorderStyle = BorderStyle.None;
            tboxSend.Location = new Point(34, 710);
            tboxSend.Margin = new Padding(8, 8, 8, 8);
            tboxSend.Multiline = true;
            tboxSend.Name = "tboxSend";
            tboxSend.Size = new Size(912, 250);
            tboxSend.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSend.Location = new Point(754, 979);
            btnSend.Margin = new Padding(8, 8, 8, 8);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(192, 53);
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
            groupBox1.Location = new Point(722, 140);
            groupBox1.Margin = new Padding(8, 8, 8, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(8, 8, 8, 8);
            groupBox1.Size = new Size(980, 1057);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "聊天区";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(754, 642);
            btnClear.Margin = new Padding(8, 8, 8, 8);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(192, 53);
            btnClear.TabIndex = 4;
            btnClear.Text = "清空";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // ssStrip
            // 
            ssStrip.ImageScalingSize = new Size(20, 20);
            ssStrip.Items.AddRange(new ToolStripItem[] { tsslStatus, tspbProgress });
            ssStrip.Location = new Point(0, 1204);
            ssStrip.Name = "ssStrip";
            ssStrip.Padding = new Padding(2, 0, 36, 0);
            ssStrip.Size = new Size(1800, 52);
            ssStrip.TabIndex = 4;
            ssStrip.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            tsslStatus.Name = "tsslStatus";
            tsslStatus.Size = new Size(197, 39);
            tsslStatus.Text = "请连接服务器";
            // 
            // tspbProgress
            // 
            tspbProgress.Name = "tspbProgress";
            tspbProgress.Size = new Size(258, 36);
            tspbProgress.Style = ProgressBarStyle.Marquee;
            tspbProgress.Value = 10;
            tspbProgress.Visible = false;
            // 
            // tboxServerIP1
            // 
            tboxServerIP1.Location = new Point(280, 35);
            tboxServerIP1.Margin = new Padding(8, 8, 8, 8);
            tboxServerIP1.Name = "tboxServerIP1";
            tboxServerIP1.Size = new Size(258, 46);
            tboxServerIP1.TabIndex = 9;
            tboxServerIP1.Text = "127.0.0.1";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(30, 41);
            label21.Margin = new Padding(8, 0, 8, 0);
            label21.Name = "label21";
            label21.Size = new Size(224, 39);
            label21.TabIndex = 8;
            label21.Text = "服务器IP地址：";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAddFriend);
            groupBox2.Controls.Add(tboxFriName);
            groupBox2.Controls.Add(listFriend);
            groupBox2.Location = new Point(30, 140);
            groupBox2.Margin = new Padding(8, 8, 8, 8);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(8, 8, 8, 8);
            groupBox2.Size = new Size(676, 1057);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "好友栏";
            // 
            // btnAddFriend
            // 
            btnAddFriend.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddFriend.Location = new Point(468, 979);
            btnAddFriend.Margin = new Padding(8, 8, 8, 8);
            btnAddFriend.Name = "btnAddFriend";
            btnAddFriend.Size = new Size(192, 53);
            btnAddFriend.TabIndex = 5;
            btnAddFriend.Text = "添加";
            btnAddFriend.UseVisualStyleBackColor = true;
            btnAddFriend.Click += btnAddFriend_Click;
            // 
            // tboxFriName
            // 
            tboxFriName.Location = new Point(16, 979);
            tboxFriName.Margin = new Padding(8, 8, 8, 8);
            tboxFriName.Name = "tboxFriName";
            tboxFriName.Size = new Size(388, 46);
            tboxFriName.TabIndex = 1;
            // 
            // listFriend
            // 
            listFriend.FormattingEnabled = true;
            listFriend.ItemHeight = 39;
            listFriend.Items.AddRange(new object[] { "公共聊天室" });
            listFriend.Location = new Point(16, 51);
            listFriend.Margin = new Padding(8, 8, 8, 8);
            listFriend.Name = "listFriend";
            listFriend.Size = new Size(640, 901);
            listFriend.TabIndex = 0;
            listFriend.SelectedIndexChanged += listFriend_SelectedIndexChanged;
            listFriend.SelectedValueChanged += listFriend_SelectedValueChanged;
            // 
            // FormClient
            // 
            AutoScaleDimensions = new SizeF(18F, 39F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1800, 1256);
            Controls.Add(groupBox2);
            Controls.Add(tboxServerIP1);
            Controls.Add(label21);
            Controls.Add(ssStrip);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(8, 8, 8, 8);
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
