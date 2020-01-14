﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fbchat_sharp.API
{
    public class FB_Image
    {
        /// URL to the image
        public string url { get; set; }
        /// Width of the image
        public int image_width { get; set; }
        /// Height of the image
        public int image_height { get; set; }

        /// <summary>
        /// Represents a Facebook image.
        /// </summary>
        public FB_Image(string url = null, int image_width = 0, int image_height = 0)
        {
            this.url = url;
            this.image_width = image_width;
            this.image_height = image_height;
        }

        public static FB_Image _from_uri(JToken data)
        {
            return new FB_Image(
                    image_width: data?.get("width")?.Value<int>() ?? 0,
                    image_height: data?.get("height")?.Value<int>() ?? 0,
                    url: data?.get("uri")?.Value<string>());
        }

        public static FB_Image _from_url(JToken data)
        {
            return new FB_Image(
                    image_width: data?.get("width")?.Value<int>() ?? 0,
                    image_height: data?.get("height")?.Value<int>() ?? 0,
                    url: data?.get("url")?.Value<string>());
        }

        public static FB_Image _from_uri_or_none(JToken data)
        {
            return (data?.get("uri") != null) ? FB_Image._from_uri(data) : null;
        }

        public static FB_Image _from_url_or_none(JToken data)
        {
            return (data?.get("url") != null) ? FB_Image._from_url(data) : null;
        }
    }
}
