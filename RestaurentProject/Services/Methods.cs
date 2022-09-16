using RestaurentProject.Data;
using System;

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
    }
}
