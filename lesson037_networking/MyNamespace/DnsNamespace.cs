using System.Net;

namespace DnsNamespace
{
    class DemoDns
    {
        public static void RunDemo()
        {
            // var hostname = Dns.GetHostName();
            // Console.WriteLine(hostname);
            // ==================================

            var url = "https://www.bootstrapcdn.com";
            var uri = new Uri(url);
            Console.WriteLine(uri.Host);

            var IpHostEntry = Dns.GetHostEntry(uri.Host);
            Console.WriteLine(IpHostEntry.HostName);

            IpHostEntry.AddressList.ToList().ForEach(
                ip =>
                {
                    Console.WriteLine(ip);
                }
            );
        }
    }
}