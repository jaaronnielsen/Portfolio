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
    public class PublicProjectApiService
    {
        private readonly HttpClient client;


        public PublicProjectApiService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var response = await client.GetAsync("api/project");
            return await client.GetFromJsonAsync<IEnumerable<Project>>("api/project");
        }

        public async Task<Project> GetProjectBySlugAsync(string slug)
        {
            return await client.GetFromJsonAsync<Project>($"api/project/{slug}");
        }

        public async Task<Language> GetLanguageBySlugAsync(string slug)
        {
            return await client.GetFromJsonAsync<Language>($"api/project/getlanguagebyslug/{slug}");
        }

        public async Task<Technology> GetTechnologyBySlugAsync(string slug)
        {
            return await client.GetFromJsonAsync<Technology>($"api/project/gettechnologybyslug/{slug}");
        }

        public async Task<Platform> GetPlatformBySlugAsync(string slug)
        {
            return await client.GetFromJsonAsync<Platform>($"api/project/getplatformbyslug/{slug}");
        }

        public async Task<IEnumerable<Language>> GetLanguagesByProjectId(int Id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Language>>("api/project/getlanguages?id=" + Id);
        }

        public async Task<IEnumerable<Technology>> GetTechnologyByProjectId(int Id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Technology>>("api/project/gettechnologies?id=" + Id);
        }

        public async Task<IEnumerable<Platform>> GetPlatformsByProjectId(int Id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Platform>>("api/project/getplatforms?id=" + Id);
        }

        public async Task<IEnumerable<Project>> getProjectsForLanguages(int Id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Project>>("api/project/getprojectsforlanguage?id=" + Id);
        }
        public async Task<IEnumerable<Project>> getProjectsForTechnologies(int Id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Project>>("api/project/getprojectsfortechnology?id=" + Id);
        }
        public async Task<IEnumerable<Project>> getProjectsForPlatforms(int Id)
        {
            return await client.GetFromJsonAsync<IEnumerable<Project>>("api/project/getprojectsforplatform?id=" + Id);
        }
    }
}
