namespace api.Plugins;

/// <summary>
/// Plugin that provides access to make an outbound HTTP call.
/// </summary>
public class HttpPlugin 
{
    /// <summary>
    /// Gets the response length of the content at the given URL
    /// </summary>
    /// <param name="url">The URL to retrieve.</param>
    /// <returns>The response length of the content at the URL.</returns>
    public int GetResponseLength(string url)
    {
        var client = new HttpClient();
        var response = client.GetAsync(url).Result;

        return Convert.ToInt32(response.Content.Headers.ContentLength);
    }
}