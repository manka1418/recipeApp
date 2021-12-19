using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using RecipeApp.Models;

namespace RecipeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewRecipe : ContentPage
    {
        MRecipe beforeModRecipe; // ezt használja visszaállításhoz, ha módosításra kerül sor, de a vissza gombra kattintanak

        public NewRecipe()
        {
            InitializeComponent();
            BindingContext = new MRecipe();
        }

        public NewRecipe(MRecipe toModRecipe)
        {
            InitializeComponent();

            beforeModRecipe = new MRecipe(toModRecipe);
            BindingContext = toModRecipe;
        }

        async void NewRecipeSaveClicked(object sender, EventArgs e)
        {
            ErrorMessage.IsVisible = false;

            var note = (MRecipe)BindingContext;
            
            if (!string.IsNullOrWhiteSpace(note.RecipeName) &&
                !string.IsNullOrWhiteSpace(note.Ingredients) &&
                !string.IsNullOrWhiteSpace(note.Description)
                )
            {
                if (string.IsNullOrWhiteSpace(note.Filename))
                {
                    // új recept mentése
                    var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.recipe.txt");
                    File.WriteAllText(filename, note.Content);
                }
                else
                {
                    // recept frissítése
                    File.WriteAllText(note.Filename, note.Content);
                }

                await Navigation.PopAsync(); // bezárja a jelenlegi oldalt // PushAsync ellentéte, csak ez nem vár page paramétert
            }
            else
            {
                ErrorMessage.IsVisible = true;
            }
        }

        async void NewRecipeBackClicked(object sender, EventArgs e) 
        {
            if (beforeModRecipe != null)
            {
                (BindingContext as MRecipe).Copy(beforeModRecipe);
            }
            await Navigation.PopAsync();
        }

    }
}