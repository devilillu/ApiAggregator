namespace Helper;

public static class HttpClientHelper
{
    public static async Task<HttpClientResult> SendAsync(string uri, IEnumerable<KeyValuePair<string, string>> headers)
    {
        DateTime start = DateTime.Now;
        try
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, uri);
            using var client = new HttpClient();

            foreach (var item in headers)
                client.DefaultRequestHeaders.Add(item.Key, item.Value);

            var httpResponse = await client.SendAsync(httpRequest);

            return new(await httpResponse.Content.ReadAsStringAsync(), DateTime.Now - start);
        }
        catch (ArgumentNullException ex)
        {
            return new($"{uri}:{ex.Message}", DateTime.Now - start); ;
        }
        catch (InvalidOperationException ex)
        {
            return new($"{uri}:{ex.Message}", DateTime.Now - start); ;
        }
        catch (HttpRequestException ex)
        {
            return new($"{uri}:{ex.Message}", DateTime.Now - start); ;
        }
        catch (TaskCanceledException ex)
        {
            return new($"{uri}:{ex.Message}", DateTime.Now - start);;
        }
    }
}

public record class HttpClientResult(string Result, TimeSpan Ellapsed);
