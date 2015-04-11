using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace DSEServer
{
    class ServerThread
    {
        private List<User> users;
        TcpClient clientSocket = default(TcpClient);
        private TcpListener tcpServer;
        public Home sharedForm;
        public ServerThread(Home f1)
        {
            tcpServer = new TcpListener(1337);
            tcpServer.Start();
            users = new List<User>(10000);
            sharedForm = f1;
            AppendText("Server Online");
        }
        public void listen()
        {
            while (true)
            {
                clientSocket = tcpServer.AcceptTcpClient();
                Console.WriteLine(users.Count);
                int x = users.Count;
                sharedForm.AppendText("User Connected: " + x +  " AV: " + GC.GetTotalMemory(true));
                users.Add(new User(clientSocket, sharedForm, this, users, x - 1));
            }
        }
        public void AppendText(String text)
        {
            sharedForm.AppendText("[SERVER]: " + text);
        }
        
    }
}
