using System;
using NUnit.Framework;
using asysx;

namespace asysx.Tests
{
    [TestFixture]
    public class Class1
    {
        #region Creation

        [Test]
        public void NewBox_ShouldHaveInactiveState()
        {
            // arrange
            var b = new BoxJob {Name = "Box"};
            // assert
            Assert.That(b.Status, Is.EqualTo(Status.Inactive));
        }

        [Test]
        public void NewCmdJob_ShouldHaveInaciveState()
        {
            // arrange
            var c = new CmdJob {Name = "Cmd"};
            // assert
            Assert.That(c.Status, Is.EqualTo(Status.Inactive));
        }

        #endregion

        #region Activation

        [Test]
        public void BoxWithOneCmdAndEmptyConditions_OnForceStartJob_ShouldHaveAllChildrenActivated()
        {
            // arrange
            var mainBox = new BoxJob {Name = "MainBox"};
            var childBox = new BoxJob {Name = "ChildBox"};
            var grandChildCmd = new CmdJob {Name = "Child"};
            mainBox.ChildJobs.Add(childBox);
            childBox.ChildJobs.Add(grandChildCmd);

            var eventProcessor = new EventProcessor();
            // act
            eventProcessor.ProcessEvent(mainBox, Event.ForceStartJob);

            // assert
            Assert.That(mainBox.Status, Is.EqualTo(Status.Running));
            Assert.That(childBox.Status, Is.EqualTo(Status.Activated));
            Assert.That(grandChildCmd.Status, Is.EqualTo(Status.Activated));
        }
        #endregion

        #region Update



        #endregion

        #region Conditions

        [Test]
        public void BoxWithNoDependencies_ShouldMatchConditions()
        {
            // arrange
            var b = new BoxJob();
            // act
            // assert
            Assert.That(b.Condition.Result(),Is.EqualTo(true));
        }

        [Test]
        public void BoxWithEmptyAndConditions_ShouldMatchConditions()
        {
            // arrange
            var b = new BoxJob{Condition = new AndConditionExpression()};
            // act
            // assert
            Assert.That(b.Condition.Result(),Is.EqualTo(true));
        }

        [Test]
        public void BoxWithEmptyOrConditions_ShouldMatchConditions()
        {
            // arrange
            var b = new BoxJob{Condition = new OrConditionExpression()};
            // act
            // assert
            Assert.That(b.Condition.Result(), Is.EqualTo(true));
        }
        #endregion
    }
}