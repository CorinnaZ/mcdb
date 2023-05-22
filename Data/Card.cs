namespace Data
{
    /// <summary>
    /// Data structure for a single card
    /// </summary>
    public class Card
    {
        public string pack_code { get; set; }
        public string pack_name { get; set; }
        public string type_code { get; set; }
        public string type_name { get; set; }
        public string faction_code { get; set; }
        public string faction_name { get; set; }
        public string card_set_code { get; set; }
        public string card_set_name { get; set; }
        public string card_set_type_name_code { get; set; }
        public int position { get; set; }
        public int set_Position { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string real_name { get; set; }
        public string subname { get; set; }
        public int cost { get; set; }
        public string text { get; set; }
        public string real_text { get; set; }
        public int quantity { get; set; }
        public int resource_physical { get; set; }
        public int health { get; set; }
        public bool health_per_hero { get; set; }
        public int thwart { get; set; }
        public int thwart_cost { get; set; }
        public int attack { get; set; }
        public int attack_cost { get; set; }
        public bool base_threat_fixed { get; set; }
        public bool escalation_threat_fixed { get; set; }
        public bool threat_fixed { get; set; }
        public int deck_limit { get; set; }
        public string traits { get; set; }
        public string real_traits { get; set; }
        public string flavor { get; set; }
        public string illustrator { get; set; }
        public bool is_unique { get; set; }
        public bool hidden { get; set; }
        public bool permanent { get; set; }
        public bool double_sided { get; set; }
        public string octgn_id { get; set; }
        public string url { get; set; }
        public string imagesrc { get; set; }
    }
}
