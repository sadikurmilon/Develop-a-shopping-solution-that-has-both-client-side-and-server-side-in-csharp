using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingClient
{
    public class OrdersFromServer
    {
        public string Productname { get; set; }
        public int Quantity { get; set; }

        public string Username { get; set; }
        public OrdersFromServer(string name, int quantity, string username)
        {
            Productname = name;
            Quantity = quantity;
            Username = username;

        }
    }
}
