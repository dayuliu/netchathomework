namespace ChatServer
{
    partial class Form1
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
            this.button_start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.textBox_online_client = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_start = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(614, 34);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(112, 34);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "开启服务器";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务器地址";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(169, 36);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(150, 30);
            this.textBox_ip.TabIndex = 2;
            this.textBox_ip.Text = "127.0.0.1";
            // 
            // textBox_online_client
            // 
            this.textBox_online_client.Location = new System.Drawing.Point(115, 122);
            this.textBox_online_client.Multiline = true;
            this.textBox_online_client.Name = "textBox_online_client";
            this.textBox_online_client.Size = new System.Drawing.Size(534, 549);
            this.textBox_online_client.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "在线客户端";
            // 
            // label_start
            // 
            this.label_start.AutoSize = true;
            this.label_start.Location = new System.Drawing.Point(70, 697);
            this.label_start.Name = "label_start";
            this.label_start.Size = new System.Drawing.Size(118, 24);
            this.label_start.TabIndex = 5;
            this.label_start.Text = "服务器未启动";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 742);
            this.Controls.Add(this.label_start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_online_client);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_start);
            this.Name = "Form1";
            this.Text = "Chat Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_start;
        private Label label1;
        private TextBox textBox_ip;
        private TextBox textBox_online_client;
        private Label label2;
        private Label label_start;
    }
}