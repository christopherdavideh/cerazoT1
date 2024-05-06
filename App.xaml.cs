using cerazoT1.Repository;
using cerazoT1.Views;

namespace cerazoT1
{
    public partial class App : Application
    {
        public static PersonRepository _personRepository { get; set; }

        public App(PersonRepository personRepository)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
            _personRepository = personRepository;
        }
    }
}
