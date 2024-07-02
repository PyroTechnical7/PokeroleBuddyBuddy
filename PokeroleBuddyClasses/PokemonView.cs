using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeroleBuddyClasses
{
    public class PokemonView
    {
        public PokemonEntry currentPokemon {  get; set; }
        public PokemonView() 
        {
            currentPokemon = new PokemonEntry();
        }
    }

    
}
