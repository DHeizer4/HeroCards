using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Text.Json;
using Cards_Games.Cards;
using Cards_Games.Enumerations;
using Cards_Games.Players;
using static Cards_Games.Enumerations.CharacterRaceEnumueration;

namespace Cards_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> WelcomeMessage = new List<string>();
            WelcomeMessage.Add("Welcome to Hero Cards");
            // Display.ColorTest();
            Display.SimpleDialogBox(WelcomeMessage);

            CardLibrary.MakeLibrary();
            Console.Write("What is your name?: ");
            string name = Console.ReadLine();

            List<string> header = new List<string>();
            List<string> races = GetCharacterRaceChoice();
            int choice = Display.DialogWithInput(header, races, "Please choose a race: ", "dialog");
            CharacterRace race = (CharacterRace)(choice -1);

            List<Deck> decks = Deck.GetStarterDecks();
            List<string> deckchoices = new List<string>();
            
            foreach (Deck deck in decks)
            {
                deckchoices.Add(deck.GetDeckName());
            }
            choice = Display.DialogWithInput(header, deckchoices, "Please choose a starter deck: ", "dialog");
            Deck chosenDeck = decks[choice - 1];

            HumanRPG player1 = CharacterCreation.CharacterCreator.CreateBaseRace(name, race, new List<string>(), chosenDeck);
            Console.Clear();

           // var jsonString = JsonSerializer.Serialize(player1);
           // Console.WriteLine(jsonString);


           // string filePath = $"C:\\Users\\heize\\source\\repos\\HeroCards\\Save\\Characters\\Stuff.txt";
           // string result = InputOutput.FileHandler.ReadFromFile(filePath);

            RPGCardGame Game = new RPGCardGame();
            Game.StartGame(player1);
            Console.SetCursorPosition(0, 0);
        }


        private static List<string> GetCharacterRaceChoice()
        {
            var list = new List<string>();

            string lapine = $"{CharacterRace.Lapine}: A Speed based caster";
            string minotaur = $"{CharacterRace.Minotaur}: A Crit based warrior";
            string draconian = $"{CharacterRace.Draconian}: A warrior caster hybrid";
            string mausian = $"{CharacterRace.Mausian}: A Speed based assassin";
            string naga = $"{CharacterRace.Naga}: A Crit based assassin";
            string centaur = $"{CharacterRace.Centaur}: A Speed based Warrior";
            string ailuran = $"{CharacterRace.Ailuran}: An expert in hand to hand fighting";
            string saytr = $"{CharacterRace.Saytr}: A Support caster";
            string vanara = $"{CharacterRace.Vanara}: A Trickster";
            string aarakocra = $"{CharacterRace.Aarakocra}: A pure caster";
            string adlet = $"{CharacterRace.Adlet}: An all around balance";
            string erymanthian = $"{CharacterRace.Erymanthian}: A Bezerker";

            list.Add(lapine);
            list.Add(minotaur);
            list.Add(draconian);
            list.Add(mausian);
            list.Add(naga);
            list.Add(centaur);
            list.Add(ailuran);
            list.Add(saytr);
            list.Add(vanara);
            list.Add(aarakocra);
            list.Add(adlet);
            list.Add(erymanthian);

            return list;
        }


    }
}
