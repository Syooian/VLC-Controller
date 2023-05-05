using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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

        }

        private void Btn_Play_Click(object sender, EventArgs e)
        {
            if (VLCRemote != null)
                VLCRemote.Play();
        }

        private void Btn_Pause_Click(object sender, EventArgs e)
        {
            if (VLCRemote != null)
                VLCRemote.Pause();
        }

        #region 選擇VLC執行檔
        /// <summary>
        /// 選擇VLC執行檔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SelectVLC_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Txt_VLCLocation.Text = OpenFileDialog.FileName;

                    Debug.Print("選擇檔案 : " + OpenFileDialog.FileName);
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
    }
}
