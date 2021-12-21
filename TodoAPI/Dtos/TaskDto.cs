using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Dtos
{
    public class TaskDto
    {
        public Guid TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime CreateAt { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }
}
