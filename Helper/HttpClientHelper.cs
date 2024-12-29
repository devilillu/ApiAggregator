using System.Text;

namespace Helper;

public static class HttpClientHelper
{
    public static async Task<string> GetAsync(string uri)
    {
        try
        {
            using var response = await new HttpClient().GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            return $"{uri}:{ex.Message}";
        }
    }

    public static async Task<HttpResponseMessage> PostJsonAsync(string uri, string jsonObject)
    {
        var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        return await new HttpClient().PostAsync(uri, content);
    }

    /// <param name="uri">"https://covid-19-data.p.rapidapi.com/country/code?format=json&code=it"</param>
    ///             Headers =
    ///{
    /// { "x-rapidapi-key", "Sign Up for Key" },
    ///{ "x-rapidapi-host", "covid-19-data.p.rapidapi.com" },
    ///},

    public static async
    Task<string?> Run(string uri, IEnumerable<KeyValuePair<string, string>> headers)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uri),
        };

        foreach (var item in headers)
            request.Headers.Add(item.Key, item.Value);

        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
