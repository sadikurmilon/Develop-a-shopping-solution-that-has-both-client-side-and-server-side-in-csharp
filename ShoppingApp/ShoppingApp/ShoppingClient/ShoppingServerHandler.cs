using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingClient
{
    public class ShoppingServerHandler : IShoppingClient
    {
        public string HostName { get; set; } = "localhost"; 
        public int AccountNu { get; set; }
        public string Connectionstatus { get; set; } = "";
        public int ServerPort { get; set; } = 55092;
        public string CustomerName { get; set; } = "";
        public string purchasestatus { get; set; } = "";

        //public IProgress<ClientInfo> Progress { get; set; } = null;
        private TcpClient m_tcpClient = null;
        private StreamReader m_reader;
        private StreamWriter m_writer;
        public bool IsClosed => null == m_tcpClient;
        public void Start()
        {
            try
            {
                m_tcpClient = new TcpClient(); // Default constructor only allows IPv4
                m_tcpClient.Connect(HostName, ServerPort);
                NetworkStream stream = m_tcpClient.GetStream();
                m_reader = new StreamReader(stream);
                m_writer = new StreamWriter(stream);
            }
            catch (SocketException se)
            {
                Close();
                throw new InvalidOperationException("Server Unavailable", se);
            }

        }
        public void Exit()
        {
            if (!IsClosed)
            {
                try
                {
                    m_writer.WriteLine("DISCONNECT");
                    m_writer.Flush();
                }
                catch (IOException)
                {
                    // Do nothing
                }
                finally
                {
                    m_tcpClient?.Close();
                    m_tcpClient = null;
                }
            }
        }
        public async Task<List<ProductsFromServer>> GetProductAsync() 
        {
            if (IsClosed)
                throw new InvalidOperationException("Client Closed");
            try
            {
                List<ProductsFromServer> products = new List<ProductsFromServer>();
                await m_writer.WriteLineAsync("GET_PRODUCTS");
                await m_writer.FlushAsync();
                string line = await m_reader.ReadLineAsync();
                if (line != null)
                {
                    if (line.StartsWith("PRODUCTS:"))
                    {
                        string newLine = line.Substring(9);
                        foreach (string product in newLine.Split('|'))
                        {

                            string[] productInfo = product.Split(',');
                            if (2 == productInfo.Length && int.TryParse(productInfo[1], out int x))
                            {
                                products.Add(new ProductsFromServer(productInfo[0], x));
                            }
                        }
                    }

                }
                
                return products;

            }
            catch (IOException ioe)
            {
                Close(); // Close on error
                throw new InvalidOperationException("Server Unavailable", ioe);
            }

        }
        public async Task<List<OrdersFromServer>> GetOrdersAsync() 
        {
            if (IsClosed)
                throw new InvalidOperationException("Client Closed");
            try
            {
                List<OrdersFromServer> orders = new List<OrdersFromServer>();
                await m_writer.WriteLineAsync("GET_ORDERS");
                await m_writer.FlushAsync();
                string line = await m_reader.ReadLineAsync();
                if (line != null)
                {
                    if (line.StartsWith("ORDERS:"))
                    {
                        string newLine = line.Substring(7);
                        
                        if (newLine.Contains('|'))
                        {
                            foreach (string product in newLine.Split('|'))
                            {
                                string[] productInfo = product.Split(',');
                                if (3 == productInfo.Length && int.TryParse(productInfo[1], out int x))
                                {
                                    orders.Add(new OrdersFromServer(productInfo[0], x, productInfo[2]));
                                }  
                            }

                        }
                        else 
                        {
                            string[] productInfo = newLine.Split(',');
                            if (3 == productInfo.Length && int.TryParse(productInfo[1], out int x))
                            {
                                orders.Add(new OrdersFromServer(productInfo[0], x, productInfo[2]));
                            }

                        }
                        
                    }

                }
                else
                {
                    return null;
                }
                
                return orders;

            }
            catch (IOException ioe)
            {
                Close(); // Close on error
                throw new InvalidOperationException("Server Unavailable", ioe);
            }

        }
        private void Close()
        {
            m_tcpClient?.Close();
            m_tcpClient = null;
        }
        public async Task Purchase(string productname) 
        {
            string readline = string.Empty;
            if (IsClosed)
            {
                throw new InvalidOperationException("Client Closed");

            }
            try
            {
                await m_writer.WriteLineAsync($"PURCHASE:{productname}");
                await m_writer.FlushAsync();
                readline = await m_reader.ReadLineAsync();


                if (readline != null)
                {
                    if ("DONE" == readline)
                    {
                        purchasestatus = "DONE";

                    }
                    else if ( "NOT_AVAILABLE" == readline)
                    {
                        purchasestatus = "NOT_AVAILABLE";

                    }
                    else if ( "NOT_VALID" == readline) 
                    {
                        purchasestatus = "NOT_VALID";

                    }

                }
                


            }
            catch (SocketException se)
            {
                m_tcpClient = null;
                throw new InvalidOperationException("Server Unavailable", se);
            }

        }
        public async Task LoginForm(int accountno)
        {
            string readline = string.Empty;
            if (IsClosed) 
            {
                throw new InvalidOperationException("Client Closed");

            }
                

            try
            {
                await m_writer.WriteLineAsync($"CONNECT:{accountno}");
                await m_writer.FlushAsync();
                readline = await m_reader.ReadLineAsync();


                if (readline != null)
                {
                    if (readline.StartsWith("CONNECTED:"))
                    {
                        string Name = string.Empty;
                        
                        string newLine = readline.Substring(9);
                        
                        string[] clientName = newLine.Split(':');
                        //MessageBox.Show("Can't read file");
                        Name = clientName[1];
                        CustomerName = Name;
                        Connectionstatus = "CONNECTED";
                        
                    }
                    else if (readline.StartsWith("CONNECT_ERROR"))
                    {
                        Connectionstatus = "CONNECT_ERROR";
                        
                    }

                }
                
                
                
            }
            catch (SocketException se)
            {
                Close();
                throw new InvalidOperationException("Server Unavailable", se);
            }
        }
    }
}
