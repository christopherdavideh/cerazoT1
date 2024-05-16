using cerazoT1.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net;

namespace cerazoT1.Views;

public partial class RestPage : ContentPage
{
    private const string URL = "http://192.168.100.158:8080/api/v1/users";
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

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient client = new WebClient();
            var parameters = new System.Collections.Specialized.NameValueCollection
            {
                { "useId", selectedPerson.useId.ToString() },
                { "useName", txtName.Text },
                { "useLastname", txtLastname.Text },
                { "useEmail", txtEmail.Text }
            };
            client.UploadValues(URL, "POST", parameters);
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

    private void btnDelete_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient client = new WebClient();
            client.UploadValues(URL + "/" + selectedPerson.useId.ToString(), "DELETE", null);
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

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        try {
            WebClient client = new WebClient();
            var parameters = new System.Collections.Specialized.NameValueCollection();
            parameters.Add("useName" , txtName.Text) ;
            parameters.Add("useLastname", txtLastname.Text) ;
            parameters.Add("useEmail" , txtEmail.Text) ;
            client.UploadValues(URL, "POST", parameters);
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