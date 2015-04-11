using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Windows;

namespace LunchMoneyMatch.Server
{
    public class TcpConnect
    {
        TcpClient tc;
        NetworkStream ns;
        /// <summary>
        /// Creates a rapper for the server connection.
        /// ASSUME: Connection was established successfully.
        /// </summary>
        /// <param name="tc">Open Client Connection</param>
        /// <param name="ns">Open Network Stream</param>
        public TcpConnect(TcpClient tc, NetworkStream ns)
        {
            this.tc = tc;
            this.ns = ns;
        }
        /// <summary>
        /// Gets a pooled message from the server.
        /// </summary>
        /// <returns>Response from the server.</returns>
        public string getMessage()
        {
            string returndata = "";
            byte[] data = new Byte[1];
            do
            {
                Int32 bytes = ns.Read(data, 0, data.Length);
                returndata += System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            }
            while (ns.DataAvailable);
            return returndata;

        }
        /// <summary>
        /// Sends a message to the server.
        /// </summary>
        /// <param name="Message">Message to rely to server.</param>
        public void sendMessage(string Message)
        {
            ns.Write(Encoding.ASCII.GetBytes(Message), 0, Encoding.ASCII.GetBytes(Message).Length);
            ns.Flush();
        }
        /// <summary>
        /// Kills the server.
        /// </summary>
        public void killServer()
        {
            tc.Close();
            ns.Close();
        }
    }
}
