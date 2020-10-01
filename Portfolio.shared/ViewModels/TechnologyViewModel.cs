using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.shared.ViewModels
{
    public class TechnologyViewModel
    {
        public TechnologyViewModel() { }
        public TechnologyViewModel(Technology t)
        {
            Id = t.Id;
            Name = t.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
