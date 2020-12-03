using System;
using BE;

namespace BLL.Interfaces
{
    public interface ITaskManager
    {
        Task[] GetAll();
        void Save(Task task);
        void Delete(Task task);
    }
}
