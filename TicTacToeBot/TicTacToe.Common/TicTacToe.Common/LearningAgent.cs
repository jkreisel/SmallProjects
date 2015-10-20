using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Common
{
    public class LearningAgent : ITicTacToeAgent
    {
        private List<GameState> MoveHistory = new List<GameState>();
        private LightweightGraph<GameState> KnowledgeBase = new LightweightGraph<GameState>();
        public Token PlayerToken { get; private set; }

        public LearningAgent(Token playerToken)
        {
            PlayerToken = playerToken;
        }

        public void Play(Game simulation)
        {
            MoveHistory.Add(new GameState(simulation.CurrentState));

            if (!simulation.GameOver())
            {
                int? bestMove = null;

                bestMove = EvaluateKnowledgeBase(simulation.CurrentState);
                
                if (bestMove.HasValue)
                {
                    var success = simulation.PlaceToken(PlayerToken, bestMove.Value);
                    if (!success)
                    {
                        throw new NotSupportedException();
                    }
                    MoveHistory.Add(new GameState(simulation.CurrentState));
                }
                else
                {
                    PlayRandomly(simulation);
                    MoveHistory.Add(new GameState(simulation.CurrentState));
                }
            }
            else
            {
                throw new InvalidOperationException("No token can be placed because the game is over.");
            }
        }

        private int? EvaluateKnowledgeBase(GameState gameState)
        {
            int? bestMove = null;

            if (KnowledgeBase.Contains(gameState))
            {
                var adjacentStates = KnowledgeBase.GetAdjacentItems(gameState).Where(s => s.LastToken == PlayerToken).Where(s => gameState.Board[s.LastMove.Value] == Token.Blank);
                var positiveStates = adjacentStates.Where(s => KnowledgeBase.GetWeightBetweenAdjacentItems(gameState, s) > 0).ToList();
                positiveStates.OrderByDescending(s => KnowledgeBase.GetWeightBetweenAdjacentItems(gameState, s));
                
                if (positiveStates.Count > 0)
                    bestMove = positiveStates.First().LastMove;
            }

            return bestMove;
        }

        private void PlayRandomly(Game simulation)
        {
            CryptoRandom rand = new CryptoRandom();
            var square = rand.Next(0, 9);
            while (!simulation.PlaceToken(PlayerToken, square))
            {
                square = rand.Next(0, 9);
            }            
        }


        public void GameOver(Token winner)
        {
            if (winner == PlayerToken)
            {
                UpdateKnowledgeBase(1);
            }
            else if (winner != Token.Blank)
            {
                UpdateKnowledgeBase(-1);
            }
            else
            {
                UpdateKnowledgeBase(0);
            }

            MoveHistory = new List<GameState>();
        }

        private void UpdateKnowledgeBase(int adjustment)
        {
            for (int i = 0; i < MoveHistory.Count - 1; i++)
            {
                KnowledgeBase.AddEdge(MoveHistory[i], MoveHistory[i + 1], 0);
                var currentWeight = KnowledgeBase.GetWeightBetweenAdjacentItems(MoveHistory[i], MoveHistory[i+1]);
                KnowledgeBase.UpdateEdgeWeight(MoveHistory[i], MoveHistory[i + 1], adjustment);
            }
        }

        public void SaveKnowledgeBase(string filePath)
        {
            Stream outputStream = File.Create(filePath);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(outputStream, KnowledgeBase);
            outputStream.Close();
        }

        public void LoadKnowledgeBase(string filePath)
        {
            Stream inputStream = File.OpenRead(filePath);
            BinaryFormatter deserializer = new BinaryFormatter();
            KnowledgeBase = (LightweightGraph<GameState>)deserializer.Deserialize(inputStream);
            inputStream.Close();
        }
    }
}
