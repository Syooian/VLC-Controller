using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCP
{
    public class TCP
    {
        /// <summary>
        /// 
        /// </summary>
        TcpClient Client;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="Port"></param>
        public TCP(string IP, int Port)
        {
            Client = new TcpClient();
            Client.Connect(IP, Port);

            Thread T = new Thread(new ThreadStart(RunThread));
            T.IsBackground = true;
            T.Start();
        }

        /// <summary>
        /// 執行傳送,接收訊息的副執行續
        /// </summary>
        void RunThread()
        {
            while (Client != null && Client.Connected)
            {
                //https://dotblogs.com.tw/kevintan1983/2010/10/15/18348

                string ReceiveMsg = "";
                byte[] ReceiveBytes = new byte[Client.ReceiveBufferSize];
                int BytesRead = 0;
                NetworkStream ns = Client.GetStream();

                if (ns.CanRead)
                {
                    while (ns.DataAvailable)
                    {
                        BytesRead = ns.Read(ReceiveBytes, 0, Client.ReceiveBufferSize);
                        ReceiveMsg = Encoding.Default.GetString(ReceiveBytes, 0, BytesRead);
                    }

                    if (!string.IsNullOrEmpty(ReceiveMsg))
                    {
                        Console.WriteLine("GetMessage : " + ReceiveMsg);
                        OnGetMessage.Invoke(ReceiveMsg);
                    }
                }

                Thread.Sleep(100);
            }
        }

        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GetMessage"></param>
        public delegate void GetMessageDelegate(string GetMessage);
        /// <summary>
        /// 接收訊息事件
        /// </summary>
        public event GetMessageDelegate OnGetMessage;
        #endregion
    }
}
