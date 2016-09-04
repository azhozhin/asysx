using System.Collections.Generic;

namespace asysx
{
    public class EventProcessor
    {


        public void Execute()
        {
            throw new System.NotImplementedException();

        }

        public void ProcessEvent(BoxJob mainBox, Event newEvent)
        {
            if (newEvent == Event.ForceStartJob)
            {
                mainBox.Status = Status.Running;
                SetStatusRecursive(mainBox.ChildJobs, Status.Activated);
            }
        }

        private void SetStatusRecursive(List<BaseJob> childJobs, Status status)
        {
            foreach (var job in childJobs)
            {
                job.Status = status;
                if (job is BoxJob)
                {
                    SetStatusRecursive(((BoxJob)job).ChildJobs, status);
                }
            }
        }
    }
}