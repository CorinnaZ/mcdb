using Data;
using System;
using System;
using System.Dynamic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiCall
{
    public class HttpCall
    {
        static readonly HttpClient client = new HttpClient();
        static private string _url = "https://marvelcdb.com/";


        public HttpCall(string lang)
        {
            switch (lang)
            {
                case "de": _url = "https://de.marvelcdb.com/ "; break;
                case "en": _url = "https://marvelcdb.com/"; break;
                default: _url = "https://marvelcdb.com/"; break;
            }
        }

        public HttpCall() { }

        /// <summary>
        /// Returns a Card object of a card db query
        /// </summary>
        /// <param name="id">The Id of the card as a string</param>
        /// <returns>The deserialized card</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<Card> GetCardDataById(string id)
        {
            string request = "api/public/card/";
            var response = await client.GetAsync(_url + request + id);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Card>(content);
            }
            else
            {
                throw new HttpRequestException($"Failed to get card data with status code {response.StatusCode}");
            }
        }

        /// <summary>
        /// Returns a Deck object of the deck db query
        /// </summary>
        /// <param name="id">The id of the deck as a string</param>
        /// <returns>The deserialized deck</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<Deck> GetDeckById(string id)
        {
            string request = "api/public/decklist/";
            var response = await client.GetAsync(_url + request + id);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Deck>(content);
            }
            else
            {
                throw new HttpRequestException($"Failed to get deck data with status code {response.StatusCode}");
            }
        }

        /// <summary>
        /// Returns a list with all cards
        /// Careful, this actually takes a while (~0.5sec)
        /// </summary>
        /// <returns>List with all cards</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<List<Card>> GetAllCards()
        {
            string request = "api/public/cards";
            var response = await client.GetAsync(_url + request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Card>>(content);
            }
            else
            {
                throw new HttpRequestException($"Failed to get card data with status code {response.StatusCode}");
            }
        }

        /// <summary>
        /// Returns a list with all packs
        /// </summary>
        /// <returns>List with all packs</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<List<Pack>> GetAllPacks()
        {
            string request = "api/public/packs";
            var response = await client.GetAsync(_url + request);

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Pack>>(content);
            }
            else
            {
                throw new HttpRequestException($"Failed to get pack data with status code {response.StatusCode}");
            }
        }

        /// <summary>
        /// Returns cards from pack specified by code, e.g. "Core".
        /// </summary>
        /// <param name="code">The code of the pack to retrieve</param>
        /// <returns>A list of cards</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<List<Card>> GetCardsFromPackByCode(string code)
        {
            string request = "api/public/cards/";
            var response = await client.GetAsync(_url + request + code);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Card>>(content);
            }
            else
            {
                throw new HttpRequestException($"Failed to get deck data with status code {response.StatusCode}");
            }
        }
    }
}