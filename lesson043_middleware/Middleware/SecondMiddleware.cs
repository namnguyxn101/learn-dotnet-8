public class SecondMiddleware : IMiddleware
{
    /*
        Url: "/abc.html"
            - Không gọi middleware phía sau
            - Không truy cập được
            - Header - SecondMiddleware: "Bạn không được truy cập"
        Url: != "/abc.html"
            - Header - SecondMiddleware: "Bạn được truy cập"
            - Chuyển httpcontext cho middleware phía sau
    */

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var dataFromFirstMiddleware = context.Items["DataFirstMiddleware"];

        if (context.Request.Path == "/abc.html")
        {
            context.Response.Headers.Append("SecondMiddleware", "Ban khong duoc truy cap");

            if (dataFromFirstMiddleware != null)
                await context.Response.WriteAsync((string)dataFromFirstMiddleware);

            await context.Response.WriteAsync("Ban khong duoc truy cap");
        }
        else
        {
            context.Response.Headers.Append("SecondMiddleware", "Ban duoc truy cap");

            if (dataFromFirstMiddleware != null)
                await context.Response.WriteAsync((string)dataFromFirstMiddleware);

            await next(context);
        }
    }
}