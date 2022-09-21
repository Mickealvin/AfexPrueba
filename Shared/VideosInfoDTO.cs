using AfexPrueba.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AfexPrueba.Shared
{
    public class VideosInfoDTO
    {
        public Snippet Snippet { get; set; }
    }

    public class Snippet
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Thumbnails Thumbnails { get; set; }
    }

    public class Thumbnails
    {
        public ThumbnailInfo standard { get; set; }
    }

    public class ThumbnailInfo
    {
        public string url { get; set; }
    }
}