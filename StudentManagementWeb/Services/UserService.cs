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
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://studentsportalysu.azurewebsites.net/api/");
            //_httpClient.BaseAddress = new Uri("https://localhost:5001/");

        }

        public async Task<List<User>> GetUsers()
        {
            gRPCService service = new gRPCService();
            var answer = await service.GetUsers();
            //{users{firstName,lastName}}
            HttpResponseMessage response = await _httpClient.GetAsync(new Uri("Users", UriKind.Relative));


            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<List<User>>(json ,new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }

        public async Task<User> GetUser(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(new Uri($"Users/{id}", UriKind.Relative));

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<User>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            throw new HttpRequestException(await response.Content.ReadAsStringAsync());

        }

        public async Task UpdateUser(User user)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(user);
            
            var stringJson = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(new Uri($"Users/{user.Id}", UriKind.Relative), stringJson);
            if (response.IsSuccessStatusCode) 
            {
                return;
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }

        public async Task DeleteUser(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(new Uri($"Users/{id}", UriKind.Relative));
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }

    }
}

