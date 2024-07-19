namespace PokeroleBuddyBuddy;
using PokeroleBuddyClasses;
using static System.Runtime.InteropServices.JavaScript.JSType;

public partial class PokemonPage : ContentPage
{
    PokemonCollectionHandler pokemonCollectionHandler;
    PokemonEntry currentPokemon;
    IEnumerable<string> types;
    public PokemonPage()
    {
        InitializeComponent();
        pokemonCollectionHandler = new PokemonCollectionHandler();
        currentPokemon = new();
        types = new List<string> {"None", "Normal", "Fire", "Water", "Electric", "Grass", "Ice", "Fighting", "Poison", "Ground", "Flying", "Psychic", "Bug", "Rock", "Ghost", "Dragon", "Dark", "Steel", "Fairy"};

        CurrentPokemonType1.ItemsSource = (System.Collections.IList) types;
        CurrentPokemonType2.ItemsSource = (System.Collections.IList) types;

        CurrentPokemonType1.SelectedIndex = 0;
        CurrentPokemonType2.SelectedIndex = 0;
    }

    private async void OnImportPokemonClicked(object sender, EventArgs e)
    {
        FileResult jsonFile = await ImportJsonCollectionPrompt();
        if (jsonFile != null)
        {
            IList<PokemonEntry> importPokemon = await pokemonCollectionHandler.ImportJsonCollection(jsonFile);
            ListView.ItemsSource = importPokemon;
            
            //CounterBtn.Text = pokemonCollectionHandler.getPokemonName();
        }



        //SemanticScreenReader.Announce(ImportPokemonBtn.Text);
    }

    private async void OnTextChanged(object sender, EventArgs e)
    {
        ListView.ItemsSource = pokemonCollectionHandler.SearchQuerry(PokemonSearchBar.Text);
    }

    private async Task<FileResult> ImportJsonCollectionPrompt()
    {
        var jsonFileType = new FilePickerFileType(
            new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                    { DevicePlatform.iOS, new[] { "public.my.comic.extension" } }, // UTType values
                    { DevicePlatform.Android, new[] { "application/comics" } }, // MIME type
                    { DevicePlatform.WinUI, new[] { ".json" } }, // file extension
                    { DevicePlatform.Tizen, new[] { "*/*" } },
                    { DevicePlatform.macOS, new[] { "json" } }, // UTType values
            });

        PickOptions options = new PickOptions
        {
            PickerTitle = "Select the Data Collection",
            FileTypes = jsonFileType
        };
        try
        {
            var result = await FilePicker.PickAsync(options);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return null;
    }

    private void NewPokemonBtnClicked(object sender, EventArgs e)
    {
        // TODO: check current pokemon

        pokemonCollectionHandler.AddPokemon(currentPokemon);
        ListView.ItemsSource = pokemonCollectionHandler.GetPokemon();
    }

    private void OnPokemonSelected(object sender, SelectedItemChangedEventArgs e)
    {
        currentPokemon = e.SelectedItem as PokemonEntry;

        if (currentPokemon != null)
        {
            UpdateCurrentPokemon();
        }
    }

    private void UpdateCurrentPokemon()
    {
        try
        {
            CurrentPokemonName.Text = currentPokemon.Name;
            CurrentPokemonNumber.Text = currentPokemon.Number.ToString();
            CurrentPokemonDexID.Text = currentPokemon.DexID;

            CurrentPokemonType1.SelectedIndex = currentPokemon.Type1;
            CurrentPokemonType2.SelectedIndex = currentPokemon.Type2;

            CurrentPokemonMinStrength.SetNumber(currentPokemon.MinStrength);
            CurrentPokemonMaxStrength.SetNumber(currentPokemon.MaxStrength);

            CurrentPokemonMinDex.SetNumber(currentPokemon.MinDexterity);
            CurrentPokemonMaxDex.SetNumber(currentPokemon.MaxDexterity);

            CurrentPokemonMinVit.SetNumber(currentPokemon.MinVitality);
            CurrentPokemonMaxVit.SetNumber(currentPokemon.MaxVitality);

            CurrentPokemonMinSpec.SetNumber(currentPokemon.MinSpecial);
            CurrentPokemonMaxSpec.SetNumber(currentPokemon.MaxSpecial);

            CurrentPokemonMinIns.SetNumber(currentPokemon.MinInsight);
            CurrentPokemonMaxIns.SetNumber(currentPokemon.MaxInsight);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}