using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PW_Karcianka
{
    class Communicator
    {
        private static Socket socket;
        private static Game game;

        public static Player owner;
        public static Player opponent;

        public delegate void GameUpdateHandler(object sender, System.EventArgs e);
        public static event GameUpdateHandler OnUpdateGame;


        public static Game Game
        {
            get { return Communicator.game; }
            set { Communicator.game = value; }
        }
        public Communicator(Socket sck, Game g)
        {
            socket = sck;
            game = g;
        }

        public static void Receive()
        {
            Socket client = socket;
            try
            {
                StateObject state = new StateObject();
                state.workSocket = client;
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;
                int bytesRead = client.EndReceive(ar);
                BinaryFormatter formattor = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(state.buffer);
                game = (Game)formattor.Deserialize(ms);
                updateGame();
                Receive();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public static void sendGame()
        {
            if (game.typeOfChange != -1)
            {
                game.players[0] = owner;
                game.players[1] = opponent;
            }
            MemoryStream fs = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, game);
            byte[] buffer = fs.ToArray();
            socket.Send(buffer);
        }

        public static void updateGame()
        {
            // Make sure someone is listening to event
            //if (OnUpdateGame == null) return;
            EventArgs args = new EventArgs();
            OnUpdateGame(new Communicator(socket, game), args);
        }
    }
}
