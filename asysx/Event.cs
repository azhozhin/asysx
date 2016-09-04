namespace asysx
{
    public class Event
    {
        public static Event Alarm = new Event("Alarm", "ALARM");
        public static Event ChangePriority = new Event("ChangePriority", "CHANGE_PRIORITY");
        public static Event ChangeStatus = new Event("ChangeStatus", "CHANGE_STATUS");
        public static Event CheckHeartbeat = new Event("CheckHearbeat", "CHECK_HEARTBEAT");
        public static Event CheckBoxTerm = new Event("CheckBoxTerm", "CHK_BOX_TERM");
        public static Event CheckMaxAlarm = new Event("CheckMaxAlarm", "CHK_MAX_ALARM");
        public static Event CheckNStart = new Event("CheckNStart", "CHK_N_START");
        public static Event CheckRunWindow = new Event("CheckRunWindow", "CHK_RUN_WINDOW");
        public static Event Comment = new Event("Comment", "COMMENT");
        public static Event DeleteJob = new Event("DeleteJob", "DELETEJOB");
        public static Event ExternalDependency = new Event("ExternalDependency", "EXTERNAL_DEPENDENCY");
        public static Event ForceStartJob = new Event("ForceStartJob", "FORCE_STARTJOB");
        public static Event Heartbeat = new Event("Heartbeat", "HEARTBEAT");
        public static Event JobOffHold = new Event("JobOffHold", "JOB_OFF_HOLD");
        public static Event JobOffIce = new Event("JobOffIce", "JOB_OFF_ICE");
        public static Event JobOnHold = new Event("JobOnHold", "JOB_ON_HOLD");
        public static Event JobOnIce = new Event("JobOnIce", "JOB_ON_ICE");
        public static Event KillJob = new Event("KillJob", "KILLJOB");
        public static Event QueueRecovery = new Event("QueueRecovery", "QUE_RECOVERY");
        public static Event RefreshBroker = new Event("RefreshBroker", "REFRESH_BROKER");
        public static Event ResendExternalStatus = new Event("ResendExternalStatus", "RESEND_EXTERNAL_STATUS");
        public static Event SendSignal = new Event("SendSignal", "SEND_SIGNAL");
        public static Event SetGlobal = new Event("SetGlobal", "SET_GLOBAL");
        public static Event StartJob = new Event("StartJob", "STARTJOB");

        private readonly string _name;
        private readonly string _eventName;


        private Event(string name, string eventName)
        {
            _name = name;
            _eventName = eventName;
        }
    }
}