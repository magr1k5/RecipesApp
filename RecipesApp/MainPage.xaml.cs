using RecipeApp.Screens;

namespace RecipesApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void ToRegisterScreen(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("RegisterScreen");
            await Navigation.PushAsync(new RegisterScreen());

        }

        private async void ToLoginScreen(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginScreen());
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
          //  count++;

            //if (count == 1)
             //   CounterBtn.Text = $"Clicked {count} time";
           // else
             //   CounterBtn.Text = $"Clicked {count} times";

           // SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}