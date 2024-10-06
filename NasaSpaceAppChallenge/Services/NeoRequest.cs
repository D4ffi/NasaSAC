using Microsoft.Extensions.Options;
using NasaSpaceAppChallenge.Models;

namespace NasaSpaceAppChallenge.Services;


public class NeoRequest : INeoRequest
{
    private readonly HttpClient _httpClient;
    private readonly NeoApi _appSettings;

    public NeoRequest(HttpClient httpClient, IOptions<NeoApi> neoApi)
    {
        _httpClient = httpClient;
        _appSettings = neoApi.Value;
    }
    
    public async Task<HttpResponseMessage> GetNeoFeed(string startDate, string endDate)
    {
        var url = $"{_appSettings.BaseUrl}feed?start_date={startDate}&end_date={endDate}&api_key={_appSettings.ApiKey}";        
        var response = await _httpClient.GetAsync(url);
        
        return response;
    }
}