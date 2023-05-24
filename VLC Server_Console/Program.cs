using System;
using System.Collections.Generic;
using System.Linq;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace VLC_Server_Console
{
    class Program
    {
        #region WebSocket
        /// <summary>
        /// 
        /// </summary>
        static WebSocketServer Socket;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="E"></param>
        static void OnSocketOpen(object Sender, EventArgs E)
        {
            Console.WriteLine("Socket Open : " + Sender);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="E"></param>
        static void OnSocketClose(object Sender, EventArgs E)
        {
            Console.WriteLine("Socket Close : " + Sender);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="E"></param>
        static void OnSocketError(object Sender, EventArgs E)
        {
            Console.WriteLine("Socket Error : " + Sender);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="E"></param>
        static void OnSocketMessage(object Sender, MessageEventArgs E)
        {
            Console.WriteLine("Socket GetMessage : " + E.Data);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region 設定檔讀取
            ConnectionConfigStruct Config;
            {
                ShowLog("讀取設定檔");

                string ConfigFile = Directory.GetCurrentDirectory() + "/SetupConfig.json";

                if (File.Exists(ConfigFile))
                {
                    try
                    {
                        Config = JsonConvert.DeserializeObject<ConnectionConfigStruct>(File.ReadAllText(ConfigFile));
                    }
                    catch (Exception ex)
                    {
                        ShowLog("設定檔解碼錯誤，請檢查是否編寫正確 : " + ex.Message);
                        Console.ReadLine();
                        return;
                    }
                }
                else
                {
                    ShowLog("設定檔不存在 : " + ConfigFile);
                    Console.ReadLine();
                    return;
                }
            }
            #endregion

            #region WebSocket連線
            try
            {
                Socket = new WebSocketServer(Config.Port);
                Socket.Start();
            }
            catch (Exception ex)
            {
                ShowLog("Server啟動失敗 : " + ex.Message);
                Console.ReadLine();
                return;
            }
            #endregion

            ShowLog("Server啟動成功，Port : " + Socket.Port);
            Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        static void ShowLog(string Msg)
        {
            string LogMsg = DateTime.Now.ToString() + "	" + Msg;

            Console.WriteLine(LogMsg);
        }
    }
}

/// <summary>
/// 
/// </summary>
[Serializable]
public struct ConnectionConfigStruct
{
    /// <summary>
    /// 
    /// </summary>
    public string IP;
    /// <summary>
    /// 
    /// </summary>
    public int Port;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="IP"></param>
    /// <param name="Port"></param>
    public ConnectionConfigStruct(string IP, int Port)
    {
        this.IP = IP;
        this.Port = Port;
    }
}