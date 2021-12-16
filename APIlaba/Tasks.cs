using System;

namespace MyTasks
{
    public class MyTask
    {
        public uint id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public DateTime dateEdited { get; set; }
        public bool isUrgent { get; set; }
        public bool isCompleted { get; set; }
        
        public MyTask()
        {
            
        }

        ~MyTask()
        {

        }

        public MyTask(uint id, string name, string description, string type, DateTime dateEdited, bool isUrgent, bool isCompleted)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.type = type;
            this.dateEdited = dateEdited;
            this.isUrgent = isUrgent;
            this.isCompleted = isCompleted;
        }
    }
}
