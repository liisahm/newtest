using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zite.Models
{
    public class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public string Guid { get; set; }

        [JsonProperty(PropertyName = "date_published")]
        public DateTime? PublishDate { get; set; }

        [JsonProperty(PropertyName = "lead_image_url")]
        public string Media { get; set; }

        [JsonProperty(PropertyName = "dek")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}
