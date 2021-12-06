using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAuth.Data.Models
{
    public class AppUser : IdentityUser
    {
        public string HairColour { get; set; }
    }
}
