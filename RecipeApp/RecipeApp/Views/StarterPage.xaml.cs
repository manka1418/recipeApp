using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecipeApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class StarterPage : MasterDetailPage
    {
        private const int MenuRecipe = 0;
        private const int MenuSearch = 1;
        private const int MenuInformations = 2;

        Dictionary<int, NavigationPage> pages;

        public StarterPage()
        {
            InitializeComponent();

            pages = new Dictionary<int, NavigationPage>();
        }

        public async Task NavigateMenu(int id)
        {
            if (pages.ContainsKey(id))
            {
                Detail = pages[id];
            }
            else
            {
                NavigationPage page = new NavigationPage(new RecipePage());
                switch (id)
                {
                    case MenuRecipe:
                        page = new NavigationPage(new RecipePage());
                        break;
                    case MenuSearch:
                        page = new NavigationPage(new SearchPage());
                        break;
                    case MenuInformations:
                        page = new NavigationPage(new InfoPage());
                        break;
                }
                pages[id] = page;
                Detail = page;
            }
            
            if (Device.RuntimePlatform == Device.Android)
            {
                await Task.Delay(100);
            }
            IsPresented = false;

        }
    }

}
