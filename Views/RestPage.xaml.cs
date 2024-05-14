using cerazoT1.Model;
using Java.Net;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace cerazoT1.Views;

public partial class RestPage : ContentPage
{
    private const string URL = "http://10.2.1.216:8080/api/v1/users";
    private readonly HttpClient _httpClient = new HttpClient();
    public ObservableCollection<Person> persons { get; set; }
    public RestPage()
	{
		InitializeComponent();
        getUsers();
	}

    public async void getUsers()
    {
        var content = await _httpClient.GetStringAsync(URL);
        List<Person> users = JsonConvert.DeserializeObject<List<Person>>(content);
        persons = new ObservableCollection<Person>(users);
        listViewPerson.ItemsSource = users;
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {

    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {

    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {

    }
}