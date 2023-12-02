using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeDatabase.Data;
using RecipeDatabase.Models;

namespace RecipeDatabase.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly RecipeDatabase.Data.RecipeDatabaseContext _context;

        public IndexModel(RecipeDatabase.Data.RecipeDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string Option { get; set; }

        public List<SelectListItem> OptionsList { get; set; }

        public IList<Recipe> Recipe { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Recipe> recipes = _context.Recipe.AsQueryable();

            // Filtering based on the selected option
            if (!string.IsNullOrEmpty(Option) && Option == "Ingredients")
            {
                if (!string.IsNullOrEmpty(SearchString))
                {
                    recipes = recipes.Where(r => r.Ingredients.Contains(SearchString));
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(SearchString))
                {
                    recipes = recipes.Where(r => r.Name.Contains(SearchString));
                }
            }

            Recipe = await recipes.ToListAsync();

            // Populating OptionsList with your desired options
            OptionsList = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "All" },
                new SelectListItem { Value = "Ingredients", Text = "Ingredient" },
                // Add other SelectListItem objects as needed
            };
        }
    }
}



