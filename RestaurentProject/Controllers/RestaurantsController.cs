using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurentProject.Data;
using RestaurentProject.Models;
using RestaurentProject.ViewModel;

namespace RestaurentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public RestaurantsController(RestaurantDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            return await _context.Restaurants.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }
       
        [HttpPut]
        public IActionResult PutRestaurant([FromBody] EditRestaurantViewModel model)
        {
            var chick = _context.Restaurants.FirstOrDefault(x => x.Id == model.Id);

            if (chick == null)
            {
                return BadRequest();
            }

            chick.Name = model.Name;
            chick.PhoneNumber = model.PhoneNumber;
            chick.UpdatedDate = DateTime.Now;
            _context.SaveChanges();

            return Ok(chick);

        }


        [HttpPost]
        public ActionResult PostRestaurant([FromBody]RestaurantViewModel model)
        {
            var res = new Restaurant
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.MinValue,
                Archived = true,
            };

            _context.Restaurants.Add(res);
            _context.SaveChanges();

            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
