using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YugiohRandomDeckMaker.Classes
{
    internal class Banlist
    {
        public Banlist(string filename) {
            BanlistFromFile(filename);
        }
        public string Name { get; set; }
        public List<Card> cards;
        public List<Card> extradeck;

        private void BanlistFromFile(string filename)
        {
            List<Card> mainDeckCards = new List<Card>();
            List<Card> extraDeckCards = new List<Card>();

            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Construct relative paths using Path.Combine
            string cardDatabaseDirectory = Path.Combine(appDirectory, "CardDatabase");
            string configFile = Path.Combine(appDirectory, "config.txt");

            // Load CSV cards using relative path
            string relativePath = Path.Combine(appDirectory, "CardDatabase");
            List<CSVCard> csvCards = CSVHandler.LoadCardsFromCsvDirectory(relativePath);

            string[] lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                if (line.StartsWith("!"))
                {
                    Name = line.TrimStart('!', ' ');
                }
                else if (line.StartsWith("#"))
                {
                    // Skip comment lines
                }
                else if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] parts = line.Split(' ');
                    if (parts.Length >= 3)
                    {
                        Card card = new Card
                        {
                            Id = parts[0],
                            Name = string.Join(" ", parts, 2, parts.Length - 2)
                        };

                        if (IsExtraDeckType(card, csvCards))
                        {
                            int count = int.Parse(parts[1]); // Get the count from parts[1]
                            for (int i = 0; i < count; i++)
                            {
                                extraDeckCards.Add(card);
                            }
                        }
                        else
                        {
                            int count = int.Parse(parts[1]); // Get the count from parts[1]
                            for (int i = 0; i < count; i++)
                            {
                                mainDeckCards.Add(card);
                            }
                        }
                    }
                }
            }

            cards = mainDeckCards;
            extradeck = extraDeckCards;
        }

        bool IsExtraDeckType(Card card, List<CSVCard> csvCards)
        {
            return csvCards.Any(csvCard =>
                csvCard.Passcode == card.Id &&
                (IsTypeMatching(csvCard.Type, "fusion") ||
                 IsTypeMatching(csvCard.Type, "synchro") ||
                 IsTypeMatching(csvCard.Type, "xyz") ||
                 IsTypeMatching(csvCard.Type, "link") ||
                 IsTypeMatching(csvCard.Type, "token"))
            );
        }

        public Deck GenerateRandomDeck(int mainDeckCards, int sideDeckCards, int extraDeckCards)
        {
            if (mainDeckCards <= 0 || mainDeckCards > cards.Count)
            {
                throw new ArgumentException("Invalid number of main deck cards.");
            }

            if (sideDeckCards < 0 || sideDeckCards > cards.Count)
            {
                throw new ArgumentException("Invalid number of side deck cards.");
            }

            if (extraDeckCards < 0 || extraDeckCards > extradeck.Count)
            {
                throw new ArgumentException("Invalid number of extra deck cards.");
            }

            Random random = new Random();
            Dictionary<Card, int> mainDeckSelectedCards = new Dictionary<Card, int>();
            Dictionary<Card, int> sideDeckSelectedCards = new Dictionary<Card, int>();
            Dictionary<Card, int> extraDeckSelectedCards = new Dictionary<Card, int>();

            // Add cards to the main deck
            for (int i = 0; i < mainDeckCards; i++)
            {
                int randomIndex = random.Next(cards.Count);
                Card selectedCard = cards[randomIndex];

                if (mainDeckSelectedCards.ContainsKey(selectedCard))
                {
                    mainDeckSelectedCards[selectedCard]++;
                }
                else
                {
                    mainDeckSelectedCards[selectedCard] = 1;
                }

                // Remove one copy of the selected card from the list
                cards.RemoveAt(randomIndex);
            }

            // Add cards to the side deck
            for (int i = 0; i < sideDeckCards; i++)
            {
                int randomIndex = random.Next(cards.Count);
                Card selectedCard = cards[randomIndex];

                if (sideDeckSelectedCards.ContainsKey(selectedCard))
                {
                    sideDeckSelectedCards[selectedCard]++;
                }
                else
                {
                    sideDeckSelectedCards[selectedCard] = 1;
                }

                // Remove one copy of the selected card from the list
                cards.RemoveAt(randomIndex);
            }

            // Add cards to the extra deck
            for (int i = 0; i < extraDeckCards; i++)
            {
                int randomIndex = random.Next(extradeck.Count);
                Card selectedCard = extradeck[randomIndex];

                if (extraDeckSelectedCards.ContainsKey(selectedCard))
                {
                    extraDeckSelectedCards[selectedCard]++;
                }
                else
                {
                    extraDeckSelectedCards[selectedCard] = 1;
                }

                // Remove one copy of the selected card from the list
                extradeck.RemoveAt(randomIndex);
            }

            return new Deck
            {
                Name = $"Randomized {Name}",
                Cards = mainDeckSelectedCards,
                ExtraDeck = extraDeckSelectedCards,
                SideDeck = sideDeckSelectedCards
            };
        }

        private static string CalculateRelativePath(string basePath, string targetPath)
        {
            Uri baseUri = new Uri(basePath);
            Uri targetUri = new Uri(targetPath);
            Uri relativeUri = baseUri.MakeRelativeUri(targetUri);

            return Uri.UnescapeDataString(relativeUri.ToString());
        }

        bool IsTypeMatching(string cardType, string keyword)
        {
            return cardType.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
