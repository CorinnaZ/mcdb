using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Deck
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public string date_creation { get; set; }
        public string date_update { get; set; }
        public string description_md { get; set; }
        public int user_id { get; set; }
        public string investigator_code { get; set; }
        public string investigator_name { get; set; }
        public Dictionary<string, int> slots { get; set; }
        public int? ignoreDeckLimitSlots { get; set; }
        public string version { get; set; }
        public string meta { get; set; }
        public string tags { get; set; }
    }
}
