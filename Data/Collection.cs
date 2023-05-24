using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Collection
    {
        private List<Card> _myCards;
        /// <summary>
        /// My Cards doesn't need a setter, as they should never be set from outside.
        /// </summary>
        public List<Card> MyCards
        {
            get { return _myCards; }
            set { _myCards = value; }
        }

        private List<Pack> _myPacks;
        /// <summary>
        /// My Packs doesn't need a setter, as they should never be set from outside.
        /// </summary>
        public List<Pack> MyPacks
        {
            get { return _myPacks; }
            set { _myPacks = value; }
        }

        public Collection()
        {
            _myCards = new List<Card>();
            _myPacks = new List<Pack>();
        }
    }
}
