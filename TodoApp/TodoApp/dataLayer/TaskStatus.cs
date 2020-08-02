using System;
using System.Collections.Generic;

namespace dataLayer
{
    public partial class TaskStatus
    {
        public TaskStatus()
        {
            Task = new HashSet<Task>();
        }

        public int TaskStatusId { get; set; }
        public string TaskStatusName { get; set; }

        public virtual ICollection<Task> Task { get; set; }
    }
}
