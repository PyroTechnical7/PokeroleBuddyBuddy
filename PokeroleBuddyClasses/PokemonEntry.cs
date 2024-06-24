using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeroleBuddyClasses
{
    public class PokemonEntry
    {
        public int Number { get; set; }
        public string DexID { get; set; }
        public string Name { get; set; }
        public int Type1 { get; set; }
        public int Type2 { get; set; }
        public int BaseHP { get; set; }
        public int MinStrength { get; set; }
        public int MaxStrength { get; set; }
        public int MinDexterity { get; set; }
        public int MaxDexterity { get; set; }
        public int MinVitality { get; set; }
        public int MaxVitality { get; set; }
        public int MinSpecial { get; set; }
        public int MaxSpecial { get; set; }
        public int MinInsight { get; set; }
        public int MaxInsight { get; set; }
        public Ability Ability1 { get; set; }
        public Ability Ability2 { get; set; }
        public Ability HiddenAbility { get; set; }
        public string EventAbilities { get; set; }
        public int RecommendedRank { get; set; }
        public int GenderType { get; set; }
        public bool Legendary { get; set; }
        public bool GoodStarter { get; set; }
        public string _id { get; set; }
        public string DexCategory { get; set; }
        public string DexDescription { get; set; }
        public string BoxSprite { get; set; }
        public string BoxSpriteShiny { get; set; }
        public string BoxSpriteFemale { get; set; }
        public string BoxSpriteFemaleShiny { get; set; }
        public Height Height { get; set; }
        public Weight Weight { get; set; }
        public string EvolvesFrom { get; set; }
        public List<object> Evolutions { get; set; }
        public List<Move> Moves { get; set; }
    }

    public class Height
    {
        public double Meters { get; set; }
        public double Feet { get; set; }
    }

    public class Weight
    {
        public double Kilograms { get; set; }
        public double Pounds { get; set; }
    }
}
