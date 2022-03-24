using Newtonsoft.Json;
using StudentManagementWeb.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentManagementWeb.Services
{
    public class UserService
    {
        public async Task<List<User>> GetUsers()
        {
            HttpClient _httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();

            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(@"https://studentsportalysu.azurewebsites.net/api/Users");

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                //var NameObject = JsonConvert.DeserializeObject<User>(json);
                return System.Text.Json.JsonSerializer.Deserialize<List<User>>(json);
            }
            throw new HttpRequestException(await response.Content.ReadAsStringAsync());

        }

        public async Task<User> GetUser(int id)
        {
            HttpClient _httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();

            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(@"https://studentsportalysu.azurewebsites.net/api/Users/" + id);

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                //var NameObject = JsonConvert.DeserializeObject<User>(json);
                return System.Text.Json.JsonSerializer.Deserialize<User>(json);
            }
            throw new HttpRequestException(await response.Content.ReadAsStringAsync());

        }
    }
}
