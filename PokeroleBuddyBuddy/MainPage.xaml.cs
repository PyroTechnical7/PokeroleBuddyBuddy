using PokeroleBuddyClasses;
using System;
using System.Threading.Tasks;

namespace PokeroleBuddyBuddy
{
    public partial class MainPage : ContentPage
    {
        PokemonCollectionHandler pokemonCollectionHandler;
        ItemCollectionHandler itemCollectionHandler;
        AbilityCollectionHandler abilityCollectionHandler;
        MoveCollectionHandler moveCollectionHandler;

        public MainPage()
        {
            InitializeComponent();
        }


        private async void OnImportItemsClicked(object sender, EventArgs e)
        {
            FileResult jsonFile = await ImportJsonCollectionPrompt();
            if (jsonFile != null)
            {
                itemCollectionHandler = new ItemCollectionHandler();
                itemCollectionHandler.ImportJsonCollection(jsonFile);
            }


            SemanticScreenReader.Announce(ImportItemsBtn.Text);
        }

        private async void OnImportAbilitiesClicked(object sender, EventArgs e)
        {
            FileResult jsonFile = await ImportJsonCollectionPrompt();
            if (jsonFile != null)
            {
                abilityCollectionHandler = new AbilityCollectionHandler();
                abilityCollectionHandler.ImportJsonCollection(jsonFile);
            }


            SemanticScreenReader.Announce(ImportAbilitiesBtn.Text);
        }

        private async void OnImportMovesClicked(object sender, EventArgs e)
        {
            FileResult jsonFile = await ImportJsonCollectionPrompt();
            if (jsonFile != null)
            {
                moveCollectionHandler = new MoveCollectionHandler();
                moveCollectionHandler.ImportJsonCollection(jsonFile);
            }


            SemanticScreenReader.Announce(ImportMovesBtn.Text);
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
    }

}
