using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokeroleBuddyClasses
{
    public class AbilityCollection
    {
        [JsonPropertyName("abilityCollection")]
        public List<AbilityEntry> abilityEntries { get; set; }
    }
}
