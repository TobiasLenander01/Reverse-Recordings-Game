using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobiasLenanderAssignment7
{
    public class PlayerPoint
    {
        private int playerNumber = 0;
        private string guessedWord = "No guessed word assigned";
        private string correctWord = "No correct word assigned";

        public PlayerPoint(int playerNumber, string guessedWord, string correctWord)
        {
            this.playerNumber = playerNumber;
            this.guessedWord = guessedWord;
            this.correctWord = correctWord;
        }

        //Getter for playerNumber
        public int PlayerNumber
        {
            get { return playerNumber; }
        }
        //Getter for guessedWord
        public string GuessedWord
        {
            get { return guessedWord; }
        }

        //Getter for correctWord
        public string CorrectWord
        {
            get { return correctWord; }
        }
    }
}
