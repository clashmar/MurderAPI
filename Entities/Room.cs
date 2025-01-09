using System.Text.Json.Serialization;

namespace MurderAPI.Entities
{
    public class Room
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("floor")]
        public int Floor { get; set; }

        [JsonPropertyName("isLocked")]
        public bool IsLocked { get; set; }

        [JsonPropertyName("clues")]
        public string? Clues { get; set; }
    }
}
