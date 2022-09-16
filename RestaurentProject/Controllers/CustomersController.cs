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
    public class CustomersController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public CustomersController(RestaurantDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPut]
        public IActionResult PutCustomer(int id, CustomerViewModel customer)
        {
            var chick = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (chick == null)
            {
                return BadRequest();
            }
            chick.Name = customer.Name;
            chick.LastName = customer.LastName;

            _context.SaveChanges();

            return Ok(chick);
        }


        [HttpPost]
        public ActionResult PostCustomer([FromBody]CustomerViewModel customer)
        {
            
                var res = new Customer
            {
                Name = customer.Name,
                LastName = customer.LastName,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.MinValue,
                Archived = true
            };

           _context.Customers.Add(res);
           _context.SaveChanges();

            return Ok(res);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
