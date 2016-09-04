using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace asysx
{
    public abstract class BaseJob
    {
        // Primary
        public string Name { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }

        public Status Status { get; set; }
        public ConditionExpression Condition { get; set; }

        public virtual string JobType { get; set; }

        // Permissions
        public string Permission { get; set; }

        // Notification
        public string MaxRunAlarm { get; set; }
        public bool AlarmIfFail { get; set; }

        // Schedule
        public bool DateConditions { get; set; }
        public long AgerageRunTime { get; set; }

        [DisplayName("run_calendar")]
        public string RunCalendar { get; set; }

        [DisplayName("exclude_calendar")]
        public string ExcludeCalendar { get; set; }

        // could not be used with RunCalendar
        [DisplayName("days_of_week")]
        public string DaysOfWeek { get; set; }

        // could not be used with StartTimes, ex: 00,05,10
        [DisplayName("start_mins")]
        public string StartMinutes { get; set; }

        // could not be used with StartMinutes
        [DisplayName("start_times")]
        public string StartTimes { get; set; }

        [DisplayName("run_window")]
        public string RunWindow { get; set; }

        public BaseJob()
        {
            Status = Status.Inactive;
        }
    }

    public abstract class ConditionExpression
    {
        public abstract bool Result();
    }

    public class SimpleConditionExpression : ConditionExpression
    {
        public Condition Condition { get; private set; }
        public BoxJob Job { get; private set; }

        public SimpleConditionExpression(Condition condition, BoxJob job)
        {
            Condition = condition;
            Job = job;
        }

        public override bool Result()
        {
            if (Condition == Condition.Done)
            {
                return Job.Status.In(Status.Success, Status.Failure, Status.Terminated);
            }
            if (Condition == Condition.Success)
            {
                return Job.Status == Status.Success;
            }
            if (Condition == Condition.Failure)
            {
                return Job.Status == Status.Failure;
            }
            if (Condition == Condition.NotRunning)
            {
                return Job.Status != Status.Running;
            }
            if (Condition == Condition.Terminated)
            {
                return Job.Status == Status.Terminated;
            }
            throw new Exception();
        }
    }

    public abstract class CompositeConditionExpression : ConditionExpression
    {
        public List<ConditionExpression> SubExpressions { get; set; }
    }

    public class AndConditionExpression : CompositeConditionExpression
    {
        public override bool Result()
        {
            foreach (var subExpression in SubExpressions)
            {
                var subResult = subExpression.Result();
                if (!subResult) return false;
            }
            return true;
        }
    }

    public class OrConditionExpression : CompositeConditionExpression
    {
        public override bool Result()
        {
            foreach (var subExpression in SubExpressions)
            {
                var subResult = subExpression.Result();
                if (subResult) return true;
            }
            return true;
        }
    }
}