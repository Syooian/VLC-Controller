using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using VideoSettingLoader;
using System.Diagnostics;
using System.Threading;
using WebSocketSharp;

namespace VLC_Client_Console
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        static PlayerSettingStruct VideoSetting;

        /// <summary>
        /// 
        /// </summary>
        static VLCControllerLib.VLCController VLCController;

        static void Main(string[] args)
        {
            ClientSettingStruct ClientSetting;
            #region 讀取Client設定檔
            {
                Console.WriteLine("讀取影片設定檔");
                string ClientSettingFile = Directory.GetCurrentDirectory() + "/ClientSetupConfig.json";

                if (File.Exists(ClientSettingFile))
                {
                    try
                    {
                        ClientSetting = JsonConvert.DeserializeObject<ClientSettingStruct>(File.ReadAllText(ClientSettingFile));
                        //ClientSetting = new ClientSettingStruct();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("影片設定檔解碼錯誤，請檢查是否編寫正確 : " + ex.Message);
                        Console.ReadLine();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("影片設定檔不存在 : " + ClientSettingFile);
                    Console.ReadLine();
                    return;
                }
            }

            if (string.IsNullOrEmpty(ClientSetting.VLCPath))
            {
                Console.WriteLine("VLC執行檔位置指定失敗");
                Console.ReadLine();
                return;
            }
            #endregion

            #region 讀取影片設定檔
            VideoSetting = VideoSettingLoader.VideoSettingLoader.LoadVideoSetting(ClientSetting.VideoFilePath + "/OfficeVideo.json", out string Error);
            if (!string.IsNullOrEmpty(Error))
            {
                Console.WriteLine("讀取影片設定檔錯誤 : " + Error);
                Console.ReadLine();
                return;
            }

            if (VideoSetting.VideoData == null)
            {
                Console.WriteLine("影片資料為Null，請檢查影片設定檔");
                Console.ReadLine();

                return;
            }
            else
            {
                for (int a = 0; a < VideoSetting.VideoData.Length; a++)
                {
                    Debug.Print(VideoSetting.VideoData[a].ID + " : " + VideoSetting.VideoData[a].Name);
                }
            }
            #endregion

            Console.WriteLine("Client初始化完成");

            #region WebSocket連線
            try
            {
                Socket = new WebSocket($"ws://" + ClientSetting.ServerConnection.IP + ":" + ClientSetting.ServerConnection.Port + "/");
                Socket.OnOpen += OnSocketOpen;
                Socket.OnClose += OnSocketClose;
                Socket.OnError += OnSocketError;
                Socket.OnMessage += OnSocketMessage;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Socket連線設定失敗 : " + ex.Message);
                Console.ReadLine();
                return;
            }

            try
            {
                Console.WriteLine("連線中...");

                Socket.Connect();
            }
            catch (WebSocketException ex)
            {
                Console.WriteLine("Socket連線失敗1 : " + ex.Message);
                Console.ReadLine();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Socket連線失敗2 : " + ex.Message);
                Console.ReadLine();
                return;
            }
            #endregion

            Console.ReadLine();
        }

        #region WebSocket
        /// <summary>
        /// 
        /// </summary>
        static WebSocket Socket;
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
            Console.WriteLine("Socket GetMessage : " + Sender);
        }

        /// <summary>
        /// 
        /// </summary>
        static void RnnThread()
        {
            while (true)
            {



                Thread.Sleep(100);
            }
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    struct ClientSettingStruct
    {
        /// <summary>
        /// 與伺服器的連線
        /// </summary>
        public ServerURLStruct ServerConnection;
        /// <summary>
        /// 影片設定檔和影片檔放置路徑
        /// </summary>
        public string VideoFilePath;
        /// <summary>
        /// VLC播放器路徑
        /// </summary>
        public string VLCPath;
        /// <summary>
        /// 畫面寬高
        /// </summary>
        public Vector2 Canvas;
        /// <summary>
        /// 
        /// </summary>
        public CameraStruct[] Camera;
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    struct CameraStruct
    {
        /// <summary>
        /// 攝影機位置 (World)
        /// </summary>
        public Vector2 Position;
        /// <summary>
        /// 
        /// </summary>
        public int Size;
        /// <summary>
        /// 
        /// </summary>
        public int TargetDisplay;
        /// <summary>
        /// 旋轉角度
        /// </summary>
        public float RotationAngle;
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct Vector2
    {
        public float x;
        public float y;
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct ServerURLStruct
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
        public ServerURLStruct(string IP, int Port)
        {
            this.IP = IP;
            this.Port = Port;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return IP + ":" + Port;
        }
    }
}
