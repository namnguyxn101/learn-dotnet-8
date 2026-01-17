namespace UriNamespace
{
    class DemoUri
    {
        public static void RunDemo()
        {
            string url = "https://xuanthulab.net/lap-trinh/csharp/?page=3#acff";
            var uri = new Uri(url);
            var uritype = typeof(Uri);
            uritype.GetProperties().ToList().ForEach(property =>
            {
                Console.WriteLine($"{property.Name,15} {property.GetValue(uri)}");
            });
            Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");
            // KET QUA

            //    AbsolutePath /lap-trinh/csharp/
            //     AbsoluteUri https://xuanthulab.net/lap-trinh/csharp/?page=3#acff
            //       LocalPath /lap-trinh/csharp/
            //       Authority xuanthulab.net
            //    HostNameType Dns
            //   IsDefaultPort True
            //          IsFile False
            //      IsLoopback False
            //    PathAndQuery /lap-trinh/csharp/?page=3
            //        Segments System.String[]
            //           IsUnc False
            //            Host xuanthulab.net
            //            Port 443
            //           Query ?page=3
            //        Fragment #acff
            //          Scheme https
            //  OriginalString https://xuanthulab.net/lap-trinh/csharp/?page=3#acff
            //     DnsSafeHost xuanthulab.net
            //         IdnHost xuanthulab.net
            //   IsAbsoluteUri True
            //     UserEscaped False
            //        UserInfo
            //  Segments: /,lap-trinh/,csharp/
        }
    }
}