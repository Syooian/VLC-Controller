using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LibVLCSharp.Shared;

namespace Control_VLC
{
    //https://github.com/ZeBobo5/Vlc.DotNet/

    public class VLCController
    {
        /// <summary>
        /// 
        /// </summary>
        LibVLC VLC;
        /// <summary>
        /// 
        /// </summary>
        Media Media;
        /// <summary>
        /// 
        /// </summary>
        MediaPlayer MediaPlayer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="IP"></param>
        /// <param name="Port"></param>
        public VLCController(string Path, string IP, int Port)
        {
            var DirectoryInfo = new DirectoryInfo(Path);

            var Options = new string[]
            {

            };

            VLC = new LibVLC(enableDebugLogs: true);
            //VLC = new LibVLC("-L");   //X
            //VLC = new LibVLC(enableDebugLogs: true, "--loop");    //X
            //VLC = new LibVLC("-R");   //X
            //VLC = new LibVLC("--repeat"); //X
            //VLC = new LibVLC("--input-repeat=2");   //O
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="VideoPath"></param>
        public void Add(string VideoPath)
        {
            Console.WriteLine("Add : " + VideoPath);

            Media = new Media(VLC, VideoPath);
        }

        /// <summary>
        /// 播放
        /// </summary>
        public void Play()
        {
            if (MediaPlayer == null)
            {
                MediaPlayer = new MediaPlayer(VLC);

                //無用
                //MediaPlayer.Forward += new EventHandler<EventArgs>((Sender, E) => { Console.WriteLine("影片前進!!!"); });
                //MediaPlayer.Backward += new EventHandler<EventArgs>((Sender, E) => { Console.WriteLine("影片後退!!!"); });

                //播放結束時
                MediaPlayer.EndReached += PlayEnd;

                //MediaPlayer.Stopped += (S, E) => { Console.WriteLine("播放器已停止"); };
                //不合理
                //MediaPlayer.Stopped += PlayEnd;

                //MediaPlayer.Paused += (S, E) => { Console.WriteLine("播放器已暫停"); };

                //MediaPlayer.Playing += (S, E) => { Console.WriteLine("播放器正在播放"); };
            }

            MediaPlayer.Media = Media;

            MediaPlayer.Play();
        }

        /// <summary>
        /// 影片前進
        /// </summary>
        /// <param name="Second">前進的秒數</param>
        public void Forward(int Second)
        {
            if (MediaPlayer != null && MediaPlayer.IsSeekable)
            {
                MediaPlayer.SeekTo(TimeSpan.FromSeconds(GetCurrentTime).Add(TimeSpan.FromSeconds(Second)));
            }
        }
        /// <summary>
        /// 到指定秒數
        /// </summary>
        /// <param name="Second"></param>
        public void GoTo(int Second)
        {
            if (MediaPlayer != null && MediaPlayer.IsSeekable)
            {
                MediaPlayer.SeekTo(TimeSpan.FromSeconds(Second));
            }
        }
        /// <summary>
        /// 影片後退
        /// </summary>
        /// <param name="Second">後退的秒數</param>
        public void Backward(int Second)
        {
            if (MediaPlayer != null && MediaPlayer.IsSeekable)
            {
                MediaPlayer.SeekTo(TimeSpan.FromSeconds(GetCurrentTime).Subtract(TimeSpan.FromSeconds(Second)));
            }
        }

        /// <summary>
        /// 音量控制
        /// <para>0~100 (%)</para>
        /// </summary>
        public int Volume
        {
            get
            {
                if (MediaPlayer == null)
                    return 0;
                else
                    return MediaPlayer.Volume;
            }
            set
            {
                if (MediaPlayer != null)
                    MediaPlayer.Volume = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsPlaying
        {
            get
            {
                if (MediaPlayer == null)
                    return false;
                else
                    return MediaPlayer.IsPlaying;
            }
        }
        /// <summary>
        /// 影片總秒數
        /// <para>單位：秒, -1 : 錯誤</para>
        /// </summary>
        public int GetTotalTime
        {
            get
            {
                if (MediaPlayer == null)
                    return -1;
                else
                {
                    return (int)TimeSpan.FromMilliseconds(MediaPlayer.Length).TotalSeconds;
                }
            }
        }
        /// <summary>
        /// 現在播放時間總秒數
        /// <para>單位：秒, -1 : 無影片</para>
        /// </summary>
        public int GetCurrentTime
        {
            get
            {
                if (MediaPlayer == null)
                    return -1;
                else
                {
                    return (int)TimeSpan.FromMilliseconds(MediaPlayer.Time).TotalSeconds;
                }
            }
        }

        #region Loop控制
        /// <summary>
        /// 循環播放開關
        /// </summary>
        public bool Loop;
        /// <summary>
        /// 播放結束時
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="E"></param>
        void PlayEnd(object Sender, EventArgs E)
        {
            //Console.WriteLine("播放結束，是否有Loop : " + Loop);

            if (Loop)
            {
                //無法Loop的問題：https://stackoverflow.com/questions/56487740/how-to-achieve-looping-playback-with-libvlcsharp

                //Console.WriteLine("Loop Play, WillPlay : " + MediaPlayer.WillPlay);

                System.Threading.ThreadPool.QueueUserWorkItem(_ => Play());
            }
            else
            {

            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void Pause()
        {
            if (MediaPlayer != null)
            {
                MediaPlayer.Pause();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            if (MediaPlayer != null)
            {
                MediaPlayer.Stop();
            }
        }
    }
}
