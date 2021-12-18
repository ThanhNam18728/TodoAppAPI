using System;
using System.Collections.Generic;
using TodoAPI.Models;

namespace TodoAPI.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        ICollection<Task> GetTasks();
        Task GetTask(int id);
        bool CreateTask(Task task);
        bool UpdateTask(Task task);
        bool DelteTask(Task task);
        bool TaskExist(string name);
        bool Save();
    }
}
