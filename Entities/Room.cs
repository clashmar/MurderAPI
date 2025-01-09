using System.Text.Json.Serialization;

namespace MurderAPI.Entities
{
    public class Room
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Floor")]
        public int Floor { get; set; }

        [JsonPropertyName("IsLocked")]
        public bool IsLocked { get; set; }

        [JsonPropertyName("Clues")]
        public string? Clues { get; set; }
    }
}
