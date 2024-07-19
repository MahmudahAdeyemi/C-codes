using Microsoft.AspNetCore.Identity;

namespace identityUserTut.Models;

public class User : IdentityUser
    {
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
    }
