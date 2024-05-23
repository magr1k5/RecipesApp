using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeApp.Classes;

namespace RecipeApp.ViewModel
{
    public class RecipeDetailsViewModel: BindableObject
    {
        public RecipeDetailsViewModel()
        {
            Ingredients = new ObservableCollection<Ingredient>();
            Steps = new ObservableCollection<RecipesSteps>();
        }

        private Recipes _recipe;
        public Recipes Recipe
        {
            get => _recipe;
            set
            {
                _recipe = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Ingredient> _ingredients;
        public ObservableCollection<Ingredient> Ingredients
        {
            get => _ingredients;
            set
            {
                _ingredients = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<RecipesSteps> _steps;
        public ObservableCollection<RecipesSteps> Steps
        {
            get => _steps;
            set
            {
                _steps = value;
                OnPropertyChanged();
            }
        }

        private DatabaseManager _dbManager;


        public RecipeDetailsViewModel(Recipes recipe)
        {
            _recipe = recipe;
            _ingredients = new ObservableCollection<Ingredient>();
            _steps = new ObservableCollection<RecipesSteps>();
            _dbManager = new DatabaseManager($"User Id=postgres;Host=localhost;Database=recipe_app_db;Port=5432;password=root");

            LoadRecipeDetails();
        }

        public async Task LoadRecipeDetails()
        {
            await Task.Run(() =>
            {
                _dbManager.OpenConnection();
                var ingredients = _dbManager.GetIngredientsForRecipe(_recipe.recipeid);
                var steps = _dbManager.GetRecipeSteps(_recipe.recipeid);
                _dbManager.CloseConnection();

                foreach (var ingredient in ingredients)
                {
                    Ingredients.Add(ingredient);
                }

                foreach (var step in steps)
                {
                    Steps.Add(step);
                }
            });
        }
    }
}
