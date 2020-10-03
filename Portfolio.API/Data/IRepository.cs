using Portfolio.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Api.Data
{
    public interface IRepository
    {
        IQueryable<Project> Projects { get; }
        IQueryable<Language> Languages { get; }
        IQueryable<Technology> Technologies { get; }
        IQueryable<Platform> Platforms { get; }
        IQueryable<ProjectLanguage> ProjectLanguages { get; }
        IQueryable<ProjectTechnology> ProjectTechnologies { get; }
        IQueryable<ProjectPlatform> ProjectPlatforms { get; }
        Task AddProjectAsync(Project project);
        void EditProjects(Project project);
        Project GetProject(int id);
        void DeleteProject(Project project);
        Task AssignCategoryAsync(AssignRequest assignRequest);
    }
}
