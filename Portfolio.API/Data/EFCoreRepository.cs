using Microsoft.EntityFrameworkCore;
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

        public IQueryable<Language> Languages => context.Languages;

        public IQueryable<ProjectLanguage> ProjectLanguages => context.ProjectLanguages;

        public IQueryable<Technology> Technologies => context.Technologies;

        public IQueryable<Platform> Platforms => context.Platforms;

        public IQueryable<ProjectTechnology> ProjectTechnologies => context.ProjectTechnology;

        public IQueryable<ProjectPlatform> ProjectPlatforms => context.ProjectPlatform;

        public async Task AddProjectAsync(Project project)
        {
            project.Slug = project.Title.ToSlug();
            context.Projects.Add(project);
            await context.SaveChangesAsync();
        }

        public void EditProjects(Project project)
        {
            var entity = context.Projects.FirstOrDefault(t => t.Id == project.Id);

            if (entity != null)
            {
                entity.Slug = project.Title.ToSlug();
                entity.Title = project.Title;
                entity.Requirements = project.Requirements;
                entity.Design = project.Design;
                entity.CompletedDate = project.CompletedDate;
            }

            context.Projects.Update(entity);
            context.SaveChanges();
        }

        public Project GetProjectById(int id)
        {
            Project project = context.Projects.First(project => project.Id == id);
            return project;
        }

        public Project GetProjectBySlug(string slug)
        {
            Project project = context.Projects.First(project => project.Slug == slug);
            return project;
        }

        public void DeleteProject(Project project)
        {
            context.Projects.Remove(project);
            context.SaveChanges();
        }

        public async Task AssignCategoryAsync(AssignRequest assignRequest)
        {
            switch (assignRequest.CategoryType)
            {
                case Project.LanguageCategory:
                    var language = await context.Languages.FirstOrDefaultAsync(l => l.Name == assignRequest.Name);
                    if (language == null)
                    {
                        language = new Language {
                            Name = assignRequest.Name,
                            Slug = assignRequest.Name.ToSlug()
                        };
                        context.Languages.Add(language);
                        await context.SaveChangesAsync();
                    }
                    var lc = new ProjectLanguage
                    {
                        ProjectId = assignRequest.ProjectId,
                        LanguageId = language.Id
                    };
                    context.ProjectLanguages.Add(lc);
                    await context.SaveChangesAsync();
                    break;
                case Project.PlatformCategory:
                    var platform = await context.Platforms.FirstOrDefaultAsync(p => p.Name == assignRequest.Name);
                    if (platform == null)
                    {
                        platform = new Platform
                        {
                            Name = assignRequest.Name,
                            Slug = assignRequest.Name.ToSlug()
                        };
                        context.Platforms.Add(platform);
                        await context.SaveChangesAsync();
                    }
                    var pc = new ProjectPlatform
                    {
                        ProjectId = assignRequest.ProjectId,
                        PlatformId = platform.Id
                    };
                    context.ProjectPlatform.Add(pc);
                    await context.SaveChangesAsync();
                    break;
                case Project.TechnologyCategory:
                    var technology = await context.Technologies.FirstOrDefaultAsync(t => t.Name == assignRequest.Name);
                    if (technology == null)
                    {
                        technology = new Technology
                        {
                            Name = assignRequest.Name,
                            Slug = assignRequest.Name.ToSlug()
                        };
                        context.Technologies.Add(technology);
                        await context.SaveChangesAsync();
                    }
                    var tc = new ProjectTechnology
                    {
                        ProjectId = assignRequest.ProjectId,
                        TechnologyId = technology.Id
                    };
                    context.ProjectTechnology.Add(tc);
                    await context.SaveChangesAsync();
                    break;
                default:
                    break;
            }
        }
    }
}
