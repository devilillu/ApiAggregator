using System.Text;

namespace Helper;

public static class HttpClientHelper
{
    public static async Task<string> SendAsync(string uri, IEnumerable<KeyValuePair<string, string>> headers)
    {
        try
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, uri);
            using var client = new HttpClient();

            foreach (var item in headers)
                client.DefaultRequestHeaders.Add(item.Key, item.Value);

            var httpResponse = await client.SendAsync(httpRequest);
            return await httpResponse.Content.ReadAsStringAsync();
        }
        catch (ArgumentNullException ex)
        {
            return $"{uri}:{ex.Message}";
        }
        catch (InvalidOperationException ex)
        {
            return $"{uri}:{ex.Message}";
        }
        catch (HttpRequestException ex)
        {
            return $"{uri}:{ex.Message}";
        }
        catch (TaskCanceledException ex)
        {
            return $"{uri}:{ex.Message}";
        }
    }
}
