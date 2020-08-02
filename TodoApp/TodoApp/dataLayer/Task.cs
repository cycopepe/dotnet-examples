using System;
using System.Collections.Generic;

namespace dataLayer
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int TaskStatus { get; set; }
        public int TaskProject { get; set; }

        public virtual Project TaskProjectNavigation { get; set; }
        public virtual TaskStatus TaskStatusNavigation { get; set; }
    }
}
