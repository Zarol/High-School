using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Windows;
namespace LunchMoneyMatch.Server
{
    public class ServerControl
    {        
        public TcpConnect tc = null;
        public UserInfo ui = null;
        public ServerControl()
        {
        }
        public bool Connect()
        {
            
            TcpClient tcpcl = new TcpClient();
            try
            {
                tcpcl.Connect("127.0.0.1", 1337);
                while (true)
                {
                    NetworkStream serverStream = tcpcl.GetStream();
                    byte[] inStream = new byte[10025];
                    serverStream.Read(inStream, 0, (int)tcpcl.ReceiveBufferSize);
                    string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                    if (returndata.Contains("GREET"))
                    {
                        NetworkStream ns = tcpcl.GetStream();
                        tc = new TcpConnect(tcpcl, ns);
                        tc.sendMessage(ServerString.ESTABLISH);
                        return true;
                    }
                }
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                
                return false;
            }
        }
        public bool CanConnect()
        {
            return (tc != null ? true : false);
        }
        
        public UserInfo LogIn(string username, string password)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("log;");
            sb.Append(username + ";");
            sb.Append(password + ";");
            tc.sendMessage(sb.ToString());
            string temp = tc.getMessage();
            if (temp.Contains("clear;"))
            {
                string[] xs = temp.Substring(6).Split(';');
                return new UserInfo(null, null, null, null, null, null, null, null, null, null);
              //  MessageBox.Show(temp);
            }
            return null;
        }
    }
}
