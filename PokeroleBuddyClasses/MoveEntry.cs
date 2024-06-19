using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokeroleBuddyClasses
{
    internal class MoveEntry
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Type")]
        public int Type { get; set; }

        [JsonPropertyName("Power")]
        public int Power { get; set; }

        [JsonPropertyName("Damage1")]
        public string Damage1 { get; set; }

        [JsonPropertyName("Damage2")]
        public string Damage2 { get; set; }

        [JsonPropertyName("Accuracy1")]
        public string Accuracy1 { get; set; }

        [JsonPropertyName("Accuracy2")]
        public string Accuracy2 { get; set; }

        [JsonPropertyName("Target")]
        public string Target { get; set; }

        [JsonPropertyName("Effect")]
        public string Effect { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [JsonPropertyName("Category")]
        public string Category { get; set; }
    }
}
