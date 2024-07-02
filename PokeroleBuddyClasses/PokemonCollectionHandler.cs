using System.Collections;
using System.Text.Json;

namespace PokeroleBuddyClasses
{
    // All the code in this file is included in all platforms.
    public class PokemonCollectionHandler : CollectionHandler
    {
        PokemonCollection PokemonCollection;
        public async Task<List<PokemonEntry>> ImportJsonCollection(FileResult jsonCollection)
        {
            string pokemonCollectionJson;

            try
            {
                pokemonCollectionJson = await ReadFileContentsAsync(jsonCollection);
                PokemonCollection = JsonSerializer.Deserialize<PokemonCollection>(pokemonCollectionJson);
            }
            catch (Exception e)
            {
                Console.WriteLine("failed to import JSON collection.");
                Console.WriteLine(e);
            }

            return PokemonCollection.pokemonEntries;

        }

        private async Task<string> ReadFileContentsAsync(FileResult fileResult)
        {
            if (fileResult == null)
                return null;

            try
            {
                // Read the selected file's contents as text
                using (var stream = await fileResult.OpenReadAsync())
                using (var reader = new StreamReader(stream))
                {
                    string content = await reader.ReadToEndAsync();
                    return content;
                }
            }
            catch (Exception e)
            {
                // Handle exceptions
                Console.WriteLine($"An error occurred while reading the file: {e.Message}");
                return null;
            }
        }

        public async void ExportToJson(string filePath)
        {
            var options = new JsonSerializerOptions 
            {
                WriteIndented = true
            };
           
            await using FileStream createStream = File.Create(filePath);
            await JsonSerializer.SerializeAsync(createStream, PokemonCollection, options);

        }

        public void AddPokemon(string pokemonJson)
        {
            PokemonEntry pokemon = JsonSerializer.Deserialize<PokemonEntry>(pokemonJson);
            PokemonCollection.pokemonEntries.Add(pokemon);
        }

        public void AddPokemon(PokemonEntry pokemon)
        {
            if(pokemon != null) PokemonCollection.pokemonEntries.Add(pokemon);
        }

        public string getPokemonName(int i = 0)
        {
            return PokemonCollection.pokemonEntries[0].Name;
        }

        public IList<object> GetPokemon()
        {
            return (IList<object>) this.PokemonCollection.pokemonEntries;
        }

        public IEnumerable SearchQuerry(string text)
        {
            var result = PokemonCollection.pokemonEntries.Where(p => p.Name.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0);
            return result;
        }

    }
}
