using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Data;
using TodoAPI.Repositories.Interfaces;

namespace TodoAPI.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateTask(Models.Task task)
        {
            _context.Tasks.Add(task);
            return Save();
        }

        public bool DelteTask(Models.Task task)
        {
            _context.Tasks.Remove(task);
            return Save();
        }

        public Models.Task GetTask(int id)
        {
            var taskInDb = _context.Tasks.SingleOrDefault(t => t.TaskId == id);
            return taskInDb;
        }

        public ICollection<Models.Task> GetTasks()
        {
            return _context.Tasks.OrderBy(o => o.TaskName).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true: false;
        }

        public bool TaskExist(string name)
        {
            var taskExist = _context.Tasks.Any(n => n.TaskName.ToLower() == name.ToLower().Trim());
            return taskExist;
        }

        public bool UpdateTask(Models.Task task)
        {
            _context.Tasks.Update(task);
            return Save();
        }
    }
}
