// ===============================
// AUTHOR       : Maaike Burghoorn, Wouter van 't Hof
// CREATE DATE  : November 2017
// COURSE       : Multi-agent systems - Utrecht University 2017/2018
// PURPOSE      : Visualization of casino 
// SPECIAL NOTES: Also takes care of updates per tick, action selection and user input in windows form.
// ===============================

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace RLMAL
{
    public partial class CasinoForm : Form
    {
        #region GLOBAL VARS
        //Size of agent on screen
        int sizeA = 15;
        //Size of slot machine on screen
        int sizeM = 40;
        //nr of agents in casino
        int nrAgent;
        //nr of machines in casino
        int nrMachine;
        //current algorithm selection in dropdown
        int algIndex;
        //algorithm parameters
        double eps;
        double t;
        double a;
        int initvals;
        //Stores all agent objects
        List<Agent> agentList;
        //Stores all slot machine objects
        List<SlotMachine> slotmachineList;
        //Used for plot
        List<LineSeries> lines;
        //Stores elapsed ticks
        int tickCount;
        //Plots actions over time
        PlotModel actionsOverTime;
        LinearAxis x_axis;
        LinearAxis y_axis;
        //Random created only once to avoid agents choosing same action
        Random random;
        #endregion

        public CasinoForm()
        {
            InitializeComponent();
            this.InitialSetup();
            this.Start();
            this.initPlotActions();
        }

        public void InitialSetup()
        {
            //Create random
            random = new Random();

            //Disable timer
            this.TickTimer.Enabled = false;
            this.TickTimer.Interval = 200;

            //Select egreedy as starting algorithm
            this.dropDownAlgorithm.SelectedIndex = 0;
            //Hide labels/trackbar non-applicable to egreedy algorithm
            this.epsilon.Show();
            this.epsilonLabel.Show();
            this.tau.Hide();
            this.tauLabel.Hide();

            //init vars with initial values
            nrAgent = this.nrAgents.Value;
            nrMachine = this.nrMachines.Value;
            a = (double)alpha.Value / 100;
            eps = (double)epsilon.Value / 100;
            t = (double)tau.Value / 100;
            initvals = initialValues.Value;

            //init all labels with initial values
            this.agentLabel.Text = string.Format("NrAgents = {0}", nrAgent);
            this.machineLabel.Text = string.Format("NrMachines = {0}", nrMachine);
            this.epsilonLabel.Text = string.Format("epsilon = {0}", eps);
            this.tauLabel.Text = string.Format("tau = {0}", t);
            this.initialValuesLabel.Text = string.Format("initial values = {0}", initvals);
            this.alphaLabel.Text = string.Format("alpha = {0}", a);
            this.ticksLabel.Text = string.Format("Ticks: {0}", tickCount);
            this.speedLabel.Text = string.Format("Tick Interval = {0} ms", TickTimer.Interval);

            //Setup background of casino
            this.casino.BackgroundImage = Image.FromFile("..//..//casinofloor.png");
        }

        public void Start()
        {
            //Reset ticks
            tickCount = 1;
            this.ticksLabel.Text = string.Format("Ticks: {0}", tickCount);

            //Algorithm selection
            algIndex = dropDownAlgorithm.SelectedIndex;

            //check new value of nragents and nrmachine
            nrAgent = this.nrAgents.Value;
            nrMachine = this.nrMachines.Value;

            //Hide labels/trackbar non-applicable to algorithm
            switch (algIndex)
            {
                default:
                    break;
                case 0: //e-greedy
                    //initvalues reset to 0
                    initvals = 0;
                    this.initialValues.Value = initvals;
                    this.initialValuesLabel.Text = string.Format("initial values = {0}", initvals);
                    this.epsilon.Show();
                    this.epsilonLabel.Show();
                    this.tau.Hide();
                    this.tauLabel.Hide();
                    this.initialValues.Hide();
                    this.initialValuesLabel.Hide();
                    break;
                case 1: //softmax
                    //initvalues reset to 0
                    initvals = 0;
                    this.initialValues.Value = initvals;
                    this.initialValuesLabel.Text = string.Format("initial values = {0}", initvals);
                    this.tau.Show();
                    this.tauLabel.Show();
                    this.epsilon.Hide();
                    this.epsilonLabel.Hide();
                    this.initialValues.Hide();
                    this.initialValuesLabel.Hide();
                    break;
                case 2: //optimistic
                    this.initialValues.Show();
                    this.initialValuesLabel.Show();
                    this.tau.Hide();
                    this.tauLabel.Hide();
                    this.epsilon.Hide();
                    this.epsilonLabel.Hide();
                    break;
            }

            //Create nrAgents and store in list
            Random r = new Random();
            agentList = new List<Agent>();
            for (int i = 0; i < nrAgent; i++)
            {
                //agent knows nr of machines in casino
                Agent agent = new Agent(nrMachine, r, initvals);
                //Draw agents outside screen on setup //they're waiting outside in the cold :p
                agent.getPosX = -100;
                agent.getPosY = -100;
                agentList.Add(agent);
            }

            //Create nrSlotMachines and store in list
            slotmachineList = new List<SlotMachine>();
            for (int i = 1; i <= nrMachine; i++)
            {
                slotmachineList.Add(new SlotMachine(i));
            }

            //Initialize the plot
            this.initPlotActions();

            casino.Invalidate();
        }

        private void tickTimer_Tick(object sender, EventArgs e)
        {
            //
            //Updates that need to be done every tick
            //

            //Each agent chooses a slot machine
            chooseActions();
            //Calls updateScore for each agent after queues are formed
            updateActionReward();
            //Updates the actions plot
            updatePlotActions();
            //All slot machine queue counts are set to 0
            resetQueues();

            //Update tick count visibly
            tickCount++;
            this.ticksLabel.Text = string.Format("Ticks: {0}", tickCount);

            //Redraw casino
            casino.Invalidate();
        }

        #region Action Selection
        public void chooseActions()
        {
            int width = casino.Width;
            int machineIndex;

            //Each agent picks a slot machine

            foreach (var agent in agentList)
            {
                //Select current algorithm
                switch (algIndex)
                {
                    default:
                        machineIndex = 0;
                        MessageBox.Show("No algorithm was selected", "Wrong algorithm selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                        break;
                    case 0:
                        machineIndex = Algorithms.egreedy(eps, agent, random);
                        break;
                    case 1:
                        machineIndex = Algorithms.softmax(t, agent, random);
                        break;
                    case 2:
                        machineIndex = Algorithms.optimistic(agent, random);
                        break;
                }
                agent.getMachineId = machineIndex;
                //Retrieve slot machine reward and update position
                performAction(agent, width);
            }
        }

        public void performAction(Agent agent, int width)
        {
            int machineIndex = agent.getMachineId;

            //Update queue for slot machine
            slotmachineList[machineIndex].getQueueCount++;
            int queue = slotmachineList[machineIndex].getQueueCount;

            //Reward drawn from machine by agent
            //agent.getReward_t = slotmachineList[machineIndex].getReward();

            //Update position based on machinenr
            agent.getPosX = (width / (nrMachine + 1) * (machineIndex+1)) - sizeM / 2 + sizeM/2-sizeA/2;
            agent.getPosY = sizeM + queue*sizeA;
        }

        public void updateActionReward()
        {
            foreach (var agent in agentList)
            {
                int machineIndex = agent.getMachineId;

                //Reward drawn from machine by agent
                double reward_t = slotmachineList[machineIndex].getReward();

                //Length of queue in which the agent is located
                int queuelength = slotmachineList[agent.getMachineId].getQueueCount;
                //Update reward with queue penalty
                //double waitpenalty = 1;
                //reward_t = (reward_t + (queuelength-1) * waitpenalty) / queuelength;
                reward_t /= queuelength;
                //Update the agents beliefs on rewards per slot machine
                double newReward = Algorithms.updateScore(agent, a, reward_t);
                agent.getRewards[machineIndex] = newReward;
            }
        }
        #endregion

        public void resetQueues()
        {
            foreach (var slot in slotmachineList)
            {
                slot.getQueueCount = 0;
            }
        }

        private void dropDownAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change parameter options based on selected algorithm
            algIndex = dropDownAlgorithm.SelectedIndex;
            switch (algIndex)
            {
                default:
                    break;
                case 0: //e-greedy
                    //initvalues reset to 0
                    initvals = 0;
                    this.initialValues.Value = initvals;
                    this.initialValuesLabel.Text = string.Format("initial values = {0}", initvals);
                    this.epsilon.Show();
                    this.epsilonLabel.Show();
                    this.tau.Hide();
                    this.tauLabel.Hide();
                    this.initialValues.Hide();
                    this.initialValuesLabel.Hide();
                    break;
                case 1: //softmax
                    //initvalues reset to 0
                    initvals = 0;
                    this.initialValues.Value = initvals;
                    this.initialValuesLabel.Text = string.Format("initial values = {0}", initvals);
                    this.tau.Show();
                    this.tauLabel.Show();
                    this.epsilon.Hide();
                    this.epsilonLabel.Hide();
                    this.initialValues.Hide();
                    this.initialValuesLabel.Hide();
                    break;
                case 2: //optimistic
                    this.initialValues.Show();
                    this.initialValuesLabel.Show();
                    this.tau.Hide();
                    this.tauLabel.Hide();
                    this.epsilon.Hide();
                    this.epsilonLabel.Hide();
                    break;
            }
            //Restart when algorithm is changed
            this.Start();
        }

        #region Plot
        public void initPlotActions()
        {
            //Create new plotmodel
            actionsOverTime = new PlotModel { Title = "Action Distribution" };
            actionsOverTime.LegendTitle = "Slot Machines";
            actionsOverTime.LegendPosition = LegendPosition.RightTop;
            actionsOverTime.LegendPlacement = LegendPlacement.Outside;
            //Create x and y axes
            x_axis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 100,
                Title = "Ticks"
            };
            actionsOverTime.Axes.Add(x_axis);
            y_axis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = 0,
                Maximum = nrAgent,
                Title = "Nr Agents"
            };
            actionsOverTime.Axes.Add(y_axis);

            //Create a line for each slot machine
            lines = new List<LineSeries>();

            for (int i = 0; i < nrMachine; i++)
            {
                LineSeries line1 = new LineSeries {
                    Title = string.Format("Slot {0}", i),
                    StrokeThickness = 1
                };
                line1.Points.Add(new DataPoint(0, 0));


                lines.Add(line1);
            }

            //Add lines to plot model
            foreach (var line in lines)
            {
                actionsOverTime.Series.Add(line);
            }

            //View plotmodel in plotview
            this.plotView_actions.Model = actionsOverTime;
        }

        public void updatePlotActions()
        {
            int counter = 0;
            foreach (var machine in slotmachineList)
            {
                int queue = machine.getQueueCount;
                lines[counter].Points.Add(new DataPoint(tickCount, queue));
                counter++;
            }
            //If nr ticks exceeds x axis maximum, update x axis maximum
            if (tickCount >= x_axis.Maximum)
            {
                x_axis.Maximum = tickCount + 100;
            }
            this.actionsOverTime.InvalidatePlot(true);
            this.plotView_actions.Invalidate();
        }
        #endregion

        #region Paint Events
        private void casino_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.SmoothingMode = SmoothingMode.AntiAlias; //draws smoother circles
            int width = casino.Width;

            //draw slot machines
            for (int i = 1; i <= nrMachine; i++)
            {
                int w = (width / (nrMachine + 1) * i) - sizeM / 2;
                gr.DrawImage(Image.FromFile("..//..//slotmachine.png"), w, 0, sizeM, sizeM);
            }

            //draw agents
            foreach (var agent in agentList)
            {
                gr.FillEllipse(agent.getColor, agent.getPosX, agent.getPosY, sizeA, sizeA);
            }
        }

        #endregion

        #region Trackbars
        //Handle Trackbar value updates in labels

        private void nrAgents_Scroll(object sender, EventArgs e)
        {
            //Update according to the value of the nrAgents trackbar
            //nrAgent = nrAgents.Value;
            agentLabel.Text = string.Format("NrAgents = {0}", nrAgents.Value);
        }

        private void nrMachines_Scroll(object sender, EventArgs e)
        {
            //Update according to the value of the nrMachines trackbar
            //nrMachine = nrMachines.Value;
            machineLabel.Text = string.Format("NrMachines = {0}", nrMachines.Value);
        }

        private void epsilon_Scroll(object sender, EventArgs e)
        {
            eps = (double)epsilon.Value / 100;
            epsilonLabel.Text = string.Format("epsilon = {0}", eps);
        }

        private void alpha_Scroll(object sender, EventArgs e)
        {
            a = (double)alpha.Value / 100;
            alphaLabel.Text = string.Format("alpha = {0}", a);
        }

        private void tau_Scroll(object sender, EventArgs e)
        {
            t = (double)tau.Value / 100;
            tauLabel.Text = string.Format("tau = {0}", t);
        }

        private void initialValues_Scroll(object sender, EventArgs e)
        {
            initvals = initialValues.Value;
            initialValuesLabel.Text = string.Format("initial values = {0}",initvals);
        }

        private void speed_Scroll(object sender, EventArgs e)
        {
            this.TickTimer.Interval = this.speed.Value;
            this.speedLabel.Text = string.Format("Tick Interval = {0} ms", this.TickTimer.Interval);
        }

        #endregion

        #region Buttons

        private void setupButton_Click(object sender, EventArgs e)
        {
            this.Start();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (pauseButton.Text == "Pause")
            {
                pauseButton.Text = "Play";
                //this.TickTimer.Start();
                this.TickTimer.Enabled = false;
            }
            else if (pauseButton.Text == "Play")
            {
                pauseButton.Text = "Pause";
                //this.TickTimer.Stop();
                this.TickTimer.Enabled = true;
            }
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            this.TickTimer.Enabled = false;
            pauseButton.Text = "Play";

            //Each agent chooses a slot machine
            chooseActions();
            //Calls updateScore for each agent after queues are formed
            updateActionReward();
            //Updates the actions plot
            updatePlotActions();
            //All slot machine queue counts are set to 0
            resetQueues();

            //Update tick count visibly
            tickCount++;
            this.ticksLabel.Text = string.Format("Ticks: {0}", tickCount);

            //Redraw casino
            casino.Invalidate();
        }

        #endregion


    }
}
