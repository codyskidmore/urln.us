using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Http.Extensions;

namespace Url.Api.Infrastructure;

public class EnrichLogMiddleware
{
    private const string LoopbackIp = "::1";
    private readonly RequestDelegate _next;
    private readonly ILogger<EnrichLogMiddleware> _logger;

    public EnrichLogMiddleware(ILogger<EnrichLogMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var request = context.Request;
        
        var outputStrings = new List<string>();

        outputStrings.Add($"URL: {request.GetEncodedUrl()}");
        outputStrings.Add($"Method: {request.Method}");
        outputStrings.Add(await GetRquestBodyFormatted(context, request.Method, request));
        // This doesn't actually work as expected. It returns the IP of the container
        // host. View the container access logs to get the client IP address instead.
        outputStrings.Add($"IP Addr: {GetIP(context)}");

        _logger.LogInformation($"request: {outputStrings.Aggregate(((a,b) => a + ", " + b))}");

        await _next(context);
    }

    private static async Task<string> GetRquestBodyFormatted(HttpContext context, string method, HttpRequest request)
    {
        var body = string.Empty;
        if (method == "POST" || method == "PUT")
        {
            context.Request.EnableBuffering();
            body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            request.Body.Position = 0;

            return $"Body: {body}";
        }

        return string.Empty;
    }

    private string GetIP(HttpContext context)
    {
        var ipAddress = context.Connection.RemoteIpAddress.ToString();

        if (ipAddress != LoopbackIp) return ipAddress;

        var addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
        var addr = addressList.FirstOrDefault(addr =>
            addr.AddressFamily == AddressFamily.InterNetwork);

        if (addr == null)
            addr = addressList.FirstOrDefault(addr =>
                addr.AddressFamily == AddressFamily.InterNetworkV6);

        ipAddress = addr.ToString();

        return ipAddress;
    }
}