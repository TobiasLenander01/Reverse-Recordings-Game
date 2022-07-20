namespace TobiasLenanderAssignment7
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.numericUpDownNumOfWords = new System.Windows.Forms.NumericUpDown();
            this.labelChooseNumberOfWords = new System.Windows.Forms.Label();
            this.labelSelectDevices = new System.Windows.Forms.Label();
            this.textBoxNamePlayer2 = new System.Windows.Forms.TextBox();
            this.textBoxNamePlayer1 = new System.Windows.Forms.TextBox();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayerNames = new System.Windows.Forms.Label();
            this.comboBoxOutput = new System.Windows.Forms.ComboBox();
            this.comboBoxInput = new System.Windows.Forms.ComboBox();
            this.labelOutput = new System.Windows.Forms.Label();
            this.labelInput = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.groupBoxRecordWords = new System.Windows.Forms.GroupBox();
            this.buttonRecordWordsListenReverse = new System.Windows.Forms.Button();
            this.buttonRecordWordsListen = new System.Windows.Forms.Button();
            this.labelWordCount = new System.Windows.Forms.Label();
            this.buttonRemoveWord = new System.Windows.Forms.Button();
            this.buttonAddWord = new System.Windows.Forms.Button();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.textBoxWord = new System.Windows.Forms.TextBox();
            this.listBoxWords = new System.Windows.Forms.ListBox();
            this.labelRecordWordsInstructions = new System.Windows.Forms.Label();
            this.groupBoxGuessWords = new System.Windows.Forms.GroupBox();
            this.labelCurrentWord = new System.Windows.Forms.Label();
            this.buttonGuess = new System.Windows.Forms.Button();
            this.comboBoxWords = new System.Windows.Forms.ComboBox();
            this.buttonListenToWord = new System.Windows.Forms.Button();
            this.labelGuessWordsInstructions = new System.Windows.Forms.Label();
            this.groupBoxResults = new System.Windows.Forms.GroupBox();
            this.listBoxResult = new System.Windows.Forms.ListBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.groupBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumOfWords)).BeginInit();
            this.groupBoxRecordWords.SuspendLayout();
            this.groupBoxGuessWords.SuspendLayout();
            this.groupBoxResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.numericUpDownNumOfWords);
            this.groupBoxOptions.Controls.Add(this.labelChooseNumberOfWords);
            this.groupBoxOptions.Controls.Add(this.labelSelectDevices);
            this.groupBoxOptions.Controls.Add(this.textBoxNamePlayer2);
            this.groupBoxOptions.Controls.Add(this.textBoxNamePlayer1);
            this.groupBoxOptions.Controls.Add(this.labelPlayer2);
            this.groupBoxOptions.Controls.Add(this.labelPlayer1);
            this.groupBoxOptions.Controls.Add(this.labelPlayerNames);
            this.groupBoxOptions.Controls.Add(this.comboBoxOutput);
            this.groupBoxOptions.Controls.Add(this.comboBoxInput);
            this.groupBoxOptions.Controls.Add(this.labelOutput);
            this.groupBoxOptions.Controls.Add(this.labelInput);
            this.groupBoxOptions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxOptions.Location = new System.Drawing.Point(12, 12);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(483, 329);
            this.groupBoxOptions.TabIndex = 0;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Configure options";
            // 
            // numericUpDownNumOfWords
            // 
            this.numericUpDownNumOfWords.Location = new System.Drawing.Point(349, 273);
            this.numericUpDownNumOfWords.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownNumOfWords.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumOfWords.Name = "numericUpDownNumOfWords";
            this.numericUpDownNumOfWords.Size = new System.Drawing.Size(73, 29);
            this.numericUpDownNumOfWords.TabIndex = 12;
            this.numericUpDownNumOfWords.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownNumOfWords.ValueChanged += new System.EventHandler(this.numericUpDownNumOfWords_ValueChanged);
            // 
            // labelChooseNumberOfWords
            // 
            this.labelChooseNumberOfWords.AutoSize = true;
            this.labelChooseNumberOfWords.Location = new System.Drawing.Point(62, 275);
            this.labelChooseNumberOfWords.Name = "labelChooseNumberOfWords";
            this.labelChooseNumberOfWords.Size = new System.Drawing.Size(260, 21);
            this.labelChooseNumberOfWords.TabIndex = 11;
            this.labelChooseNumberOfWords.Text = "Choose number of words per player";
            // 
            // labelSelectDevices
            // 
            this.labelSelectDevices.AutoSize = true;
            this.labelSelectDevices.Location = new System.Drawing.Point(68, 36);
            this.labelSelectDevices.Name = "labelSelectDevices";
            this.labelSelectDevices.Size = new System.Drawing.Size(226, 21);
            this.labelSelectDevices.TabIndex = 10;
            this.labelSelectDevices.Text = "Select input and output devices";
            // 
            // textBoxNamePlayer2
            // 
            this.textBoxNamePlayer2.Location = new System.Drawing.Point(150, 231);
            this.textBoxNamePlayer2.Name = "textBoxNamePlayer2";
            this.textBoxNamePlayer2.Size = new System.Drawing.Size(272, 29);
            this.textBoxNamePlayer2.TabIndex = 4;
            // 
            // textBoxNamePlayer1
            // 
            this.textBoxNamePlayer1.Location = new System.Drawing.Point(150, 196);
            this.textBoxNamePlayer1.Name = "textBoxNamePlayer1";
            this.textBoxNamePlayer1.Size = new System.Drawing.Size(272, 29);
            this.textBoxNamePlayer1.TabIndex = 3;
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.Location = new System.Drawing.Point(62, 233);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(69, 21);
            this.labelPlayer2.TabIndex = 7;
            this.labelPlayer2.Text = "Player 2:";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(62, 199);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(69, 21);
            this.labelPlayer1.TabIndex = 6;
            this.labelPlayer1.Text = "Player 1:";
            // 
            // labelPlayerNames
            // 
            this.labelPlayerNames.AutoSize = true;
            this.labelPlayerNames.Location = new System.Drawing.Point(62, 162);
            this.labelPlayerNames.Name = "labelPlayerNames";
            this.labelPlayerNames.Size = new System.Drawing.Size(159, 21);
            this.labelPlayerNames.TabIndex = 5;
            this.labelPlayerNames.Text = "Choose player names";
            // 
            // comboBoxOutput
            // 
            this.comboBoxOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOutput.FormattingEnabled = true;
            this.comboBoxOutput.Location = new System.Drawing.Point(150, 112);
            this.comboBoxOutput.Name = "comboBoxOutput";
            this.comboBoxOutput.Size = new System.Drawing.Size(272, 29);
            this.comboBoxOutput.TabIndex = 2;
            // 
            // comboBoxInput
            // 
            this.comboBoxInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInput.FormattingEnabled = true;
            this.comboBoxInput.Location = new System.Drawing.Point(150, 73);
            this.comboBoxInput.Name = "comboBoxInput";
            this.comboBoxInput.Size = new System.Drawing.Size(272, 29);
            this.comboBoxInput.TabIndex = 1;
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(68, 115);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(59, 21);
            this.labelOutput.TabIndex = 1;
            this.labelOutput.Text = "Output";
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(78, 76);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(46, 21);
            this.labelInput.TabIndex = 0;
            this.labelInput.Text = "Input";
            // 
            // buttonNext
            // 
            this.buttonNext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonNext.Location = new System.Drawing.Point(403, 347);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(92, 34);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = "Next ->";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // groupBoxRecordWords
            // 
            this.groupBoxRecordWords.Controls.Add(this.buttonRecordWordsListenReverse);
            this.groupBoxRecordWords.Controls.Add(this.buttonRecordWordsListen);
            this.groupBoxRecordWords.Controls.Add(this.labelWordCount);
            this.groupBoxRecordWords.Controls.Add(this.buttonRemoveWord);
            this.groupBoxRecordWords.Controls.Add(this.buttonAddWord);
            this.groupBoxRecordWords.Controls.Add(this.buttonRecord);
            this.groupBoxRecordWords.Controls.Add(this.textBoxWord);
            this.groupBoxRecordWords.Controls.Add(this.listBoxWords);
            this.groupBoxRecordWords.Controls.Add(this.labelRecordWordsInstructions);
            this.groupBoxRecordWords.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxRecordWords.Location = new System.Drawing.Point(516, 12);
            this.groupBoxRecordWords.Name = "groupBoxRecordWords";
            this.groupBoxRecordWords.Size = new System.Drawing.Size(548, 375);
            this.groupBoxRecordWords.TabIndex = 11;
            this.groupBoxRecordWords.TabStop = false;
            this.groupBoxRecordWords.Text = "Record words";
            // 
            // buttonRecordWordsListenReverse
            // 
            this.buttonRecordWordsListenReverse.Location = new System.Drawing.Point(413, 274);
            this.buttonRecordWordsListenReverse.Name = "buttonRecordWordsListenReverse";
            this.buttonRecordWordsListenReverse.Size = new System.Drawing.Size(119, 85);
            this.buttonRecordWordsListenReverse.TabIndex = 11;
            this.buttonRecordWordsListenReverse.Text = "Listen to word in reverse";
            this.buttonRecordWordsListenReverse.UseVisualStyleBackColor = true;
            this.buttonRecordWordsListenReverse.Click += new System.EventHandler(this.buttonRecordWordsListenReverse_Click);
            // 
            // buttonRecordWordsListen
            // 
            this.buttonRecordWordsListen.Location = new System.Drawing.Point(413, 231);
            this.buttonRecordWordsListen.Name = "buttonRecordWordsListen";
            this.buttonRecordWordsListen.Size = new System.Drawing.Size(119, 37);
            this.buttonRecordWordsListen.TabIndex = 10;
            this.buttonRecordWordsListen.Text = "Listen to word";
            this.buttonRecordWordsListen.UseVisualStyleBackColor = true;
            this.buttonRecordWordsListen.Click += new System.EventHandler(this.buttonRecordWordsListen_Click);
            // 
            // labelWordCount
            // 
            this.labelWordCount.Location = new System.Drawing.Point(412, 103);
            this.labelWordCount.Name = "labelWordCount";
            this.labelWordCount.Size = new System.Drawing.Size(107, 24);
            this.labelWordCount.TabIndex = 17;
            this.labelWordCount.Text = "0/10 words";
            this.labelWordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonRemoveWord
            // 
            this.buttonRemoveWord.Location = new System.Drawing.Point(413, 188);
            this.buttonRemoveWord.Name = "buttonRemoveWord";
            this.buttonRemoveWord.Size = new System.Drawing.Size(119, 37);
            this.buttonRemoveWord.TabIndex = 9;
            this.buttonRemoveWord.Text = "Remove word";
            this.buttonRemoveWord.UseVisualStyleBackColor = true;
            this.buttonRemoveWord.Click += new System.EventHandler(this.buttonRemoveWord_Click);
            // 
            // buttonAddWord
            // 
            this.buttonAddWord.Location = new System.Drawing.Point(412, 68);
            this.buttonAddWord.Name = "buttonAddWord";
            this.buttonAddWord.Size = new System.Drawing.Size(119, 29);
            this.buttonAddWord.TabIndex = 8;
            this.buttonAddWord.Text = "Add";
            this.buttonAddWord.UseVisualStyleBackColor = true;
            this.buttonAddWord.Click += new System.EventHandler(this.buttonAddWord_Click);
            // 
            // buttonRecord
            // 
            this.buttonRecord.Location = new System.Drawing.Point(251, 68);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(156, 29);
            this.buttonRecord.TabIndex = 7;
            this.buttonRecord.Text = "Start recording";
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // textBoxWord
            // 
            this.textBoxWord.Location = new System.Drawing.Point(23, 68);
            this.textBoxWord.Name = "textBoxWord";
            this.textBoxWord.Size = new System.Drawing.Size(222, 29);
            this.textBoxWord.TabIndex = 6;
            // 
            // listBoxWords
            // 
            this.listBoxWords.FormattingEnabled = true;
            this.listBoxWords.ItemHeight = 21;
            this.listBoxWords.Location = new System.Drawing.Point(23, 103);
            this.listBoxWords.Name = "listBoxWords";
            this.listBoxWords.Size = new System.Drawing.Size(384, 256);
            this.listBoxWords.TabIndex = 12;
            this.listBoxWords.SelectedIndexChanged += new System.EventHandler(this.listBoxWords_SelectedIndexChanged);
            // 
            // labelRecordWordsInstructions
            // 
            this.labelRecordWordsInstructions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRecordWordsInstructions.Location = new System.Drawing.Point(23, 31);
            this.labelRecordWordsInstructions.Name = "labelRecordWordsInstructions";
            this.labelRecordWordsInstructions.Size = new System.Drawing.Size(519, 34);
            this.labelRecordWordsInstructions.TabIndex = 11;
            this.labelRecordWordsInstructions.Text = "Player 1 will start with recording words. Player 2 should leave the room.";
            // 
            // groupBoxGuessWords
            // 
            this.groupBoxGuessWords.Controls.Add(this.labelCurrentWord);
            this.groupBoxGuessWords.Controls.Add(this.buttonGuess);
            this.groupBoxGuessWords.Controls.Add(this.comboBoxWords);
            this.groupBoxGuessWords.Controls.Add(this.buttonListenToWord);
            this.groupBoxGuessWords.Controls.Add(this.labelGuessWordsInstructions);
            this.groupBoxGuessWords.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxGuessWords.Location = new System.Drawing.Point(12, 433);
            this.groupBoxGuessWords.Name = "groupBoxGuessWords";
            this.groupBoxGuessWords.Size = new System.Drawing.Size(483, 329);
            this.groupBoxGuessWords.TabIndex = 12;
            this.groupBoxGuessWords.TabStop = false;
            this.groupBoxGuessWords.Text = "Guess words";
            // 
            // labelCurrentWord
            // 
            this.labelCurrentWord.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCurrentWord.Location = new System.Drawing.Point(78, 77);
            this.labelCurrentWord.Name = "labelCurrentWord";
            this.labelCurrentWord.Size = new System.Drawing.Size(110, 30);
            this.labelCurrentWord.TabIndex = 19;
            this.labelCurrentWord.Text = "Word 1/10";
            // 
            // buttonGuess
            // 
            this.buttonGuess.BackColor = System.Drawing.Color.LightGray;
            this.buttonGuess.ForeColor = System.Drawing.Color.Black;
            this.buttonGuess.Location = new System.Drawing.Point(197, 146);
            this.buttonGuess.Name = "buttonGuess";
            this.buttonGuess.Size = new System.Drawing.Size(215, 41);
            this.buttonGuess.TabIndex = 17;
            this.buttonGuess.Text = "Guess and go to next word";
            this.buttonGuess.UseVisualStyleBackColor = false;
            this.buttonGuess.Click += new System.EventHandler(this.buttonGuess_Click);
            // 
            // comboBoxWords
            // 
            this.comboBoxWords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWords.FormattingEnabled = true;
            this.comboBoxWords.Location = new System.Drawing.Point(197, 111);
            this.comboBoxWords.Name = "comboBoxWords";
            this.comboBoxWords.Size = new System.Drawing.Size(215, 29);
            this.comboBoxWords.TabIndex = 16;
            // 
            // buttonListenToWord
            // 
            this.buttonListenToWord.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonListenToWord.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonListenToWord.ForeColor = System.Drawing.Color.White;
            this.buttonListenToWord.Location = new System.Drawing.Point(78, 111);
            this.buttonListenToWord.Name = "buttonListenToWord";
            this.buttonListenToWord.Size = new System.Drawing.Size(113, 76);
            this.buttonListenToWord.TabIndex = 15;
            this.buttonListenToWord.Text = "Listen to word";
            this.buttonListenToWord.UseVisualStyleBackColor = false;
            this.buttonListenToWord.Click += new System.EventHandler(this.buttonListenToWord_Click);
            // 
            // labelGuessWordsInstructions
            // 
            this.labelGuessWordsInstructions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGuessWordsInstructions.Location = new System.Drawing.Point(23, 36);
            this.labelGuessWordsInstructions.Name = "labelGuessWordsInstructions";
            this.labelGuessWordsInstructions.Size = new System.Drawing.Size(421, 29);
            this.labelGuessWordsInstructions.TabIndex = 13;
            this.labelGuessWordsInstructions.Text = "Player 1 will start guessing words. Player 2 can watch.";
            // 
            // groupBoxResults
            // 
            this.groupBoxResults.Controls.Add(this.listBoxResult);
            this.groupBoxResults.Controls.Add(this.labelResult);
            this.groupBoxResults.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxResults.Location = new System.Drawing.Point(516, 433);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Size = new System.Drawing.Size(483, 329);
            this.groupBoxResults.TabIndex = 13;
            this.groupBoxResults.TabStop = false;
            this.groupBoxResults.Text = "Results";
            // 
            // listBoxResult
            // 
            this.listBoxResult.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxResult.FormattingEnabled = true;
            this.listBoxResult.ItemHeight = 16;
            this.listBoxResult.Location = new System.Drawing.Point(6, 89);
            this.listBoxResult.Name = "listBoxResult";
            this.listBoxResult.Size = new System.Drawing.Size(471, 228);
            this.listBoxResult.TabIndex = 18;
            // 
            // labelResult
            // 
            this.labelResult.Location = new System.Drawing.Point(77, 36);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(330, 29);
            this.labelResult.TabIndex = 17;
            this.labelResult.Text = "Player X won the game!";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 779);
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.groupBoxGuessWords);
            this.Controls.Add(this.groupBoxRecordWords);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.buttonNext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reverse Recordings Game by Tobias Lenander";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumOfWords)).EndInit();
            this.groupBoxRecordWords.ResumeLayout(false);
            this.groupBoxRecordWords.PerformLayout();
            this.groupBoxGuessWords.ResumeLayout(false);
            this.groupBoxResults.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxOptions;
        private Label labelSelectDevices;
        private TextBox textBoxNamePlayer2;
        private TextBox textBoxNamePlayer1;
        private Label labelPlayer2;
        private Label labelPlayer1;
        private Label labelPlayerNames;
        private ComboBox comboBoxOutput;
        private ComboBox comboBoxInput;
        private Label labelOutput;
        private Label labelInput;
        private Button buttonNext;
        private GroupBox groupBoxRecordWords;
        private ListBox listBoxWords;
        private Label labelRecordWordsInstructions;
        private GroupBox groupBoxGuessWords;
        private GroupBox groupBoxResults;
        private Label labelGuessWordsInstructions;
        private Button buttonRecordWordsListenReverse;
        private Button buttonRecordWordsListen;
        private Label labelWordCount;
        private Button buttonRemoveWord;
        private Button buttonAddWord;
        private Button buttonRecord;
        private TextBox textBoxWord;
        private Button buttonGuess;
        private ComboBox comboBoxWords;
        private Button buttonListenToWord;
        private Label labelResult;
        private Label labelCurrentWord;
        private Label labelChooseNumberOfWords;
        private NumericUpDown numericUpDownNumOfWords;
        private ListBox listBoxResult;
    }
}