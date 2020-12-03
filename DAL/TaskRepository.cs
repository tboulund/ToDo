using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using DAL.Interfaces;

namespace DAL
{
    public class TaskRepository : ITaskRepository
    {
        private static readonly List<Task> tasks = new List<Task>(new[] {
                new Task { Description = "Water flowers", IsCompleted = false }
            }
        );

        public Task[] GetAll()
        {
            return tasks.ToArray();
        }

        public void Save(Task task)
        {
            Task repoTask = tasks.FirstOrDefault(t => t.Id == task.Id);
            if (repoTask != null)
            {
                repoTask.Description = task.Description;
                repoTask.IsCompleted = task.IsCompleted;
            }
            else
            {
                tasks.Add(task);
            }
        }

        public void Delete(Task task)
        {
            Task repoTask = tasks.FirstOrDefault(t => t.Id == task.Id);
            if (repoTask != null)
            {
                tasks.Remove(repoTask);
            }
        }
    }
}
