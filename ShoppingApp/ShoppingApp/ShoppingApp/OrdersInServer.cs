using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class OrdersInServer
    {
        public string Productname { get; set; }
        public int Quantity { get; set; }

        public string Username { get; set; }
        public OrdersInServer(string name, int quantity, string username)
        {
            Productname = name;
            Quantity = quantity;
            Username = username;

        }

    }
}
