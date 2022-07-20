using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave; //Library for recording/playing wave files by Mark Heath
using WaveFileManipulator; //Library used for reversing wave files by David Klempfner
using VarispeedDemo.SoundTouch; //Used for different playback speeds by Mark Heath

namespace TobiasLenanderAssignment7
{
    public class WaveRecorder
    {
        private WaveIn waveIn;
        private WaveOut waveOut;
        private WaveFileWriter waveFileWriter;
        private int fileNumber = 1;
        private string fileName;
        private string filePath;
        private string reversedFileName;
        private string reversedFilePath;

        /// <summary>
        /// Getter for filePath
        /// </summary>
        public string FilePath
        {
            get { return filePath; }
        }

        /// <summary>
        /// Getter for reversedFilePath
        /// </summary>
        public string ReversedFilePath
        {
            get { return reversedFilePath; }
        }

        /// <summary>
        /// This method increments the file number
        /// </summary>
        public void IncrementFileNumber()
        {
            fileNumber++;
        }

        /// <summary>
        /// Starts recording from inputDevice, saves a wave file as playernumber and wordnumber .wav
        /// </summary>
        /// <param name="inputDeviceIndex"></param>
        /// <param name="currentPlayer"></param>
        public void RecordStart(int inputDeviceIndex, int currentPlayer)
        {
            fileName = $"Player{currentPlayer}Word{fileNumber}.wav";
            filePath = Application.StartupPath + $"\\words/" + fileName;

            waveIn = new WaveIn();
            waveIn.WaveFormat = new WaveFormat(44100, 1);
            waveIn.DeviceNumber = inputDeviceIndex;
            waveIn.DataAvailable += WaveIn_DataAvailable;
            waveIn.RecordingStopped += WaveIn_RecordingStopped;
            waveFileWriter = new WaveFileWriter(filePath, waveIn.WaveFormat);
            waveIn.StartRecording();
        }

        /// <summary>
        /// When recording is stopped the waveFileWriter is disposed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaveIn_RecordingStopped(object? sender, StoppedEventArgs e)
        {
            waveFileWriter.Dispose();
        }

        /// <summary>
        /// Writes data when data is available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaveIn_DataAvailable(object? sender, WaveInEventArgs e)
        {
            waveFileWriter.Write(e.Buffer, 0, e.BytesRecorded);
        }

        /// <summary>
        /// Stops any ongoing recording
        /// </summary>
        public void RecordStop()
        {
            waveIn.StopRecording();
            waveIn.Dispose();
        }

        /// <summary>
        /// Method for playing a wave file from a filePath and out a specified device
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="outputDeviceIndex"></param>
        public void PlayWave(string filePath, int outputDeviceIndex)
        {
            disposeWaveRecorder();
            AudioFileReader audioFileReader = new AudioFileReader(filePath);
            waveOut = new WaveOut();
            waveOut.DeviceNumber = outputDeviceIndex;
            waveOut.Init(new WaveChannel32(audioFileReader));
            waveOut.Play();
        }

        /// <summary>
        /// This method is the same as play wave method but uses varispeedSampleProvider to modify playbackrate
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="outputDeviceIndex"></param>
        public void PlayWaveSlowed(string filePath, int outputDeviceIndex)
        {
            disposeWaveRecorder();
            AudioFileReader audioFileReader = new AudioFileReader(filePath);
            VarispeedSampleProvider varispeedSampleProvider = new VarispeedSampleProvider(audioFileReader, 100, new SoundTouchProfile(true, true));
            varispeedSampleProvider.PlaybackRate = 0.85F;
            waveOut = new WaveOut();
            waveOut.DeviceNumber = outputDeviceIndex;
            waveOut.Init(varispeedSampleProvider);
            waveOut.Play();
        }

        /// <summary>
        /// Method for reversing a wave file
        /// </summary>
        /// <param name="currentPlayer"></param>
        public void ReverseWave(int currentPlayer)
        {
            reversedFileName = $"ReversedPlayer{currentPlayer}Word{fileNumber}.wav";
            reversedFilePath = Application.StartupPath + $"\\words/" + reversedFileName;
            var manipulator = new Manipulator(filePath);
            var reversedByteArray = manipulator.Reverse();
            using (FileStream reversedFileStream = new FileStream(reversedFilePath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                reversedFileStream.Write(reversedByteArray, 0, reversedByteArray.Length);
            }
        }

        /// <summary>
        /// This method increases the volume to a normal level if the recording volume was low
        /// Code from Mark Heath's open source Naudio
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void NormalizeWave()
        {
            AudioFileReader audioFileReader = new AudioFileReader(filePath);

            float max = 0;

            // find the max peak
            float[] buffer = new float[audioFileReader.WaveFormat.SampleRate];
            int read;
            do
            {
                read = audioFileReader.Read(buffer, 0, buffer.Length);
                for (int n = 0; n < read; n++)
                {
                    var abs = Math.Abs(buffer[n]);
                    if (abs > max) max = abs;
                }
            } while (read > 0);
            Console.WriteLine($"Max sample value: {max}");

            if (max == 0 || max > 1.0f)
                throw new InvalidOperationException("File cannot be normalized");

            // rewind and amplify
            audioFileReader.Position = 0;
            audioFileReader.Volume = 1.0f / max;

            // write out to a temp WAV file
            string tempFile = Application.StartupPath + $"\\words/tempFile.wav";
            WaveFileWriter.CreateWaveFile16(tempFile, audioFileReader);
            audioFileReader.Dispose();
            System.IO.File.Copy(tempFile, filePath, true); //Overwrites the input file with the normalized file
            System.IO.File.Delete(tempFile); //Deletes the tempFile
        }

        /// <summary>
        /// This method deletes the previously saved recordings in the words directory
        /// </summary>
        public void deleteSavedRecordings()
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(Application.StartupPath + "\\words");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        /// <summary>
        /// Disposes the waveIn, waveOut and waveFileWriter if possible.
        /// </summary>
        public void disposeWaveRecorder()
        {
            if (waveIn != null)
            {
                waveIn.StopRecording();
                waveIn.Dispose();
            }
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
            }
            if (waveFileWriter != null)
            {
                waveFileWriter.Dispose();
            }
        }
    }
}
