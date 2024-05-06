using AndroidX.Lifecycle;
using cerazoT1.Model;
using System.Collections.ObjectModel;
using static Java.Util.Jar.Attributes;

namespace cerazoT1.Views;

public partial class PersonPage : ContentPage
{
    public ObservableCollection<Person> persons { get; set; }
    public Person selectedPerson { get; set; }
    public PersonPage()
	{
		InitializeComponent();
        listDataPersons();

    }

    private void listDataPersons()
    {
        persons = new ObservableCollection<Person>();
        List<Person> listPersons = App._personRepository.GetPerson();

        listViewPerson.ItemsSource = listPersons;
    }

    private void clearEntries()
    {
        txtEmail.Text = "";
        txtName.Text = "";
        txtLastname.Text = "";
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App._personRepository.AddNewPerson(txtName.Text, txtLastname.Text, txtEmail.Text);
        lblStatus.Text = App._personRepository.statusMessage;
        if (!lblStatus.Text.Contains("Error")) { 
            listDataPersons();
            clearEntries();
        }

    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        Person person = new()
        {
            Id = selectedPerson.Id,
            Name = txtName.Text,
            Lastname = txtLastname.Text,
            Email = txtEmail.Text,
        };
        App._personRepository.UpdatePerson(person);
        lblStatus.Text = App._personRepository.statusMessage;
        if (!lblStatus.Text.Contains("Error")) { 
            listDataPersons(); 
            clearEntries();
            btnAdd.IsEnabled = true;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }
    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App._personRepository.DeletePerson(selectedPerson);
        lblStatus.Text = App._personRepository.statusMessage;
        if (!lblStatus.Text.Contains("Error")) { 
            listDataPersons();
            clearEntries();
            btnAdd.IsEnabled = true;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }
    }

    private void listViewPerson_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        selectedPerson = (Person)e.SelectedItem ;

        if (selectedPerson != null)
        {
            txtEmail.Text = selectedPerson.Email;
            txtName.Text = selectedPerson.Name;
            txtLastname.Text = selectedPerson.Lastname;
            btnAdd.IsEnabled = false;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;
        }
        else
        {
            clearEntries();
            btnAdd.IsEnabled = true;
            btnUpdate.IsEnabled=false;
            btnDelete.IsEnabled=false;
        }
    }
}