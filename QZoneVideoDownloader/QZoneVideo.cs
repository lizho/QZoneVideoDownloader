using Lizho.SimpleBriefJson;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace QZoneVideoDownloader
{

    class QZoneVideo
    {
        public string PreImg { get; private set; }
        public string VidUrl { get; private set; }
        public string Title { get; private set; }
        public string Key { get; private set; }

        public Bitmap CoverImage { get; private set; }

        public QZoneVideo(SBJsonDict json)
        {
            if (json == null) return;
            Key = json["vid"].CastTo<SBJsonString>().Value;
            PreImg = Regex.Unescape(json["pre"].CastTo<SBJsonString>().Value);
            VidUrl = Regex.Unescape(json["url"].CastTo<SBJsonString>().Value);

            Title = json["title"].CastTo<SBJsonString>().Value;
            if (!string.IsNullOrEmpty(Title)) return;
            Title = json["desc"].CastTo<SBJsonString>().Value;
            if (!string.IsNullOrEmpty(Title)) return;
            var dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddTicks((long)(json["uploadTime"].CastTo<SBJsonNumber>().Value * 1e7));
            Title = dt.ToString("yyyy-M-d");
        }

        public void GenerateCover(byte[] data, Size size)
        {
            var bmp = new Bitmap(new MemoryStream(data));

            var rect = Rectangle.Empty;
            if (bmp.Height * size.Width < bmp.Width * size.Height)
            {
                var w = bmp.Height * size.Width / size.Height;
                rect.X = Math.Abs(bmp.Width - w) >> 1;
                rect.Width = Math.Max(w, size.Width);
                rect.Height = Math.Max(bmp.Height, size.Height);
            }
            else
            {
                var h = bmp.Width * size.Height / size.Width;
                rect.Y = Math.Abs(bmp.Height - h) >> 1;
                rect.Height = Math.Max(h, size.Height);
                rect.Width = Math.Max(bmp.Width, size.Width);
            }

            CoverImage = bmp.Clone(rect, bmp.PixelFormat);
        }

        public override string ToString() => Title;
    }
}
