using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace VLC_Server_Console
{
    class Server : WebSocketBehavior
    {
        /// <summary>
        /// 劇院ID
        /// </summary>
        public int TheaterID { get { return theaterid; } }
        /// <summary>
        /// 
        /// </summary>
        int theaterid;

        /// <summary>
        /// 
        /// </summary>
        protected override void OnOpen()
        {
            try
            {
                base.OnOpen();

                IPAddress ClientIP = Context.UserEndPoint.Address;

                Program.ShowLog("Client已連線，IP : " + ClientIP);
            }
            catch (Exception ex)
            {
                Console.WriteLine("S1 : " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClose(CloseEventArgs e)
        {
            try
            {
                base.OnClose(e);

                Program.ShowLog("Server Close");
            }
            catch (Exception ex)
            {
                Console.WriteLine("S2 : " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnError(ErrorEventArgs e)
        {
            try
            {
                base.OnError(e);

                Program.ShowLog("Socket錯誤：" + e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("S3 : " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMessage(MessageEventArgs e)
        {
            try
            {
                base.OnMessage(e);

                Program.ShowLog("Socket接收訊息 : " + e.Data);

            }
            catch (Exception ex)
            {
                Console.WriteLine("S4 : " + ex.Message);
            }
        }
    }
}
