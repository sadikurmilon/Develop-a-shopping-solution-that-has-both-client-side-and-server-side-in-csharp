using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingClient
{
    public class ProductsFromServer
    {
        public string Productname { get; }
        public int Quantity { get; }

        public ProductsFromServer(string name, int quantity)
        {
            Productname = name;
            Quantity = quantity;
        }
    }
}
