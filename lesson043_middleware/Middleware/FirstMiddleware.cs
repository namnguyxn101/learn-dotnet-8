namespace lesson043_middleware.Middleware;

public class FirstMiddleware
{
    private readonly RequestDelegate _next;
    
    public FirstMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    // Pthuc này đc gọi khi HttpContext đi qua pipeline
    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"URL: {context.Request.Path}");
        context.Items.Add("DataFirstMiddleware", $"<p>URL: {context.Request.Path}</p>");
        
        await _next(context);
    }
}