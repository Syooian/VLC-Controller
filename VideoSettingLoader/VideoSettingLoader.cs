using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace VideoSettingLoader
{
    public class VideoSettingLoader
    {
        /// <summary>
        /// 讀取影片設定檔
        /// </summary>
        /// <param name="Path">設定檔路徑</param>
        /// <param name="Error">錯誤訊息</param>
        /// <returns></returns>
        public static PlayerSettingStruct LoadVideoSetting(string Path, out string Error)
        {
            if (!File.Exists(Path))
            {
                Error = "影片設定檔不存在";

                return new PlayerSettingStruct();
            }

            try
            {
                Error = "";

                return JsonConvert.DeserializeObject<PlayerSettingStruct>(File.ReadAllText(Path));
            }
            catch (Exception ex)
            {
                Error = "影片設定檔解碼錯誤";

                return new PlayerSettingStruct();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct PlayerSettingStruct
    {
        /// <summary>
        /// 預設輪播影片
        /// <para>-1 : 不輪播, 其他值：程式開啟時會自動讀取指定的影片做輪播</para>
        /// </summary>
        public int DefaultLoopVideo;
        /// <summary>
        /// 影片設定
        /// </summary>
        public VideoDataStruct[] VideoData;
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct VideoDataStruct
    {
        /// <summary>
        /// 影片名稱
        /// <para>也用作接收播放影片指令的指標</para>
        /// </summary>
        public string Name;
        /// <summary>
        /// 影片ID
        /// </summary>
        public int ID;
        /// <summary>
        /// 影片檔名
        /// </summary>
        public string VideoName;
        /// <summary>
        /// 聲音檔名
        /// </summary>
        public string SoundName;
        /// <summary>
        /// 音量
        /// </summary>
        public int Volume;
        /// <summary>
        /// 顯示時鐘
        /// </summary>
        public bool ShowClock;
    }
}
