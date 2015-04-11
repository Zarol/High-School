using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Windows.Forms;

namespace DSEServer
{
    class User
    {
        delegate void AppendText(string newText);
        TcpClient istream;
        Thread curr;
        NetworkStream stream;
        ServerThread super;
        List<User> clients;
        int myLoc;
        Home f1;
        public User(TcpClient tcpLoc, Home f1, ServerThread super, List<User> clients, int myLoc)
        {
            istream = tcpLoc;
            stream = istream.GetStream();
            this.super = super;
            this.clients = clients;
            this.myLoc = myLoc;
            sendMessage("GREET");
            curr = new Thread(requestInformation);
            this.f1 = f1;
            curr.Start();
        }
        private void callbacks()
        {
            requestInformation();
        }
        private void requestInformation()
        {
            string temp;
            String IP = ((IPEndPoint)istream.Client.RemoteEndPoint).Address.ToString();
            while (true)
            {
                if (stream.DataAvailable)
                {
                    temp = getMessage();
                    if (temp.Contains("-kill"))
                    {
                        super.AppendText(temp);
                        istream.Close();
                        stream.Close();
                        curr.Abort();
                        clients.Remove(this);
                    }
                    else if (temp.Contains("idcreation"))
                    {
                        string email, password, firstname, lastname, sex, dob;
                        //  public void CreateAccount(string FirstName, string LastName, string DOB, string Email,string password, string Sex, string DateCreated, string IPCreated)
                        super.AppendText(temp);
                        sendMessage("OK");
                        temp = getMessage(true);
                        String values = temp;
                        super.AppendText(temp);
                        string[] xs = values.Split(';');
                        email = xs[0];
                        password = xs[1];
                        firstname = xs[2];
                        lastname = xs[3];
                        sex = xs[4].ToString();
                        dob = xs[5];
                        super.AppendText("EMAIL:" + email + ";   " + "Password:" + password + ";   " + "FirstName:" + firstname + ";   " + "LASTNAME" + lastname);
                        if (f1.CreateAccount(firstname, lastname, dob, email, password, sex, IP) > 0)
                        {
                            sendMessage("gg");
                        }
                    }
                    else if (temp.Contains("log"))
                    {
                        string[] xs = temp.Substring(4).Split(';');
                        string username = xs[0];
                        string password = xs[1];
                        string userInfo = f1.CheckUsernameAndPassword(username, password);
                        super.AppendText(userInfo);
                        if (userInfo.Length > 0)
                        {
                            sendMessage("clear;" + userInfo);
                        }
                        else
                        {
                            sendMessage("none");

                        }
                    }
                    
                    super.AppendText(IP + ": " + temp);
                }
                if (!IsConnected(istream.Client))
                {
                    super.AppendText("CLIENTDC");
                    istream.Close();
                    stream.Close();
                    curr.Abort();
                    clients.Remove(this);
                }
                else
                {
                    //sendMessage("keepalive");
                }
                Thread.Sleep(1000);
            }
        }
        public NetworkStream getStream()
        {
            return stream;
        }
        public void sendMessage(string Message)
        {
            stream.Write(Encoding.ASCII.GetBytes(Message), 0, Encoding.ASCII.GetBytes(Message).Length);
            stream.Flush();
        }
        public string getMessage()
        {
            string returndata = "";
            byte[] data = new Byte[1];
            if (stream.DataAvailable)
            {
                do
                {
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    returndata += System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                }
                while (stream.DataAvailable);
            }
            return returndata;

        }
        public bool IsConnected(Socket socket)
        {
            try
            {
                return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch (SocketException) { return false; }
        }
        public string getMessage(bool eos)
        {
            string returndata = "";
            byte[] data = new Byte[1];
            do
            {
                Int32 bytes = stream.Read(data, 0, data.Length);
                returndata += System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            }
            while (!returndata.Contains("EOS"));

            return returndata;

        }
        public void addText(string newText)
        {
            string text;
            if (super.sharedForm.txtBox.InvokeRequired)
            {
                AppendText del = new AppendText(super.sharedForm.AppendText);
                text = super.sharedForm.txtBox.Text + DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo) + " " + newText + "\r\n";
                super.sharedForm.txtBox.Invoke(del, new object[] { newText });
            }
        }
    }
}
