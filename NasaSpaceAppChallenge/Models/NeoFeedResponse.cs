using System.Text.Json.Serialization;

namespace NasaSpaceAppChallenge.Models;

public class NeoFeedResponse
{
    
    public string Id { get; set; }
    public string Name { get; set; }
    [JsonPropertyName("kilometers_per_second")]
    public string KilometersPerSecond { get; set; }
}