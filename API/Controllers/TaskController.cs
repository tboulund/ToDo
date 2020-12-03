using BE;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskManager taskManager = new TaskManager();

        // GET: /<controller>/
        [HttpGet]
        public Task[] Get()
        {
            return taskManager.GetAll();
        }

        [HttpPost]
        public void Post(Task task)
        {
            taskManager.Save(task);
        }

        [HttpPut]
        public void Put(Task task)
        {
            taskManager.Save(task);
        }

        [HttpDelete]
        public void Delete(Task task)
        {
            taskManager.Delete(task);
        }
    }
}
