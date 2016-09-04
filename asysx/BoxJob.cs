using System.Collections.Generic;

namespace asysx
{
    public class BoxJob : BaseJob
    {
        public override string JobType => "box";

        public List<BaseJob> ChildJobs { get; set; }

        public BoxJob()
        {
            ChildJobs = new List<BaseJob>();
        }
    }
}