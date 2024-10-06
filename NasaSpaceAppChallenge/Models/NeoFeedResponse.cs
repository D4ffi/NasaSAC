using System.Text.Json.Serialization;

namespace NasaSpaceAppChallenge.Models;

public class NeoFeedResponse
{
    // Missing to correct the way the JSON is deserialized and the way the data is stored
    [JsonPropertyName("near_earth_objects")]
    public Dictionary<string, List<Asteroid>> NearEarthObjects { get; set; }
}