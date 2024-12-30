using Helper.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Helper;

public static class MoreHttpContext
{
    const int TruncatedMessageLength = 128;

    public static async Task WriteToBodyAsync(this HttpContext context, string message)
    {
        try
        {
            await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(message + Environment.NewLine));
        }
        catch (ArgumentNullException ex)
        {
            throw new RetrieveUriInfoException(
                $"Exception writing to context, message:{message[..Math.Min(TruncatedMessageLength, message.Length)]}", ex);
        }
        catch (EncoderFallbackException ex)
        {
            throw new RetrieveUriInfoException(
                $"Exception writing to context, message:{message[..Math.Min(TruncatedMessageLength, message.Length)]}", ex);
        }
    }

    public static string RetrieveFromUri(this HttpContext context, string key)
    {
        try
        {
            return (context.Request.RouteValues.TryGetValue(key, out object? value) && value is string valueAsString)
                ? valueAsString
                : throw new RetrieveUriInfoException($"Exception retrieving key:{key} from context, unrecognized value");
        }
        catch (ArgumentNullException ex)
        {
            throw new RetrieveUriInfoException($"Exception retrieving key:{key} from context", ex);
        }
    }

    public async static Task<T?> ReadJsonAsync<T>(this HttpContext context) =>
        await context.Request.ReadFromJsonAsync<T>();
}

