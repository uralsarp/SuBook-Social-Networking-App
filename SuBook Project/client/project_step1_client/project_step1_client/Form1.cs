using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {

        bool terminating = false;
        bool connected = false;
        Socket clientSocket;
        bool server = true;
        bool clientclose = true;
        bool connection = false;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }
        string user;
        private void button_connect_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = textBox_IP.Text;
            int portNum;
            if (IP == "")
            {
                logs.AppendText("IP cannot be empty\n");

            }
            else
            {
                if (Int32.TryParse(textBox_Port.Text, out portNum))
                {
                    try
                    {

                        clientSocket.Connect(IP, portNum);
                        button_connect.Enabled = false;
                        button_send.Enabled = true;
                        textBox_post.Enabled = true;
                        textBox_Username.Enabled = true;
                        button_disconnect.Enabled = true;
                        connected = true;

                        string username;
                        username = textBox_Username.Text;

                        if (username == "")
                        {
                            logs.AppendText("Please enter your username!\n");
                            string empty = "empty";
                            Byte[] buffer = Encoding.Default.GetBytes(empty);
                            clientSocket.Send(buffer);
                            button_connect.Enabled = true;
                            button_disconnect.Enabled = false;
                            button_send.Enabled = false;
                            textBox_post.Enabled = false;
                        }
                        else
                        {
                            bool exists = false;
                            bool online = false;
                            foreach (string line in File.ReadLines("../../user-db.txt")) // path to the txt file inside server folder
                            {
                                string dbusername;
                                dbusername = line;
                                if (dbusername == username)
                                {
                                    exists = true;
                                }
                            }
                            if (exists == false)
                            {
                                logs.AppendText("Please enter a valid username!\n");
                                username = username + '*';
                                Byte[] buffer = Encoding.Default.GetBytes(username);
                                clientSocket.Send(buffer);
                                textBox_post.Enabled = false;
                                button_send.Enabled = false;
                                button_connect.Enabled = true;
                                button_disconnect.Enabled = false;
                            }
                            else
                            {

                                foreach (string line2 in File.ReadLines("../../users.txt"))
                                {
                                    string activeUser = line2;
                                    if (activeUser == username)
                                    {
                                        online = true;
                                    }
                                }

                                if (online)
                                {
                                    logs.AppendText("There are already existing users with this username!\n");
                                    button_connect.Enabled = true;
                                    button_disconnect.Enabled = false;
                                    button_send.Enabled = false;
                                    textBox_post.Enabled = false;
                                    string existing = "existing";
                                    Byte[] buffer = Encoding.Default.GetBytes(existing);
                                    clientSocket.Send(buffer);
                                    connection = true;

                                }
                                else
                                {
                                    using (StreamWriter file = new StreamWriter("../../users.txt", append: true)) //get the database.txt's path which is in the server folder
                                    {
                                        file.WriteLine(username);
                                    }                               
                                    logs.AppendText("Hello " + username + ". You are connected to the server!\n");
                                    user = username;
                                    username = username + '%';
                                    Byte[] buffer = Encoding.Default.GetBytes(username);
                                    clientSocket.Send(buffer);
                                    button_allposts.Enabled = true;
                                    button_addfriend.Enabled = true;
                                    button_delete.Enabled = true;
                                    textBox_postID.Enabled = true;
                                    textBox_user.Enabled = true;
                                    button_myposts.Enabled = true;
                                    button_friendpost.Enabled = true;
                                    button_removefriend.Enabled = true;
                                    button_showfriend.Enabled=true;
                                    textBox_deletefriend.Enabled = true;
                                    clientclose = true;
                                    connection = true;
                                }
                            }

                            Thread receiveThread = new Thread(Receive);
                            receiveThread.Start();
                        }
                    }

                    catch
                    {

                        logs.AppendText("Could not connect to the server!\n");
                    }
                }

                else
                {

                    logs.AppendText("Check your port number!\n");
                }

            }
        }
        private void Receive()
        {
            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    clientSocket.Receive(buffer);
                    string incomingMessage = Encoding.Default.GetString(buffer);
                }
                catch
                {

                    if (!terminating)
                    {
                        logs.AppendText("\nThe server has disconnected\n");
                        server = false;
                        button_connect.Enabled = true;
                        button_send.Enabled = false;
                        button_allposts.Enabled = false;
                        textBox_Username.Enabled = true;
                        textBox_post.Enabled = false;
                        button_disconnect.Enabled = false;
                        button_addfriend.Enabled = false;
                        button_delete.Enabled = false;
                        textBox_postID.Enabled = false;
                        textBox_user.Enabled = false;
                        button_myposts.Enabled = false;
                        button_friendpost.Enabled = false;
                        button_removefriend.Enabled = false;
                        button_showfriend.Enabled = false;
                        textBox_deletefriend.Enabled = false;
                        connection = true;
                    }

                    clientSocket.Close();
                    connected = false;
                }
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;
            string usernamelast = '+' + user;
            Byte[] buffer = Encoding.Default.GetBytes(usernamelast);
            if (server && clientclose && connection)
            {
                clientSocket.Send(buffer);
                logs.AppendText(user + " has disconnected\n");
            }
            else
            {
                logs.AppendText(user + " has disconnected\n");
            }

            var Lines = File.ReadAllLines("../../users.txt");
            var newLines = Lines.Where(line => !line.Contains(user));
            File.WriteAllLines("../../users.txt", newLines);
            Environment.Exit(0);
        }



        private void button_disconnect_Click(object sender, EventArgs e)
        {
            connected = false;
            terminating = true;
            button_connect.Enabled = true;
            button_send.Enabled = false;
            textBox_post.Enabled = false;
            textBox_Username.Enabled = true;
            button_allposts.Enabled = false;
            button_disconnect.Enabled = false;
            button_addfriend.Enabled = false;
            button_delete.Enabled = false;
            textBox_postID.Enabled = false;
            textBox_user.Enabled = false;
            button_myposts.Enabled = false;
            button_friendpost.Enabled = false;
            button_removefriend.Enabled = false;
            button_showfriend.Enabled = false;
            textBox_deletefriend.Enabled = false;

            string usernamelast = '+' + user;
            Byte[] buffer = Encoding.Default.GetBytes(usernamelast);
            clientSocket.Send(buffer);
            clientSocket.Close();
            logs.AppendText("\nSuccessfully disconnected\n");

            var Lines = File.ReadAllLines("../../users.txt");
            var newLines = Lines.Where(line => !line.Contains(user));
            File.WriteAllLines("../../users.txt", newLines);

            clientclose = false;
            connection = true;
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            string postID;
            if (new FileInfo("../../posts.txt").Length == 0)
            {
                postID = "1";
            }
            else
            {
                var lastLine = File.ReadLines("../../posts.txt").Last();
                if (lastLine.Contains('-'))
                {
                    int indx = lastLine.IndexOf('%');
                    postID = lastLine.Substring(0, indx);
                    int result = Int32.Parse(postID);
                    result = (result + 1);
                    string resultstr = result.ToString();
                    postID = resultstr;
                }
                else
                {
                    postID = "1";
                }
            }


            string post = textBox_post.Text;
            string time = DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss");
            var charsToRemove = new string[] { "’", "‘" };
            foreach (var c in charsToRemove)
            {
                time = time.Replace(c, string.Empty);
            }

            string final = user + '-' + post;
            if (post == "")
            {

            }
            else
            {
                Byte[] buffer = Encoding.Default.GetBytes(final);
                clientSocket.Send(buffer);
                logs.AppendText("You have successfully sent a post!\n");
                logs.AppendText(user + ": " + post + "\n");


                string clientfinal = postID + '%' + user + '-' + post + '*' + time;

                using (StreamWriter file = new StreamWriter("../../posts.txt", append: true)) //get the database.txt's path which is in the server folder
                {
                    file.WriteLine(clientfinal);
                }

            }
            connection = true;
        }

        private void button_allposts_Click(object sender, EventArgs e)
        {
            foreach (string line in File.ReadLines("../../posts.txt")) // path to the txt file inside server folder
            {
                //../../posts.txt 
                //serverdan post oku
                //son linedaki post id si
                if (!line.Contains('-'))
                {

                }
                else
                {
                    int idx = line.IndexOf('%');
                    string postid = line.Substring(0, idx);
                    int idx3 = line.IndexOf('-');
                    string usermess = line.Substring(idx + 1, (idx3 - idx - 1));
                    if (usermess == user)
                    {

                    }
                    else
                    {
                        logs.AppendText("\nShowing all posts for you: \n");
                        int idx2 = line.IndexOf('*');
                        //usermess=username          
                        int idx1 = idx2 - 1 - idx3;
                        string post = line.Substring(idx3 + 1, idx1);
                        string time1 = line.Substring(idx2 + 1);

                        logs.AppendText("Username: " + usermess + "\n");
                        logs.AppendText("Post ID: " + postid + "\n");
                        logs.AppendText("Post: " + post + "\n");
                        logs.AppendText("Time: " + time1 + "\n");

                    }
                }

            }
            string usernamelast = '&' + user;
            Byte[] buffer = Encoding.Default.GetBytes(usernamelast);
            clientSocket.Send(buffer);
            connection = true;
        }

        private void button_addfriend_Click(object sender, EventArgs e)
        {

            string friend = textBox_user.Text;
            if (user == friend)
            {
                logs.AppendText("You cannot add yourself!\n");
            }
            else if (friend == "")
            {
                logs.AppendText("Type a username!\n");
            }
            else
            {
                bool exists = false;
                bool self = false;
                foreach (string line in File.ReadLines("../../user-db.txt")) // path to the txt file inside server folder
                {
                    string dbusername;
                    dbusername = line;
                    if (dbusername == friend)
                    {
                        exists = true;
                    }
                    else if (user == friend)
                    {
                        self = true;
                    }
                }
                if (exists == false)
                {
                    logs.AppendText("The user you are trying to add is not in the db!\n");
                }
                else if (self == true)
                {
                    logs.AppendText("You cannot add yourself!\n");
                }
                else
                {

                    string[] file = File.ReadAllLines("../../friends.txt");
                    File.Delete("../../friends.txt");// Deleting the file
                    using (StreamWriter sw = File.AppendText("../../friends.txt"))
                    {
                        bool userfound = false;
                        bool dbcheck = false;
                        bool fileempty = false;
                        bool firstline = true;
                        if (file.Length != 0)
                        {
                            foreach (string line in file)
                            {
                                if (line != "")
                                {
                                    int idx1 = line.IndexOf(":");
                                    string newus = line.Substring(0, idx1);
                                    if (user == newus)
                                    {
                                        userfound = true;
                                        if (!line.Contains(friend))
                                        {
                                            string finfriend = friend + " ";
                                            string linenew = line + finfriend;
                                            sw.WriteLine(linenew);
                                        }
                                        else
                                        {
                                            sw.WriteLine(line);
                                        }
                                    }
                                    else if (friend == newus)
                                    {
                                        dbcheck = true;
                                        if (!line.Contains(user))
                                        {
                                            string finfriend = user + " ";
                                            string linenew = line + finfriend;
                                            sw.WriteLine(linenew);
                                        }
                                        else
                                        {
                                            sw.WriteLine(line);
                                        }
                                    }
                                    else
                                    {
                                        sw.WriteLine(line);
                                    }

                                }
                                else
                                {
                                    string addline = user + ":" + friend + " ";
                                    firstline = false;
                                    sw.WriteLine(addline);
                                }
                            }

                        }
                        else
                        {
                            string addline = user + ":" + friend + " ";
                            fileempty = true;
                            sw.WriteLine(addline);

                        }
                        if (!dbcheck)
                        {
                            string addline1 = friend + ":" + user + " ";
                            sw.WriteLine(addline1);
                        }
                        if (!userfound && !fileempty && firstline)
                        {
                            string addline = user + ":" + friend + " ";
                            sw.WriteLine(addline);
                        }
                    }
                    logs.AppendText("You have added " + friend + " as a friend!\n");
                    string message = 'ß' + user + 'æ' + friend;
                    Byte[] buffer = Encoding.Default.GetBytes(message);
                    clientSocket.Send(buffer);
                }

            }                                                   
            connection = true;
        }

        private void button_myposts_Click(object sender, EventArgs e)
        {
            foreach (string line in File.ReadLines("../../posts.txt")) // path to the txt file inside server folder
            {
                //../../posts.txt 
                //serverdan post oku
                //son linedaki post id si
                if (!line.Contains('-'))
                {

                }
                else
                {
                    int idx = line.IndexOf('%');
                    string postid = line.Substring(0, idx);
                    int idx3 = line.IndexOf('-');
                    string usermess = line.Substring(idx + 1, (idx3 - idx - 1));
                    if (usermess == user)
                    {
                        logs.AppendText("\nShowing all posts for you: \n");
                        int idx2 = line.IndexOf('*');
                        //usermess=username          
                        int idx1 = idx2 - 1 - idx3;
                        string post = line.Substring(idx3 + 1, idx1);
                        string time1 = line.Substring(idx2 + 1);

                        logs.AppendText("Username: " + usermess + "\n");
                        logs.AppendText("Post ID: " + postid + "\n");
                        logs.AppendText("Post: " + post + "\n");
                        logs.AppendText("Time: " + time1 + "\n");
                    }
                    else
                    {

                    }
                }

            }
            string usernamelast = '|' + user;
            Byte[] buffer = Encoding.Default.GetBytes(usernamelast);
            clientSocket.Send(buffer);
            connection = true;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {

            string postID = textBox_postID.Text;

            string[] Lines = File.ReadAllLines("../../posts.txt");
            File.Delete("../../posts.txt");// Deleting the file
            using (StreamWriter sw = File.AppendText("../../posts.txt"))
            {
                bool name = false;
                bool flag = true;
                foreach (string line in Lines)
                {
                    int idx = line.IndexOf('%');
                    int idx3 = line.IndexOf('-');
                    string usermess = line.Substring(idx + 1, (idx3 - idx - 1));
                    if (line.Substring(0, idx) == postID && usermess == user)
                    {
                        name = true;
                        continue;
                    }
                    else if (line.Substring(0, idx) == postID && usermess != user)
                    {
                        flag = false;
                        sw.WriteLine(line);
                    }

                    else
                    {
                        sw.WriteLine(line);
                    }
                }
                if (name == true)
                {
                    logs.AppendText("Post with ID: " + postID + " is deleted successfully\n");
                    postID = '€' + postID;
                    Byte[] buffer = Encoding.Default.GetBytes(postID);
                    clientSocket.Send(buffer);
                }
                else if (flag == true)
                {
                    logs.AppendText("There is no post with ID: " + postID + "\n");
                    postID = '#' + postID;
                    Byte[] buffer = Encoding.Default.GetBytes(postID);
                    clientSocket.Send(buffer);
                }
                else
                {
                    logs.AppendText("Post with ID: " + postID + " is not yours\n");
                    string message = '¨' + postID + '+' + user;
                    Byte[] buffer = Encoding.Default.GetBytes(message);
                    clientSocket.Send(buffer);
                }
            }

            connection = true;
        }

        private void button_showfriend_Click(object sender, EventArgs e)
        {
            friendBox.AppendText("Showing Your Current Friends: \n");
            string[] file = File.ReadAllLines("../../friends.txt");
            foreach (string line in file)
            {
                if (line != "")
                {
                    int idx1 = line.IndexOf(":");
                    string newus = line.Substring(0, idx1);
                    if (user == newus)
                    {
                        string allfriends = line.Substring(idx1 + 1);
                        friendBox.AppendText(allfriends + "\n");
                        logs.AppendText("You have " + allfriends + " in your friendlist!\n");
                    }
                }
                else
                {

                }
            }

        }

        private void button_friendpost_Click(object sender, EventArgs e)
        {

            string[] friendlist= new string[] { }; 
            string[] file = File.ReadAllLines("../../friends.txt");
            foreach (string line in file)
            {
                if (line != "")
                {
                    int idx1 = line.IndexOf(":");
                    string newus = line.Substring(0, idx1);
                    if (user == newus)
                    {                        
                        string allfriends = line.Substring(idx1 + 1);
                        friendlist=allfriends.Split(' ');                      
                        friendlist = friendlist.Take(friendlist.Count() - 1).ToArray(); //remove last element
                    }
                }
                else
                {

                }
            }

            foreach (string line in File.ReadLines("../../posts.txt")) // path to the txt file inside server folder
            {
                //../../posts.txt 
                //serverdan post oku
                //son linedaki post id si
                if (!line.Contains('-'))
                {
                    
                }
                else
                {
                    int idx = line.IndexOf('%');
                    string postid = line.Substring(0, idx);
                    int idx3 = line.IndexOf('-');
                    string usermess = line.Substring(idx + 1, (idx3 - idx - 1));
                    int pos = Array.IndexOf(friendlist, usermess);
                    bool contain = false;
                    if (pos > -1)
                    {
                        contain = true;
                    }
                    else
                    {

                    }

                    if (contain==false)
                    {

                    }
                    else
                    {
                        logs.AppendText("\nShowing all posts from friends: \n");
                        int idx2 = line.IndexOf('*');
                        //usermess=username          
                        int idx1 = idx2 - 1 - idx3;
                        string post = line.Substring(idx3 + 1, idx1);
                        string time1 = line.Substring(idx2 + 1);

                        logs.AppendText("Username: " + usermess + "\n");
                        logs.AppendText("Post ID: " + postid + "\n");
                        logs.AppendText("Post: " + post + "\n");
                        logs.AppendText("Time: " + time1 + "\n");

                    }
                }

            }

        }

        private void button_removefriend_Click(object sender, EventArgs e)
        {
            string deletefriend = textBox_deletefriend.Text;
            if (user == deletefriend)
            {
                logs.AppendText("You cannot remove yourself!\n");
            }
            else if (deletefriend == "")
            {
                logs.AppendText("Type a username!\n");
            }
            else
            {
                string[] file = File.ReadAllLines("../../friends.txt");
                File.Delete("../../friends.txt");// Deleting the file
                using (StreamWriter sw = File.AppendText("../../friends.txt"))
                {
                    foreach (string line in file)
                    {
                        if (line != "")
                        {
                            int idx1 = line.IndexOf(":");
                            string newus = line.Substring(0, idx1);
                            if (user == newus)
                            {
                                if (!line.Contains(deletefriend))
                                {
                                    sw.WriteLine(line);
                                }
                                else
                                {
                                    int idx = deletefriend.Length;
                                    int index1 = line.IndexOf(deletefriend); //11                                
                                    string newline = line.Remove(index1, (idx + 1));
                                    sw.WriteLine(newline);
                                }
                            }
                            else if (deletefriend == newus)
                            {
                                if (!line.Contains(user))
                                {
                                    sw.WriteLine(line);
                                }
                                else
                                {
                                    int idx = user.Length;
                                    int index1 = line.IndexOf(user);
                                    string newline = line.Remove(index1, (idx + 1));
                                    sw.WriteLine(newline);
                                }
                            }
                            else
                            {
                                sw.WriteLine(line);
                            }

                        }
                        else
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
                logs.AppendText("You have removed " + deletefriend + " from your friend list.\n");
                string message = '½' + user + '[' + deletefriend;
                Byte[] buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
            }
 
            connection = true;
        }

    }
}

