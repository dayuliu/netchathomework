using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;
using MessengerClinet;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button_connect_Click(object sender, EventArgs e) // ���ӷ�����
        {
            if (label_connected.Text != "������������")
            {
                socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint _port = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 20255);
                socketClient.SendTimeout = 1000;
                socketClient.BeginConnect(_port, new AsyncCallback(ConnectCallback), socketClient);
            }
        }
        private void ConnectCallback(IAsyncResult ia) // ���ӳɹ��Ļص�
        {
            try
            {
                Invoke(() =>
                {
                    ((Socket)ia.AsyncState).EndConnect(ia);
                    socketClient = ia.AsyncState as Socket;


                    label_connected.Text = "������������";
                    socketClient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socketClient);// �첽������Ϣ
                });
            }
            catch (Exception ex)  //�쳣����
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ReceiveCallback(IAsyncResult ia) // ���յ���Ϣ�Ļص�
        {
            socketClient = ia.AsyncState as Socket;
            if (socketClient == null)
            {
                return;
            }
            try
            {
                
                    int bytesRead = socketClient.EndReceive(ia);  //������Ϣ�ɹ���������Ϣ���� 
                    string context = Encoding.Default.GetString(buffer, 0, bytesRead);  //�������Ϊ�ַ���
                    socketClient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socketClient);  //�첽������Ϣ
                    MessageBox.Show(context);
                Invoke(() =>
                {
                    if (context == "04|03")
                    {
                        this.Hide();
                        Form formClient = new FormClient(socketClient);
                        formClient.Show();
                    }
                });
                // ������Ϣ
            }
            catch (Exception ex)  //�쳣����
            {
                MessageBox.Show(ex.ToString());
            }
        }

        byte[] buffer = new byte[5 * 1024 * 1024];  //����������Ϣ�������鲢Լ�����泤�Ƚ��ճ������
        Socket socketClient = null;  //����ȫ�ֱ����ͻ����׽���

        private void button_reg_Click(object sender, EventArgs e)
        {
            send_to_Server("01|" + textBox_nickname_reg.Text + "|" + textBox_password_reg.Text);
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            send_to_Server("03|" + textBox_account.Text + "|" + textBox_password_login.Text);
        }

        private void send_to_Server(string str)
        {
            byte[] buffer_tmp = Encoding.Default.GetBytes(str);
            socketClient.Send(buffer_tmp, 0, buffer_tmp.Length, SocketFlags.None);
        }
    }
}