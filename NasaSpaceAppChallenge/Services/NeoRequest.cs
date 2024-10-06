using Microsoft.Extensions.Options;
using NasaSpaceAppChallenge.Models;

namespace NasaSpaceAppChallenge.Services;


public class NeoRequest : INeoRequest
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<NeoRequest> _logger;
    private readonly NeoApi _appSettings;

    public NeoRequest(HttpClient httpClient, IOptions<NeoApi> neoApi, ILogger<NeoRequest> logger)
    {
        _httpClient = httpClient;
        _appSettings = neoApi.Value;
        _logger = logger;
    }
    
    public async Task<HttpResponseMessage> GetNeoFeed(string startDate, string endDate)
    {
        var url = $"feed?start_date={startDate}&end_date={endDate}&api_key={_appSettings.ApiKey}";    
        var response = await _httpClient.GetAsync(url);
        _logger.LogInformation("Received response: {StatusCode}", response.StatusCode);
        
        return response;
    }
}