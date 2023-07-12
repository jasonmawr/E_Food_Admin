using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text.Json;
using ViewLayer.Data;
using JsonSerializer = System.Text.Json.JsonSerializer;
using E_Food_Admin.Models;
using System.Text;

namespace ViewLayer.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly HttpClient client = null;
        private string RestaurantApiUrl = "";
        private string DishesApiUrl = "";

        public RestaurantsController()
        {
            client = HomeController.client;
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            RestaurantApiUrl = "https://localhost:44330/api/Restaurants";
            DishesApiUrl = "https://localhost:44330/api/Dishes";
        }

        // GET: Restaurants
        public async Task<IActionResult> Index()
        {
            var response = await client.GetAsync(RestaurantApiUrl);
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
                var employees = JsonConvert.DeserializeObject<List<RestaurantApiModel>>(data);
                return View(employees);
            }
            return View();
        }

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var response = await client.GetAsync($"{RestaurantApiUrl}/{id}");
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
                var employee = JsonConvert.DeserializeObject<RestaurantApiModel>(data);
                return View(employee);
            }
            return View();
        }

        // GET: Restaurants/Create
        public async Task<IActionResult> Create()
        {
            return View();

        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResId,Name,District,Address,Image,Price,OpenTime,VoteRating,Description,Lat,Log,Status,IsDeleted")] RestaurantApiModel restaurant)
        {
            var json = JsonConvert.SerializeObject(restaurant);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RestaurantApiUrl, content);
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
            TempData["ErrorMessage"] = "An error occurred while updating the employee! Try another email!";
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.GetAsync($"{RestaurantApiUrl}/{id}");
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
                var employee = JsonConvert.DeserializeObject<RestaurantApiModel>(data);
                return View(employee);
            }
            return View();
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResId,Name,District,Address,Image,Price,OpenTime,VoteRating,Description,Lat,Log,Status,IsDeleted")] RestaurantApiModel restaurant)
        {
            var json = JsonConvert.SerializeObject(restaurant);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{RestaurantApiUrl}/{id}", content);

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
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var response = await client.GetAsync($"{RestaurantApiUrl}/{id}");
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
                var employee = JsonConvert.DeserializeObject<RestaurantApiModel>(data);
                return View(employee);
            }
            return View();
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await client.DeleteAsync($"{RestaurantApiUrl}/{id}");
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
