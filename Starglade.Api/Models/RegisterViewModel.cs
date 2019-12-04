﻿using System.ComponentModel.DataAnnotations;

namespace Starglade.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
