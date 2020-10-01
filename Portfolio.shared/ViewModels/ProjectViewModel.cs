using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Portfolio.shared.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel()
        {
            Languages = new List<LanguageViewModel>();
            Platforms = new List<PlatformViewModel>();
            Technologies = new List<TechnologyViewModel>();
        }

        public ProjectViewModel(Project p)
        {
            Id = p.Id;
            Title = p.Title;
            Requirements = p.Requirements;
            Design = p.Design;
            CompletedDate = p.CompletedDate;
            Languages = new List<LanguageViewModel>(p.ProjectLanguages.Select(pl => new LanguageViewModel(pl.Language)));
           // Platforms = new List<PlatformViewModel>(p.ProjectPlatforms.Select(pl => new PlatformViewModel(pl.Platform)));
            //Technologies = new List<TechnologyViewModel>(p.ProjectTechnologies.Select(pl => new TechnologyViewModel(pl.Technology)));
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
        public string Design { get; set; }
        public DateTime CompletedDate { get; set; }
        public IList<LanguageViewModel> Languages { get; set; }
        public IList<PlatformViewModel> Platforms { get; set; }
        public IList<TechnologyViewModel> Technologies { get; set; }
    }
}
