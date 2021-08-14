using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            ShoppingServer server = new ShoppingServer(cancellationTokenSource.Token);
            Thread thServer = new Thread(server.Start);
            thServer.Start();
            Console.WriteLine("Press Q to shut down");
            while (thServer.IsAlive && (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Q))
                ;
            cancellationTokenSource.Cancel();
            Console.WriteLine("Server is shutting down.");
            
            Console.ReadKey();
        }
    }
}
