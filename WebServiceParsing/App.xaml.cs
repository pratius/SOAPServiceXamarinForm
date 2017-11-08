using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;
using Common.WebServices;
using Xamarin.Forms;

namespace WebServiceParsing
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            LoadConfiguration();
			var data = "Cryptographic example";
			var pass = "MySecretKey";
			var salt = Crypto.CreateSalt(16);
            var bytes = Crypto.EncryptAes(data, pass, salt);
			var str = Crypto.DecryptAes(bytes, pass, salt);
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

        private void LoadConfiguration()
        {

			var assembly = typeof(App).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("WebServiceParsing.Country.xml");
			string text = "";
			using (var reader = new System.IO.StreamReader(stream))
			{
				text = reader.ReadToEnd();
			}
            var responseObj =Crypto.DeserializeXMLFileToObject<Configurations>(text);
            if (responseObj !=null)
            {
                foreach (var item in responseObj.Connfiguration)
                {
                    if (item.Id=="Production")
                    {
                        var strname = item.ValidateLogin.Text;
                        var strss= item.UserName.Text;
                    }
                }

            }
        }

    }
}
