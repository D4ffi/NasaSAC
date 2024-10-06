using System.Text.Json.Serialization;

namespace NasaSpaceAppChallenge.Models;

public class NeoFeedResponse
{
    // crear un diccionario de asteroides
    [JsonPropertyName("near_earth_objects")]
    public Dictionary<string, List<Asteroid>> NearEarthObjects { get; set; }
}