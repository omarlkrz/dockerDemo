using System;
using System.Collections.Generic;

namespace WebApi10.Models
{
    public partial class UserType
    {
        public UserType()
        {
            User = new HashSet<User>();
        }

        public int IdUserType { get; set; }
        public string Description { get; set; }

        public ICollection<User> User { get; set; }
    }
}
