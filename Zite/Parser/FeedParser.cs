using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Zite.Models;

namespace Zite.Parser
{
   
    public class FeedParser
    {
      public virtual IList<Item> ParseRss(string url)
      {
        try
        {
          XDocument doc = XDocument.Load(url);
          // RSS/Channel/item
          var entries = from item in doc.Root.Descendants().First(i => i.Name.LocalName == "channel").Elements().Where(i => i.Name.LocalName == "item")
                        select new Item
                        {
                          Title = item.Elements().First(i => i.Name.LocalName == "title").Value,
                          Link = item.Elements().First(i => i.Name.LocalName == "link").Value,
                          Guid = item.Elements().First(i => i.Name.LocalName == "guid").Value,
                          Description = item.Elements().First(i => i.Name.LocalName == "description").Value,
                          PublishDate = ParseDate(item.Elements().First(i => i.Name.LocalName == "pubDate").Value),
                          //Author = item.Elements().First(i => i.Name.LocalName == "author").Value,
                        };
          return entries.ToList();
        }
        catch
        {
          return new List<Item>();
        }
      }

      private DateTime ParseDate(string date)
      {
        DateTime result;
        if (DateTime.TryParse(date, out result))
          return result;
        else
          return DateTime.MinValue;
      }
    }
}

