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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_reg = new System.Windows.Forms.Button();
            this.button_login = new System.Windows.Forms.Button();
            this.textBox_nickname_reg = new System.Windows.Forms.TextBox();
            this.textBox_password_reg = new System.Windows.Forms.TextBox();
            this.textBox_account = new System.Windows.Forms.TextBox();
            this.textBox_password_login = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.label_connected = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 475);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "昵称";
            // 
            // button_reg
            // 
            this.button_reg.Location = new System.Drawing.Point(558, 267);
            this.button_reg.Name = "button_reg";
            this.button_reg.Size = new System.Drawing.Size(112, 34);
            this.button_reg.TabIndex = 4;
            this.button_reg.Text = "注册";
            this.button_reg.UseVisualStyleBackColor = true;
            this.button_reg.Click += new System.EventHandler(this.button_reg_Click);
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(558, 441);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(112, 34);
            this.button_login.TabIndex = 5;
            this.button_login.Text = "登录";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // textBox_nickname_reg
            // 
            this.textBox_nickname_reg.Location = new System.Drawing.Point(308, 254);
            this.textBox_nickname_reg.Name = "textBox_nickname_reg";
            this.textBox_nickname_reg.Size = new System.Drawing.Size(150, 30);
            this.textBox_nickname_reg.TabIndex = 6;
            // 
            // textBox_password_reg
            // 
            this.textBox_password_reg.Location = new System.Drawing.Point(308, 295);
            this.textBox_password_reg.Name = "textBox_password_reg";
            this.textBox_password_reg.Size = new System.Drawing.Size(150, 30);
            this.textBox_password_reg.TabIndex = 7;
            // 
            // textBox_account
            // 
            this.textBox_account.Location = new System.Drawing.Point(308, 409);
            this.textBox_account.Name = "textBox_account";
            this.textBox_account.Size = new System.Drawing.Size(150, 30);
            this.textBox_account.TabIndex = 8;
            // 
            // textBox_password_login
            // 
            this.textBox_password_login.Location = new System.Drawing.Point(308, 469);
            this.textBox_password_login.Name = "textBox_password_login";
            this.textBox_password_login.Size = new System.Drawing.Size(150, 30);
            this.textBox_password_login.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "服务器IP地址";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(189, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 30);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "127.0.0.1";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(501, 79);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(112, 34);
            this.button_connect.TabIndex = 12;
            this.button_connect.Text = "连接服务器";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // label_connected
            // 
            this.label_connected.AutoSize = true;
            this.label_connected.Location = new System.Drawing.Point(103, 629);
            this.label_connected.Name = "label_connected";
            this.label_connected.Size = new System.Drawing.Size(118, 24);
            this.label_connected.TabIndex = 13;
            this.label_connected.Text = "服务器未连接";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 720);
            this.Controls.Add(this.label_connected);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_password_login);
            this.Controls.Add(this.textBox_account);
            this.Controls.Add(this.textBox_password_reg);
            this.Controls.Add(this.textBox_nickname_reg);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.button_reg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "客户端登录/注册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button_reg;
        private Button button_login;
        private TextBox textBox_nickname_reg;
        private TextBox textBox_password_reg;
        private TextBox textBox_account;
        private TextBox textBox_password_login;
        private Label label5;
        private TextBox textBox1;
        private Button button_connect;
        private Label label_connected;
    }
}