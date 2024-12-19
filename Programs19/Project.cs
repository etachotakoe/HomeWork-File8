using System;
using System.Collections.Generic;

namespace TaskManager
{
    public class Project
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Person Initiator { get; set; }
        public Person TeamLead { get; set; }
        public List<Task> Tasks { get; set; }
        public ProjectStatus Status { get; set; }

        public Project(string description, DateTime deadline, Person initiator, Person teamLead)
        {
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            TeamLead = teamLead;
            Tasks = new List<Task>();
            Status = ProjectStatus.Project;
        }

        public void AddTask(Task task)
        {
            if (Status == ProjectStatus.Project)
            {
                Tasks.Add(task);
            }
            else
            {
                Console.WriteLine("Cannot add tasks when the project is not in 'Project' status.");
            }
        }

        public void StartProject()
        {
            if (Tasks.Count > 0)
            {
                Status = ProjectStatus.InProgress;
                Console.WriteLine("Project is now in progress.");
            }
            else
            {
                Console.WriteLine("Cannot start project with no tasks.");
            }
        }

        public bool IsCompleted()
        {
            foreach (var task in Tasks)
            {
                if (task.Status != TaskStatus.UnderReview)
                {
                    return false;
                }
            }
            return true;
        }

        public void CloseProject()
        {
            if (IsCompleted())
            {
                Status = ProjectStatus.Closed;
                Console.WriteLine("Project is now closed.");
            }
            else
            {
                Console.WriteLine("Cannot close project until all tasks are completed.");
            }
        }
    }
}
