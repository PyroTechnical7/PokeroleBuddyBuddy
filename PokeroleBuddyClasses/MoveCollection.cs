using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokeroleBuddyClasses
{
    internal class MoveCollection
    {
        [JsonPropertyName("moveCollection")]
        public List<MoveEntry> moveEntries {  get; set; }
    }
}
