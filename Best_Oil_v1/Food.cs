using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best_Oil
{
    class Food
    {
        public string FoodName { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public Food(string foodName, double price)
        {
            Amount = 0;
            FoodName = foodName;
            Price = price;
        }
    }
}
