using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using Zite.Models;
using System.Diagnostics.Tracing;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Zite.Parser;

namespace Zite.Controllers
{
  //[Produces("application/json")]
  [Route("api/[controller]")]
  [EnableCors("AllowSpecificOrigin")]
  public class NewsController : Controller
  {

    public IEnumerable<Item> ReadRss()
    {
      FeedParser parser = new FeedParser();
      var items = parser.ParseRss("https://www.wired.com/feed");
      //var items = parser.ParseRss("https://flipboard.com/@raimoseero/feed-nii8kd0sz?rss");
      return items.ToList();
    }

    [HttpGet]
    public async Task<List<Article>> GetRSSViaMercuryAsync()
    {
      HttpClient client = new HttpClient();
      client.BaseAddress = new Uri("https://mercury.postlight.com/");
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(
          new MediaTypeWithQualityHeaderValue("application/json"));
      client.DefaultRequestHeaders.Add(
          "x-api-key", "tRJMxAIDVRAKUKp4nROBNNBfKBwQPp4VlpLM25IB");

      var retList = new List<Article>();
      foreach (var item in ReadRss())
      {
        HttpResponseMessage response = await client.GetAsync($"parser?url={item.Link}");
        if (response.IsSuccessStatusCode)
        {
          var temp = await response.Content.ReadAsAsync<Article>();
          temp.Description = item.Description;
          retList.Add(temp);
        }
      }
      return retList;
    }
  }
}
