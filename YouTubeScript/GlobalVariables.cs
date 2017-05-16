using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeScript
{
    class GlobalVariables
    {
        static public readonly String YOUTUBE_DL = @"youtube-dl.exe";

        static public readonly String DOWNLOAD_FOLDER = @"Downloads";

        public enum URL_TYPE
        {
            Video,
            PlayList,
            Channel
        }
    }
}
