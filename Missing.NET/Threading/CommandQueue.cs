using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Missing.Threading
{
    public class CommandQueue
    {
        private readonly Queue<Action> queue = new Queue<Action>();

        public event Action ProcessingFinnished;

        private void InvokeProcessingFinnished()
        {
            Action finnished = ProcessingFinnished;
            if (finnished != null) finnished();
        }

        public void Engueue(Action action)
        {
            queue.Enqueue(action);
        }

        public void Execute()
        {
            var thread = new Thread(Run);
            thread.Start();
        }

        private void Run()
        {
            while (queue.Any())
            {
                Action action = queue.Peek();
                action();
                queue.Dequeue();
            }
            lock (this) Monitor.PulseAll(this);
            InvokeProcessingFinnished();
        }

        public void WaitForProsessing()
        {
            lock (this) Monitor.Wait(this);
        }

        public void Engueue(ICommand cmd)
        {
            Engueue(cmd.Execute);
        }
    }
}