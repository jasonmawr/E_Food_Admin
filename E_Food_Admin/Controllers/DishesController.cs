using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;
using Repository.IRepository;
using Repository.Repository;
using E_Food_Admin.Models;
using System.Xml.Linq;

namespace E_Food_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IDishRepository _dishRepository;

        public DishesController(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        private List<DishApiModel> ToDishApiModel(List<Dish> dishes)
        {
            var listDishes = new List<DishApiModel>();
            foreach (var dish in dishes)
            {
                listDishes.Add(new DishApiModel
                {
                    Name = dish.Name,
                    Image= dish.Image,
                    VoteRating= dish.VoteRating,
                    Price = dish.Price,
                    Description= dish.Description,
                    Status= dish.Status,
                    IsDeleted= dish.IsDeleted,
                });
            }
            return listDishes;
        }

        // GET: api/Dishes
        [HttpGet]
        public IActionResult GetDishes()
        {
            return Ok(ToDishApiModel(_dishRepository.GetAll()));
        }

        // GET: api/Dishes/5
        [HttpGet("{id}")]
        public IActionResult GetDish(int id)
        {
            var dish = _dishRepository.GetById(id);

            if (dish == null)
            {
                return NotFound();
            }

            return Ok(ToDishApiModel(dish));
        }

        // PUT: api/Dishes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutDish(int id, Dish dish)
        {
            if (id != dish.DishId)
            {
                return BadRequest();
            }

            try
            {
                _dishRepository.Update(dish);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishExists(id))
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

        // POST: api/Dishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostDish(Dish dish)
        {
           _dishRepository.Add(dish);

            return CreatedAtAction("GetDish", new { id = dish.DishId }, dish);
        }

        // DELETE: api/Dishes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDish(int id)
        {
            var dish = _dishRepository.FindById(id);
            if (dish == null)
            {
                return NotFound();
            }

            _dishRepository.Remove(id);

            return NoContent();
        }

        private bool DishExists(int id)
        {
            return _dishRepository.GetById(id) != null;
        }
    }
}
