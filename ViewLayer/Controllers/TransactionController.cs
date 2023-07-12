using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ViewLayer.Data;
using System.Transactions;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using E_Food_Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using BussinessObject.Models;
using System.Text;

namespace ViewLayer.Controllers
{
    public class TransactionController : Controller
    {
        private readonly HttpClient client = null;
        private string TransactionApiUrl = "";

        public TransactionController()
        {
            client = HomeController.client;
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            TransactionApiUrl = "https://localhost:44330/api/Transaction";
        }

        // GET: api/Transaction
        public async Task<IActionResult> Index()
        {
            var response = await client.GetAsync(TransactionApiUrl);
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ResponeObject res = JsonSerializer.Deserialize<ResponeObject>(strData, options);
                TempData["MESSAGE"] = res.Message;
                return RedirectToAction("login", "Home");
            }
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var employees = JsonConvert.DeserializeObject<List<TransactionApiModel>>(data);
                return View(employees);
            }
            return View();
        }

        // GET: api/Employee/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {

            var response = await client.GetAsync($"{TransactionApiUrl}/{id}");
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ResponeObject res = JsonSerializer.Deserialize<ResponeObject>(strData, options);
                TempData["MESSAGE"] = res.Message;
                return RedirectToAction("login", "Home");
            }
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var employee = JsonConvert.DeserializeObject<List<TransactionApiModel>>(data);               
                return View(employee[0]); 
            }
            return View();

        }

        // POST: api/Employee/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            var response = await client.DeleteAsync($"{TransactionApiUrl}/{id}");
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ResponeObject res = JsonSerializer.Deserialize<ResponeObject>(strData, options);
                TempData["MESSAGE"] = res.Message;
                return RedirectToAction("login", "Home");
            }
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: api/Employee/Delete/{id}
        public async Task<IActionResult> Confirm(int transid)
        {

            var response = await client.PutAsync($"{TransactionApiUrl}/Confirm/{transid}", null);
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ResponeObject res = JsonSerializer.Deserialize<ResponeObject>(strData, options);
                TempData["MESSAGE"] = res.Message;
                return RedirectToAction("login", "Home");
            }
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var employee = JsonConvert.DeserializeObject<List<UserApiModel>>(data);
                return View(employee[0]);
            }
            return View();

        }


        // POST: api/Employee/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirm(int transid, IFormCollection collection)
        {
            var response = await client.PutAsync($"{TransactionApiUrl}/Confirm/{transid}", null);
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                ResponeObject res = JsonSerializer.Deserialize<ResponeObject>(strData, options);
                TempData["MESSAGE"] = res.Message;
                return RedirectToAction("login", "Home");
            }
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
       
    }
}
