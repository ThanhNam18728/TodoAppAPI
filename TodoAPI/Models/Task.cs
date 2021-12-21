using System;
using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models
{
    public class Task
    {
        [Key]
        public Guid TaskId { get; set; }
        [Required]
        public string TaskName { get; set; }
        [Required]
        public DateTime CreateAt { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
