using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class SavedUsers
    {
        public string Username { get; set; }
        public int accountno { get; set; }

        public SavedUsers(string name, int number)
        {
            Username = name;
            accountno = number;
        }
    }
}
