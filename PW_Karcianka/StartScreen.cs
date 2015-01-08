using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Timers;

namespace PW_Karcianka
{
    public partial class StartScreen : Form
    {
        Socket sListener;
        Socket senderSock;
        int gameok = 0;
        GameScreen gs;
        System.Timers.Timer t = new System.Timers.Timer();
        public StartScreen()
        {
            InitializeComponent();
            gs = new GameScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SocketPermission permission = new SocketPermission(NetworkAccess.Accept,
            //       TransportType.Tcp, "", SocketPermission.AllPorts);
            //IPHostEntry ipHost = Dns.GetHostEntry("");
            IPHostEntry ipHost = Dns.GetHostEntry("");
            IPAddress ipAddr = ipHost.AddressList[0];
            try
            {
                IPAddress serverAddr = IPAddress.Parse(textBox1.Text);
                //textBox2.Text = serverAddr.ToString();
                senderSock = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipEndPoint = new IPEndPoint(serverAddr, 9999);
                byte[] bytesRec = new byte[1000];
                senderSock.Connect(ipEndPoint);
                byte[] msg = Encoding.Unicode.GetBytes("start");
                senderSock.Send(msg);
                int msgSize = senderSock.Receive(bytesRec);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd przy próbie połączenia. Upewnij się, że podałeś poprawny adres IPv6 hosta i spróbuj ponownie.","Błąd");
            }
            MessageBox.Show("Udało ci się połączyć z serwerem, możecie rozpocząć grę klikając odpowiedni przycisk.", "Błąd");
            gameok = 1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
                string strHostName = "";
                strHostName = System.Net.Dns.GetHostName();
                IPHostEntry ipHost = Dns.GetHostEntry("");
                IPAddress ipAddr = ipHost.AddressList[0];
                try
                {
                    IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 9999);
                    textBox2.Text = ipAddr.ToString();
                    sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    sListener.Bind(ipEndPoint);
                    sListener.Listen(1);
                    AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
                    sListener.BeginAccept(aCallback, sListener);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wystąpił błąd. Spróbuj ponownie. Nawet za jakiś czas. W razie nieustającego problemu skontaktuj się z supportem.", "Błąd");
                }
                /*t.Interval = 1000; //In milliseconds here
                t.AutoReset = true;
                t.Elapsed += new ElapsedEventHandler(TimerElapsed);
                t.Start();*/

        }

        /*void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (gameok == 1)
            {
                t.Stop();
            }
        }*/

        private void AcceptCallback(IAsyncResult ar)
        {
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);  
            byte[] bytesRec = new byte[1000];
            int msgSize = handler.Receive(bytesRec);
            byte[] msg = Encoding.Unicode.GetBytes("start");
            handler.Send(msg);
            MessageBox.Show("Ktoś się z tobą połączył, możecie rozpocząć grę klikając odpowiedni przycisk.", "Komunikat");
            gameok = 1;
        }

        private void StartScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (gameok == 1)
            {
                gs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Możesz rozpocząć grę dopiero po nawiązaniu połączenia.", "Komunikat");
            }
        }
    }
}
