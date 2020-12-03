using System;
using BE;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;

namespace BLL
{
    public class TaskManager : ITaskManager
    {
        private readonly ITaskRepository taskRepository = new TaskRepository();

        public void Delete(Task task)
        {
            taskRepository.Delete(task);
        }

        public Task[] GetAll()
        {
            return taskRepository.GetAll();
        }

        public void Save(Task task)
        {
            taskRepository.Save(task);
        }
    }
}
