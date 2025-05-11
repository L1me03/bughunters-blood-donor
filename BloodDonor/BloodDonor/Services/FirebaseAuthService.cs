using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;

namespace BloodDonor.Services
{
    public class FirebaseAuthService
    {
        private const string ApiKey = "AIzaSyDmr1EB83kSCjCye1Ixly6tTDnvdnn0rk4";
        private static readonly HttpClient client = new HttpClient();

        public async Task<string> Register(string email, string password)
        {
            var payload = new
            {
                email = email,
                password = password,
                returnSecureToken = true
            };

            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={ApiKey}", content);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception("Registracija nije uspela: " + result);

            dynamic obj = JsonConvert.DeserializeObject(result);
            return obj.idToken;
        }

        public async Task<string> Login(string email, string password)
        {
            var payload = new
            {
                email = email,
                password = password,
                returnSecureToken = true
            };

            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={ApiKey}", content);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception("Login nije uspeo: " + result);

            dynamic obj = JsonConvert.DeserializeObject(result);
            return obj.idToken;
        }
    }
}
