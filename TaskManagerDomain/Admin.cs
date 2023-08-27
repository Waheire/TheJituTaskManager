using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerDomain
{
    public class Admin : User
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
