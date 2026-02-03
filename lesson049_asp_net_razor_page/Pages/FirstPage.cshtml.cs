using Microsoft.AspNetCore.Mvc.RazorPages;

public class FirstPageModel : PageModel
{
    public string Title { get; set; } = "Day la trang Razor Page dau tien";

    public void OnGet()
    {
        Console.WriteLine("Truy van GET");
        ViewData["mydata"] = "Phuong Nam 2026";
    }

    public void OnGetXyz()
    {
        Console.WriteLine("Truy van GET co query la handler=Xyz");
        ViewData["mydata"] = "Phuong Nam 2026";
    }

    public string Welcome(string name)
    {
        return $"Chao mung {name}";
    }
}