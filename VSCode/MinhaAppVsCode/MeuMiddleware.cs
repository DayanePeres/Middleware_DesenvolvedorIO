using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
public class MeuMiddleware{

    // necessary structure for middleware (Necessary to include in Startup.cs)
    private readonly RequestDelegate _next;

    public MeuMiddleware(RequestDelegate next){
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context){
        Console.WriteLine("\n\r --- Antes --- \n\r");

        await _next(context);

        Console.WriteLine("\n\r --- Depois --- \n\r");

    }
}

// example created to not have to add the method as we created in the example above;
public static class MeuMiddlewareExtension{
    public static IApplicationBuilder UseMeuMiddleware(this IApplicationBuilder builder){
        return builder.UseMiddleware<MeuMiddleware>();
    }
}