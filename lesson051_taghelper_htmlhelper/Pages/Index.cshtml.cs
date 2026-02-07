using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lesson051_taghelper_htmlhelper.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [DisplayName("Ten nguoi dung")]
    public string Username { get; set; } = "Nguyen Phuong Nam";

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
