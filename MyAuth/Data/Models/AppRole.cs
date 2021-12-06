using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAuth.Data.Models
{
    public class AppRole : IdentityRole
    {
        public AppRole()
        {
        }

        public AppRole(string role) : base(role)
        {
        }
    }
}
