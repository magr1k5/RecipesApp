using RecipesApp.ViewModel;
using RecipeApp.Screens;
using RecipesApp.Screens;

namespace RecipesApp
{
    public partial class AppShell : Shell
    {
        public UserViewModel ViewModel { get; } = new UserViewModel();


        public AppShell()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }
        private async void OnAddRecipeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddRecipeScreen());
        }
    }
}