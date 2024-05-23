using Microsoft.Maui.Controls;
using RecipeApp.Classes;
using RecipeApp.ViewModel;
namespace RecipeApp.Screens;

[QueryProperty(nameof(Recipes), "Recipe")]
public partial class RecipeDetails : ContentPage
{
    private Recipes _recipe;

    public Recipes Recipe
    {
        get => _recipe;
        set
        {
            _recipe = value;
            OnPropertyChanged();
            BindingContext = _recipe;  // Установите контекст привязки
        }
    }
    public RecipeDetails()
	{
		InitializeComponent();
        BindingContext = new RecipeDetailsViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is RecipeDetailsViewModel viewModel)
        {
            if (Shell.Current.CurrentPage.BindingContext is IDictionary<string, object> parameters && parameters.TryGetValue("Recipe", out var recipe))
            {
                viewModel.Recipe = recipe as Recipes;
                viewModel.LoadRecipeDetails();
            }
        }
    }
}