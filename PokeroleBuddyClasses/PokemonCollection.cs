using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokeroleBuddyClasses
{
    internal class PokemonCollection
    {
        [JsonPropertyName("pokemonCollection")]
        public List<PokemonEntry> pokemonEntries { get; set; }
    }

}
