using Portfolio.shared;
using Portfolio.shared.ViewModels;
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

        public async void EditProject(ProjectViewModel project)
        {
           await client.PostAsJsonAsync("api/project/editproject", project);
        }

        public async Task AssignAsync(string categoryType, int projectId, string newName)
        {
            var assignBody = new AssignRequest
            {
                CategoryType = categoryType,
                Name = newName,
                ProjectId = projectId
            };
            await client.PostAsJsonAsync($"api/project/assign/", assignBody);
        }

        public async Task<ProjectViewModel> GetProjectByIDAsync(int id)
        {
            return await client.GetFromJsonAsync<ProjectViewModel>($"api/project/{id}");
        }
    }
}
