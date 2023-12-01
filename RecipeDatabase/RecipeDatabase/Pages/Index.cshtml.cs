using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeDatabase.Data;
using RecipeDatabase.Models;
using System.Collections.Generic;

public class IndexModel : PageModel
{
    private readonly RecipeDatabaseContext _context;

    public IndexModel(RecipeDatabaseContext context)
    {
        _context = context;
    }

    public IList<Recipe> Recipe { get; set; } = new List<Recipe>();

    public void OnGet()
    {
        // Fetch recipes from the database and assign them to the Recipe property
        Recipe = _context.Recipe.ToList();
    }
}
