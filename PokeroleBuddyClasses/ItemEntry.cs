using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokeroleBuddyClasses
{
    internal class ItemEntry
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("ID")]
        public string ID { get; set; }

        [JsonPropertyName("Source")]
        public string Source { get; set; }

        [JsonPropertyName("PMD")]
        public bool PMD { get; set; }

        [JsonPropertyName("Pocket")]
        public string Pocket { get; set; }

        [JsonPropertyName("Category")]
        public string Category { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("OneUse")]
        public bool OneUse { get; set; }

        [JsonPropertyName("TrainerPrice")]
        public int TrainerPrice { get; set; }

        [JsonPropertyName("HealthRestored")]
        public int HealthRestored { get; set; }

        [JsonPropertyName("Cures")]
        public string Cures { get; set; }

        [JsonPropertyName("Boost")]
        public List<string> Boost { get; set; }

        [JsonPropertyName("Value")]
        public int Value { get; set; }

        [JsonPropertyName("ForTypes")]
        public string ForTypes { get; set; }

        [JsonPropertyName("ForPokemon")]
        public List<string> ForPokemon { get; set; }

        [JsonPropertyName("ItemSpritePath")]
        public string ItemSpritePath { get; set; }
    }
}
