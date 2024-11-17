﻿using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class User : IdentityUser
    {
        public List<Motorcycle> Stable { get; set; } = [];
        public bool IsDeleted { get; set; }
    }
}
