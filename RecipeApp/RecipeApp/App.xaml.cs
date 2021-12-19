using RecipeApp.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeApp
{
    public partial class App : Application
    {
        public static string FolderPath { get; private set; }

        public App()
        {
            InitializeComponent();
            FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            MainPage = new StarterPage();
        }
    }
}
