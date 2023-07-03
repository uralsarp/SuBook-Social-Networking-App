using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();

        bool terminating = false;
        bool listening = false;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }
        string user;
        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;
            if (Int32.TryParse(textBox_svport.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(5);

                listening = true;
                button_listen.Enabled = false;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                svlogs.AppendText("Started listening on port: " + serverPort + "\n");
            }

            else
            {
                svlogs.AppendText("Check the port number\n");
            }
        }

        private void Accept()
        {
            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    string check = receiveMessage(newClient);
                    if (check.Contains('*'))
                    {
                        string result = check.Remove(check.Length - 1);
                        svlogs.AppendText(result + " tried to connect to the server but this username doesn't exist.\n");
                    }
                    else if (check.Contains('%'))
                    {
                        clientSockets.Add(newClient);
                        string result = check.Remove(check.Length - 1);
                        svlogs.AppendText(result + " is connected.\n");
                        user = result;
                        Thread receiveThread = new Thread(() => Receive(newClient)); // updated 
                        receiveThread.Start();
                    }
                    else if (check == "empty")
                    {

                    }
                    else if (check == "existing")
                    {

                    }
                    else
                    {
                        Thread receiveThread = new Thread(() => Receive(newClient)); // updated 
                        receiveThread.Start();
                    }

                }

                catch
                {

                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        svlogs.AppendText("The socket stopped working.\n");
                    }
                }
            }
        }

        private void Receive(Socket thisClient)
        {
            bool connected = true;

            while (connected && !terminating)
            {
                try
                {
                    string message = receiveMessage(thisClient);
                    if (message[0] == '+')
                    {
                        user = message.Substring(1);
                        throw new Exception(user);
                    }
                    else if (message[0] == '&')
                    {
                        string usern = message.Substring(1);
                        svlogs.AppendText("Showed all posts for " + usern + "\n");
                    }
                    else if (message[0] == '|')
                    {
                        string usern = message.Substring(1);
                        svlogs.AppendText("Showed " + usern + "'s posts\n");
                    }
                    else if (message[0] == '€')
                    {
                        string postID = message.Substring(1);
                        svlogs.AppendText("Post with ID: " + postID + " is deleted\n");
                    }
                    else if (message[0] == '#')
                    {
                        string postID = message.Substring(1);
                        svlogs.AppendText("Post with ID: " + postID + " does not exist\n");
                    }
                    else if (message[0] == '¨')
                    {
                        int idx = message.IndexOf('¨');
                        int idx2 = message.IndexOf('+');
                        string postID = message.Substring(idx + 1, idx2 - 1);
                        string usern = message.Substring(idx2 + 1);
                        svlogs.AppendText("Post with ID: " + postID + " is not " + usern + "'s\n");
                    }
                    else if (message[0] == 'ß')
                    {
                        int idx = message.IndexOf('ß');
                        int idx2 = message.IndexOf('æ');
                        string username = message.Substring(idx + 1, idx2 - 1);
                        string friend = message.Substring(idx2 + 1);
                        svlogs.AppendText(username + " has added " + friend + " as a friend!\n");
                    }
                    else if (message[0] == '½')
                    {
                        int idx = message.IndexOf('½');
                        int idx2 = message.IndexOf('[');
                        string username = message.Substring(idx + 1, idx2 - 1);
                        string friend = message.Substring(idx2 + 1);
                        svlogs.AppendText(username + " has removed " + friend + " from friends!\n");
                    }
                    else
                    {
                        int idx = message.IndexOf('-');
                        string usermess = message.Substring(0, idx);
                        string finmess = message.Substring(idx + 1);
                        svlogs.AppendText(usermess + " has sent a message: \n");
                        svlogs.AppendText(finmess + "\n");
                    }

                }
                catch (Exception)
                {
                    if (!terminating)
                    {
                        if (user != "")
                        {
                            svlogs.AppendText(user + " has disconnected\n");
                        }
                    }
                    thisClient.Close();
                    clientSockets.Remove(thisClient);
                    connected = false;
                }
            }
        }
        

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            //File.Create(@"C:\Users\user\Documents\visual studio 2015\Projects\server\server\database.txt").Close();
            Environment.Exit(0);
        }

        private string receiveMessage(Socket clientSocket) // this function receives only one message and returns it
        {
            Byte[] buffer = new Byte[64];
            clientSocket.Receive(buffer);
            string incomingMessage = Encoding.Default.GetString(buffer);
            incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
            return incomingMessage;
        }
    }
}
