using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YugiohRandomDeckMaker.Classes
{
    internal class CSVCard
    {
        public string Passcode { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Attribute { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        public string LinkArrows { get; set; }
        public string Rank { get; set; }
        public string PendulumScale { get; set; }
        public string Level { get; set; }
        public string Attack { get; set; }
        public string Defense { get; set; }
        public string SpellAttribute { get; set; }
        public string SummoningCondition { get; set; }
        public string PendulumCondition { get; set; }
        public string CardText { get; set; }
        public string CardSupports { get; set; }
        public string CardAntiSupports { get; set; }
        public string CardActions { get; set; }
        public string EffectTypes { get; set; }
    }
}
