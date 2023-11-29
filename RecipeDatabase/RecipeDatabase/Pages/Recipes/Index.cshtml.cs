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

        public IList<Recipe> Recipe { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? RecipeName { get; set; }


        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from r in _context.Recipe
                                            orderby r.Name
                                            select r.Name;

            var recipes = from r in _context.Recipe
                         select r;
            if (!string.IsNullOrEmpty(SearchString))
            {
                recipes = recipes.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(RecipeName))
            {
                recipes = recipes.Where(x => x.Name == RecipeName);
            }

            Recipe = await recipes.ToListAsync();
        }
    }
}
