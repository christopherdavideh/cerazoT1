using Android.Media;
using cerazoT1.Views;

namespace cerazoT1
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {
            Routes.Add("inicio", typeof(MainPage));
            Routes.Add("aportes", typeof(UserPage));
            Routes.Add("calificaciones", typeof(QualificationPage));

            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
