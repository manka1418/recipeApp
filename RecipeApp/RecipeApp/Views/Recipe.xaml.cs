using RecipeApp.Models;
using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Recipe : ContentPage
    {
        MRecipe item;

        public Recipe(MRecipe item)
        {
            InitializeComponent();
            this.item = item;
            BindingContext = this.item;

            OnLinkClickHandler();
        }

        private void OnLinkClickHandler()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                if (item.Link.StartsWith("http"))
                {
                    Device.OpenUri(new Uri(item.Link));
                }
                else
                {
                    Device.OpenUri(new Uri("http://" + item.Link));
                }

            };
            Link.GestureRecognizers.Clear();
            Link.GestureRecognizers.Add(tapGestureRecognizer);
        }

        async void EditingRecipeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewRecipe(this.item));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // itt frissíti a nézet adatait
            BindingContext = null;
            BindingContext = this.item;
        }

        async void DeleteRecipeClicked(object sender, EventArgs e)
        {
            if (File.Exists(this.item.Filename))
            {
                File.Delete(this.item.Filename);
            }
            await Navigation.PopAsync();
        }
    }
}