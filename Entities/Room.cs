using System.Text.Json.Serialization;

namespace MurderAPI.Entities
{
    public class Room
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Room")]
        public string? RoomName { get; set; }

        [JsonPropertyName("Floor")]
        public int Floor { get; set; }

        [JsonPropertyName("IsLocked")]
        public bool IsLocked { get; set; }

        [JsonPropertyName("Impressions")]
        public string? Impressions { get; set; }

        [JsonPropertyName("PlacesToSearch")]
        public string[]? PlacesToSearch { get; set; }
    }
}
