using Portfolio.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Headers;

namespace Portfolio.BlazorWasm
{
    public class ProjectApiService
    {
        private readonly HttpClient client;

        public ProjectApiService(HttpClient client)
        {
            this.client = client;
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
    }
}
