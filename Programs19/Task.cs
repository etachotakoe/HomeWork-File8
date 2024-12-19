
using System;

namespace TaskManager
{
    public class Task
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Person Initiator { get; set; }
        public Person Assignee { get; set; }
        public TaskStatus Status { get; set; }
        public Report TaskReport { get; set; }

        public Task(string description, DateTime deadline, Person initiator)
        {
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            Status = TaskStatus.Assigned;
        }

        public void StartTask(Person executor)
        {
            Assignee = executor;
            Status = TaskStatus.InProgress;
        }

        public void DelegateTask(Person newAssignee)
        {
            Assignee = newAssignee;
            Status = TaskStatus.Assigned;
        }

        public void RejectTask()
        {
            Assignee = null;
            Status = TaskStatus.Assigned;
        }

        public void CreateReport(string text, DateTime completionDate)
        {
            TaskReport = new Report(text, completionDate, Assignee);
            Status = TaskStatus.UnderReview;
        }
    }
}
