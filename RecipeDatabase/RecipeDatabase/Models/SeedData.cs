using Microsoft.EntityFrameworkCore;
using RecipeDatabase.Data;

namespace RecipeDatabase.Models;


public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RecipeDatabaseContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RecipeDatabaseContext>>()))
        {
            if (context == null || context.Recipe == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Recipe.Any())
            {
                return;   // DB has been seeded
            }

            context.Recipe.AddRange(
                new Recipe
                {
                    Name = "Spaghetti Carbonara",
                    Ingredients = "Spaghetti, Guanciale or Pancetta, Eggs, Pecorino Romano cheese, Black pepper",
                    Description = "A classic Italian pasta dish made with cured pork, cheese, and eggs.",
                    Steps = "1. Boil spaghetti until al dente. 2. Cook guanciale or pancetta until crispy. 3. Mix eggs and cheese. 4. Combine everything, adding black pepper. 5. Serve immediately."

                },
                  new Recipe
                  {
                      Name = "Chicken Alfredo",
                      Ingredients = "Chicken breast, Fettuccine pasta, Heavy cream, Parmesan cheese, Garlic, Butter",
                      Description = "A creamy pasta dish with tender chicken and a rich Alfredo sauce.",
                      Steps = "1. Cook chicken until golden brown. 2. Cook pasta until tender. 3. Make the Alfredo sauce with cream, cheese, garlic, and butter. 4. Combine everything. 5. Garnish with parsley if desired."

                  },
                   new Recipe
                   {
                       Name = "Chocolate Chip Cookies",
                       Ingredients = "Flour, Butter, Sugar, Brown sugar, Eggs, Vanilla extract, Baking soda, Chocolate chips",
                       Description = "Classic cookies loaded with chocolate chips, perfect for a sweet treat.",
                       Steps = "1. Cream butter and sugars. 2. Add eggs and vanilla extract. 3. Mix dry ingredients separately. 4. Combine wet and dry ingredients. 5. Fold in chocolate chips. 6. Bake until golden brown."
                   }

            );
            context.SaveChanges();
        }

    }
}

