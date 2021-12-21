using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [Required]
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Avatar { get; set; }

    }
}
