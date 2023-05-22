using ApiCall;
using Data;

namespace CollectionHandling
{
    public class CollectionHandler
    {
        public List<Deck> _myDecks;
        
        // Todo: make language adaptable
        private HttpCall _call = new HttpCall("en");
        private List<Card> _allCards;
        private List<Pack> _allPacks;

        private List<Card> _myCards;
        /// <summary>
        /// My Cards doesn't need a setter, as they should never be set from outside.
        /// </summary>
        public List<Card> MyCards
        {
            get { return _myCards; }
        }

        private List<Pack> _myPacks;
        /// <summary>
        /// My Packs doesn't need a setter, as they should never be set from outside.
        /// </summary>
        public List<Pack> MyPacks
        {
            get { return _myPacks; }
        }

        #region Constructors
        public CollectionHandler()
        {
            _myDecks = new List<Deck>();
            _myCards = new List<Card>();
            _myPacks = new List<Pack>();
            var task = InitAllCards();
            task.Wait();
            task = InitAllPacks();
            task.Wait();
        }
        #endregion

        #region init
        /// <summary>
        /// Initializes all available Cards
        /// </summary>
        public async Task InitAllCards()
        {
            _allCards = await _call.GetAllCards();
        }

        /// <summary>
        /// Initializes all available packs
        /// </summary>
        public async Task InitAllPacks()
        {
            _allPacks = await _call.GetAllPacks();
        }
        #endregion

        /// <summary>
        /// Adds pack to collection and updates cards
        /// </summary>
        /// <param name="pack">The pack to add</param>
        /// <returns></returns>
        public bool AddPack(string pack)
        {
            foreach (Pack p in _allPacks)
            {
                if (p.name.ToLower().Equals(pack.ToLower()))
                {
                    _myPacks.Add(p);
                    AddCards(p);
                    return true;
                }
            }
            return false;
        }

        private async void AddCards(Pack p)
        {
            var task = _call.GetCardsFromPackByCode(p.code.ToString());
            task.Wait();
            List<Card> cardsInPack = task.Result;
            foreach (Card card in cardsInPack)
            {
                _myCards.Add(card);
            }
        }

        /// <summary>
        /// Removes pack from collection and updates cards
        /// </summary>
        /// <param name="pack">The pack to remove</param>
        /// <returns></returns>
        public bool RemovePack(string pack) 
        { 
            foreach(Pack p in MyPacks)
            {
                if(p.name.ToLower().Equals(pack.ToLower()))
                {
                    _myPacks.Remove(p);
                    RemoveCards(p);
                    return true;
                }
            }
            return false;
        }
        private async void RemoveCards(Pack p)
        {
            var task = _call.GetCardsFromPackByCode(p.code.ToString());
            task.Wait();
            List<Card> cardsInPack = task.Result;
            int idx;
            foreach (Card card in cardsInPack)
            {
                idx = _myCards.FindIndex(a => a.code == card.code);
                _myCards.RemoveAt(idx);
            }
        }

        #region FileHandling
        /// <summary>
        /// Loads a collection from file
        /// </summary>
        public void LoadCollection()
        {
            
        }

        /// <summary>
        /// Saves a collection to file
        /// </summary>
        public void SaveCollection()
        {

        }
        #endregion
    }
}