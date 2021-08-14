using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class ShoppingCart
    {
        private static readonly object m_lock = new object();
        public List<ProductsInServer> m_products { get; set; }
        public List<SavedUsers> m_users { get; set; }
        Random random = new Random();
        public string username { get; set; }
        public string Productname { get; set; }

        public int accountno { get; set; } = 0;

        private string orderstatus { get; set; }

        List<OrdersInServer> orders = new List<OrdersInServer>();


        public ShoppingCart()
        {
            
            m_products = new List<ProductsInServer>();
            m_users = new List<SavedUsers>();
            getitems();
            lock (m_lock) 
            {
                accountno++;
            }
            
           
            

        }
        public void getitems()
        {
            
            //m_users = users;
            m_products.Add(new ProductsInServer("Apple", random.Next(1, 4)));
            m_products.Add(new ProductsInServer("Banana", random.Next(1, 4)));
            m_products.Add(new ProductsInServer("Orange", random.Next(1, 4)));
            m_products.Add(new ProductsInServer("Lemon", random.Next(1, 4)));
            m_products.Add(new ProductsInServer("Mango", random.Next(1, 4)));
            m_products.Add(new ProductsInServer("Kiwi", random.Next(1, 4)));
            m_products.Add(new ProductsInServer("Peaches", random.Next(1, 4)));
            //adding user
            m_users.Add(new SavedUsers("John", 1111));
            m_users.Add(new SavedUsers("Jack", 2222));
            m_users.Add(new SavedUsers("Sadikur", 3333));


        }

        public List<ProductsInServer> GetProducts()
        {
            return m_products;

        }
        public (bool, string) checkuser(int accno)
        {
            //(List<ProductsInServer> product, List<SavedUsers> sav) = getitems();
            var user = (from p in m_users where p.accountno == accno select p.Username).FirstOrDefault();
            if (string.IsNullOrEmpty(user))
            {
                return (false, "");

            }
            return (true, user);

        }
        public List<OrdersInServer> GetOrders()
        {

            //string status = 
            if (username != null && Productname != null && orderstatus != "NOT_AVAILABLE" && orderstatus != "NOT_VALID")
            {
                orders.Add(new OrdersInServer(Productname, 1, username));
                Productname = null;
                return orders;

            }
            else if(orderstatus == "NOT_AVAILABLE" && orderstatus == "NOT_VALID")
            {
                return null;
            }            
            return orders;
           

        }
        public string purchase(string productname)
        {
            bool checkproduct = false;

            checkproduct = (from name in m_products where name.Productname == productname select true).FirstOrDefault();
            if (checkproduct)
            {
                var quantity = (from name in m_products where name.Productname == productname select name.Quantity).FirstOrDefault();
                var qua = m_products.FirstOrDefault(c => c.Productname == productname);
                if (quantity != 0)
                {

                    quantity--;
                    qua.Quantity = quantity;
                    orderstatus = "DONE";
                    return "DONE";

                }
                else
                {
                    orderstatus = "NOT_AVAILABLE";
                    return "NOT_AVAILABLE";

                }

            }
            else 
            {
                orderstatus = "NOT_VALID";
                return "NOT_VALID";

            }
            



        }
    }
            

}
 
