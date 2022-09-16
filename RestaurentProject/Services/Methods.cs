using Microsoft.EntityFrameworkCore;
using RestaurentProject.Data;
using RestaurentProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurentProject.Services
{
    public class Methods : IMethods
    {
        private readonly RestaurantDbContext _context;

        public Methods(RestaurantDbContext context)
        {
            _context = context;
        }
        public bool IsAvaliable(int id)
        {
            var meel = _context.RestaurentMenus.Find(id);
            var chick = meel.Quantity;
            if (chick > 0)
            {
                return true;
            }
            else
            {
                return true;
            }
        }
        public float ConvertToUSD(float nis)
        {
            float usd = (float)(nis / 3.5);
            return usd;
        }

        public string CapFirstChar(string Name)
        {
            if (Name.Length == 0)
            {
                return "Empty String";

            }
            string res = char.ToUpper(Name[0]) + Name.Substring(1);
            return res;
        }
        public List<CsvModelView> GetCsvData()
        {
            var restuarant = _context.Restaurants.ToList();
            List<CsvModelView> list = new List<CsvModelView>();

                foreach (var item in restuarant)
                {
                   var data = _context.CustomerMenus.Where(x => x.RestaurentMenu.RestaurantId == item.Id);
                   var res = new CsvModelView
                       {
                        RestuarantName = item.Name ,
                        NumberOfOrderCustomer = data.Count(),
                        ProfitInUsd = data.Sum(x => x.RestaurentMenu.PriceInUsd),
                        ProfitInNis = data.Sum(x => x.RestaurentMenu.PriceInNis),
                        TheBestSellingMeal = data.Max(x => x.RestaurentMenu.MealName),
                        MostPurchasedCustomer  = data.Max(x => x.Customer.Name)+ " " + data.Max(x => x.Customer.LastName),
                       };
                   list.Add(res);
                }
            return list;

        }
    }
}
