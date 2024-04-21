
namespace cerazoT1.Views;

public partial class LoginPage : ContentPage
{
    private string[] users = { "Carlos", "Ana", "Jose" };
    private string[] passwords = { "carlos123", "ana123", "jose123" };
    public LoginPage()
	{
		InitializeComponent();
	}

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        string username = txtUser.Text;
        string password = txtPass.Text;

        int index = Array.IndexOf(users, username);
        if (index != -1 && passwords[index] == password)
        {
            Preferences.Set("Username", username);
            Navigation.PushAsync(new AppShell());
        }
        else
        {
            DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
        }
    }
}