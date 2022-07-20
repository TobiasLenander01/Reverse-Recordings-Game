using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace TobiasLenanderAssignment7
{
    /// <summary>
    /// Saves the filePaths of the recorded words and the
    /// word as a string.
    /// </summary>
    public class Recording
    {
        private string wordString = "No word specified";
        private string waveFilePath;
        private string reversedWaveFilePath;

        public Recording(string wordString, string waveFileName, string reversedWaveFileName)
        {
            this.wordString = wordString;
            this.waveFilePath = waveFileName;
            this.reversedWaveFilePath = reversedWaveFileName;
        }

        public Recording() : this(string.Empty, string.Empty, string.Empty)
        {

        }

        //Getter and setter for wordString
        public string WordString
        {
            get { return wordString; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    wordString = value;
            }
        }

        //Getter and setter for waveFilePath
        public string WaveFilePath
        {
            get { return waveFilePath; }
            set 
            { 
                if (!string.IsNullOrEmpty(value))
                    waveFilePath = value; 
            }
        }

        //Getter and setter for reversedWaveFilePath
        public string ReversedWaveFilePath
        {
            get { return reversedWaveFilePath; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    reversedWaveFilePath = value;
            }
        }
    }
}