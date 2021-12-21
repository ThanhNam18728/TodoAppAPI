using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoAPI.Dtos;
using TodoAPI.Models;
using TodoAPI.Repositories.Interfaces;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepo;
        private readonly IMapper _mapper;

        public TasksController(ITaskRepository taskRepo, IMapper mapper)
        {
            _taskRepo = taskRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _taskRepo.GetTasks();
            var tasksDto = new List<TaskDto>();
            foreach (var item in tasks)
            {
                tasksDto.Add(_mapper.Map<TaskDto>(item));
            }
            return Ok(tasksDto);
        }

        [HttpGet("{taskId}")]
        public IActionResult GetTask(int taskId)
        {
            var task = _taskRepo.GetTask(taskId);
            if (task == null) return NotFound();
            var taskDto = _mapper.Map<TaskDto>(task);
            return Ok(taskDto);

        }

        [HttpPost]
        public IActionResult CreateTask(TaskDto taskDto)
        {
            if (taskDto == null) return BadRequest(ModelState);
            if (_taskRepo.TaskExist(taskDto.TaskName))
            {
                ModelState.AddModelError("", "This task already existed...!");
                return BadRequest(ModelState);
            }
            var task = _mapper.Map<Task>(taskDto);

            if (!_taskRepo.CreateTask(task))
            {
                ModelState.AddModelError("", "Error when create a task...!");
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPatch("{taskId}", Name = "UpdateTask")]
        public IActionResult UpdateTask(int taskId, TaskDto taskDto)
        {
            if (taskId != taskDto.TaskId || taskDto == null)
                return BadRequest();

            var UpTask = _mapper.Map<Task>(taskDto);

            if (!_taskRepo.UpdateTask(UpTask))
                return BadRequest("Update failed...!");
            return NoContent();
        }


        [HttpDelete("{taskId}", Name = "DalteTask")]
        public IActionResult DeleteTask(int taskId)
        {
            var taskInDb = _taskRepo.GetTask(taskId);
            if (taskInDb == null)
                return NotFound();
            return Ok(_taskRepo.DelteTask(taskInDb));
        }

    }
}
