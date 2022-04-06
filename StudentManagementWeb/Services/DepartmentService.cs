using Newtonsoft.Json;
using StudentManagementWeb.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentManagementWeb.Services
{
    public class DepartmentService
    {
        private readonly HttpClient _httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://studentsportalysu.azurewebsites.net/api/");
            //_httpClient.BaseAddress = new Uri("https://localhost:5001/");

        }

        public async Task<List<DepartmentMeri>> GetDepartments()
        {
           
            HttpResponseMessage response =  await _httpClient.GetAsync(new Uri("Department",UriKind.Relative));

            
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<List<DepartmentMeri>>(json ,new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }

        public async Task<DepartmentMeri> GetDepartment(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(new Uri($"Department/{id}", UriKind.Relative));

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return System.Text.Json.JsonSerializer.Deserialize<DepartmentMeri>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            throw new HttpRequestException(await response.Content.ReadAsStringAsync());

        }

        public async Task UpdateDepartment(DepartmentMeri department)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(department);
            
            var stringJson = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(new Uri($"Department/{department.DepartmentId}", UriKind.Relative), stringJson);
            if (response.IsSuccessStatusCode) 
            {
                return;
            }

            throw new HttpRequestException(await response.Content.ReadAsStringAsync());
        }


    }
}


