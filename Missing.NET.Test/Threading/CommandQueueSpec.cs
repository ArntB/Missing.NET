using System;
using System.Threading;
using Missing.Threading;
using NUnit.Framework;
using Rhino.Mocks;

namespace Missing.NET.Test.Threading
{
    [TestFixture]
    public class CommandQueueSpec
    {
        private CommandQueue queue;
        private Semaphore prosessingFinnishedSemaphore;

        [SetUp]
        public void Setup()
        {
            prosessingFinnishedSemaphore = new Semaphore(0, 1);
            queue = new CommandQueue();
            queue.ProcessingFinnished +=
                delegate
                    {
                        prosessingFinnishedSemaphore.Release(1);
                    };
        }

        [Test]
        public void it_should_execute_1_command()
        {
            bool executed = false;
            queue.Engueue(delegate(){ executed = true;});
            queue.Execute();
            WaitForProsessing();
            Assert.IsTrue(executed);
        }

        [Test]
        public void it_should_execute_2_commands()
        {
            int executeCount = 0;
            queue.Engueue(delegate() { executeCount++; });
            queue.Engueue(delegate() { executeCount++; });
            queue.Execute();
            WaitForProsessing();
            Assert.AreEqual(2,executeCount); 
        }

        [Test]
        public void it_should_execute_in_separate_thread()
        {
            int executeCount = 0;
            var monitor = new object();
            Semaphore commandSemaphore = new Semaphore(0,1);
            Semaphore testSemaphore = new Semaphore(0, 1);
            Action action =
                delegate
                    {
                        testSemaphore.Release(1);
                        commandSemaphore.WaitOne();
                        executeCount++;
                    };
            queue.Engueue(action);
            queue.Execute();

            testSemaphore.WaitOne();
            Assert.AreEqual(0, executeCount);
            commandSemaphore.Release(1);
            WaitForProsessing();
            Assert.AreEqual(1, executeCount);
            
        }

        [Test]
        public void It_should_execute_command()
        {
            var mocks = new MockRepository();
            ICommand cmd = mocks.DynamicMock<ICommand>();
            queue.Engueue(cmd);
            Expect.Call(cmd.Execute);
            mocks.ReplayAll();
            queue.Execute();
            mocks.VerifyAll();

        }

        [Test,Ignore]
        public void it_should_be_able_to_cancel_execution()
        {
            Assert.Fail("Not implemented");
        }

        private void WaitForProsessing()
        {
            prosessingFinnishedSemaphore.WaitOne();
        }
    }
}