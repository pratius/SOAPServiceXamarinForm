using Xamarin.Forms;

namespace WebServiceParsing
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Common.WebServices.UserLoginService obj = new Common.WebServices.UserLoginService();
            var result = obj.PostResponseFromHttpRequest("test", "testPassword");
            MainPage = new WebServiceParsingPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
