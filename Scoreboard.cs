using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobiasLenanderAssignment7
{
    public class Scoreboard
    {
        private List<PlayerPoint> playerOnePointList;
        private List<PlayerPoint> playerTwoPointList;
        private int playerOneTotalPoints = 0;
        private int playerTwoTotalPoints = 0;

        public Scoreboard()
        {
            playerOnePointList = new List<PlayerPoint>();
            playerTwoPointList = new List<PlayerPoint>();
        }

        /// <summary>
        /// ReadOnly getter for playerOneTotalPoints
        /// </summary>
        public int PlayerOneTotalPoints
        {
            get { return playerOneTotalPoints; }
        }

        /// <summary>
        /// ReadOnly getter for playerTwoTotalPoints
        /// </summary>
        public int PlayerTwoTotalPoints
        {
            get { return playerTwoTotalPoints; }
        }

        /// <summary>
        /// Increments playerPoint for currentPlayer if guessedWord == correctWord.
        /// Saves the guessedWord and correctWord in a list
        /// </summary>
        /// <param name="player"></param>
        /// <param name="guessedWord"></param>
        /// <param name="correctWord"></param>
        public void GivePointToPlayer(int player, string guessedWord, string correctWord)
        {
            PlayerPoint playerPoint = new PlayerPoint(player, guessedWord, correctWord);

            if (player == 1)
            {
                playerOnePointList.Add(playerPoint);
                if (guessedWord == correctWord)
                    playerOneTotalPoints++;
            }
            else if (player == 2)
            {
                playerTwoPointList.Add(playerPoint);
                if (guessedWord == correctWord)
                    playerTwoTotalPoints++;
            }
        }

        /// <summary>
        /// Returns an array of strings to display as result at the end
        /// of the game.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>result</returns>
        public string[] GetPlayerResult(int player)
        {
            if (player == 1)
            {
                string[] result = new string[playerOnePointList.Count];

                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = string.Format("{0, -25}{1}", playerOnePointList[i].GuessedWord, playerOnePointList[i].CorrectWord);
                }
                return result;
            }
            else if (player == 2)
            {
                string[] result = new string[playerTwoPointList.Count];

                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = string.Format("{0, -25}{1}", playerTwoPointList[i].GuessedWord, playerTwoPointList[i].CorrectWord);
                }
                return result;
            }
            return null;
        }
    }
}
