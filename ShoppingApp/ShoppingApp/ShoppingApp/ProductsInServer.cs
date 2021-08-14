using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class ProductsInServer
    {
        public string Productname { get; set; }
        public int Quantity { get; set; }

        public ProductsInServer(string name, int quantity)
        {
            Productname = name;
            Quantity = quantity;
        }
    }
}
