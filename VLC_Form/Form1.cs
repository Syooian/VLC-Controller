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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLC_Form
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 
        /// </summary>
        vlcmote.VlcRemote VLCRemote;

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

                    VLCRemote.GetMessageAction -= GetMessage;
                }
            });
        }

        private void Btn_Play_Click(object sender, EventArgs e)
        {
            if (VLCRemote != null)
            {
                VLCRemote.Add("D:\\移動劇院測試用影片\\around0313.mp4");

                VLCRemote.Play();
            }
        }

        private void Btn_Pause_Click(object sender, EventArgs e)
        {
            if (VLCRemote != null)
                VLCRemote.Pause();
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
            if (Server != null)
            {
                Server.Stop();
            }

            //string HostName = Dns.GetHostName();
            //Debug.Print("主機名稱 : " + HostName);

            //IPAddress[] IPA = Dns.GetHostAddresses(HostName);
            //for (int a = 0; a < IPA.Length; a++)
            //    Debug.Print("主機IP : " + IPA[a].ToString());

            try
            {
                Server = new TcpListener(IPAddress.Parse(Tb_LocalIP.Text), int.Parse(Tb_LocalPort.Text));
                Server.Start();
            }
            catch (Exception ex)
            {
                Debug.Print("建立Server錯誤 : " + ex.Message);
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

                    VLCRemote = new vlcmote.VlcRemote(OpenFileDialog.FileName, Tb_LocalIP.Text, Port);
                    VLCRemote.GetMessageAction += GetMessage;
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
    }
}
