namespace PokeroleBuddyBuddy;
using PokeroleBuddyClasses;
using static System.Runtime.InteropServices.JavaScript.JSType;

public partial class PokemonPage : ContentPage
{
    PokemonCollectionHandler pokemonCollectionHandler;
    PokemonEntry currentPokemon;
    public PokemonPage()
    {
        InitializeComponent();
        pokemonCollectionHandler = new PokemonCollectionHandler();
        currentPokemon = new();

        CurrentPokemonView.BindingContext = currentPokemon;
        CurrentPokemonName.SetBinding(Label.TextProperty, new Binding("Name"));

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
    }
}