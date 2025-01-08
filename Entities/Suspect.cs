using System.Text.Json.Serialization;

namespace MurderAPI.Entities
{
    public class Suspect
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }
    }
}
