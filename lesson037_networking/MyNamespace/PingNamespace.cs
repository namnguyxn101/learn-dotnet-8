using System.Net.NetworkInformation;

namespace PingNamespace
{
    class DemoPing
    {
        public static void RunDemo()
        {
            var ping = new Ping();
            var pingReply = ping.Send("www.google.com");
            Console.WriteLine(pingReply.Status);
            if (pingReply.Status == IPStatus.Success)
            {
                Console.WriteLine(pingReply.RoundtripTime);
                Console.WriteLine(pingReply.Address);
            }
        }
    }
}