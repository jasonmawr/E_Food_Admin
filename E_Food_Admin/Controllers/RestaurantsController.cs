using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;
using Repository.Repository;
using Repository.IRepository;
using E_Food_Admin.Models;

namespace E_Food_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantsController(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        private List<Restaurant> ToRestaurant(List<RestaurantApiModel> restaurants)
        {
            var restaurantApiModel = new List<Restaurant>();
            foreach (var item in restaurants)
            {
                restaurantApiModel.Add(new Restaurant
                {
                    ResId = item.ResId,
                    Name = item.Name,
                    District = item.District,
                    Address = item.Address,
                    Image = item.Image,
                    Price = item.Price,
                    OpenTime = TimeSpan.Parse(item.OpenTime),
                    VoteRating = item.VoteRating,
                    Description = item.Description,
                    Lat = item.Lat.Value,
                    Log = item.Log,
                    Status = item.Status,
                    IsDeleted = item.IsDeleted,
                });
            }
            return restaurantApiModel;
        }

        private List<RestaurantApiModel> ToRestaurantApiModel(List<Restaurant> restaurants)
        {
            var restaurantApiModel = new List<RestaurantApiModel>();
            foreach (var item in restaurants)
            {
                restaurantApiModel.Add(new RestaurantApiModel
                {
                    ResId = item.ResId,
                    Name = item.Name,
                    District = item.District,
                    Address = item.Address,
                    Image = item.Image,
                    Price = item.Price,
                    OpenTime = item.OpenTime.Value.ToString(),
                    VoteRating = item.VoteRating,
                    Description = item.Description,
                    Lat = item.Lat.Value,
                    Log = item.Log,
                    Status = item.Status,
                    IsDeleted = item.IsDeleted,
                });
            }
            return restaurantApiModel;
        }

        private Restaurant ToRestaurantApiObject(RestaurantApiModel restaurant)
        {
            return new Restaurant
            {
                ResId = restaurant.ResId,
                Name = restaurant.Name,
                District = restaurant.District,
                Address = restaurant.Address,
                Image = restaurant.Image,
                Price = restaurant.Price,
                OpenTime = TimeSpan.Parse(restaurant.OpenTime),
                VoteRating = restaurant.VoteRating,
                Description = restaurant.Description,
                Lat = restaurant.Lat.Value,
                Log = restaurant.Log,
                Status = restaurant.Status,
                IsDeleted = restaurant.IsDeleted,
            };
        }

        // GET: api/Restaurants
        [HttpGet]
        public IActionResult GetRestaurants()
        {
            var listRestaurants = _restaurantRepository.GetAll();
            
            return Ok(ToRestaurantApiModel(listRestaurants));
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public IActionResult GetRestaurant(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var restaurant = _restaurantRepository.GetById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(ToRestaurantApiModel(restaurant)[0]);
        }

        // PUT: api/Restaurants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutRestaurant(int id, RestaurantApiModel restaurant)
        {
            if (id != restaurant.ResId)
            {
                return BadRequest();
            }

            try
            {
                _restaurantRepository.Update(ToRestaurantApiObject(restaurant));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Restaurants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostRestaurant(RestaurantApiModel restaurant)
        {
            _restaurantRepository.Add(ToRestaurantApiObject(restaurant));

            return CreatedAtAction("GetRestaurant", new { id = restaurant.ResId }, restaurant);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            var restaurant = _restaurantRepository.FindById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _restaurantRepository.Remove(id);

            return NoContent();
        }

        private bool RestaurantExists(int id)
        {
            return _restaurantRepository.FindById(id) != null;
        }
    }
}
