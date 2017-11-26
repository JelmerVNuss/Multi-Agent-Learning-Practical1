// ===============================
// AUTHOR       : Maaike Burghoorn, Wouter van 't Hof
// CREATE DATE  : November 2017
// COURSE       : Multi-agent systems - Utrecht University 2017/2018
// PURPOSE      : Agent object blueprint
// SPECIAL NOTES: This class can be changed if agent requires extra parameters or different initial parameter settings
// ===============================
using System;
using System.Drawing;
using System.Reflection;

namespace RLMAL
{
    public class Agent
    {
        //Used to draw the agent in the correct position
        int posX;
        int posY;
        //Number of slot machines
        int nrSlots;
        //Current machine index from which reward is drawn
        int machineId;
        //Stores average reward per action
        double[] rewardEstimates;
        //Agent's color on screen
        Brush color;

        public Agent(int nrMachine, Random r, int initvals)
        {
            this.nrSlots = nrMachine;
            rewardEstimates = new double[nrSlots];

            //Need to initialise estimates high for optimistic values
            for (int i = 0; i < rewardEstimates.Length; i++)
                rewardEstimates[i] = initvals;

            //Assign agent a random color
            color = PickRandomBrush(r);
        }

        //Use this to retrieve the average rewards per slot machine
        public double[] getRewards
        {
            get
            {
                return rewardEstimates;
            }
            set
            {
                rewardEstimates = value;
            }
        }

        //Use this to retrieve the nrSlots in the casino
        public int getNrSlots
        {
            get
            {
                return nrSlots;
            }
        }

        //Use this to retrieve the machine id which the agent chose at tick t
        public int getMachineId
        {
            get
            {
                return machineId;
            }
            set
            {
                machineId = value;
            }
        }

        //Used to retrieve and set the X coordinate of the agent
        public int getPosX
        {
            get
            {
                return posX;
            }
            set
            {
                this.posX = value;
            }
        }

        //Used to retrieve and set the Y coordinate of the agent
        public int getPosY
        {
            get
            {
                return posY;
            }
            set
            {
                this.posY = value;
            }
        }

        //Used to retrieve brush color of agent
        public Brush getColor
        {
            get
            {
                return color;
            }
        }

        //Used to assign random color to agent
        private Brush PickRandomBrush(Random r)
        {
            Brush brushColor = Brushes.Transparent;
            Type brushType = typeof(Brushes);
            PropertyInfo[] properties = brushType.GetProperties();
            int random = r.Next(1, properties.Length);
            brushColor = (Brush)properties[random].GetValue(null, null);
            return brushColor;
        }
    }
}
