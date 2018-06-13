using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Zite.Models;

namespace Zite
{
  public class Program
  {
    private static readonly HttpClient client = new HttpClient();

    public static void Main(string[] args)
    {
      BuildWebHost(args).Run();
      //ProcessRepositories().Wait();

      var config = new ConfigurationBuilder().AddCommandLine(args).Build();
      var host = new WebHostBuilder()
          .UseKestrel()
          .UseContentRoot(Directory.GetCurrentDirectory())
          .UseConfiguration(config)
          .UseIISIntegration()
          .UseStartup<Startup>()
          .Build();
      host.Run();
    }

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
  }
}
