using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LibVLCSharp.Shared;
using System.Diagnostics;

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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="VideoPath"></param>
        public void Add(string VideoPath)
        {
            Media = new Media(VLC, VideoPath);
        }


        public void Play()
        {
            if (MediaPlayer == null)
            {
                MediaPlayer = new MediaPlayer(VLC);
            }

            MediaPlayer.Media = Media;

            MediaPlayer.Play();
        }
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
