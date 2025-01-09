using System.Text.Json.Serialization;

namespace MurderAPI.Entities
{
    public class PlaceToSearch
    {
        [JsonPropertyName("RoomId")]
        public int RoomId { get; set; }

        [JsonPropertyName("PlaceName")]
        public string? PlaceName { get; set; }

        [JsonPropertyName("PossibleClues")]
        public string? PossibleClues { get; set; }
    }
}
