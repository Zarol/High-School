using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Net.Sockets;
namespace Server_Stress_Test
{
    public partial class Form1 : Form
    {
        ArrayList tcpc = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            for (int x = 0; x < Convert.ToInt32(txtAmountToEstablish.Text); x++)
            {
                TcpConnect tc = null;
                TcpClient tcpcl = new TcpClient();
                try
                {
                    tcpcl.Connect("127.0.0.1", 1337);
                        NetworkStream serverStream = tcpcl.GetStream();
                        byte[] inStream = new byte[10025];
                        serverStream.Read(inStream, 0, (int)tcpcl.ReceiveBufferSize);
                        string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                        if (returndata.Contains("GREET"))
                        {
                            NetworkStream ns = tcpcl.GetStream();
                            tc = new TcpConnect(tcpcl, ns);
                            tc.sendMessage(ServerString.ESTABLISH);
                        }
                    
                }
                catch (System.Net.Sockets.SocketException ex)
                {
                    MessageBox.Show("X");
                }

            }
        }
    }
}
