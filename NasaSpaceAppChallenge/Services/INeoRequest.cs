namespace NasaSpaceAppChallenge.Services;

public interface INeoRequest
{ 
    Task<HttpResponseMessage> GetNeoFeed(String startDate, String endDate);
}