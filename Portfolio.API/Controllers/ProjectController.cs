using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Data;
using Portfolio.shared;
using Portfolio.shared.ViewModels;

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
        public async Task<List<ProjectViewModel>> Get()
        {
            return await repository.Projects
                .Include(p => p.ProjectLanguages)
                    .ThenInclude(pc => pc.Language)
                .Select(p => new ProjectViewModel(p))
                .ToListAsync();
        }

        [HttpPost()]
        public async Task Post(Project project)
        {
           await repository.AddProjectAsync(project);
        }

        [HttpPost("[action]")]
        public void EditProject(ProjectViewModel project)
        {
            repository.EditProjects(project);
        }

        [HttpPost("[action]")]
        public void DeleteProject(Project project)
        {
            repository.DeleteProject(project);
        }
        [HttpGet("{id}")]
        public async Task<ProjectViewModel> GetProject(int id)
        {
            var project = await repository.Projects
               .Include(p => p.ProjectLanguages)
                   .ThenInclude(pc => pc.Language)
                .FirstOrDefaultAsync(p => p.Id == id);


            return new ProjectViewModel(project);
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

    }
}
