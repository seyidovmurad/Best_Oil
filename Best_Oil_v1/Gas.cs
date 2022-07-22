using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Best_Oil
{
    class Gas
    {
        public string Type { get; set; }

        public double Price { get; set; } //Per Litre

        public Gas(string type, double price)
        {
            Type = type;
            Price = price;
        }

        public override string ToString()
        {
            return Type;
        }
    }
}
