using System;
using System.Collections.Generic;

namespace dataLayer
{
    public partial class Project
    {
        public Project()
        {
            Task = new HashSet<Task>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public virtual ICollection<Task> Task { get; set; }
    }
}
