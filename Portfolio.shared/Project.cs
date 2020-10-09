using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portfolio.shared
{
    public class Project
    {

        public const string LanguageCategory = "language";
        public const string PlatformCategory = "platform";
        public const string TechnologyCategory = "technology";

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("requirements")]
        public string Requirements { get; set; }

        [JsonPropertyName("design")]
        public string Design { get; set; }

        [JsonPropertyName("completedDate")]
        public DateTime CompletedDate { get; set; }

        public string Slug { get; set; }

        public List<ProjectLanguage> ProjectLanguages { get; set; }
        public List<ProjectTechnology> ProjectTechnologies { get; set; }
        public List<ProjectPlatform> ProjectPlatforms { get; set; }
    }
}
