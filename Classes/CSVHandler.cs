using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace YugiohRandomDeckMaker.Classes
{
    internal class CSVHandler
    {
        public static List<CSVCard> LoadCardsFromCsvDirectory(string directoryPath)
        {
            List<CSVCard> cards = new List<CSVCard>();

            string[] csvFiles = Directory.GetFiles(directoryPath, "*.csv");

            foreach (string csvFile in csvFiles)
            {
                using (var reader = new StreamReader(csvFile))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = "$",
                    HasHeaderRecord = false,
                    BadDataFound = null // Ignore bad data
                }))
                {
                    cards.AddRange(csv.GetRecords<CSVCard>());
                }
            }

            return cards;
        }
    }
}

