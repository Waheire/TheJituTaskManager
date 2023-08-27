using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerDomain
{
    internal class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}
