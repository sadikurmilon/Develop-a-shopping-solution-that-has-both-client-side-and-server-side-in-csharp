using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingClient
{
    public interface IShoppingClient
    {
        string HostName { get; set; }

        int AccountNu { get; set; }

        int ServerPort { get; set; }
        string CustomerName { get; set; }
        string Connectionstatus { get; set; }
        string purchasestatus { get; set; }
        Task LoginForm(int accountno);
        Task<List<ProductsFromServer>> GetProductAsync();
        Task<List<OrdersFromServer>> GetOrdersAsync();
        Task Purchase(string productname);
        bool IsClosed { get; }
        void Exit();

        void Start();


    }
}
