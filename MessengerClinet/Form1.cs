using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;
using MessengerClinet;
using System.Drawing;
using SocketCommon;
using System.Threading.Tasks;

namespace ChatClient
{
    public partial class Form1 : Form
    {



        private Client client;                          // �ͻ���ʵ��


        public Form1()
        {
            InitializeComponent();
            button_reg.Enabled = false;
            button_login.Enabled = false;

            // ��ʼ���ͻ���
            client = new Client();

            // ע�����������״̬ˢ���¼�
            client.RefreshConnectStatus += Client_RefreshConnectStatus;

            // ע�����ݽ����¼�
            client.DataReceive += Client_DataReceive;


        }




        /// <summary>
        /// �¼��������ݽ����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_DataReceive(object? sender, SocketCommon.ReceiveEventArgs e)
        {
            // ��ʾ���յ�������

            string context = e.Text;
            Invoke(() =>
            {
                string[] args = context.Split("|");

                switch (args[0])
                {
                    case "02": // ע��
                        {
                            on_reg_resp(args);
                            break;
                        }

                    case "04": // ��¼
                        {
                            on_login_resp(args);
                            break;
                        }

                    default:
                        break;
                }

            });
        }


        /// <summary>
        /// �¼���������������״̬�ı�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_RefreshConnectStatus(object? sender, ConnectEventArgs e)
        {
            if (e.Connected)
            {
                // ����״̬����ʾ����ť״̬
                Invoke(() =>
                {
                    label_connected.Text = "������������";
                    button_connect.Visible = false;
                    button_reg.Enabled = true;
                    button_login.Enabled = true;
                });
            }
            else
            {
                // ����״̬����ʾ����ť״̬
                Invoke(() =>
                {
                    label_connected.Text = "�������ӷ�����...";
                });
            }
        }



        private void button_connect_Click(object sender, EventArgs e) // ���ӷ�����
        {

            client.Connect("127.0.0.1", 20255);
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

                Invoke(() =>
                {
                    string[] args = context.Split("|");

                    switch (args[0])
                    {
                        case "02": // ע��
                            {
                                on_reg_resp(args);
                                break;
                            }

                        case "04": // ��¼
                            {
                                 on_login_resp(args);
                                break;
                            }

                        default:
                                break;
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




        private void on_reg_resp(string[] args) {

            if (args[1] == "1")
            {
                MessageBox.Show("�˺��Ѿ�����");
                return;
            }

            MessageBox.Show("ע��ɹ�");

        }

        private void on_login_resp(string[] args)
        {

            if (args[1] == "1")
            {
                MessageBox.Show("�˺��Ѿ�����");
                return;
            }

            if (args[1] == "2")
            {
                MessageBox.Show("���벻��ȷ");
                return;
            }


            if (args[1] == "3")
            {
                MessageBox.Show("�û��ѵ�¼");
                return;
            }


            MessageBox.Show("��¼�ɹ�");

            this.Hide();
            // ע�����������״̬ˢ���¼�
            client.RefreshConnectStatus -= Client_RefreshConnectStatus;

            // ע�����ݽ����¼�
            client.DataReceive -= Client_DataReceive;
            Form formClient = new FormClient(textBox_nickname_reg.Text, this.client);
            formClient.Show();

        }



        private void button_reg_Click(object sender, EventArgs e)
        {
            send_to_Server("01|" + textBox_nickname_reg.Text + "|" + textBox_password_reg.Text);
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            send_to_Server("03|" + textBox_nickname_reg.Text + "|" + textBox_password_reg.Text);
        }

        private void send_to_Server(string str)
        {
            client.Send(str);
        }

       
    }
}