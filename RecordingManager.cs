using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace TobiasLenanderAssignment7
{
    public class RecordingManager
    {
        private List<Recording> recordingList;

        public RecordingManager()
        {
            recordingList = new List<Recording>();
        }

        public List<Recording> RecordingList
        {
            get { return recordingList; }
        }

        /// <summary>
        /// A method for adding a recording to the recordingList
        /// </summary>
        /// <param name="recordingIn"></param>
        /// <returns>true or false</returns>
        public bool AddRecording(Recording recordingIn)
        {
            if (recordingIn == null)
                return false;

            recordingList.Add(recordingIn);
            return true;
        }

        /// <summary>
        /// A method for checking if the selected index
        /// is valid or not
        /// </summary>
        /// <param name="index"></param>
        /// <returns>true or false</returns>
        private bool CheckIndex(int index)
        {
            return (index >= 0) && (index < recordingList.Count);
        }

        /// <summary>
        /// A method for getting a recording
        /// at a position in the recordingList
        /// </summary>
        /// <param name="index"></param>
        /// <returns>recording</returns>
        public Recording GetRecordingAt(int index)
        {
            if (index < 0 || index >= recordingList.Count)
                return null;

            return recordingList[index];
        }

        /// <summary>
        /// Creates an array of the recordingList wordStrings
        /// </summary>
        /// <returns>recordingArray</returns>
        public string[] GetRecordingWordsArray()
        {
            string[] recordingArray = new string[recordingList.Count];

            int index = 0;
            foreach (Recording recordingObj in recordingList)
            {
                recordingArray[index] = recordingList[index].WordString;
                index++;
            }
            return recordingArray;
        }

        /// <summary>
        /// Creates an array of the recordingList wordStrings and randomizes them
        /// </summary>
        /// <returns>recordingArray</returns>
        public string[] GetRecordingWordsArrayRandomized()
        {
            string[] recordingArray = new string[recordingList.Count];

            int index = 0;
            foreach (Recording recordingObj in recordingList)
            {
                recordingArray[index] = recordingList[index].WordString;
                index++;
            }

            Random rnd = new Random();
            string[] recordingArrayRandom = recordingArray.OrderBy(x => rnd.Next()).ToArray();

            return recordingArrayRandom;
        }

        /// <summary>
        /// A method for deleting a recording
        /// </summary>
        /// <param name="index"></param>
        /// <returns>true or false</returns>
        public bool DeleteRecordingAt(int index)
        {
            if (CheckIndex(index))
                recordingList.RemoveAt(index);
            else
                return false;

            return true;
        }
    }
}
