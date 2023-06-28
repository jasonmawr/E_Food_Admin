using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using ViewLayer.Models;
using ViewLayer.Data;

namespace ViewLayer.Controllers
{
    public class HomeController : Controller
    {
        public readonly static HttpClient client = new HttpClient();
        private readonly ILogger<HomeController> _logger;
        private string API = "";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            API = "https://localhost:44330/api/Home/login";
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginRequest model)
        {
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage;

            responseMessage = await client.PostAsync(API, content);
            string strData = await responseMessage.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            ResponeObject respone = JsonSerializer.Deserialize<ResponeObject>(strData, options);


            Uri uri = new Uri(API);
            IEnumerable<Cookie> responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
            foreach (Cookie cookie in responseCookies)
                HttpContext.Session.SetString(cookie.Name, cookie.Value);
            if (respone.Data != null)
            {
                JsonElement user = (JsonElement)respone.Data;
                HttpContext.Session.SetString("id", user.GetProperty("id").GetInt32().ToString());
            }


            HttpContext.Session.SetInt32("role", respone.role);
            TempData["MESSAGE"] = respone.Message;
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> LogoutAsync()
        {
            HttpResponseMessage responseMessage = await HomeController.client.GetAsync("https://localhost:44330/api/Home/login");
            string strData = await responseMessage.Content.ReadAsStringAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
