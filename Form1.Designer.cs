namespace YugiohRandomDeckMaker
{
    partial class YugiohRandomizer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.confSourceFilePath = new System.Windows.Forms.TextBox();
            this.GenerateDeck = new System.Windows.Forms.Button();
            this.numUpDownRandomLines = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lstBoxRandomDeck = new System.Windows.Forms.ListBox();
            this.SaveDeck = new System.Windows.Forms.Button();
            this.ExtraDeck = new System.Windows.Forms.CheckBox();
            this.RerollCounter = new System.Windows.Forms.TextBox();
            this.BackgroundPictureBox = new System.Windows.Forms.PictureBox();
            this.LogoBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Banlist Files (*.conf)|*.conf|All Files (*.*)|*.*";
            this.openFileDialog1.Title = "Draft Banlist";
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(670, 295);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(96, 20);
            this.BrowseBtn.TabIndex = 0;
            this.BrowseBtn.Text = "Browse";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // confSourceFilePath
            // 
            this.confSourceFilePath.Location = new System.Drawing.Point(338, 295);
            this.confSourceFilePath.Name = "confSourceFilePath";
            this.confSourceFilePath.Size = new System.Drawing.Size(326, 20);
            this.confSourceFilePath.TabIndex = 1;
            this.confSourceFilePath.Text = "Search for Banlist";
            this.confSourceFilePath.TextChanged += new System.EventHandler(this.confSourceFilePath_TextChanged);
            // 
            // GenerateDeck
            // 
            this.GenerateDeck.Location = new System.Drawing.Point(338, 346);
            this.GenerateDeck.Name = "GenerateDeck";
            this.GenerateDeck.Size = new System.Drawing.Size(326, 78);
            this.GenerateDeck.TabIndex = 2;
            this.GenerateDeck.Text = "Generate Deck";
            this.GenerateDeck.UseVisualStyleBackColor = true;
            this.GenerateDeck.Click += new System.EventHandler(this.GenerateDeck_Click);
            // 
            // numUpDownRandomLines
            // 
            this.numUpDownRandomLines.AutoSize = true;
            this.numUpDownRandomLines.Location = new System.Drawing.Point(429, 323);
            this.numUpDownRandomLines.Name = "numUpDownRandomLines";
            this.numUpDownRandomLines.Size = new System.Drawing.Size(82, 17);
            this.numUpDownRandomLines.TabIndex = 3;
            this.numUpDownRandomLines.Text = "Side Deck?";
            this.numUpDownRandomLines.UseVisualStyleBackColor = true;
            this.numUpDownRandomLines.CheckedChanged += new System.EventHandler(this.numUpDownRandomLines_CheckedChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // lstBoxRandomDeck
            // 
            this.lstBoxRandomDeck.FormattingEnabled = true;
            this.lstBoxRandomDeck.Location = new System.Drawing.Point(12, 17);
            this.lstBoxRandomDeck.Name = "lstBoxRandomDeck";
            this.lstBoxRandomDeck.Size = new System.Drawing.Size(302, 407);
            this.lstBoxRandomDeck.TabIndex = 4;
            // 
            // SaveDeck
            // 
            this.SaveDeck.Location = new System.Drawing.Point(670, 346);
            this.SaveDeck.Name = "SaveDeck";
            this.SaveDeck.Size = new System.Drawing.Size(96, 78);
            this.SaveDeck.TabIndex = 5;
            this.SaveDeck.Text = "SaveDeck";
            this.SaveDeck.UseVisualStyleBackColor = true;
            this.SaveDeck.Click += new System.EventHandler(this.SaveDeck_Click);
            // 
            // ExtraDeck
            // 
            this.ExtraDeck.AutoSize = true;
            this.ExtraDeck.Location = new System.Drawing.Point(338, 323);
            this.ExtraDeck.Name = "ExtraDeck";
            this.ExtraDeck.Size = new System.Drawing.Size(85, 17);
            this.ExtraDeck.TabIndex = 6;
            this.ExtraDeck.Text = "Extra Deck?";
            this.ExtraDeck.UseVisualStyleBackColor = true;
            this.ExtraDeck.CheckedChanged += new System.EventHandler(this.ExtraDeck_CheckedChanged);
            // 
            // RerollCounter
            // 
            this.RerollCounter.Location = new System.Drawing.Point(670, 320);
            this.RerollCounter.Name = "RerollCounter";
            this.RerollCounter.Size = new System.Drawing.Size(96, 20);
            this.RerollCounter.TabIndex = 7;
            this.RerollCounter.Text = "Rerolls: 0";
            this.RerollCounter.TextChanged += new System.EventHandler(this.RerollCounter_TextChanged);
            // 
            // BackgroundPictureBox
            // 
            this.BackgroundPictureBox.Location = new System.Drawing.Point(338, 140);
            this.BackgroundPictureBox.Name = "BackgroundPictureBox";
            this.BackgroundPictureBox.Size = new System.Drawing.Size(428, 149);
            this.BackgroundPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BackgroundPictureBox.TabIndex = 8;
            this.BackgroundPictureBox.TabStop = false;
            this.BackgroundPictureBox.Click += new System.EventHandler(this.BackgroundPictureBox_Click);
            // 
            // LogoBox
            // 
            this.LogoBox.Location = new System.Drawing.Point(338, 17);
            this.LogoBox.Name = "LogoBox";
            this.LogoBox.Size = new System.Drawing.Size(428, 117);
            this.LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoBox.TabIndex = 9;
            this.LogoBox.TabStop = false;
            // 
            // YugiohRandomizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LogoBox);
            this.Controls.Add(this.RerollCounter);
            this.Controls.Add(this.ExtraDeck);
            this.Controls.Add(this.SaveDeck);
            this.Controls.Add(this.lstBoxRandomDeck);
            this.Controls.Add(this.numUpDownRandomLines);
            this.Controls.Add(this.GenerateDeck);
            this.Controls.Add(this.confSourceFilePath);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.BackgroundPictureBox);
            this.Name = "YugiohRandomizer";
            this.Text = "YugiohRandomizer";
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.TextBox confSourceFilePath;
        private System.Windows.Forms.Button GenerateDeck;
        private System.Windows.Forms.CheckBox numUpDownRandomLines;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ListBox lstBoxRandomDeck;
        private System.Windows.Forms.Button SaveDeck;
        private System.Windows.Forms.CheckBox ExtraDeck;
        private System.Windows.Forms.TextBox RerollCounter;
        private System.Windows.Forms.PictureBox BackgroundPictureBox;
        private System.Windows.Forms.PictureBox LogoBox;
    }
}

