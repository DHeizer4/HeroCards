﻿using Cards_Games.Cards;
using Cards_Games.Models;
using Cards_Games.Players;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cards_Games
{
    class RPGCardGame
    {
        public void StartGame(IRPGPlayer player1)
        {
            
            List<IRPGPlayer> players = new List<IRPGPlayer>();
            player1.Team = 1;
            players.Add(player1);
            //CompTopRPG comp1 = new CompTopRPG("That guy", 2);
            //players.Add(comp1);
            CompTopRPG comp2 = new CompTopRPG("Goblin Scout", 2, Deck.GoblinScoutDeck(), GetGoblinScout());
            CompTopRPG comp3 = new CompTopRPG("Goblin Bruiser", 2, Deck.GoblinBruiserDeck(), GetGoblinBruiser());
            CompTopRPG comp4 = new CompTopRPG("Red Dragon", 2, Deck.FireDragonDeck(), GetRedDragon());

            List<string> header = new List<string>();
            header.Add("Choose your fight");
            List<string> listOfChoices = new List<string>();
            listOfChoices.Add("Goblin Scout");
            listOfChoices.Add("Goblin Bruiser");
            listOfChoices.Add("Goblins Pack");
            listOfChoices.Add("Dragon");

            int choice = Display.DialogWithInput(header, listOfChoices, "", "dialog");

            switch (choice)
            {
                case 1:  // goblin scout
                    players.Add(comp2);
                    break;
                case 2:  // goblin bruiser
                    players.Add(comp3);
                    break;
                case 3:  // goblin pack
                    players.Add(comp2);
                    players.Add(comp3);
                    break;
                case 4:  // Dragon
                    players.Add(comp4);
                    break;
            }


            // players.Add(comp4);
            BattleOrchestrator.Start(players);
        }

        private static CharacterProperties GetGoblinScout()
        {
            CharacterProperties properties = new CharacterProperties();

            properties.Strength = 5;
            properties.Intellect = 0;
            properties.Agility = 15;
            properties.Dexterity = 0;
            properties.Endurance = 5;
            properties.Concentration = 0;
            properties.Speed = 0;
            properties.Haste = 0;
            properties.Armor = 0;
            properties.Resistance = 0;

            return properties;
        }

        private static CharacterProperties GetGoblinBruiser()
        {
            CharacterProperties properties = new CharacterProperties();

            properties.Strength = 15;
            properties.Intellect = 0;
            properties.Agility = 5;
            properties.Dexterity = 0;
            properties.Endurance = 7;
            properties.Concentration = 0;
            properties.Speed = 0;
            properties.Haste = 0;
            properties.Armor = 0;
            properties.Resistance = 0;

            return properties;
        }


        private static CharacterProperties GetRedDragon()
        {
            CharacterProperties properties = new CharacterProperties();

            properties.Strength = 50;
            properties.Intellect = 50;
            properties.Agility = 15;
            properties.Dexterity = 0;
            properties.Endurance = 40;
            properties.Concentration = 20;
            properties.Speed = 0;
            properties.Haste = 0;
            properties.Armor = 0;
            properties.Resistance = 0;

            return properties;
        }
    }


}
