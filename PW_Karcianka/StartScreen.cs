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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PW_Karcianka
{
    public partial class StartScreen : Form
    {
        Player player2;
        Socket sListener;
        Socket senderSock;
        int gameok = 0;
        bool hihi;
        GameScreen gs;
        System.Timers.Timer t = new System.Timers.Timer();
        public StartScreen()
        {
            InitializeComponent();
            gs = new GameScreen(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPHostEntry ipHost = Dns.GetHostEntry("");
            IPAddress ipAddr = ipHost.AddressList[0];
            try
            {
                IPAddress serverAddr = IPAddress.Parse(textBox1.Text);
                senderSock = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipEndPoint = new IPEndPoint(serverAddr, 9999);
                byte[] bytesRec = new byte[25000];
                senderSock.Connect(ipEndPoint);
                senderSock.Send(playerInfo());
                int msgSize = senderSock.Receive(bytesRec);
                BinaryFormatter formattor = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(bytesRec);
                player2 = (Player)formattor.Deserialize(ms);
                new Communicator(senderSock, new Game(Communicator.owner, player2));
                Communicator.Game.turn = player2.Nickname;
                hihi = true;
                gs.startGame();
                hihi = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd przy próbie połączenia. Upewnij się, że podałeś poprawny adres IPv6 hosta i spróbuj ponownie.","Błąd");
                return;
            }
            MessageBox.Show("Udało ci się połączyć z serwerem, możecie rozpocząć grę klikając odpowiedni przycisk.", "Błąd");
            gameok = 1;

        }

        private byte[] playerInfo()
        {
            Player p = new Player(textBox3.Text, "rogue");
            Communicator.owner = p;
            MemoryStream fs = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, p);
            byte[] buffer = fs.ToArray();
            return buffer;
        }

        private void button2_Click(object sender, EventArgs e)
        {
                string strHostName = "";
                if (sListener != null)
                {
                    sListener.Close();
                    //sListener.Shutdown(SocketShutdown.Both);
                   // sListener.Disconnect(true);
                }
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

        }

        private void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);
                byte[] bytesRec = new byte[25000];
                int msgSize = handler.Receive(bytesRec);
                BinaryFormatter formattor = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(bytesRec);
                player2 = (Player)formattor.Deserialize(ms);
                handler.Send(playerInfo());
                new Communicator(handler, new Game(Communicator.owner, player2));
                Communicator.Game.turn = Communicator.owner.Nickname;
                MessageBox.Show("Ktoś się z tobą połączył, możecie rozpocząć grę klikając odpowiedni przycisk.", "Komunikat");
                gameok = 1;
            }
            catch (Exception ex)
            {
            }
        }

        private void StartScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sListener != null)
            {
                sListener.Close();
            }
            if (senderSock != null)
            {
                senderSock.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (gameok == 1)
            {
                gs.Show();
                if (hihi == false)
                {
                    gs.startGame();
                }
                gameok = 0;
                if (sListener != null)
                {
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Możesz rozpocząć grę dopiero po nawiązaniu połączenia.", "Komunikat");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
