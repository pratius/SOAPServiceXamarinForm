using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Common.WebServices
{
    public class UserLoginService:WebServicesBase
    {
        
        public UserLoginService()
        {
            
        }

        public async Task<object> PostResponseFromHttpRequest(string userName, string password)
		{
			try
			{
                var soapString = this.ConstructSoapRequest(userName, password);
				using (var client = new HttpClient())
				{
					var credentials = Encoding.UTF8.GetBytes("soauser:soauser123");
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
					var content = new StringContent(soapString, Encoding.UTF8, "text/xml");
					using (var response = await client.PostAsync("http://soastage.emaar.ae/soa-infra/services/eServMobile/eServicesMobileProject/eservicesmobileprocess_client_ep", content))
					{
						var soapResponse = await response.Content.ReadAsStringAsync();
						var Value = XDocument.Parse(soapResponse);
						XNamespace ns = @"http://schemas.xmlsoap.org/soap/envelope/";
						var unwrappedResponse = Value.Descendants((XNamespace)"http://schemas.xmlsoap.org/soap/envelope/" + "Body").First().FirstNode;
                        XmlSerializer oXmlSerializer = new XmlSerializer(typeof(object));
                        var responseObj = (object)oXmlSerializer.Deserialize(unwrappedResponse.CreateReader());
						return responseObj;
					}

				}
			}

			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
                return new object();

			}

		}

		
        private string ConstructSoapRequest(string userName,string Password)
		{
            var assembly = typeof(UserLoginService).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("Common.WebServiceTemplates.ADAuthentication_Template.xml");
			string text = "";
			using (var reader = new System.IO.StreamReader(stream))
			{
				text = reader.ReadToEnd();
			}
            return string.Format(@text, userName, Password);
		}

	}
}
