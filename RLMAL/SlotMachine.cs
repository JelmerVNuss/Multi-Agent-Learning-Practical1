// ===============================
// AUTHOR       : Maaike Burghoorn, Wouter van 't Hof
// CREATE DATE  : November 2017
// COURSE       : Multi-agent systems - Utrecht University 2017/2018
// PURPOSE      : Slot machine object blueprint
// SPECIAL NOTES: This class is not to be changed.
// ===============================

using System;

namespace RLMAL
{
    class SlotMachine
    {
        int mean;
        int sd;
        //Nr of agents in queue for machine at time t
        int queueCount;

        public SlotMachine(int m)
        {
            //Mean is equal to nr of the slot machine
            mean = m;
            sd = 1;
            queueCount = 0;
        }

        //Generate number from normal distribution
        public double getReward()
        {
            Random random = new Random();
            double x1 = 1.0 - random.NextDouble();
            double x2 = 1.0 - random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(x1)) * Math.Sin(2.0 * Math.PI * x2);
            double reward = mean + sd * randStdNormal;
            return reward;
        }

        //Used to retrieve and set the queueCount of the machine
        public int getQueueCount
        {
            get
            {
                return queueCount;
            }
            set
            {
                this.queueCount = value;
            }
        }
    }
}
