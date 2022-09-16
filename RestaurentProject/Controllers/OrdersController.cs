using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
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
    public class OrdersController : ControllerBase
    {
        private readonly RestaurantDbContext _context;
        private readonly IMethods _methods;

        public OrdersController(RestaurantDbContext context , IMethods methods)
        {
            _context = context;
            _methods = methods;
        }

        [HttpGet]
        public IActionResult GetCustomerMenus()
        {
            var res = _context.CustomerMenus.ToList();
            return Ok(res);
        }

        //public IActionResult UpdateOrder(int idCustomer,int idMenu ,[FromBody] OrderViewModel order)
        //{
        //    var chick = _context.CustomerMenus.Find(idCustomer, idMenu);

        //    if (chick == null)
        //    {
        //        return BadRequest();
        //    }

        //    _context.CustomerMenus.Remove(chick);
            
        //    // to add quantity +1 
        //    var chickMenu = _context.RestaurentMenus.FirstOrDefault(x => x.Id == order.MenuId);
        //    var MenuDeleted = _context.RestaurentMenus.FirstOrDefault(x => x.Id == chick.RestaurentMenuId);
        //    MenuDeleted.Quantity++;
            
        //    // add new order
        //    bool avaliability = _methods.IsAvaliable(chickMenu.Id);

        //    if (avaliability == true)
        //    {
        //        var res = new CustomerMenu
        //        {
        //            CustomerId = order.CustomerId,
        //            RestaurentMenuId = order.MenuId
        //        };
        //        _context.CustomerMenus.Add(res);
        //        chickMenu.Quantity--;
        //        _context.SaveChanges();
        //        return Ok(res);
        //    }
        //    else
        //    {
        //        return BadRequest("Not Avaliable");
        //    }
        //}


        [HttpPost]
        public ActionResult PostCustomerMenu(OrderViewModel customerMenu)
        {
            var chick = _context.RestaurentMenus.FirstOrDefault(x => x.Id == customerMenu.MenuId);
            bool avaliability = _methods.IsAvaliable(chick.Id);

            if (avaliability == true)
            {
                var res = new CustomerMenu
                {
                    CustomerId = customerMenu.CustomerId,
                    RestaurentMenuId = customerMenu.MenuId
                };
                _context.CustomerMenus.Add(res);
                chick.Quantity--; 
                _context.SaveChanges();
                return Ok(customerMenu);
            }
            else
            {
                return BadRequest("Not Avaliable");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerMenu(int id , int id2)
        {
            var customerMenu = await _context.CustomerMenus.FindAsync(id ,id2);
            if (customerMenu == null)
            {
                return NotFound();
            }

            _context.CustomerMenus.Remove(customerMenu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
