
using RecipeApp.Classes;

namespace RecipeApp.Screens;

public partial class EventScreen : ContentPage
{
    private DatabaseManager dbManager;
    
    public EventScreen()
	{
		InitializeComponent();
        dbManager = new DatabaseManager("User Id=postgres;Host=localhost;Database=recipe_app_db;Port=5432;password=ROOT"); // 192.168.0.101

    }
    

}