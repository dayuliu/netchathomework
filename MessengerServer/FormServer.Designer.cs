namespace MessengerServer
{
    partial class FormServer
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
            ssStatus = new StatusStrip();
            tsslStatus = new ToolStripStatusLabel();
            label1 = new Label();
            lbClients = new ListBox();
            label2 = new Label();
            tboxServerIP = new TextBox();
            btnStart = new Button();
            ssStatus.SuspendLayout();
            SuspendLayout();
            // 
            // ssStatus
            // 
            ssStatus.Items.AddRange(new ToolStripItem[] { tsslStatus });
            ssStatus.Location = new Point(0, 454);
            ssStatus.Name = "ssStatus";
            ssStatus.Size = new Size(307, 22);
            ssStatus.TabIndex = 0;
            ssStatus.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            tsslStatus.Name = "tsslStatus";
            tsslStatus.Size = new Size(80, 17);
            tsslStatus.Text = "请启动服务器";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 43);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 1;
            label1.Text = "在线客户端";
            // 
            // lbClients
            // 
            lbClients.FormattingEnabled = true;
            lbClients.ItemHeight = 17;
            lbClients.Location = new Point(12, 63);
            lbClients.Name = "lbClients";
            lbClients.Size = new Size(285, 378);
            lbClients.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 12);
            label2.Name = "label2";
            label2.Size = new Size(91, 17);
            label2.TabIndex = 3;
            label2.Text = "服务器IP地址：";
            // 
            // tboxServerIP
            // 
            tboxServerIP.Location = new Point(109, 9);
            tboxServerIP.Name = "tboxServerIP";
            tboxServerIP.Size = new Size(82, 23);
            tboxServerIP.TabIndex = 4;
            tboxServerIP.Text = "127.0.0.1";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(201, 9);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(96, 23);
            btnStart.TabIndex = 5;
            btnStart.Text = "启动服务器";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // FormServer
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 476);
            Controls.Add(btnStart);
            Controls.Add(tboxServerIP);
            Controls.Add(label2);
            Controls.Add(lbClients);
            Controls.Add(label1);
            Controls.Add(ssStatus);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormServer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Messenger Server";
            ssStatus.ResumeLayout(false);
            ssStatus.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip ssStatus;
        private ToolStripStatusLabel tsslStatus;
        private Label label1;
        private ListBox lbClients;
        private Label label2;
        private TextBox tboxServerIP;
        private Button btnStart;
    }
}