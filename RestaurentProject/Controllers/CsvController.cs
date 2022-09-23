using AutoMapper;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using RestaurentProject.Data;
using RestaurentProject.Mapper;
using RestaurentProject.Services;
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
        private readonly IMethods _methods;

        public CsvController(RestaurantDbContext context , IMapper mapper ,IMethods methods)
        {

            _context = context;
            _mapper2 = mapper;
            _methods = methods;
        }

        [HttpGet]
        public IActionResult SaveFileView()
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
        [HttpGet("SaveFile")]
        public IActionResult SaveFile()
        {

            var data = _methods.GetCsvData().ToArray();
            using (var writer = new StreamWriter(@"C:\Users\DiaaAldin\Desktop\RestorantData.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InstalledUICulture))
            {
                csv.WriteRecords(data);
            }
            return Ok();
        }
    }
}
