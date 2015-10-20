using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Common;

namespace TicTacToeGUI
{
    public partial class ticTacToeForm : Form
    {
        ITicTacToeAgent xPlayer;
        ITicTacToeAgent oPlayer;
        SimulationRunner runner;

        public ticTacToeForm()
        {
            InitializeComponent();
        }

        private void agent1Btn_Click(object sender, EventArgs e)
        {
            if (agent1Btn.Text == "Random")
            {
                agent1Btn.Text = "Learning";
                loadGraphCheckBox.Enabled = true;
            }
            else
            {
                agent1Btn.Text = "Random";
                if (agent2Btn.Text == "Random")
                {
                    loadGraphCheckBox.Checked = false;
                    loadGraphCheckBox.Enabled = false;
                }
            }
        }

        private void agent2Btn_Click(object sender, EventArgs e)
        {
            if (agent2Btn.Text == "Random")
            {
                agent2Btn.Text = "Learning";
                loadGraphCheckBox.Enabled = true;
            }
            else
            {
                agent2Btn.Text = "Random";
                if (agent1Btn.Text == "Random")
                {
                    loadGraphCheckBox.Checked = false;
                    loadGraphCheckBox.Enabled = false;
                }
            }
        }

        private void simulateBtn_Click(object sender, EventArgs e)
        {
            runner = new SimulationRunner();
            simulateBtn.Enabled = false;
            simCountInput.Enabled = false;
            loadGraphCheckBox.Enabled = false;

            if (agent1Btn.Text == "Random")
            {
                xPlayer = new RandomAgent(Token.X);
            }
            else
            {
                xPlayer = new LearningAgent(Token.X);
            }

            if (agent2Btn.Text == "Random")
            {
                oPlayer = new RandomAgent(Token.O);
            }
            else
            {
                oPlayer = new LearningAgent(Token.O);
            }

            if (xPlayer.GetType() == typeof(LearningAgent) && loadGraphCheckBox.Checked)
            {
                var kbPath = ConfigurationManager.AppSettings["kbPathX"];
                if (System.IO.File.Exists(kbPath))
                    ((LearningAgent)xPlayer).LoadKnowledgeBase(kbPath);
            }
            if (oPlayer.GetType() == typeof(LearningAgent) && loadGraphCheckBox.Checked)
            {
                var kbPath = ConfigurationManager.AppSettings["kbPathO"];
                if (System.IO.File.Exists(kbPath))
                    ((LearningAgent)oPlayer).LoadKnowledgeBase(kbPath);
            }

            backgroundSimulator.RunWorkerAsync();

            if (xPlayer.GetType() == typeof(LearningAgent) && loadGraphCheckBox.Checked)
            {
                var kbPath = ConfigurationManager.AppSettings["kbPathX"];
                ((LearningAgent)xPlayer).SaveKnowledgeBase(kbPath);
            }
            if (oPlayer.GetType() == typeof(LearningAgent) && loadGraphCheckBox.Checked)
            {
                var kbPath = ConfigurationManager.AppSettings["kbPathO"];
                ((LearningAgent)oPlayer).SaveKnowledgeBase(kbPath);
            }
        }

        private void backgroundSimulator_DoWork(object sender, DoWorkEventArgs e)
        {
            runner.Simulate((int)simCountInput.Value, xPlayer, oPlayer);
        }

        private void backgroundSimulator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var numGames = simCountInput.Value;
            var numDraws = numGames - runner.XWins - runner.OWins;
            xWinsBox.Text = String.Concat(runner.XWins.ToString(), " (", (runner.XWins / numGames * 100).ToString("G2"), "%)");
            oWinsBox.Text = String.Concat(runner.OWins.ToString(), " (", (runner.OWins / numGames * 100).ToString("G2"), "%)");
            drawsBox.Text = String.Concat(numDraws, " (", (numDraws / numGames * 100).ToString("G2"), "%)");
            simulateBtn.Enabled = true;
            simCountInput.Enabled = true;
            loadGraphCheckBox.Enabled = true;
        }
    }
}
