using System.ComponentModel;

namespace asysx
{
    public class Condition
    {
        public static Condition Done = new Condition("d");
        public static Condition Failure = new Condition("f");
        public static Condition NotRunning=new Condition("n");
        public static Condition Success = new Condition("s");
        public static Condition Terminated = new Condition("t");

        private readonly string _shortName;
        private Condition(string shortName)
        {
            _shortName = shortName;
        }

        protected bool Equals(Condition other)
        {
            return string.Equals(_shortName, other._shortName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Condition) obj);
        }

        public override int GetHashCode()
        {
            return _shortName.GetHashCode();
        }
    }
}