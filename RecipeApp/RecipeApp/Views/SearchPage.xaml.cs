using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        List<MRecipe> filteredRecipes = new List<MRecipe>();

        public SearchPage(string unittest = null)
        {
            if (unittest == null)
            {
                InitializeComponent();
            }
        }

        void OnTextChanged(object sender, EventArgs e)
        {
            SearchInList();
            HandleSearchResultOnScreen();
        }

        public List<MRecipe> SearchInList(List<MRecipe> recipes = null, string name = null, string tag = null, string ingredient = null)
        {
            List<MRecipe> searchInThisList = new List<MRecipe>();
            if(recipes == null)
            {
                searchInThisList = RecipePage.allRecipes;
            }
            else
            {
                searchInThisList = recipes;
            }

            filteredRecipes.Clear();
            string searchRecipeName = name ?? RecipeNameSB.Text; // name != null ? name : RecipeNameSB.Text
            string searchTag = tag ?? TagSB.Text;
            string searchIngredient = ingredient ?? IngredientSB.Text;


            if (!string.IsNullOrWhiteSpace(searchRecipeName) && !string.IsNullOrWhiteSpace(searchTag) && !string.IsNullOrWhiteSpace(searchIngredient))
            {
                Debug.WriteLine("search 1");

                filteredRecipes.AddRange(searchInThisList.Where(n => n.RecipeName.IndexOf(searchRecipeName, StringComparison.OrdinalIgnoreCase) >= 0)
                                                         .Where(n => n.Tags.IndexOf(searchTag, StringComparison.OrdinalIgnoreCase) >= 0)
                                                         .Where(n => n.Ingredients.IndexOf(searchIngredient, StringComparison.OrdinalIgnoreCase) >= 0)
                );
            }			
            else if (!string.IsNullOrWhiteSpace(searchRecipeName) && !string.IsNullOrWhiteSpace(searchTag))
            {
                Debug.WriteLine("search 2");
                filteredRecipes.AddRange(searchInThisList.Where(n => n.RecipeName.IndexOf(searchRecipeName, StringComparison.OrdinalIgnoreCase) >= 0)
                                                         .Where(n => n.Tags.IndexOf(searchTag, StringComparison.OrdinalIgnoreCase) >= 0)
                );
            }
            else if (!string.IsNullOrWhiteSpace(searchRecipeName) && !string.IsNullOrWhiteSpace(searchIngredient))
            {
                Debug.WriteLine("search 3");
                filteredRecipes.AddRange(searchInThisList.Where(n => n.RecipeName.IndexOf(searchRecipeName, StringComparison.OrdinalIgnoreCase) >= 0)
                                                         .Where(n => n.Ingredients.IndexOf(searchIngredient, StringComparison.OrdinalIgnoreCase) >= 0)
                );
            }
            else if (!string.IsNullOrWhiteSpace(searchTag) && !string.IsNullOrWhiteSpace(searchIngredient))
            {
                Debug.WriteLine("search 4");
                filteredRecipes.AddRange(searchInThisList.Where(n => n.Tags.IndexOf(searchTag, StringComparison.OrdinalIgnoreCase) >= 0)
                                                         .Where(n => n.Ingredients.IndexOf(searchIngredient, StringComparison.OrdinalIgnoreCase) >= 0)
                );
            }
            else if (!string.IsNullOrWhiteSpace(searchRecipeName))
            {
                Debug.WriteLine("search 5");
                filteredRecipes.AddRange(searchInThisList.Where(n => n.RecipeName.IndexOf(searchRecipeName, StringComparison.OrdinalIgnoreCase) >= 0));
            }
            else if (!string.IsNullOrWhiteSpace(searchTag))
            {
                Debug.WriteLine("search 6");
                filteredRecipes.AddRange(searchInThisList.Where(n => n.Tags.IndexOf(searchTag, StringComparison.OrdinalIgnoreCase) >= 0));
            }
            else if (!string.IsNullOrWhiteSpace(searchIngredient))
            {
                Debug.WriteLine("search 7");
                filteredRecipes.AddRange(searchInThisList.Where(n => n.Ingredients.IndexOf(searchIngredient, StringComparison.OrdinalIgnoreCase) >= 0));
            }

            return filteredRecipes.Distinct().ToList();
        }

        void HandleSearchResultOnScreen()
        {
            if (filteredRecipes.Any()) //van keresési eredmény
            {
                SearchResultsList.IsVisible = true;
                NoSearchResultLabel.IsVisible = false;
                SearchResultsList.ItemsSource = filteredRecipes.Distinct();
            }
            else // nincs keresési eredmény
            {
                SearchResultsList.IsVisible = false;
                NoSearchResultLabel.IsVisible = true;
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as MRecipe;
            if (item == null)
                return;

            await Navigation.PushAsync(new Recipe(item));

            // lista kiválasztásának megszüntetése (szín eltűntetése)
            SearchResultsList.SelectedItem = null;
        }
    }
}