using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace RecipeApp.Models
{
    public class MRecipe
    {
        public string Filename { get; set; }
        public string RecipeName { get; set; }
        public string Tags { get; set; }
        public string CookingTimeMinutes { get; set; }
        public string CookingTimeHours { get; set; }
        public string Persons { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public string Content {
            get
            {
                return $"{RecipeName}|{Tags}|{CookingTimeHours}|{CookingTimeMinutes}|{Persons}|{Ingredients}|{Description}|{Link}";
            }
        }

        public override string ToString()
        {
            return Content;
        }

        public string ListDetails
        {
            get
            {
                string detail = "";
                if(!string.IsNullOrWhiteSpace(CookingTimeHours) && Convert.ToInt32(CookingTimeHours) > 0)
                {
                    detail += $"{CookingTimeHours} óra ";
                }
                if(!string.IsNullOrWhiteSpace(CookingTimeMinutes) && Convert.ToInt32(CookingTimeMinutes) > 0)
                {
                    detail += $"{CookingTimeMinutes} perc";
                }
                return $"Elkészítési idő: " + detail;
            }
        }

        public MRecipe() { }

        public MRecipe(MRecipe other)
        {
            Copy(other);
        }

        public void Copy(MRecipe other)
        {
            Filename = other.Filename;
            RecipeName = other.RecipeName;
            Tags = other.Tags;
            CookingTimeHours = other.CookingTimeHours;
            CookingTimeMinutes = other.CookingTimeMinutes;
            Persons = other.Persons;
            Ingredients = other.Ingredients;
            Description = other.Description;
            Link = other.Link;
        }

    }
}
