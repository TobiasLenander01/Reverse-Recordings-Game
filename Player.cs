using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace TobiasLenanderAssignment7
{
    public class Player
    {
        private RecordingManager recordingManager = new RecordingManager(); //The player's recorded words are stored in the recordingManager
        private string playerName; //This is the player name

        public RecordingManager RecordingManager
        {
            get { return recordingManager; }
            set { recordingManager = value; }
        }

        public string PlayerName
        {
            get { return playerName; }
            set 
            { 
                if (!string.IsNullOrEmpty(value))
                    playerName = value;
            }
        }
    }
}
