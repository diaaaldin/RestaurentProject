using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurentProject.Data;
using RestaurentProject.Models;
using RestaurentProject.Services;
using RestaurentProject.ViewModel;

namespace RestaurentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurentMenusController : ControllerBase
    {
        private readonly RestaurantDbContext _context;
        private readonly IMethods _methods;

        public RestaurentMenusController(RestaurantDbContext context , IMethods methods)
        {
            _context = context;
            _methods = methods;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurentMenu>>> GetRestaurentMenus()
        {
            return await _context.RestaurentMenus.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurentMenu>> GetRestaurentMenu(int id)
        {
            var restaurentMenu = await _context.RestaurentMenus.FindAsync(id);

            if (restaurentMenu == null)
            {
                return NotFound();
            }

            return restaurentMenu;
        }

        [HttpPut]
        public IActionResult PutRestaurentMenu(int id ,[FromBody]EditMenuViewModel model)
        {
            var chick = _context.RestaurentMenus.FirstOrDefault(x => x.Id == id);
                   
            if (chick == null)
            {
                return BadRequest();
            }
            chick.MealName = model.MealName;
            chick.PriceInNis = model.PriceInNis;
            chick.PriceInUsd = _methods.ConvertToUSD(model.PriceInNis);
            chick.UpdatedDate = DateTime.Now;
            chick.Quantity = model.Quantity;
            chick.RestaurantId = model.RestaurantId;
            _context.SaveChanges();

            return Ok(chick);
            
        }


        [HttpPost]
        public ActionResult PostRestaurentMenu(MenuViewModel model)
        {
            var res = new RestaurentMenu
            {
                MealName = model.MealName,
                PriceInNis = model.PriceInNis,
                PriceInUsd = _methods.ConvertToUSD(model.PriceInNis),
                Quantity = model.Quantity,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.MinValue,
                Archived = true,
                RestaurantId = model.RestaurantId
            };
            _context.RestaurentMenus.Add(res);
            _context.SaveChanges();

            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurentMenu(int id)
        {
            var restaurentMenu = await _context.RestaurentMenus.FindAsync(id);
            if (restaurentMenu == null)
            {
                return NotFound();
            }

            _context.RestaurentMenus.Remove(restaurentMenu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
