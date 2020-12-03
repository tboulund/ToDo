using System;
using BE;

namespace DAL.Interfaces
{
    public interface ITaskRepository
    {
        Task[] GetAll();
        void Save(Task task);
        void Delete(Task task);
    }
}
