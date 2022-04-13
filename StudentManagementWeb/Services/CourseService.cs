/*using Newtonsoft.Json;
using StudentManagementWeb.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentManagementWeb.Services
{
    public class GradeService
    {
        private readonly HttpClient _httpClient;

        public GradeService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://studentsportalysu.azurewebsites.net/api/");
            //_httpClient.BaseAddress = new Uri("https://localhost:5001/");

        }

        public async Task<List<GradeStudent>> GetUsers()
        {

            HttpResponseMessage response = await _httpClient.GetAsync(new Uri("Records", UriKind.Relative));

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                
                return System.Text.Json.JsonSerializer.Deserialize<List<GradeStudent>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }

        public async Task<GradeStudent> GetUser(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(new Uri($"Records/{id}", UriKind.Relative));

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<GradeStudent>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            throw new HttpRequestException(await response.Content.ReadAsStringAsync());

        }

        public async Task UpdateUser(GradeStudent GradeStudent)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(GradeStudent);

            var stringJson = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(new Uri($"Records/{GradeStudent.Id}", UriKind.Relative), stringJson);
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());

        }
    }
}*/

/*using Newtonsoft.Json;
using StudentManagementWeb.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentManagementWeb.Services
{
    public class CourseService
    {
        private readonly HttpClient _httpClient;

        public CourseService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://studentsportalysu.azurewebsites.net/api/");
            //_httpClient.BaseAddress = new Uri("https://localhost:5001/");

        }

        public async Task<List<Course>> GetUsers()
        {

            HttpResponseMessage response = await _httpClient.GetAsync(new Uri("Courses", UriKind.Relative));

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                return System.Text.Json.JsonSerializer.Deserialize<List<Course>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }

        public async Task<GradeStudent> GetUser(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(new Uri($"Records/{id}", UriKind.Relative));

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<GradeStudent>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            throw new HttpRequestException(await response.Content.ReadAsStringAsync());

        }

        public async Task UpdateUser(GradeStudent GradeStudent)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(GradeStudent);

            var stringJson = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(new Uri($"Records/{GradeStudent.Id}", UriKind.Relative), stringJson);
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());

        }
    }
}*/

