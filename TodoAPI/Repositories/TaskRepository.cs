using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TodoAPI.Data;
using TodoAPI.Models;
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
        public bool CreateTask(Task task)
        {
            _context.Tasks.Add(task);
            return Save();
        }

        public bool DelteTask(Task task)
        {
            _context.Tasks.Remove(task);
            return Save();
        }

        public Task GetTask(int id)
        {
            var taskInDb = _context.Tasks
                .Include(c => c.Category)
                .SingleOrDefault(t => t.TaskId == id);
            return taskInDb;
        }

        public ICollection<Task> GetTasks()
        {
            return _context.Tasks.Include(c =>c.Category).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public bool TaskExist(string name)
        {
            var taskExist = _context.Tasks.Any(n => n.TaskName.ToLower() == name.ToLower().Trim());
            return taskExist;
        }

        public bool UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
            return Save();
        }
    }
}
