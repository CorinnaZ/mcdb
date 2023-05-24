// See https://aka.ms/new-console-template for more information
using ApiCall;
using CollectionHandling;
using Data;
using System.Text.Json;

Console.WriteLine("Hello, World!");

HttpCall myCall = new HttpCall();

Card cd = new Card();
cd = await myCall.GetCardDataById("23002");
//Console.WriteLine(cd.text);

Deck deck = new Deck();
deck = await myCall.GetDeckById("28184");
//Console.WriteLine(deck.name);

List<Card> cards = new List<Card>();
cards = await myCall.GetAllCards();
//Console.WriteLine(cards.Count);

List<Pack> packs = new List<Pack>();
packs = await myCall.GetAllPacks();
//Console.WriteLine(packs.Count);

cards = await myCall.GetCardsFromPackByCode("Core");
//Console.WriteLine(cards[0].name);

Console.WriteLine("-------------------------------");
CollectionHandler handler = new CollectionHandler();
handler.AddPack("Captain America");
foreach (Card c in handler.MyCards)
{
    Console.WriteLine(c.name);
}
Console.WriteLine("-------------------------------");
handler.AddPack("Core Set");
foreach (Pack p in handler.MyPacks)
{
    Console.WriteLine(p.name);
}
Console.WriteLine("-------------------------------");
handler.RemovePack("Captain America");
foreach (Pack p in handler.MyPacks) { Console.WriteLine(p.name); }
foreach (Card c in handler.MyCards) { Console.WriteLine(c.name); }

handler.RemovePack("Core Set");
handler.AddPack("Black Widow");
handler.SaveCollectionToFile();