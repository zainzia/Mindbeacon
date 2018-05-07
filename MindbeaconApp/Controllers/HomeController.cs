using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;

using Mapster;

using Microsoft.AspNetCore.Mvc;
using MindbeaconApp.Models;


namespace MindbeaconApp.Controllers
{
    [Route("API/Home")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var Images = new List<Image>();
            var serviceURL = "https://5ad8d1c9dc1baa0014c60c51.mockapi.io/api/br/v1/magic/";

            var adapter = new Adapter();

            for(int i = 0; i < 100; i++)
            {
                try
                {
                    var image = adapter.Adapt<Image>(await GetAsync(serviceURL + i));
                    if (image != null)
                    {
                        Images.Add(image);
                    }
                }
                catch (Exception ex)
                {
                    var x = ex.ToString();
                }
            }

            return new JsonResult(Images, new Newtonsoft.Json.JsonSerializerSettings() { Formatting = Newtonsoft.Json.Formatting.Indented });
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        public async Task<string> GetAsync(string uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

    }
}
