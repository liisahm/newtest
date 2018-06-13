using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Zite.Controllers;
using Zite.Parser;
using static Zite.Controllers.NewsController;

namespace Zite.Models
{
  public class Item
  {
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

    [XmlElementAttribute(IsNullable = false)]
    public string Title { get; set; }
    [XmlElementAttribute(IsNullable = false)]
    public string Link { get; set; }
    [XmlElementAttribute(IsNullable = false)]
    public string Guid { get; set; }
    [XmlElement("PublishDate")]
    public DateTime? PublishDate { get; set; }
    [XmlElementAttribute(IsNullable = false)]
    public string Author { get; set; }

    [XmlElementAttribute(IsNullable = false)]
    public string Description { get; set; }
    [XmlElementAttribute(IsNullable = false)]
    public string Media { get; set; }
    [XmlElementAttribute(IsNullable = false)]
    public string Category { get; set; }


    public Item()
    {
      Title = "";
      Link = "";
      Guid = "";
      PublishDate = DateTime.Today;
      Author = "";
      Description = "";
      Media = "";
      Category = "";
    }
  }
}
