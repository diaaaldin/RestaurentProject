using AutoMapper;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using RestaurentProject.Data;
using RestaurentProject.Mapper;
using RestaurentProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace RestaurentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvController : Controller
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper2;

        public CsvController(RestaurantDbContext context , IMapper mapper )
        {

            _context = context;
            _mapper2 = mapper;

        }
        [HttpGet]
        public IActionResult SaveFile()
        {

            var data = _context.ExportData.ToList();
            var restaurant = _context.Restaurants.ToList();
            var modelView = _mapper2.Map<List<CsvModelView>>(data);

            using (var writer = new StreamWriter(@"C:\Users\DiaaAldin\Desktop\ItemDb.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InstalledUICulture))
            {
                csv.WriteRecords(modelView);
            }
            return Ok();
        }
    }
}
