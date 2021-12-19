using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        StarterPage RootPage { get => Application.Current.MainPage as StarterPage; }

        public MenuPage()
        {
            InitializeComponent();

            List<string> menuItems = new List<string>
            {
                "Receptek",
                "Keresés",
                "Információk"
            };

            RecipeMenuList.ItemsSource = menuItems;
            RecipeMenuList.SelectedItem = menuItems[0];
        }

        public async void MenuItemClicked(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            int id = e.SelectedItemIndex;
            if(RootPage != null)
            {
                await RootPage.NavigateMenu(id);
            }
        }
    }
}