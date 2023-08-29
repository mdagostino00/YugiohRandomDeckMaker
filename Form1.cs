using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YugiohRandomDeckMaker.Classes;

namespace YugiohRandomDeckMaker
{
    public partial class YugiohRandomizer : Form
    {
        private int rerollCount = 0;

        public YugiohRandomizer()
        {
            InitializeComponent();

            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Construct relative paths using Path.Combine
            string cardDatabaseDirectory = Path.Combine(appDirectory, "CardDatabase");
            string configFile = Path.Combine(appDirectory, "config.txt");

            // Load CSV cards using relative path
            string relativePath = Path.Combine(appDirectory, "Assets");

            // Load and display the PNG image
            string imagePath = $"{relativePath}\\yugiohrandomizerbackground.png"; // Replace with the actual path to your PNG image
            LoadAndDisplayImage(imagePath, BackgroundPictureBox);
            imagePath = $"{relativePath}\\yugiohrandomizerlogo.png"; // Replace with the actual path to your PNG image
            LoadAndDisplayImage(imagePath, LogoBox);
        }

        private void LoadAndDisplayImage(string imagePath, PictureBox box)
        {
            try
            {
                // Load the PNG image from the specified path
                Image image = Image.FromFile(imagePath);

                // Set the loaded image as the PictureBox's Image property
                box.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                confSourceFilePath.Text = selectedFilePath;
            }
        }

        private void confSourceFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void GenerateDeck_Click(object sender, EventArgs e)
        {
            string sourceFilePath = confSourceFilePath.Text;
            string destFilePath = Application.StartupPath;
            int mainDeckCards = 40;
            int sideDeckCards = numUpDownRandomLines.Checked ? 15 : 0;
            int extraDeckCards = ExtraDeck.Checked ? 15 : 0;

            if (!File.Exists(sourceFilePath))
            {
                MessageBox.Show("Source file does not exist.");
                return;
            }

            Banlist banlist = new Banlist(sourceFilePath);
            Deck randomDeck = banlist.GenerateRandomDeck(mainDeckCards, sideDeckCards, extraDeckCards);
            lstBoxRandomDeck.Items.Clear();

            // Display cards from the "Main" section
            lstBoxRandomDeck.Items.Add("Main:");
            foreach (KeyValuePair<Card, int> cardEntry in randomDeck.Cards)
            {
                lstBoxRandomDeck.Items.Add($"  {cardEntry.Key.Name} x{cardEntry.Value}");
            }

            // Display cards from the "Extra" section (if ExtraDeck is not null)
            if (randomDeck.ExtraDeck != null)
            {
                lstBoxRandomDeck.Items.Add("Extra:");
                foreach (KeyValuePair<Card, int> cardEntry in randomDeck.ExtraDeck)
                {
                    lstBoxRandomDeck.Items.Add($"  {cardEntry.Key.Name} x{cardEntry.Value}");
                }
            }

            // Display cards from the "SideDeck" section (if SideDeck is not null)
            if (randomDeck.SideDeck != null)
            {
                lstBoxRandomDeck.Items.Add("SideDeck:");
                foreach (KeyValuePair<Card, int> cardEntry in randomDeck.SideDeck)
                {
                    lstBoxRandomDeck.Items.Add($"  {cardEntry.Key.Name} x{cardEntry.Value}");
                }
            }

            // Store the deck content in the list box's Tag property for later saving
            lstBoxRandomDeck.Tag = randomDeck.GenerateFileContent();

            rerollCount++;
            RerollCounter.Text = $"Reroll Count: {rerollCount}";
            MessageBox.Show("Deck Generated Successfully.");
        }

        private void numUpDownRandomLines_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void SaveDeck_Click(object sender, EventArgs e)
        {
            if (lstBoxRandomDeck.Tag is string deckContent && !string.IsNullOrEmpty(deckContent))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Deck Files|*.ydk";
                    saveFileDialog.Title = "Save Deck File";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        File.WriteAllText(filePath, deckContent);
                        MessageBox.Show("Deck saved successfully.");
                        deckContent = deckContent.Replace("----", "--");
                        File.WriteAllText("BanlistFormatDeck.ydk", deckContent);
                    }
                }
            }
            else
            {
                MessageBox.Show("No deck content to save.");
            }
        }

        private void ExtraDeck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RerollCounter_TextChanged(object sender, EventArgs e)
        {

        }

        private void BackgroundPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
