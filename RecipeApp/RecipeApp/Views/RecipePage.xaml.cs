using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {
        public static List<MRecipe> allRecipes = new List<MRecipe>();

        public RecipePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var recipes = new List<MRecipe>();

            var files = Directory.EnumerateFiles(App.FolderPath, "*.recipe.txt");
            foreach (var filename in files)
            {
                string content = File.ReadAllText(filename);
                string[] splittedContent = content.Split('|');

                MRecipe recipe = new MRecipe
                {
                    Filename = filename,
                    RecipeName = splittedContent[0],
                    Tags = splittedContent[1],
                    CookingTimeHours = splittedContent[2],
                    CookingTimeMinutes = splittedContent[3],
                    Persons = splittedContent[4],
                    Ingredients = splittedContent[5],
                    Description = splittedContent[6],
                    Link = splittedContent[7],
                };

                recipes.Add(recipe);
            }

            RecipeList.ItemsSource = recipes
                .OrderBy(d => d.RecipeName)
                .ToList();

            if(allRecipes.Count() != recipes.Count())
            {
                allRecipes.Clear();
                allRecipes.AddRange(recipes);
            }
        }

        async void OnRecipeAddedClicked(object sender, EventArgs e)
        {
            Page newRecipePage = new NewRecipe();
            await Navigation.PushAsync(newRecipePage);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as MRecipe;
            if (item == null)
                return;

            await Navigation.PushAsync(new Recipe(item));

            // lista kiválasztásának megszüntetése (szín eltűntetése)
            RecipeList.SelectedItem = null;
        }


    }
}