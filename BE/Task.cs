using System;

namespace BE
{
    public class Task
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}