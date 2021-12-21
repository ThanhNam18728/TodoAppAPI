using System;
using TodoAPI.Models;

namespace TodoAPI.Dtos
{
    public class TaskDto
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime CreateAt { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
