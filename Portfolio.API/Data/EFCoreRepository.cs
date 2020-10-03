using Portfolio.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Api.Data
{
    public class EfCoreRepository : IRepository
    {
        private readonly ApplicationDbContext context;

        public EfCoreRepository(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<Project> Projects => context.Projects;

        public async Task AddProjectAsync(Project project)
        {
            context.Projects.Add(project);
            await context.SaveChangesAsync();
        }

        public void EditProjects(Project project)
        {
            var entity = context.Projects.FirstOrDefault(t => t.Id == project.Id);

            if (entity != null)
            {
                entity.Title = project.Title;
                entity.Requirements = project.Requirements;
                entity.Design = project.Design;
                entity.CompletedDate = project.CompletedDate;
            }

            context.Projects.Update(entity);
            context.SaveChanges();
        }

        public Project GetProject(int id)
        {
            Project project = context.Projects.First(project => project.Id == id);
            return project;
        }

        public void DeleteProject(Project project)
        {
            context.Projects.Remove(project);
            context.SaveChanges();
        }
    }
}
