using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YugiohRandomDeckMaker.Classes
{
    internal class Deck
    {
        public Deck()
        {
            Cards = new Dictionary<Card, int>();
        }

        public string Name { get; set; }
        public Dictionary<Card, int> Cards { get; set; }
        public Dictionary<Card, int> ExtraDeck { get; set; }
        public Dictionary<Card, int> SideDeck { get; set; }

        public string GenerateFileContent()
        {
            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.AppendLine("#main");
            AppendCardIds(contentBuilder, Cards.Where(card => card.Value > 0));

            contentBuilder.AppendLine("\n!extra");
            if (ExtraDeck != null)
            {
                AppendCardIds(contentBuilder, ExtraDeck.Where(card => card.Value > 0));
            }

            contentBuilder.AppendLine("\n!side");
            if (SideDeck != null)
            {
                AppendCardIds(contentBuilder, SideDeck.Where(card => card.Value > 0));
            }

            return contentBuilder.ToString();
        }

        private void AppendCardIds(StringBuilder builder, IEnumerable<KeyValuePair<Card, int>> cards)
        {
            foreach (var cardEntry in cards)
            {
                for (int i = 0; i < Math.Abs(cardEntry.Value); i++)
                {
                    builder.AppendLine(cardEntry.Key.Id);
                }
            }
        }
    }
}
