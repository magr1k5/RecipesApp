namespace RecipeApp.Screens;
using Npgsql;
using RecipeApp.Classes;
using RecipesApp;

public partial class LoginScreen : ContentPage
{
    private Entry usernameEntry;
    private Entry passwordEntry;
    private DatabaseManager dbManager;

    public LoginScreen()
	{


		InitializeComponent();

        usernameEntry = new Entry { Placeholder = "������� ���� ��� ������������" };
        passwordEntry = new Entry { Placeholder = "������� ��� ������", IsPassword = true };
        var localhost = "localhost";
        var android_local = "10.0.2.2";
        Button loginButton = new Button { Text = "�����" };
        loginButton.Clicked += OnLoginButtonClicked;

        this.Content = new StackLayout
        {
            Children = { usernameEntry, passwordEntry, loginButton }
        };

        dbManager = new DatabaseManager($"User Id=postgres;Host={localhost};Database=recipe_app_db;Port=5432;password=ROOT"); // 192.168.0.101

    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string password = Hashing.toSHA256(passwordEntry.Text);

        dbManager.OpenConnection();
        Users currentUser = dbManager.GetUserByUsernameAndPassword(username, password);
        dbManager.CloseConnection();

        if (currentUser != null)
        {
            string welcomeMessage = $"����� ���������� {currentUser.Name} {currentUser.Surname}";
            await DisplayAlert("����� ����������", welcomeMessage, "��");
            await Navigation.PushAsync(new MainScreen());
            //SetTopBarVisibility(true);
            (Application.Current.MainPage as AppShell).ViewModel.UserName = $"{currentUser.Name} {currentUser.Surname} {currentUser.Username} {currentUser.RoleName}";
        }
        else
        {
            await DisplayAlert("������", "������. ������ ��� ����� ��������", "��");
        }

    }

   

}