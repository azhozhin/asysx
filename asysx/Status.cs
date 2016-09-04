using System.Linq;

namespace asysx
{
    public class Status
    {
        public static Status Activated = new Status("Activated","ACTIVATED");
        public static Status Failure = new Status("Failure","FAILURE");
        public static Status Inactive = new Status("Inactive","INACTIVE");
        public static Status OnHold = new Status("OnHold","ON_HOLD");
        public static Status OnIce = new Status("OnIce","ON_ICE");
        public static Status QueueWait = new Status("QueueWait","QUE_WAIT");
        public static Status RefreshDependencies = new Status("RefreshDependencies","REFRESH_DEPENDENCIES");
        public static Status RefreshFilewatcher = new Status("RefreshFilewatcher","REFRESH_FILEWATCHER");
        public static Status Restart = new Status("Restart","RESTART");
        public static Status Running = new Status("Running","RUNNING");
        public static Status Starting = new Status("Starting","STARTING");
        public static Status Success = new Status("Success","SUCCESS");
        public static Status Terminated = new Status("Terminated","TERMINATED");

        private readonly string _name;
        private readonly string _name2;

        private Status (string name, string name2)
        {
            _name = name;
            _name2 = name2;
        }

        protected bool Equals(Status other)
        {
            return string.Equals(_name, other._name) && string.Equals(_name2, other._name2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Status) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_name.GetHashCode() * 397) ^ _name2.GetHashCode();
            }
        }

        public override string ToString()
        {
            return $"{_name2}";
        }
    }

    public static class StatusExtensions
    {
        public static bool In(this Status status, params Status[] statuses)
        {
            return statuses.Contains(status);
        }
    }
}