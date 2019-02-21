using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Instrument_management
{
    public partial class frmSetting : Form
    {
        string[] localip = new string[20];
        Socket clientSocket;
       // new Thread(receiveMsg).Start(this);

        public frmSetting()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {

        }

        private void EnumComputers(string ip3)
        {
            try
            {
                for (int i = 1; i <= 255; i++)
                {
                    Ping myPing;
                    myPing = new Ping();
                    myPing.PingCompleted += new PingCompletedEventHandler(_myPing_PingCompleted);

                    string pingIP = "192.168." + ip3 + "." + i.ToString();
                    myPing.SendAsync(pingIP, 1000, null);
                }
            }
            catch
            {
                listBox2.Items.Add("Error");
            }
        }

        private async void _myPing_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            if (e.Reply.Status == IPStatus.Success)
            {
                await Task.Run(() =>
                {
                    //Console.WriteLine(e.Reply.Address.ToString() + "|" + Dns.GetHostByAddress(IPAddress.Parse(e.Reply.Address.ToString())).HostName);
                    listBox2.Items.Add(e.Reply.Address.ToString());
                });
            }
        }

        private void GetIP()
        {
            string hostName = Dns.GetHostName();//本机名   
            IPAddress[] addressList = Dns.GetHostAddresses(hostName);//会返回所有地址，包括IPv4和IPv6   
            foreach (IPAddress ip in addressList)  
            {
                string[] ids = ip.ToString().Split('.');
                if (ids[0] == "192" && ids[1] == "168" && ids[3] != "1")
                {
                    EnumComputers(ids[2]);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetIP();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "TCP连接")
            {
                createConn();
            }
            else
            {
                closeConn();
            }
        }

        public bool createConn()
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(textBox1.Text);       
                int connPort = Int16.Parse(textBox2.Text);
                clientSocket.Connect(new IPEndPoint(ip, connPort)); //配置服务器IP与端口  
                listBox2.Items.Add("连接服务器成功");
                button1.Text = "断开连接";
            }
            catch (Exception e)
            {
                //listBox2.Items.Add("连接服务器失败" + e.ToString());
                MessageBox.Show("连接服务器失败" + e.ToString());
                return false;
            }
            return true;
        }

        public bool closeConn()
        {
            try
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                Thread.Sleep(10);
                clientSocket.Close();
                listBox2.Items.Add("断开服务器成功");
                button1.Text = "TCP连接";
                //开启监听线程
                Thread receiveThread = new Thread(receiveMsg);
                receiveThread.Start(this);
            }
            catch (Exception e)
            {
                //listBox2.Items.Add("断开服务器失败" + e.ToString());
                MessageBox.Show("断开服务器失败" + e.ToString());
                return false;
            }
            return true;
        }

        private bool sendSignal(string signal)
        {
            if (clientSocket == null)
            {
                listBox2.Items.Add("发送失败，未连接客户端");
                return false;
            }
            try
            {
                clientSocket.Send(Encoding.UTF8.GetBytes(signal));
                return true;
            }
            catch (Exception e)
            {
                listBox2.Items.Add("发送失败" + e.ToString());
                clientSocket = null;
            }
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sendSignal(textBox3.Text);
        }

    }
}
