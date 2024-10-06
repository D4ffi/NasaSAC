using System.Text.Json.Serialization;

namespace NasaSpaceAppChallenge.Models
{
    public class Asteroid
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("estimated_diameter")]
        public EstimatedDiameter EstimatedDiameter { get; set; }
    }

    public class EstimatedDiameter
    {
        [JsonPropertyName("kilometers")]
        public DiameterRange Kilometers { get; set; }
    }

    public class DiameterRange
    {
        [JsonPropertyName("estimated_diameter_min")]
        public double Min { get; set; }

        [JsonPropertyName("estimated_diameter_max")]
        public double Max { get; set; }
    }
}