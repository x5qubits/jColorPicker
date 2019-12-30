using System;
using System.Collections.Generic;
using System.Threading;

namespace JCommon
{
    public struct InvokerTask
    {
        public float TickRate;
        public float DueTime;
        public int RepeatTimes; //0 = delete; -1 = infinite; 0++ = tick
        public Action Run;
    }

    public class Invoker
    {
        int RunEveryMS = 1000 / 5;
        private static object s_Sync = new object();
        static volatile Invoker s_Instance;
        Queue<InvokerTask> Tasks = new Queue<InvokerTask>();
        AutoResetEvent evt = new AutoResetEvent(false);
        public static Invoker Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_Sync)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new Invoker();
                            s_Instance.Init();
                        }
                    }
                }
                return s_Instance;
            }
        }

        void Init()
        {
            new Thread(new ThreadStart(Update)).Start();
        }

        void Update()
        {
            LOOP:
                evt.WaitOne(RunEveryMS);
                lock (Tasks)
                {
                    List<InvokerTask> Recycle = new List<InvokerTask>();
                    while (Tasks.Count > 0)
                    {
                        InvokerTask DoWork = Tasks.Dequeue();
                        if (DoWork.DueTime < Time.time)
                        {
                            DoWork.Run.Invoke();
                            if (DoWork.RepeatTimes == -1)
                            {
                                DoWork.DueTime = Time.time + DoWork.TickRate;
                                Recycle.Add(DoWork);
                            }
                            else if (DoWork.RepeatTimes > 0)
                            {
                                DoWork.DueTime = Time.time + DoWork.TickRate;
                                DoWork.RepeatTimes -= 1;
                                if (DoWork.RepeatTimes > 0)
                                    Recycle.Add(DoWork);
                            }
                        }
                        else
                        {
                            Recycle.Add(DoWork);
                        }

                    }
                    Tasks = new Queue<InvokerTask>(Recycle);
                }
            goto LOOP;
        }

        internal void _InvokeWithDelay(Action Method, float TickRate)
        {
            lock (Tasks)
            {
                Tasks.Enqueue(new InvokerTask() { Run = Method, DueTime = Time.time + TickRate, RepeatTimes = 0, TickRate = TickRate });
            }
        }

        internal void _InvokeRepeating(Action Method, float TickRate, int RepeatTimes)
        {
            lock (Tasks)
            {
                Tasks.Enqueue(new InvokerTask() { Run = Method, DueTime = Time.time + TickRate, RepeatTimes = RepeatTimes, TickRate = TickRate });
            }
        }

        /// <summary>
        /// Parameter TickRate means invoke delay in seconds, this function will execute the action one time.
        /// </summary>
        /// <param name="Method"></param>
        /// <param name="TickRate"></param>
        public static void InvokeWithDelay(Action Method, float TickRate)
        {
            Instance._InvokeWithDelay(Method, TickRate);
        }

        /// <summary>
        /// Parameter TickRate means invoke delay in seconds and Parameter Repeat Times means how many time to keep invoking the function, -1 means infinite times.
        /// </summary>
        /// <param name="Method"></param>
        /// <param name="TickRate"></param>
        /// <param name="RepeatTimes"></param>
        public static void InvokeRepeating(Action Method, float TickRate, int RepeatTimes = -1)
        {
            Instance._InvokeRepeating(Method, TickRate, RepeatTimes);
        }

        /// <summary>
        /// Invote a function every x seconds.
        /// </summary>
        /// <param name="Method"></param>
        /// <param name="TickRate"></param>
        /// <param name="RepeatTimes"></param>
        public static void InvokeRepeating(Action Method, float TickRate)
        {
            Instance._InvokeRepeating(Method, TickRate, -1);
        }

        /// <summary>
        /// Like in games this function will set a tick rate eg. 30 equals 30 Frames per second in this case LateInvoker will try its best to execute all functions 30 times per second.
        /// </summary>
        /// <param name="Ticks"></param>
        public static void SetTicksPerSecond(int Ticks = 5)
        {
            Instance.RunEveryMS = 1000 / Ticks;
        }

    }
}
