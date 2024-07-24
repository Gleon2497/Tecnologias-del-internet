using System.Net.Http.Headers;
using System.Text;

namespace WebAppV2.Repository
{
    public class UserAPI
    {
        public async Task<String> GetUsersRequestAsync()
        {
            String result = string.Empty;

            try
            {
                string url = "https://localhost:7066/User/";
                string api = "GetUsersDB";
                using (HttpClient client = new HttpClient())
                {

                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync(api);
                    result = response.Content.ReadAsStringAsync().Result;

                }
            }
            catch (Exception e)
            {
                String ex = e.Message.ToString();
                result = String.Empty;
            }
            if (result.Contains("HTTP ERROR 500"))
            {
                return @"{""ErrorMsg"":""There was an error getting the users""";
            }
            return result;
        }

        public async Task<String> CreateUserRequestAsync()
        {
            String result = string.Empty;

            try
            {
                string url = "https://localhost:7066/User/";
                string api = "CreateUser";
                using (HttpClient client = new HttpClient())
                {

                    String jsonString = @"{
                          ""userName"": ""usertest3"",
                          ""password"": ""ABC456"",
                          ""fsName"": ""User"",
                          ""lastName"": ""Test"",
                          ""email"": ""gabriel.piedrahita@unimilitar.edu.co"",
                          ""phone"": ""3508994766"",
                          ""doBirthday"": ""1987-10-14T00:00:00""
                        }";
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.PostAsync(api, content);
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception e)
            {
                String ex = e.Message.ToString();
                result = String.Empty;
            }
            if (result.Contains("HTTP ERROR 500"))
            {
                return @"{""ErrorMsg"":""There was an error getting the users""";
            }
            return result;
        }
    }
}
