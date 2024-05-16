namespace hchavezS7Deber
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.vProducto());
        }
    }
}
