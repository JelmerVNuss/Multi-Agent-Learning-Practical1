// ===============================
// AUTHOR       : Maaike Burghoorn, Wouter van 't Hof
// CREATE DATE  : November 2017
// COURSE       : Multi-agent systems - Utrecht University 2017/2018
// PURPOSE      : Reinforcement learning algorithms implementations
// SPECIAL NOTES: The specified assignments need to be implemented here.
// ===============================

using System;
using System.Linq;

namespace RLMAL
{
    static class Algorithms
    {
        /// TO DO: EXERCISE 1
        /// The agent action reward estimate update.
        /// RETURN      : The method should return the new reward estimate for the selected action.
        /// PARAMETERS
        /// agent       : the agent for which the reward needs to be updated
        /// alpha       : the learning parameter
        /// reward_t    : the reward the agent received at tick t from the chosen slot machine
        public static double updateScore(Agent agent, double alpha, double reward_t)
        {
            return 0;
        }

        /// TO DO: EXERCISE 2
        /// The optimistic initial values algorithm. 
        /// RETURN      : The method should return an action index (this represents the machine id).
        /// PARAMETERS
        /// agent       : the agent for which the action/slot machine is selected
        /// random      : this object can be used to generate random numbers
        public static int optimistic(Agent agent, Random random)
        {
            return 0;
        }

        /// TO DO: EXERCISE 3
        /// The egreedy algorithm.
        /// RETURN      : The method should return an action index (this represents the machine id).
        /// PARAMETERS
        /// agent       : the agent for which the action/slot machine is selected
        /// epsilon     : the random action selection parameter
        /// random      : this object can be used to generate random numbers
        public static int egreedy(double epsilon, Agent agent , Random random)
        {
            return 0;
        }

        /// TO DO: EXERCISE 4
        /// The softmax action selection algorithm.
        /// RETURN      : The method should return an action index (this represents the machine id).
        /// PARAMETERS
        /// agent       : the agent for which the action/slot machine is selected
        /// tau         : temperature parameter in Gibbs/Boltzmann distribution
        /// random      : this object can be used to generate random numbers
        public static int softmax(double tau, Agent agent, Random random)
        {
            return 0;
        }



    }
}
