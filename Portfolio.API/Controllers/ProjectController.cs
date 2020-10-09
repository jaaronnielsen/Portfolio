using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Data;
using Portfolio.shared;


namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository repository;

        public ProjectController(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet()]
        public async Task<List<Project>> Get()
        {
            return await repository.Projects.ToListAsync();
        }

        [HttpPost()]
        public async Task Post(Project project)
        {
           await repository.AddProjectAsync(project);
        }

        [HttpPost("[action]")]
        public void EditProject(Project project)
        {
            repository.EditProjects(project);
        }

        [HttpPost("[action]")]
        public void DeleteProject(Project project)
        {
            repository.DeleteProject(project);
        }

        [HttpGet("{slug}")]
        public async Task<Project> GetProjectBySlug(string slug)
        {
            return await repository.Projects.Where(p => p.Slug == slug).FirstOrDefaultAsync();
        }

        [HttpGet("[action]/{slug}")]
        public async Task<Language> GetLanguageBySlug(string slug)
        {
            return await repository.Languages.Where(l => l.Slug == slug).FirstOrDefaultAsync();
        }

        [HttpGet("[action]/{slug}")]
        public async Task<Technology> GetTechnologyBySlug(string slug)
        {
            return await repository.Technologies.Where(l => l.Slug == slug).FirstOrDefaultAsync();
        }

        [HttpGet("[action]/{slug}")]
        public async Task<Platform> GetPlatformBySlug(string slug)
        {
            return await repository.Platforms.Where(l => l.Slug == slug).FirstOrDefaultAsync();
        }

        [HttpGet("[action]")]
        public async Task DefaultData()
        {
            await repository.AddProjectAsync(new Project
            {
                Title = "Project 1",
                Requirements = "Demonstrate APIs with a database"
            });


            await repository.AddProjectAsync(new Project
            {
                Title = "Project 2",
                Requirements = "No, seriously. Do that."
            });
        }


        [HttpPost("[action]")]
        public async Task Assign(AssignRequest assignRequest)
        {
            await repository.AssignCategoryAsync(assignRequest);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Language>> GetLanguages(int id)
        {
           return await repository.ProjectLanguages.Where(pl => pl.ProjectId == id).Select(l => l.Language).ToListAsync();
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Technology>> GetTechnologies(int id)
        {
            return await repository.ProjectTechnologies.Where(pl => pl.ProjectId == id).Select(t => t.Technology).ToListAsync();
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Platform>> GetPlatforms(int id)
        {
            return await repository.ProjectPlatforms.Where(pl => pl.ProjectId == id).Select(p => p.Platform).ToListAsync();
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Project>> GetProjectsForLanguage(int id)
        {
            return await repository.ProjectLanguages.Where(pl => pl.LanguageId == id).Select(p => p.Project).ToListAsync();
        }


        [HttpGet("[action]")]
        public async Task<IEnumerable<Project>> GetProjectsForTechnology(int id)
        {
            return await repository.ProjectTechnologies.Where(pl => pl.TechnologyId == id).Select(p => p.Project).ToListAsync();
        }


        [HttpGet("[action]")]
        public async Task<IEnumerable<Project>> GetProjectsForPlatform(int id)
        {
            return await repository.ProjectPlatforms.Where(pl => pl.PlatformId == id).Select(p => p.Project).ToListAsync();
        }

    }
}
