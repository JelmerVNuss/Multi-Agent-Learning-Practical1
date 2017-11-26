using System.Drawing;

namespace RLMAL
{
    partial class CasinoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dropDownAlgorithm = new System.Windows.Forms.ComboBox();
            this.nrAgents = new System.Windows.Forms.TrackBar();
            this.epsilon = new System.Windows.Forms.TrackBar();
            this.alpha = new System.Windows.Forms.TrackBar();
            this.casino = new System.Windows.Forms.Panel();
            this.tau = new System.Windows.Forms.TrackBar();
            this.TickTimer = new System.Windows.Forms.Timer(this.components);
            this.nrMachines = new System.Windows.Forms.TrackBar();
            this.agentLabel = new System.Windows.Forms.Label();
            this.machineLabel = new System.Windows.Forms.Label();
            this.ticksLabel = new System.Windows.Forms.Label();
            this.epsilonLabel = new System.Windows.Forms.Label();
            this.alphaLabel = new System.Windows.Forms.Label();
            this.scenarioParameterLabel = new System.Windows.Forms.Label();
            this.algorithmParameterLabel = new System.Windows.Forms.Label();
            this.algorithmSelectLabel = new System.Windows.Forms.Label();
            this.tauLabel = new System.Windows.Forms.Label();
            this.pauseButton = new System.Windows.Forms.Button();
            this.setupButton = new System.Windows.Forms.Button();
            this.stepButton = new System.Windows.Forms.Button();
            this.speedLabel = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.TrackBar();
            this.plotView_actions = new OxyPlot.WindowsForms.PlotView();
            this.initialValues = new System.Windows.Forms.TrackBar();
            this.initialValuesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nrAgents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epsilon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrMachines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.initialValues)).BeginInit();
            this.SuspendLayout();
            // 
            // dropDownAlgorithm
            // 
            this.dropDownAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropDownAlgorithm.FormattingEnabled = true;
            this.dropDownAlgorithm.Items.AddRange(new object[] {
            "e-greedy",
            "Softmax Action Selection",
            "Optimistic initial values"});
            this.dropDownAlgorithm.Location = new System.Drawing.Point(917, 114);
            this.dropDownAlgorithm.Name = "dropDownAlgorithm";
            this.dropDownAlgorithm.Size = new System.Drawing.Size(166, 21);
            this.dropDownAlgorithm.TabIndex = 0;
            this.dropDownAlgorithm.SelectedIndexChanged += new System.EventHandler(this.dropDownAlgorithm_SelectedIndexChanged);
            // 
            // nrAgents
            // 
            this.nrAgents.Location = new System.Drawing.Point(917, 185);
            this.nrAgents.Maximum = 30;
            this.nrAgents.Minimum = 1;
            this.nrAgents.Name = "nrAgents";
            this.nrAgents.Size = new System.Drawing.Size(166, 45);
            this.nrAgents.TabIndex = 1;
            this.nrAgents.TickStyle = System.Windows.Forms.TickStyle.None;
            this.nrAgents.Value = 10;
            this.nrAgents.Scroll += new System.EventHandler(this.nrAgents_Scroll);
            // 
            // epsilon
            // 
            this.epsilon.Location = new System.Drawing.Point(916, 340);
            this.epsilon.Maximum = 100;
            this.epsilon.Name = "epsilon";
            this.epsilon.Size = new System.Drawing.Size(166, 45);
            this.epsilon.SmallChange = 5;
            this.epsilon.TabIndex = 2;
            this.epsilon.TickStyle = System.Windows.Forms.TickStyle.None;
            this.epsilon.Value = 10;
            this.epsilon.Scroll += new System.EventHandler(this.epsilon_Scroll);
            // 
            // alpha
            // 
            this.alpha.Location = new System.Drawing.Point(917, 268);
            this.alpha.Maximum = 100;
            this.alpha.Name = "alpha";
            this.alpha.Size = new System.Drawing.Size(166, 45);
            this.alpha.TabIndex = 3;
            this.alpha.TickStyle = System.Windows.Forms.TickStyle.None;
            this.alpha.Value = 5;
            this.alpha.Scroll += new System.EventHandler(this.alpha_Scroll);
            // 
            // casino
            // 
            this.casino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.casino.Location = new System.Drawing.Point(12, 12);
            this.casino.Name = "casino";
            this.casino.Size = new System.Drawing.Size(713, 379);
            this.casino.TabIndex = 4;
            this.casino.Paint += new System.Windows.Forms.PaintEventHandler(this.casino_Paint);
            // 
            // tau
            // 
            this.tau.Location = new System.Drawing.Point(916, 340);
            this.tau.Maximum = 100;
            this.tau.Minimum = 5;
            this.tau.Name = "tau";
            this.tau.Size = new System.Drawing.Size(166, 45);
            this.tau.TabIndex = 6;
            this.tau.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tau.Value = 20;
            this.tau.Scroll += new System.EventHandler(this.tau_Scroll);
            // 
            // TickTimer
            // 
            this.TickTimer.Enabled = true;
            this.TickTimer.Interval = 200;
            this.TickTimer.Tick += new System.EventHandler(this.tickTimer_Tick);
            // 
            // nrMachines
            // 
            this.nrMachines.LargeChange = 1;
            this.nrMachines.Location = new System.Drawing.Point(917, 226);
            this.nrMachines.Maximum = 5;
            this.nrMachines.Minimum = 1;
            this.nrMachines.Name = "nrMachines";
            this.nrMachines.Size = new System.Drawing.Size(166, 45);
            this.nrMachines.TabIndex = 7;
            this.nrMachines.TickStyle = System.Windows.Forms.TickStyle.None;
            this.nrMachines.Value = 3;
            this.nrMachines.Scroll += new System.EventHandler(this.nrMachines_Scroll);
            // 
            // agentLabel
            // 
            this.agentLabel.AutoSize = true;
            this.agentLabel.Location = new System.Drawing.Point(783, 185);
            this.agentLabel.Name = "agentLabel";
            this.agentLabel.Size = new System.Drawing.Size(61, 13);
            this.agentLabel.TabIndex = 8;
            this.agentLabel.Text = "nrAgents = ";
            // 
            // machineLabel
            // 
            this.machineLabel.AutoSize = true;
            this.machineLabel.Location = new System.Drawing.Point(782, 226);
            this.machineLabel.Name = "machineLabel";
            this.machineLabel.Size = new System.Drawing.Size(74, 13);
            this.machineLabel.TabIndex = 9;
            this.machineLabel.Text = "nrMachines = ";
            // 
            // ticksLabel
            // 
            this.ticksLabel.AutoSize = true;
            this.ticksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticksLabel.Location = new System.Drawing.Point(781, 26);
            this.ticksLabel.Name = "ticksLabel";
            this.ticksLabel.Size = new System.Drawing.Size(53, 20);
            this.ticksLabel.TabIndex = 10;
            this.ticksLabel.Text = "Ticks :";
            // 
            // epsilonLabel
            // 
            this.epsilonLabel.AutoSize = true;
            this.epsilonLabel.Location = new System.Drawing.Point(781, 340);
            this.epsilonLabel.Name = "epsilonLabel";
            this.epsilonLabel.Size = new System.Drawing.Size(52, 13);
            this.epsilonLabel.TabIndex = 11;
            this.epsilonLabel.Text = "epsilon = ";
            // 
            // alphaLabel
            // 
            this.alphaLabel.AutoSize = true;
            this.alphaLabel.Location = new System.Drawing.Point(782, 268);
            this.alphaLabel.Name = "alphaLabel";
            this.alphaLabel.Size = new System.Drawing.Size(45, 13);
            this.alphaLabel.TabIndex = 12;
            this.alphaLabel.Text = "alpha = ";
            // 
            // scenarioParameterLabel
            // 
            this.scenarioParameterLabel.AutoSize = true;
            this.scenarioParameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scenarioParameterLabel.Location = new System.Drawing.Point(782, 155);
            this.scenarioParameterLabel.Name = "scenarioParameterLabel";
            this.scenarioParameterLabel.Size = new System.Drawing.Size(141, 17);
            this.scenarioParameterLabel.TabIndex = 13;
            this.scenarioParameterLabel.Text = "Scenario Parameters";
            // 
            // algorithmParameterLabel
            // 
            this.algorithmParameterLabel.AutoSize = true;
            this.algorithmParameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.algorithmParameterLabel.Location = new System.Drawing.Point(782, 306);
            this.algorithmParameterLabel.Name = "algorithmParameterLabel";
            this.algorithmParameterLabel.Size = new System.Drawing.Size(144, 17);
            this.algorithmParameterLabel.TabIndex = 14;
            this.algorithmParameterLabel.Text = "Algorithm Parameters";
            // 
            // algorithmSelectLabel
            // 
            this.algorithmSelectLabel.AutoSize = true;
            this.algorithmSelectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.algorithmSelectLabel.Location = new System.Drawing.Point(782, 114);
            this.algorithmSelectLabel.Name = "algorithmSelectLabel";
            this.algorithmSelectLabel.Size = new System.Drawing.Size(113, 17);
            this.algorithmSelectLabel.TabIndex = 15;
            this.algorithmSelectLabel.Text = "Select algorithm:";
            // 
            // tauLabel
            // 
            this.tauLabel.AutoSize = true;
            this.tauLabel.Location = new System.Drawing.Point(782, 340);
            this.tauLabel.Name = "tauLabel";
            this.tauLabel.Size = new System.Drawing.Size(34, 13);
            this.tauLabel.TabIndex = 16;
            this.tauLabel.Text = "tau = ";
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(866, 74);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 17;
            this.pauseButton.Text = "Play";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // setupButton
            // 
            this.setupButton.Location = new System.Drawing.Point(785, 74);
            this.setupButton.Name = "setupButton";
            this.setupButton.Size = new System.Drawing.Size(75, 23);
            this.setupButton.TabIndex = 18;
            this.setupButton.Text = "Setup";
            this.setupButton.UseVisualStyleBackColor = true;
            this.setupButton.Click += new System.EventHandler(this.setupButton_Click);
            // 
            // stepButton
            // 
            this.stepButton.Location = new System.Drawing.Point(947, 74);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(75, 23);
            this.stepButton.TabIndex = 19;
            this.stepButton.Text = "Step";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(866, 31);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(75, 13);
            this.speedLabel.TabIndex = 20;
            this.speedLabel.Text = "Tick Interval =";
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(979, 26);
            this.speed.Maximum = 1000;
            this.speed.Minimum = 1;
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(104, 45);
            this.speed.TabIndex = 100;
            this.speed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.speed.Value = 200;
            this.speed.Scroll += new System.EventHandler(this.speed_Scroll);
            // 
            // plotView_actions
            // 
            this.plotView_actions.Location = new System.Drawing.Point(12, 400);
            this.plotView_actions.Name = "plotView_actions";
            this.plotView_actions.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView_actions.Size = new System.Drawing.Size(713, 368);
            this.plotView_actions.TabIndex = 21;
            this.plotView_actions.Text = "plotView1";
            this.plotView_actions.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView_actions.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView_actions.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // initialValues
            // 
            this.initialValues.Location = new System.Drawing.Point(916, 340);
            this.initialValues.Name = "initialValues";
            this.initialValues.Size = new System.Drawing.Size(166, 45);
            this.initialValues.TabIndex = 101;
            this.initialValues.TickStyle = System.Windows.Forms.TickStyle.None;
            this.initialValues.Scroll += new System.EventHandler(this.initialValues_Scroll);
            // 
            // initialValuesLabel
            // 
            this.initialValuesLabel.AutoSize = true;
            this.initialValuesLabel.Location = new System.Drawing.Point(781, 340);
            this.initialValuesLabel.Name = "initialValuesLabel";
            this.initialValuesLabel.Size = new System.Drawing.Size(76, 13);
            this.initialValuesLabel.TabIndex = 102;
            this.initialValuesLabel.Text = "initial values = ";
            // 
            // CasinoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 794);
            this.Controls.Add(this.initialValuesLabel);
            this.Controls.Add(this.initialValues);
            this.Controls.Add(this.plotView_actions);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.setupButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.tauLabel);
            this.Controls.Add(this.algorithmSelectLabel);
            this.Controls.Add(this.algorithmParameterLabel);
            this.Controls.Add(this.scenarioParameterLabel);
            this.Controls.Add(this.alphaLabel);
            this.Controls.Add(this.epsilonLabel);
            this.Controls.Add(this.ticksLabel);
            this.Controls.Add(this.machineLabel);
            this.Controls.Add(this.agentLabel);
            this.Controls.Add(this.nrMachines);
            this.Controls.Add(this.tau);
            this.Controls.Add(this.casino);
            this.Controls.Add(this.alpha);
            this.Controls.Add(this.epsilon);
            this.Controls.Add(this.nrAgents);
            this.Controls.Add(this.dropDownAlgorithm);
            this.Name = "CasinoForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nrAgents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epsilon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrMachines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.initialValues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox dropDownAlgorithm;
        private System.Windows.Forms.TrackBar nrAgents;
        private System.Windows.Forms.TrackBar epsilon;
        private System.Windows.Forms.TrackBar alpha;
        private System.Windows.Forms.Panel casino;
        private System.Windows.Forms.TrackBar tau;
        private System.Windows.Forms.Timer TickTimer;
        private System.Windows.Forms.TrackBar nrMachines;
        private System.Windows.Forms.Label agentLabel;
        private System.Windows.Forms.Label machineLabel;
        private System.Windows.Forms.Label ticksLabel;
        private System.Windows.Forms.Label epsilonLabel;
        private System.Windows.Forms.Label alphaLabel;
        private System.Windows.Forms.Label scenarioParameterLabel;
        private System.Windows.Forms.Label algorithmParameterLabel;
        private System.Windows.Forms.Label algorithmSelectLabel;
        private System.Windows.Forms.Label tauLabel;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button setupButton;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.TrackBar speed;
        private OxyPlot.WindowsForms.PlotView plotView_actions;
        private System.Windows.Forms.TrackBar initialValues;
        private System.Windows.Forms.Label initialValuesLabel;
    }
}

