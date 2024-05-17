using cerazoT1.Model;
using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace cerazoT1.Views;

public partial class RestPage : ContentPage
{
    private const string URL = "http://10.2.7.96:8080/api/v1/users";
    private readonly HttpClient _httpClient = new HttpClient();
    public ObservableCollection<Person> persons { get; set; }
    public Person selectedPerson { get; set; }
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

    private void clearEntries()
    {
        txtEmail.Text = "";
        txtName.Text = "";
        txtLastname.Text = "";
    }

    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {
        try
        {
            Person person = new()
            {
                useId = selectedPerson.useId,
                useName = txtName.Text,
                useLastname = txtLastname.Text,
                useEmail = txtEmail.Text,
            };
            var json = JsonConvert.SerializeObject(person);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(URL, content);
            response.EnsureSuccessStatusCode();
            getUsers();
            clearEntries();
            btnAdd.IsEnabled = true;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }
        catch (Exception ex)
        {

            DisplayAlert("Alerta", ex.Message, "Cerrar");
            clearEntries();
            btnAdd.IsEnabled = true;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }
    }

    private async void btnDelete_Clicked(object sender, EventArgs e)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{URL}/{selectedPerson.useId}");
            response.EnsureSuccessStatusCode();
            DisplayAlert("Confirmacion", "Elemento eliminado exitosamente", "Cerrar");
            getUsers();
            clearEntries();
            btnAdd.IsEnabled = true;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }
        catch (Exception ex)
        {

            DisplayAlert("Alerta", ex.Message, "Cerrar");
            clearEntries();
            btnAdd.IsEnabled = true;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }

    }

    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        try {
            Person person = new()
            {
                useName = txtName.Text,
                useLastname = txtLastname.Text,
                useEmail = txtEmail.Text,
            };
            var json = JsonConvert.SerializeObject(person);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(URL, content);
            response.EnsureSuccessStatusCode();
            getUsers();
            clearEntries();
            btnAdd.IsEnabled = true;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            //Navigation.PushAsync(new Inicio()) ;
        }
        catch (Exception ex) {

            DisplayAlert("Alerta", ex.Message, "Cerrar");
            clearEntries();
            btnAdd.IsEnabled = true;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }
    }

    private void listViewPerson_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        selectedPerson = (Person)e.SelectedItem;

        if (selectedPerson != null)
        {
            txtEmail.Text = selectedPerson.useEmail;
            txtName.Text = selectedPerson.useName;
            txtLastname.Text = selectedPerson.useLastname;
            btnAdd.IsEnabled = false;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;
        }
        else
        {
            clearEntries();
            btnAdd.IsEnabled = true;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }
    }
}