using Portfolio.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Portfolio.BlazorWasm
{
    public class ProjectApiService
    {
        private readonly HttpClient client;

        public ProjectApiService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var response = await client.GetAsync("api/project");
            return await client.GetFromJsonAsync<IEnumerable<Project>>("api/project");
        }

        public async Task AddProjectAsync(Project project)
        {
            await client.PostAsJsonAsync("api/project", project);
        }

        public async void DeleteProject(Project project)
        {
           await client.PostAsJsonAsync("api/project/deleteproject", project);
        }

        public async void EditProject(Project project)
        {
           await client.PostAsJsonAsync("api/project/editproject", project);
        }

        public async Task<Project> GetProject(int id)
        {
          
            return await client.GetFromJsonAsync<Project>("api/project/getproject?id=" + id);
        }
    }
}
