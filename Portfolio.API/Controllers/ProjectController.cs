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
        public async Task<IEnumerable<Project>> Get() => await repository.Projects.ToListAsync();

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
        [HttpGet("[action]")]
        public async Task<Project> GetProject(int id) => await repository.Projects.Where(p => p.Id == id).FirstOrDefaultAsync();
    }
}
