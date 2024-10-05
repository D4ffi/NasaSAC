using NasaSpaceAppChallenge.Models;

namespace NasaSpaceAppChallenge.Services;


public class NeoRequest : INeoRequest
{
    private readonly HttpClient _httpClient;
    private readonly NeoApi _appSettings;
    
    public Task<HttpResponseMessage> GetNeoFeed()
    {
        throw new NotImplementedException();
    }
}