using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class ShoppingServer
    {
        private readonly CancellationToken m_cancellationToken;
        
        private readonly ConcurrentDictionary<int, ShoppingCart> m_currentCart = new ConcurrentDictionary<int, ShoppingCart>();
        public ShoppingServer(CancellationToken cancellationToken) 
        {
            m_cancellationToken = cancellationToken;

        }
        public IPAddress ServerIp { get; set; } = IPAddress.Any;
        public int ServerPort { get; set; } = 55092;

        public void Start() 
        {
            try
            {

                ShoppingCart cart = new ShoppingCart();
                //cart.getitems();


                TcpListener listener = new TcpListener(ServerIp, ServerPort);
                listener.Start();
                m_cancellationToken.Register(listener.Stop);
                while (!m_cancellationToken.IsCancellationRequested)
                {
                    TcpClient tcpClient = listener.AcceptTcpClient();
                    ShoppingClientHandler clientHandler = new ShoppingClientHandler(tcpClient, m_cancellationToken,cart);
                    Thread thclientHandler = new Thread(clientHandler.Run);
                    thclientHandler.Start();

                }
            }
            catch (SocketException)
            {

            }

        }
        

    }
}
