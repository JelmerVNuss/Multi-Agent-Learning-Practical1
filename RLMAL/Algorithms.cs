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
            int actionIndex = agent.getMachineId;
            double oldValue = agent.getRewards[actionIndex];
            double score = oldValue + alpha * (reward_t - oldValue);
            return score;
        }

        /// TO DO: EXERCISE 2
        /// The optimistic initial values algorithm. 
        /// RETURN      : The method should return an action index (this represents the machine id).
        /// PARAMETERS
        /// agent       : the agent for which the action/slot machine is selected
        /// random      : this object can be used to generate random numbers
        public static int optimistic(Agent agent, Random random)
        {
            int action = findOptimalAction(agent, random);

            return action;
        }

        private static int findOptimalAction(Agent agent, Random random)
        {
            List<int> actionIndices = new List<int>();
            double highestEstimate = agent.getRewards.Max();

            //find all optimal actions
            for (int index = 0; index < agent.getNrSlots; index++)
            {
                if (agent.getRewards[index] == highestEstimate)
                {
                    actionIndices.Add(index);
                }
            }

            //choose a random action from the optimal actions. 
            int actionIndex = random.Next(actionIndices.Count());
            int action = actionIndices[actionIndex];
            
            return action;
        }
        
        /// TO DO: EXERCISE 3
        /// The egreedy algorithm.
        /// RETURN      : The method should return an action index (this represents the machine id).
        /// PARAMETERS
        /// agent       : the agent for which the action/slot machine is selected
        /// epsilon     : the random action selection parameter
        /// random      : this object can be used to generate random numbers
        public static int egreedy(double epsilon, Agent agent, Random random)
        {
            int actionIndex = 0;
            // Choose a random machine with probability epsilon.
            if (random.NextDouble() < epsilon)
            {
                actionIndex = random.Next(agent.getNrSlots);
            }
            // Otherwise exploit the known highest estimate machine.
            else
            {
                actionIndex = findOptimalAction(agent, random);
            }
            return actionIndex;
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
            int actionIndex = 0;

            double[] actionProbabilities = new double[agent.getNrSlots];
            for (int i = 0; i < agent.getNrSlots; i++)
            {
                double singleActionReward = Math.Pow(Math.E, agent.getRewards[i] / tau);
                double sumReward = 0.0;
                for (int j = 0; j < agent.getNrSlots; j++)
                {
                    sumReward += Math.Pow(Math.E, agent.getRewards[j] / tau);
                }
                double actionProbability = singleActionReward / sumReward;
                actionProbabilities[i] = actionProbability;
            }

            actionIndex = getRandomIndexFromSelectionWheel(actionProbabilities, random);
           
            return actionIndex;
        }

        public static int getRandomIndexFromSelectionWheel(double[] probabilities, Random random)
        {
            double universalProbability = probabilities.Sum(probability => probability);

            double randomNumber = random.NextDouble() * universalProbability;

            double sum = 0;
            for (int index = 0; index < probabilities.Length; index++)
            {
                if (randomNumber <= (sum = sum + probabilities[index]))
                {
                    return index;
                }
            }
            // Default to -1, but this should never happen.
            return -1;
        }



    }
}
