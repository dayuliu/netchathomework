namespace ChatClient
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
            label2 = new Label();
            label4 = new Label();
            button_reg = new Button();
            button_login = new Button();
            textBox_nickname_reg = new TextBox();
            textBox_password_reg = new TextBox();
            label5 = new Label();
            textBox1 = new TextBox();
            button_connect = new Button();
            label_connected = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(126, 249);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 1;
            label2.Text = "密码";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(126, 212);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 3;
            label4.Text = "账号";
            label4.Click += label4_Click;
            // 
            // button_reg
            // 
            button_reg.Location = new Point(457, 212);
            button_reg.Margin = new Padding(2, 2, 2, 2);
            button_reg.Name = "button_reg";
            button_reg.Size = new Size(92, 28);
            button_reg.TabIndex = 4;
            button_reg.Text = "注册";
            button_reg.UseVisualStyleBackColor = true;
            button_reg.Click += button_reg_Click;
            // 
            // button_login
            // 
            button_login.Location = new Point(457, 248);
            button_login.Margin = new Padding(2, 2, 2, 2);
            button_login.Name = "button_login";
            button_login.Size = new Size(92, 28);
            button_login.TabIndex = 5;
            button_login.Text = "登录";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button_login_Click;
            // 
            // textBox_nickname_reg
            // 
            textBox_nickname_reg.Location = new Point(252, 212);
            textBox_nickname_reg.Margin = new Padding(2, 2, 2, 2);
            textBox_nickname_reg.Name = "textBox_nickname_reg";
            textBox_nickname_reg.Size = new Size(123, 27);
            textBox_nickname_reg.TabIndex = 6;
            // 
            // textBox_password_reg
            // 
            textBox_password_reg.Location = new Point(252, 246);
            textBox_password_reg.Margin = new Padding(2, 2, 2, 2);
            textBox_password_reg.Name = "textBox_password_reg";
            textBox_password_reg.Size = new Size(123, 27);
            textBox_password_reg.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(52, 66);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(97, 20);
            label5.TabIndex = 10;
            label5.Text = "服务器IP地址";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(155, 66);
            textBox1.Margin = new Padding(2, 2, 2, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(123, 27);
            textBox1.TabIndex = 11;
            textBox1.Text = "127.0.0.1";
            // 
            // button_connect
            // 
            button_connect.Location = new Point(410, 66);
            button_connect.Margin = new Padding(2, 2, 2, 2);
            button_connect.Name = "button_connect";
            button_connect.Size = new Size(92, 28);
            button_connect.TabIndex = 12;
            button_connect.Text = "连接服务器";
            button_connect.UseVisualStyleBackColor = true;
            button_connect.Click += button_connect_Click;
            // 
            // label_connected
            // 
            label_connected.AutoSize = true;
            label_connected.Location = new Point(84, 524);
            label_connected.Margin = new Padding(2, 0, 2, 0);
            label_connected.Name = "label_connected";
            label_connected.Size = new Size(99, 20);
            label_connected.TabIndex = 13;
            label_connected.Text = "服务器未连接";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(655, 600);
            Controls.Add(label_connected);
            Controls.Add(button_connect);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(textBox_password_reg);
            Controls.Add(textBox_nickname_reg);
            Controls.Add(button_login);
            Controls.Add(button_reg);
            Controls.Add(label4);
            Controls.Add(label2);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "客户端登录/注册";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label4;
        private Button button_reg;
        private Button button_login;
        private TextBox textBox_nickname_reg;
        private TextBox textBox_password_reg;
        private Label label5;
        private TextBox textBox1;
        private Button button_connect;
        private Label label_connected;
    }
}