using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeApp.Models;
using RecipeApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private static Random random = new Random();
        List<MRecipe> inSearch;
        private SearchPage searchPage;

        [TestInitialize]
        public void InitSearchTest()
        {
            inSearch = GenerateRecipes(5);
            searchPage = new SearchPage("unittest");
        }

        [TestCleanup]
        public void Cleanup()
        {
            inSearch = null;
            searchPage = null;
        }

        [TestMethod]
        public void TestSearchRecipeName()
        {
            // egy darab receptnévre keres
            List<MRecipe> searchResult1 = searchPage.SearchInList(inSearch, "recipename" + random.Next(0, inSearch.Count()), "", "");
            Assert.AreEqual(1, searchResult1.Count());

            // az összes "recipename"-et tartalmazó receptre keres
            List<MRecipe> searchResult2 = searchPage.SearchInList(inSearch, "recipename", "", "");
            Assert.AreEqual(inSearch.Count(), searchResult2.Count());

            // az összes "ipename"-et tartalmazó receptre keres, vagyis a receptnév egy részletére, amely bárhol lehet a recept nevén belül
            List<MRecipe> searchResult3 = searchPage.SearchInList(inSearch, "ipename", "", "");
            Assert.AreEqual(inSearch.Count(), searchResult3.Count());
        }

        [TestMethod]
        public void TestSearchTag()
        {
            // egy darab tag-re keres
            List<MRecipe> searchResult1 = searchPage.SearchInList(inSearch, "", "tag" + random.Next(0, inSearch.Count()), "");
            Assert.AreEqual(1, searchResult1.Count());

            // az összes "tag" kifejezést tartalmazó tag-re keres
            List<MRecipe> searchResult2 = searchPage.SearchInList(inSearch, "", "tag", "");
            Assert.AreEqual(inSearch.Count(), searchResult2.Count());

            // az "a" betûre keres a tag-ekben
            List<MRecipe> searchResult3 = searchPage.SearchInList(inSearch, "", "a", "");
            Assert.AreEqual(inSearch.Count(), searchResult3.Count());
        }

        [TestMethod]
        public void TestSearchIngredients()
        {
            // egy konkrét hozzávalóra keres
            List<MRecipe> searchResult1 = searchPage.SearchInList(inSearch, "", "", "ingredients" + random.Next(0, inSearch.Count()));
            Assert.AreEqual(1, searchResult1.Count());

            // az összes hozzávalóra rákeres
            List<MRecipe> searchResult2 = searchPage.SearchInList(inSearch, "", "", "ingredients");
            Assert.AreEqual(inSearch.Count(), searchResult2.Count());

            // az összes "gred"-et tartalmazó hozzávalóra keres, vagyis a hozzávaló egy részletére, amely bárhol lehet a hozzávalón belül
            List<MRecipe> searchResult3 = searchPage.SearchInList(inSearch, "", "", "gred");
            Assert.AreEqual(inSearch.Count(), searchResult3.Count());
        }

        public List<MRecipe> GenerateRecipes(int size)
        {
            List<MRecipe> generatedRecipes = new List<MRecipe>();

            for (int i = 0; i < size; i++)
            {
                MRecipe recipe = new MRecipe
                {
                    Filename = "filename" + i,
                    RecipeName = "recipename" + i,
                    Tags = "tag" + i,
                    CookingTimeHours = "cookingtimehours" + i,
                    CookingTimeMinutes = "cookingtimeminutes" + i,
                    Persons = "persons" + i,
                    Ingredients = "ingredients" + i,
                    Description = "description" + i,
                    Link = "link" + i
                };

                //Trace.WriteLine($"Recept{i}\n{recipe}\n####################");

                generatedRecipes.Add(recipe);
            }
            return generatedRecipes;
        }
    }
}
