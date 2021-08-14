using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingClient
{
    public partial class PurchaseForm : Form
    {
        
        private readonly IShoppingClient m_Client;
        List<OrdersFromServer> orders = new List<OrdersFromServer>();
        public PurchaseForm(IShoppingClient ClientData)
        {
            InitializeComponent();
            m_Client = ClientData;
            
        }

        private async void PurchaseForm_Load(object sender, EventArgs e)
        {
            this.Text = "ShopClient, "+ "User: " + m_Client.CustomerName;
            welcomelbl.Text = "Welcome:  " + m_Client.CustomerName;
            
            //if (m_Client.Connectionstatus ==)
            List<ProductsFromServer> products =  await m_Client.GetProductAsync();
            
            foreach (ProductsFromServer product in products)
            {
               
                ProductCombobox.Items.Add(product.Productname);
            }
            CustomerPurchaseTxtBox.Clear();
            orders = await m_Client.GetOrdersAsync();
            CustomerPurchaseTxtBox.AppendLine("Product  User  Quantity\n");
            foreach (OrdersFromServer order in orders)
            {

                CustomerPurchaseTxtBox.AppendLine((order.Productname + ", " + order.Username + ", " + order.Quantity).ToString());
            }


        }
             

        

        private void PurchaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_Client.Exit();
            Application.Exit();
        }

        private async void Refreshbttn_Click(object sender, EventArgs e)
        {
            CustomerPurchaseTxtBox.Clear();
            orders = await m_Client.GetOrdersAsync();
            CustomerPurchaseTxtBox.AppendLine("Product  User  Quantity");
            //orders.RemoveAt(orders.Count - 1);
            foreach (OrdersFromServer order in orders)
            {

                CustomerPurchaseTxtBox.AppendLine((order.Productname + ", " + order.Username + ", " + order.Quantity).ToString());
            }
            //this.Update();

        }

        private async void PurchaseBttn_Click(object sender, EventArgs e)
        {
            
            string line = null;
            string productname = ProductCombobox.Text;
            //if (productname) 
            //{
            //}        
            await m_Client.Purchase(productname);
            line = m_Client.purchasestatus;
            

            if (line == null) 
            {
                
                tmrUpdate.Enabled = false;
                MessageBox.Show("Server Unavailable", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();

            }
            else if (line == "NOT_AVAILABLE")
            {                
                MessageBox.Show("The Product is not Available", "ITEM IS NOT_AVAILABLE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (line == "NOT_VALID")
            {
                MessageBox.Show("The Specified Product is not Valid", "NOT VALID ITEM NAME", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (line != "NOT_AVAILABLE" && line != "NOT_VALID") 
            {
             
                MessageBox.Show("The Order Successfully Placed", line, MessageBoxButtons.OK, MessageBoxIcon.Information);
                CustomerPurchaseTxtBox.Clear();
                orders = await m_Client.GetOrdersAsync();
                CustomerPurchaseTxtBox.AppendLine("Product  User  Quantity");

                foreach (OrdersFromServer order in orders)
                {

                    CustomerPurchaseTxtBox.AppendLine((order.Productname + ", " + order.Username + ", " + order.Quantity).ToString());
                }
            }         
        }
    }
    
    
}
