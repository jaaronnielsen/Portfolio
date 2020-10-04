using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.shared
{
   public class ProjectPlatform
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
        public Project Project { get; set; }
    }
}
