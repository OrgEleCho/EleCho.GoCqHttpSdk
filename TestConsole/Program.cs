using System;
using System.Text.Json;
using System.Threading.Tasks;
using NullLib.GoCqHttpSdk;

namespace TestConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            CqWsSession cqSession = new CqWsSession(new Uri("ws://127.0.0.1:6700/"));

            await cqSession.ConnectAsync();

            while(true)
            {
                Console.ReadKey(true);
            }
        }
    }
}
