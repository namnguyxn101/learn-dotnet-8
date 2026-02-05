using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XTLAB;

namespace lesson050_component_view.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnPost()
    {
        var username = this.Request.Form["username"];
        
        var message = new MessagePage.Message();
        message.title = "Thong bao";
        message.htmlcontent = $"Cam on {username} da gui thong tin";
        message.secondwait = 3;
        message.urlredirect = Url.Page("Privacy") ?? "/";
        
        return ViewComponent("MessagePage", message);
    }

    // public IActionResult OnGet()
    // {
    //     /**
    //      * PageModel -> Partial, ViewComponent
    //      * Controller -> PartialView, ViewComponent
    //     */
        
    //     // return Partial("_Message");
    //     return ViewComponent("ProductBox", false);
    // }
}
