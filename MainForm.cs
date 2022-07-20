using NAudio.Wave;

namespace TobiasLenanderAssignment7
{
    /// <summary>
    /// This is a two player game based on recording words then
    /// guessing the correct one after hearing a reversed recording of it.
    /// The waveRecorder class handles recording, reversing and 
    /// playing wave files using the open source Naudio (and soundTouch) library written
    /// by Mark Heath. The reversing method uses a library by David Klempfner
    /// called WaveFileManipulator.
    /// </summary>
    public partial class MainForm : Form
    {
        private WaveRecorder waveRecorder; //Used for handling wave (audio) files
        private Scoreboard scoreboard; //Used for keeping track of player score and guesses
        private Player playerOne; //Stores player name and recorded words for player one
        private Player playerTwo; //Stores player name and recorded words for player two

        //This integer keeps track of which screen is visible.
        private int screenIndex = 0;

        //This integer keeps track of which player is currently playing
        private int currentPlayer = 1;

        //This integer sets the maximum word length
        private int maxWordLength = 15;

        //Set number of words
        private int maxNumberOfWords = 10;

        //Keeps track of the current word during guessing
        private int currentWord = 1;

        private int outputDeviceIndex;
        private int inputDeviceIndex;

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        /// <summary>
        /// Method that sets default values and creates new instances
        /// of the waveRecorder etc. It displays the first screen - options.
        /// </summary>
        private void InitializeGUI()
        {
            waveRecorder = new WaveRecorder();
            scoreboard = new Scoreboard();
            playerOne = new Player();
            playerTwo = new Player();

            waveRecorder.disposeWaveRecorder();

            //Clear previous recordings from words directory
            waveRecorder.deleteSavedRecordings();

            //Load input and output devices to comboBoxes
            LoadDevices();

            //Set default values
            textBoxNamePlayer1.Text = String.Empty;
            textBoxNamePlayer2.Text = String.Empty;
            numericUpDownNumOfWords.Value = 10;
            textBoxWord.Text = String.Empty;
            listBoxWords.Items.Clear();
            listBoxResult.Items.Clear();
            buttonNext.Text = "Next ->";
            currentWord = 1;

            //Show the first screen - options
            ShowOptionsScreen();
        }

        /// <summary>
        /// Loads devices and displays them in the comboBoxes
        /// of the options screen.
        /// </summary>
        private void LoadDevices()
        {
            comboBoxInput.Items.Clear();
            comboBoxOutput.Items.Clear();

            //Populate recording device comboBox with input devices
            for (int deviceId = 0; deviceId < WaveIn.DeviceCount; deviceId++)
            {
                var deviceInfo = WaveIn.GetCapabilities(deviceId);
                comboBoxInput.Items.Add(deviceInfo.ProductName);
            }

            //Populate output device comboBox with output devices
            for (int deviceId = 0; deviceId < WaveOut.DeviceCount; deviceId++)
            {
                var deviceInfo = WaveOut.GetCapabilities(deviceId);
                comboBoxOutput.Items.Add(deviceInfo.ProductName);
            }
        }

        /// <summary>
        /// Sets screen index to 0 and shows the options screen while
        /// disabling and hiding the other screens
        /// </summary>
        private void ShowOptionsScreen()
        {
            screenIndex = 0;

            DisableAllScreens();
            
            groupBoxOptions.Enabled = true;
            groupBoxOptions.Location = new Point(12, 12);
            buttonNext.Location = new Point(403, 347);
            buttonNext.Enabled = true;
            this.Size = new Size(521, 428);
        }

        /// <summary>
        /// Sets screen index to 1 or 2 depending on player and shows the record words
        /// screen while disabling and hiding the other screens
        /// </summary>
        private void ShowRecordWordsScreen(int playerNumber)
        {
            if (playerNumber == 1)
            {
                groupBoxRecordWords.Text = "Record words -  " + playerOne.PlayerName;
                screenIndex = 1;
                currentPlayer = 1;
                labelRecordWordsInstructions.Text = playerOne.PlayerName + " will start recording words. " + 
                                                    playerTwo.PlayerName + " should leave the room.";
            }
            else //playerNumber == 2
            {
                groupBoxRecordWords.Text = "Record words - " + playerTwo.PlayerName;
                screenIndex = 2;
                currentPlayer = 2;
                labelRecordWordsInstructions.Text = playerTwo.PlayerName + " will start recording words. " +
                                                   playerOne.PlayerName + " should leave the room.";
            }

            DisableAllScreens();

            groupBoxRecordWords.Enabled = true;
            groupBoxRecordWords.Location = new Point(12, 12);
            buttonNext.Location = new Point(468, 393);
            buttonNext.Enabled = true;
            this.Size = new Size(590, 478);

            UpdateWordsListBox();
            textBoxWord.Text = string.Empty;
            buttonRecord.Text = "Start recording";

            buttonRemoveWord.Enabled = false;
            buttonRecordWordsListen.Enabled = false;
            buttonRecordWordsListenReverse.Enabled = false;
            buttonAddWord.Enabled = false;
        }

        /// <summary>
        /// Sets screen index to 3 or 4 depending on player and shows the guess words
        /// screen while disabling and hiding the other screens
        /// </summary>
        private void ShowGuessWordsScreen(int playerNumber)
        {
            if (playerNumber == 1)
            {
                groupBoxGuessWords.Text = "Guess words - " + playerOne.PlayerName;
                screenIndex = 3;
                currentPlayer = 1;
                labelGuessWordsInstructions.Text = playerOne.PlayerName + " will start guessing words. " +
                                                    playerTwo.PlayerName + " can watch.";

                comboBoxWords.Items.Clear();
                comboBoxWords.Items.AddRange(playerTwo.RecordingManager.GetRecordingWordsArrayRandomized());
            }
            else //playerNumber == 2
            {
                groupBoxGuessWords.Text = "Guess words - " + playerTwo.PlayerName;
                screenIndex = 4;
                currentPlayer = 2;
                labelGuessWordsInstructions.Text = playerTwo.PlayerName + " will start guessing words. " +
                                                   playerOne.PlayerName + " can watch.";

                comboBoxWords.Items.Clear();
                comboBoxWords.Items.AddRange(playerOne.RecordingManager.GetRecordingWordsArrayRandomized());
            }

            DisableAllScreens();

            groupBoxGuessWords.Enabled = true;
            groupBoxGuessWords.Location = new Point(12, 12);
            buttonNext.Location = new Point(403, 347);
            buttonNext.Enabled = true;
            buttonNext.Enabled = true;
            this.Size = new Size(521, 428);

            currentWord = 1;
            buttonGuess.Text = "Guess and go to next word";
            buttonNext.Enabled = false;
            groupBoxGuessWords.Enabled = true;

            UpdateCurrentWordLabel();
        }

        /// <summary>
        /// Sets screen index to 5 depending on player and shows the result
        /// screen while disabling and hiding the other screens
        /// </summary>
        private void ShowResultsScreen()
        {
            screenIndex = 5;

            DisableAllScreens();

            groupBoxResults.Enabled = true;
            groupBoxResults.Location = new Point(12, 12);
            buttonNext.Location = new Point(403, 347);
            buttonNext.Enabled = true;
            this.Size = new Size(521, 428);

            if (scoreboard.PlayerOneTotalPoints > scoreboard.PlayerTwoTotalPoints)
                labelResult.Text = playerOne.PlayerName + " won!";
            else if (scoreboard.PlayerOneTotalPoints < scoreboard.PlayerTwoTotalPoints)
                labelResult.Text = playerTwo.PlayerName + " won!";
            else //A draw
                labelResult.Text = "It was a draw";

            PopulateResultListBox();

            buttonNext.Text = "Exit";
        }

        /// <summary>
        /// Disables and hides all screens from view
        /// </summary>
        private void DisableAllScreens()
        {
            groupBoxOptions.Enabled = false;
            groupBoxOptions.Location = new Point(580, 12);
            groupBoxRecordWords.Enabled = false;
            groupBoxRecordWords.Location = new Point(580, 12);
            groupBoxGuessWords.Enabled = false;
            groupBoxGuessWords.Location = new Point(580, 12);
            groupBoxResults.Enabled = false;
            groupBoxResults.Location = new Point(580, 12);
        }

        /// <summary>
        /// When next button is pressed the next screen is shown based
        /// on current screenIndex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNext_Click(object sender, EventArgs e)
        {
            switch(screenIndex)
            {
                case 0:
                    if (comboBoxInput.SelectedIndex == -1 || comboBoxOutput.SelectedIndex == -1)
                        MessageBox.Show("You need to select input and output devices", "Forgot something?");
                    else if (textBoxNamePlayer1.Text == string.Empty || textBoxNamePlayer2.Text == string.Empty)
                        MessageBox.Show("Please enter names for both players!", "Forgot something?");
                    else
                    {
                        playerOne.PlayerName = textBoxNamePlayer1.Text;
                        playerTwo.PlayerName = textBoxNamePlayer2.Text;
                        inputDeviceIndex = comboBoxInput.SelectedIndex;
                        outputDeviceIndex = comboBoxOutput.SelectedIndex;
                        ShowRecordWordsScreen(1);
                    }
                    break;
                case 1:
                    if (listBoxWords.Items.Count == maxNumberOfWords)
                        ShowRecordWordsScreen(2);
                    else
                        MessageBox.Show("You need to create " + maxNumberOfWords + " words to continue");
                    break;
                case 2:
                    if (listBoxWords.Items.Count == maxNumberOfWords)
                        ShowGuessWordsScreen(1);
                    else
                        MessageBox.Show("You need to create " + maxNumberOfWords + " words to continue");
                    break;
                case 3:
                    ShowGuessWordsScreen(2);
                    break;
                case 4:
                    ShowResultsScreen();
                    break;
                case 5:
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// When record button is pressed recordStart method from
        /// waveRecorder is used to record sound input from microphone.
        /// The recordButton will now act as recordStopButton until it is
        /// pressed again.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRecord_Click(object sender, EventArgs e)
        {
            if (buttonRecord.Text == "Start recording")
            {
                waveRecorder.RecordStart(inputDeviceIndex, currentPlayer);
                buttonRecord.Text = "Stop recording";
            }
            else
            {
                waveRecorder.RecordStop();
                buttonRecord.Text = "Start recording";
                buttonAddWord.Enabled = true;
            }
        }

        /// <summary>
        /// Button that reverses the word that was previously recorded
        /// and adds both the normal and reversed recording to the list of recordings
        /// of the current player. The wordsListBox is updated with the new word.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddWord_Click(object sender, EventArgs e)
        {
            if (textBoxWord.Text == string.Empty || textBoxWord.Text.Length > maxWordLength)
                MessageBox.Show("You need to enter a word with a maximum of lenght of " + maxWordLength.ToString() +
                    " characters first", "Could not add word");
            else if (listBoxWords.Items.Count == 10)
                MessageBox.Show("Max number of words already added.");
            else
            {
                waveRecorder.NormalizeWave();
                waveRecorder.ReverseWave(currentPlayer);

                Recording recording = new Recording(textBoxWord.Text, waveRecorder.FilePath, waveRecorder.ReversedFilePath);
                if (currentPlayer == 1) //Player one is recording
                    playerOne.RecordingManager.AddRecording(recording);
                else //Player two is recording
                    playerTwo.RecordingManager.AddRecording(recording);

                waveRecorder.IncrementFileNumber();
                buttonAddWord.Enabled = false;
                textBoxWord.Text = string.Empty;
                UpdateWordsListBox();
            }
        }

        /// <summary>
        /// Updates the listBoxWords with the words of the current player
        /// </summary>
        private void UpdateWordsListBox()
        {
            string[] recordingArray;

            if (currentPlayer == 1)
                recordingArray = playerOne.RecordingManager.GetRecordingWordsArray();
            else //currentPlayer == 2
                recordingArray = playerTwo.RecordingManager.GetRecordingWordsArray();

            listBoxWords.Items.Clear();
            listBoxWords.Items.AddRange(recordingArray);

            labelWordCount.Text = listBoxWords.Items.Count.ToString() + "/" + maxNumberOfWords + " words";
        }

        /// <summary>
        /// Removes the selected word from the list and from the recordingManager of
        /// the current player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveWord_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxWords.SelectedIndex;
            if (selectedIndex > -1 && currentPlayer == 1)
            {
                playerOne.RecordingManager.DeleteRecordingAt(selectedIndex);
                UpdateWordsListBox();
            }
            else if (selectedIndex > -1 && currentPlayer == 2)
            {
                playerTwo.RecordingManager.DeleteRecordingAt(selectedIndex);
                UpdateWordsListBox();
            }
            else
                MessageBox.Show("Please select a word to remove first");
        }

        /// <summary>
        /// Plays the normal version of the recorded word
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRecordWordsListen_Click(object sender, EventArgs e)
        {
            int listBoxWordsIndex = listBoxWords.SelectedIndex;
            if (listBoxWordsIndex > -1 && currentPlayer == 1)
            {
                Recording recording = playerOne.RecordingManager.GetRecordingAt(listBoxWordsIndex);
                waveRecorder.PlayWave(recording.WaveFilePath, outputDeviceIndex);
            }
            else if (listBoxWordsIndex > -1 && currentPlayer == 2)
            {
                Recording recording = playerTwo.RecordingManager.GetRecordingAt(listBoxWordsIndex);
                waveRecorder.PlayWave(recording.WaveFilePath, outputDeviceIndex);
            }
            else //No word is selected
                MessageBox.Show("Please select a word first", "Could not play recording");
        }

        /// <summary>
        /// Plays a reversed version of the recorded word
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRecordWordsListenReverse_Click(object sender, EventArgs e)
        {
            int listBoxWordsIndex = listBoxWords.SelectedIndex;
            if (listBoxWordsIndex > -1 && currentPlayer == 1)
            {
                Recording recording = playerOne.RecordingManager.GetRecordingAt(listBoxWordsIndex);
                waveRecorder.PlayWaveSlowed(recording.ReversedWaveFilePath, outputDeviceIndex);
            }
            else if (listBoxWordsIndex > -1 && currentPlayer == 2)
            {
                Recording recording = playerTwo.RecordingManager.GetRecordingAt(listBoxWordsIndex);
                waveRecorder.PlayWaveSlowed(recording.ReversedWaveFilePath, outputDeviceIndex);
            }
            else //No word is selected
                MessageBox.Show("Please select a word first", "Could not play recording");
        }

        /// <summary>
        /// When a word is chosen the buttons to remove and listen to 
        /// that word is enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBoxWords.SelectedIndex;
            if (selectedIndex > -1)
            {
                buttonRemoveWord.Enabled = true;
                buttonRecordWordsListen.Enabled = true;
                buttonRecordWordsListenReverse.Enabled = true;
            }
            else
            {
                buttonRemoveWord.Enabled = false;
                buttonRecordWordsListen.Enabled = false;
                buttonRecordWordsListenReverse.Enabled = false;
            }
        }

        /// <summary>
        /// Plays a reversed version of the current word for the player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonListenToWord_Click(object sender, EventArgs e)
        {
            if (currentPlayer == 1)
            {
                Recording recording = playerTwo.RecordingManager.GetRecordingAt(currentWord - 1);
                waveRecorder.PlayWave(recording.ReversedWaveFilePath, outputDeviceIndex);
            }
            else if (currentPlayer == 2)
            {
                Recording recording = playerOne.RecordingManager.GetRecordingAt(currentWord - 1);
                waveRecorder.PlayWave(recording.ReversedWaveFilePath, outputDeviceIndex);
            }
        }
        
        /// <summary>
        /// Awards player point and saves the guessed word for result screen.
        /// Goes to next word if there is one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGuess_Click(object sender, EventArgs e)
        {
            if (comboBoxWords.SelectedIndex > -1) //If a word is chosen in the comboBox
            {
                AwardPlayerPoints();

                if (currentWord < maxNumberOfWords)
                    NextWord(); //Go to next word
                else if (currentWord == maxNumberOfWords)
                {
                    groupBoxGuessWords.Enabled = false;
                    buttonNext.Enabled = true;
                }

                comboBoxWords.SelectedIndex = -1;
            }
            else
                MessageBox.Show("Select a word from the list to guess");

            this.ActiveControl = buttonListenToWord;
        }

        /// <summary>
        /// Increments the currenWord variable. Updates the text of the
        /// guess button and the number of the current word label.
        /// </summary>
        private void NextWord()
        {
            if (currentWord == maxNumberOfWords - 1)
            {
                currentWord++;
                buttonGuess.Text = "Guess last word - Done";
            }
            else if (currentWord < maxNumberOfWords - 1)
            {
                currentWord++;
                buttonGuess.Text = "Guess and go to next word";
            }

            UpdateCurrentWordLabel();
        }

        /// <summary>
        /// Updates the currentWordLabel with the currentWord and maxNumberOfWords
        /// </summary>
        private void UpdateCurrentWordLabel()
        {
            labelCurrentWord.Text = $"Word {currentWord}/{maxNumberOfWords}";
        }

        /// <summary>
        /// Stores the guessedWord and correctWord for results screen. Gives point to currentPlayer
        /// if the guessedWord is the same as the correctWord.
        /// </summary>
        private void AwardPlayerPoints()
        {
            if (currentPlayer == 1)
            {
                string guessedWord = comboBoxWords.Text;
                string correctWord = playerTwo.RecordingManager.GetRecordingAt(currentWord - 1).WordString;
                scoreboard.GivePointToPlayer(currentPlayer, guessedWord, correctWord);
            }
            else if (currentPlayer == 2)
            {
                string guessedWord = comboBoxWords.Text;
                string correctWord = playerOne.RecordingManager.GetRecordingAt(currentWord - 1).WordString;
                scoreboard.GivePointToPlayer(currentPlayer, guessedWord, correctWord);
            }
        }

        /// <summary>
        /// The chosen number of words from the options screen is saved as integer maxNumberOfWords
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownNumOfWords_ValueChanged(object sender, EventArgs e)
        {
            decimal numOfWords = numericUpDownNumOfWords.Value;
            maxNumberOfWords = Convert.ToInt32(numOfWords);
        }
        
        /// <summary>
        /// Shows a result screen
        /// </summary>
        private void PopulateResultListBox()
        {
            listBoxResult.Items.Clear();
            listBoxResult.Items.Add("Results for " + playerOne.PlayerName);
            listBoxResult.Items.Add(string.Format("{0, -25}CORRECT WORD", "GUESSED WORD"));
            listBoxResult.Items.AddRange(scoreboard.GetPlayerResult(1));
            listBoxResult.Items.Add(playerOne.PlayerName + " total points: " + scoreboard.PlayerOneTotalPoints);
            listBoxResult.Items.Add(""); //Empty line
            listBoxResult.Items.Add("Results for " + playerTwo.PlayerName);
            listBoxResult.Items.Add(string.Format("{0, -25}CORRECT WORD", "GUESSED WORD"));
            listBoxResult.Items.AddRange(scoreboard.GetPlayerResult(2));
            listBoxResult.Items.Add(playerTwo.PlayerName + " total points: " + scoreboard.PlayerTwoTotalPoints);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            waveRecorder.disposeWaveRecorder();
        }
    }
}