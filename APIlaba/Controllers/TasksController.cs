using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTasks;

namespace APIlaba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly ILogger<TaskController> _logger;

        public TaskController(ILogger<TaskController> logger)
        {
            _logger = logger;
        }

        static List<MyTask> tasks = new List<MyTask>();

        //1. GET
        //получить весь список задач
        [HttpGet]
        public List<MyTask> Get()
        {
            return tasks;
        }

        //2. GET
        //получить задачу с указанным id
        [HttpGet("{id}", Name = "Get")]
        public MyTask Get(int id)
        {
            MyTask _task = tasks.Find(f => f.id == id);
            return _task;
        }

        //3. POST
        //добавить задачу и получить обновленный список задач
        [HttpPost]
        public List<MyTask> Post([FromBody] MyTask _task)
        {
           tasks.Add(_task);
            return tasks;
        }

        //4. PUT
        //редактировать задачу с указанным id и получить обновленный список задач
        [HttpPut("{id}")]
        public List<MyTask> Put(int id, [FromBody] MyTask _task)
        {
            MyTask TaskToUpdate = tasks.Find(f => f.id == id);
            int index = tasks.IndexOf(TaskToUpdate);

            tasks[index].name = _task.name;
            tasks[index].description = _task.description;
            tasks[index].type = _task.type;
            tasks[index].dateEdited = _task.dateEdited;
            tasks[index].isUrgent = _task.isUrgent;
            tasks[index].isCompleted = _task.isCompleted;
            return tasks;
        }

        //5. DELETE
        //удалить задачу с указанным id и получить обновленный список задач
        [HttpDelete("{id}")]
        public List<MyTask> Delete(int id)
        {
            MyTask _task = tasks.Find(f => f.id == id);
            tasks.Remove(_task);
            return tasks;
        }

        //6. DELETE
        //удалить все выполненные задачи и получить обновленный список задач
        [HttpDelete]
        public List<MyTask> Delete(bool completion = true)
        {
            tasks.RemoveAll(f => f.isCompleted == completion);
            return tasks;
        }

        //7. GET
        //получить все задачи данного типа
        [HttpGet("{type}", Name = "GetType")]
        public List<MyTask> Get(string type)
        {
            List<MyTask> tasksFound = tasks.FindAll(f => f.type == type);
            return tasksFound;
        }

        //8. DELETE
        //очистить весь список задач
        [HttpDelete]
        public List<MyTask> Delete()
        {
            tasks.Clear();
            return tasks;
        }

    }
}

