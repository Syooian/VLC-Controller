using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLC_Form
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 
        /// </summary>
        Control_VLC.VLCController VLCController;

        public Form1()
        {
            InitializeComponent();

            Txt_VLCLocation.Text = "播放器未選擇";

            //VLCRemote = new vlcmote.VlcRemote();

            FormClosing += ((Sender, E) =>
            {
                Debug.Print("APP關閉");

                if (Server != null)
                {
                    Server.Stop();

                    //VLCRemote.GetMessageAction -= GetMessage;
                }
            });
        }

        #region TCP
        /// <summary>
        /// 
        /// </summary>
        TcpListener Server;

        /// <summary>
        /// 啟動與播放器間的監聽
        /// </summary>
        void StartServer()
        {
            //if (Server != null)
            //{
            //    Server.Stop();
            //}

            //string HostName = Dns.GetHostName();
            //Debug.Print("主機名稱 : " + HostName);

            //IPAddress[] IPA = Dns.GetHostAddresses(HostName);
            //for (int a = 0; a < IPA.Length; a++)
            //    Debug.Print("主機IP : " + IPA[a].ToString());

            //try
            //{
            //    Server = new TcpListener(IPAddress.Parse(Tb_LocalIP.Text), int.Parse(Tb_LocalPort.Text));
            //    Server.Start();
            //}
            //catch (Exception ex)
            //{
            //    Debug.Print("建立Server錯誤 : " + ex.Message);
            //}

            Thread Load = new Thread(new ThreadStart(LoadingThread));
            Load.IsBackground = true;
            Load.Start();


            //Txt_CurrentTime.Invoke((MethodInvoker)() =>  Txt_CurrentTime.Text = VLCController.CurrentTime.ToString());
        }

        void LoadingThread()
        {
            while (true)
            {
                if (VLCController != null)
                {
                    //Txt_CurrentTime.Invoke((MethodInvoker)(() => { Txt_CurrentTime.Text = VLCController.CurrentTime.ToString(); }));
                    Invoke((MethodInvoker)(() => { Txt_CurrentTime.Text = VLCController.GetCurrentTime.ToString(); }));
                }

                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Server接收訊息
        /// </summary>
        void GetMessage(string Msg)
        {
            Debug.Print("Get : " + Msg);
        }
        #endregion

        #region 選擇VLC執行檔
        /// <summary>
        /// 選擇VLC執行檔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SelectVLC_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Exe Files (.exe)|*.exe|All Files (*.*)|*.*";

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Txt_VLCLocation.Text = OpenFileDialog.FileName;

                    Debug.Print("選擇檔案 : " + OpenFileDialog.FileName);

                    //Debug.Print("連線IP : " + Tb_ServerIP.Text + ", Port : " + Port);

                    int Port = int.Parse(Tb_LocalPort.Text);

                    StartServer();

                    VLCController = new Control_VLC.VLCController(OpenFileDialog.FileName, Tb_LocalIP.Text, Port);
                }
                catch (SecurityException ex)
                {
                    Txt_VLCLocation.Text = "安全性錯誤 : " + ex.Message;
                }
                catch (Exception ex)
                {
                    Txt_VLCLocation.Text = "選擇檔案錯誤 : " + ex.Message;
                }
            }
        }
        #endregion

        private void Tb_Port_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_Port_Click(object sender, EventArgs e)
        {

        }

        private void Tb_ServerIP_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 按下停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            if (VLCController != null)
                VLCController.Stop();
        }
        /// <summary>
        /// 按下新增影片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            if (VLCController != null)
            {
                VLCController.Add("D:\\移動劇院測試用影片\\around0313.mp4");
            }
        }
        /// <summary>
        /// 按下播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Play_Click(object sender, EventArgs e)
        {
            if (VLCController != null)
            {
                VLCController.Play();

                Debug.Print("影片總長 : " + VLCController.GetTotalTime);
            }
        }
        /// <summary>
        /// 按下暫停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Pause_Click(object sender, EventArgs e)
        {
            if (VLCController != null)
                VLCController.Pause();
        }
    }
}
